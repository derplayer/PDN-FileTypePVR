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
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace PdnPvrFiletype
{
    public partial class SaveDialogSettings : Form
    {
        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private const UInt32 SWP_NOSIZE = 0x0001;
        private const UInt32 SWP_NOMOVE = 0x0002;
        private const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;

        public SaveDialogSettingsState _state = new SaveDialogSettingsState();

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        public SaveDialogSettings(PuyoTools.Core.Textures.Pvr.PvrCompressionFormat c, PuyoTools.Core.Textures.Pvr.PvrDataFormat d,
            PuyoTools.Core.Textures.Pvr.PvrPixelFormat f)
        {
            InitializeComponent();
            SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);

            _state.PuyoCompressionFormat = c;
            _state.PuyoDataFormat = d;
            _state.PuyoPixelFormat = f;

            // Dirty enum cast
            _state.ShenDKCompressionFormat = (ShenmueDKSharp.Files.Images._PVRT.PvrCompressionFormat)c;
            _state.ShenDKDataFormat = (ShenmueDKSharp.Files.Images._PVRT.PvrDataFormat)d;
            _state.ShenDKPixelFormat = (ShenmueDKSharp.Files.Images._PVRT.PvrPixelFormat)f;

            comboBox_Engine.SelectedIndex = 0;
        }

        public SaveDialogSettings(ShenmueDKSharp.Files.Images._PVRT.PvrCompressionFormat c, ShenmueDKSharp.Files.Images._PVRT.PvrDataFormat d,
            ShenmueDKSharp.Files.Images._PVRT.PvrPixelFormat f)
        {
            InitializeComponent();
            SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);

            _state.ShenDKCompressionFormat = c;
            _state.ShenDKDataFormat = d;
            _state.ShenDKPixelFormat = f;

            // Dirty enum cast
            _state.PuyoCompressionFormat = (PuyoTools.Core.Textures.Pvr.PvrCompressionFormat)c;
            _state.PuyoDataFormat = (PuyoTools.Core.Textures.Pvr.PvrDataFormat)d;
            _state.PuyoPixelFormat = (PuyoTools.Core.Textures.Pvr.PvrPixelFormat)f;

            comboBox_Engine.SelectedIndex = 0;
        }

        private void comboBox_EngineChanged(object sender, EventArgs e)
        {
            // PuyoTools
            if (comboBox_Engine.SelectedIndex == 0)
            {
                comboBox_CompressionFormat.Enabled = false;
                comboBox_DataFormat.Enabled = true;
                comboBox_PixelFormat.Enabled = true;

                comboBox_CompressionFormat.DataSource = Enum.GetValues(typeof(PuyoTools.Core.Textures.Pvr.PvrCompressionFormat));
                comboBox_DataFormat.DataSource = Enum.GetValues(typeof(PuyoTools.Core.Textures.Pvr.PvrDataFormat));
                comboBox_PixelFormat.DataSource = Enum.GetValues(typeof(PuyoTools.Core.Textures.Pvr.PvrPixelFormat));

                // Force pre-selection of loaded pvr settings
                comboBox_CompressionFormat.SelectedItem = _state.PuyoCompressionFormat;
                comboBox_DataFormat.SelectedItem = _state.PuyoDataFormat;
                comboBox_PixelFormat.SelectedItem = _state.PuyoPixelFormat;
            }
            else // ShenmueDK
            {
                comboBox_CompressionFormat.Enabled = true;
                comboBox_DataFormat.Enabled = true;
                comboBox_PixelFormat.Enabled = true;

                comboBox_CompressionFormat.DataSource = Enum.GetValues(typeof(ShenmueDKSharp.Files.Images._PVRT.PvrCompressionFormat));
                comboBox_DataFormat.DataSource = Enum.GetValues(typeof(ShenmueDKSharp.Files.Images._PVRT.PvrDataFormat));
                comboBox_PixelFormat.DataSource = Enum.GetValues(typeof(ShenmueDKSharp.Files.Images._PVRT.PvrPixelFormat));

                // Force pre-selection of loaded pvr settings
                comboBox_CompressionFormat.SelectedItem = _state.ShenDKCompressionFormat;
                comboBox_DataFormat.SelectedItem = _state.ShenDKDataFormat;
                comboBox_PixelFormat.SelectedItem = _state.ShenDKPixelFormat;
            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            // PuyoTools
            if (comboBox_Engine.SelectedIndex == 0)
            {
                _state.PuyoCompressionFormat = (PuyoTools.Core.Textures.Pvr.PvrCompressionFormat)comboBox_CompressionFormat.SelectedItem;
                _state.PuyoDataFormat = (PuyoTools.Core.Textures.Pvr.PvrDataFormat)comboBox_DataFormat.SelectedItem;
                _state.PuyoPixelFormat = (PuyoTools.Core.Textures.Pvr.PvrPixelFormat)comboBox_PixelFormat.SelectedItem;

                _state.SaveEngineMode = PvrEnginePublic.PuyoTools;
            }
            else // ShenDK
            {
                _state.ShenDKCompressionFormat = (ShenmueDKSharp.Files.Images._PVRT.PvrCompressionFormat)comboBox_CompressionFormat.SelectedItem;
                _state.ShenDKDataFormat = (ShenmueDKSharp.Files.Images._PVRT.PvrDataFormat)comboBox_DataFormat.SelectedItem;
                _state.ShenDKPixelFormat = (ShenmueDKSharp.Files.Images._PVRT.PvrPixelFormat)comboBox_PixelFormat.SelectedItem;

                _state.SaveEngineMode = PvrEnginePublic.ShenmueDK;
            }

            this.Close();
        }
    }
    public class SaveDialogSettingsState
    {
        // Engine
        public PvrEnginePublic SaveEngineMode { get; set; }

        //Settings puyotools
        public PuyoTools.Core.Textures.Pvr.PvrCompressionFormat PuyoCompressionFormat { get; set; }
        public PuyoTools.Core.Textures.Pvr.PvrDataFormat PuyoDataFormat { get; set; }
        public PuyoTools.Core.Textures.Pvr.PvrPixelFormat PuyoPixelFormat { get; set; }
        //Settings ShenmueDK
        public ShenmueDKSharp.Files.Images._PVRT.PvrCompressionFormat ShenDKCompressionFormat { get; set; }
        public ShenmueDKSharp.Files.Images._PVRT.PvrDataFormat ShenDKDataFormat { get; set; }
        public ShenmueDKSharp.Files.Images._PVRT.PvrPixelFormat ShenDKPixelFormat { get; set; }

        //Generic Settings
        public string GBIX_ID { get; set; }
    }
}
