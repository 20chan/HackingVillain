using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HackingVillainServer
{
    public partial class EventViewer : Form
    {
        public EventViewer(List<string> strs)
        {
            InitializeComponent();

            foreach (var s in strs)
                listBox1.Items.Add(s);
        }

        private void EventViewer_Shown(object sender, EventArgs e)
        {

        }
    }
}
