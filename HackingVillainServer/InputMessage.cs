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
    public partial class InputMessage : Form
    {
        public event Action<string> Completed;
        public InputMessage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Completed?.Invoke(this.textBox1.Text ?? "");
        }
    }
}
