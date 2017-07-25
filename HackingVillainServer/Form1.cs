using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Network;

namespace HackingVillainServer
{
    public partial class Form1 : Form
    {
        NetworkServer _server;
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            _server = new NetworkServer(8080);
            System.Threading.Thread t = new System.Threading.Thread(_server.Listen);

            _server.ClientSent += _server_ClientSent;
            t.Start();
        }

        private void _server_ClientSent(Data obj)
        {
            this.Text = obj.InnerData.ToString();
        }
    }
}
