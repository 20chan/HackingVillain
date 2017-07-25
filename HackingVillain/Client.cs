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

namespace HackingVillain
{
    public partial class Client : Form
    {
        NetworkClient _client;
        ClientInfo _info;
        public Client()
        {
            InitializeComponent();
            _client = new NetworkClient("127.0.0.1", 8080);
            _client.Connect();
            _info = new ClientInfo(NetworkClient.myIP, NetworkClient.myNick);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _client.Send(new Data(DataType.STRING, textBox1.Text, _info));
        }
    }
}
