using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PdnPvrFiletype
{
    public partial class OpenDialogSettings : Form
    {
        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private const UInt32 SWP_NOSIZE = 0x0001;
        private const UInt32 SWP_NOMOVE = 0x0002;

        private const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        public OpenDialogSettings()
        {
            InitializeComponent();
            SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);
        }

        private void button_puyoDecode_Click(object sender, EventArgs e)
        {
            PvrFiletype.LoadEngineMode = PvrFiletype.PvrEngineEnum.PuyoTools;
            this.Close();
        }

        private void button_shenmueDecode_Click(object sender, EventArgs e)
        {
            PvrFiletype.LoadEngineMode = PvrFiletype.PvrEngineEnum.ShenmueDK;
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        private void BringToFront(Process pTemp)
        {
            SetForegroundWindow(pTemp.MainWindowHandle);
        }

        private void OpenDialogSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            //HACK: refocus on PDN (at least try)
            try
            {
                var pdnInstance = Process.GetProcessesByName("PaintDotNet");
                BringToFront(pdnInstance[0]);
            }
            catch (Exception)
            {
                // Hack failed, user will need to switch the window himself i guess
            }
        }

    }
}
