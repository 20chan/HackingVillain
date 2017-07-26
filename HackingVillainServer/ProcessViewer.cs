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
    public partial class ProcessViewer : Form
    {
        public event Action<string> TryKill;
        public ProcessViewer(List<string> processes)
        {
            InitializeComponent();
            Reset(processes);
        }

        public void Reset(List<string> processes)
        {
            listBox1.Items.Clear();
            foreach (var s in processes)
                this.listBox1.Items.Add(s);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count != 1)
                return;

            TryKill?.Invoke(listBox1.SelectedItems[0].ToString());
        }
    }
}
