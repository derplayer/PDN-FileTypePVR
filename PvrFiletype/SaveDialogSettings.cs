using ShenmueDKSharp.Files.Images._PVRT;
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
using ShenmueDKSharp.Files.Images;

namespace PdnPvrFiletype
{
    public partial class SaveDialogSettings : Form
    {
        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private const UInt32 SWP_NOSIZE = 0x0001;
        private const UInt32 SWP_NOMOVE = 0x0002;
        private const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;

        public PVRT tmpPvr { get; set; }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        public SaveDialogSettings(PVRT actPvr)
        {
            InitializeComponent();
            SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);

            tmpPvr = actPvr;

            comboBox_CompressionFormat.DataSource = Enum.GetValues(typeof(PvrCompressionFormatPublic));
            comboBox_DataFormat.DataSource = Enum.GetValues(typeof(PvrDataFormatPublic));
            comboBox_PixelFormat.DataSource = Enum.GetValues(typeof(PvrPixelFormatPublic));

            comboBox_CompressionFormat.SelectedItem = (PvrCompressionFormatPublic)tmpPvr.CompressionFormat;
            comboBox_DataFormat.SelectedItem = (PvrDataFormatPublic)tmpPvr.DataFormat;
            comboBox_PixelFormat.SelectedItem = (PvrPixelFormatPublic)tmpPvr.PixelFormat;

        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            tmpPvr.CompressionFormat = (PvrCompressionFormat)comboBox_CompressionFormat.SelectedItem;
            tmpPvr.DataFormat = (PvrDataFormat)comboBox_DataFormat.SelectedItem;
            tmpPvr.PixelFormat = (PvrPixelFormat)comboBox_PixelFormat.SelectedItem;

            this.Close();
        }
    }
}
