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
using PuyoTools.Core.Textures.Pvr;
using System.IO;
using System.Threading;

namespace PdnPvrFiletype
{
    public partial class SaveDialogSettings : Form
    {
        private static readonly IntPtr HWND_TOPMOST_LESS = new IntPtr(-1);
        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private const UInt32 SWP_NOSIZE = 0x0001;
        private const UInt32 SWP_NOMOVE = 0x0002;
        private const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;

        public SaveDialogSettingsState _state = new SaveDialogSettingsState();
        public Bitmap _img;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        public SaveDialogSettings(PuyoTools.Core.Textures.Pvr.PvrDataFormatEncodeOnly d,
            PuyoTools.Core.Textures.Pvr.PvrPixelFormat f, bool s, uint? g)
        {
            InitializeComponent();
            SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);

            _state.PuyoDataFormat = d;
            _state.PuyoPixelFormat = f;

            if (g != null) _state.GbixId = g;
            _state.SettingsLoadedFromPVRSource = s;
            GUIInit();
        }

        public SaveDialogSettings(SaveDialogSettingsState cache)
        {
            InitializeComponent();
            SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);

            _state.PuyoDataFormat = cache.PuyoDataFormat;
            _state.PuyoPixelFormat = cache.PuyoPixelFormat;
            _state.GbixId = cache.GbixId;

            _state.Dithering = cache.Dithering;
            _state.EyeWeightMode = cache.EyeWeightMode;
            _state.SettingsLoadedFromPVRSource = cache.SettingsLoadedFromPVRSource;

            GUIInit(true);
        }

        public SaveDialogSettings(ShenmueDKSharp.Files.Images._PVRT.PvrDataFormat d,
            ShenmueDKSharp.Files.Images._PVRT.PvrPixelFormat f, bool s, uint? g)
        {
            InitializeComponent();
            SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);

            try
            {
                // Dirty enum cast
                _state.PuyoDataFormat = (PuyoTools.Core.Textures.Pvr.PvrDataFormatEncodeOnly)d;
                _state.PuyoPixelFormat = (PuyoTools.Core.Textures.Pvr.PvrPixelFormat)f;
            }
            catch (Exception e)
            {
                MessageBox.Show("Settings loaded from PVR by ShenmueDK are not supported by PuyoTools and will be reseted!"
                    + Environment.NewLine + Environment.NewLine + e);
                _state.PuyoDataFormat = PuyoTools.Core.Textures.Pvr.PvrDataFormatEncodeOnly.Vq;
                _state.PuyoPixelFormat = PuyoTools.Core.Textures.Pvr.PvrPixelFormat.Argb1555;
            }

            if (g != null) _state.GbixId = g;
            _state.SettingsLoadedFromPVRSource = s;
            GUIInit();
        }

        private void GUIInit(bool fromCache = false)
        {
            comboBox_DataFormat.Enabled = true;
            comboBox_PixelFormat.Enabled = true;

            comboBox_DataFormat.DataSource = Enum.GetValues(typeof(PuyoTools.Core.Textures.Pvr.PvrDataFormatEncodeOnly));
            comboBox_PixelFormat.DataSource = Enum.GetValues(typeof(PuyoTools.Core.Textures.Pvr.PvrPixelFormat));
            comboBox_Dithering.DataSource = Enum.GetValues(typeof(PuyoTools.Core.Textures.Pvr.PvrDitherMode));

            // remove ARGB8888 because its only used by palette stuff and i didnt had time to look into it
            comboBox_PixelFormat.DataSource = Array.FindAll((PvrPixelFormat[])Enum.GetValues(typeof(PvrPixelFormat)),
            (PvrPixelFormat SM) => { return SM != PvrPixelFormat.Argb8888; });

            // Force pre-selection of loaded pvr settings before
            comboBox_DataFormat.SelectedItem = _state.PuyoDataFormat;
            comboBox_PixelFormat.SelectedItem = _state.PuyoPixelFormat;

            if (fromCache)
            {
                comboBox_Dithering.SelectedIndex = _state.Dithering;
                checkBox_eyeMode.Checked = _state.EyeWeightMode;
            }
            else
            {
                comboBox_Dithering.SelectedItem = PuyoTools.Core.Textures.Pvr.PvrDitherMode.NoDither;
                // checkBox_eyeMode is false anyway
            }

            var tmp = ((PuyoTools.Core.Textures.Pvr.PvrDataFormatEncodeOnly)comboBox_DataFormat.SelectedItem);

            if (tmp == PuyoTools.Core.Textures.Pvr.PvrDataFormatEncodeOnly.Vq
                || tmp == PuyoTools.Core.Textures.Pvr.PvrDataFormatEncodeOnly.VqMipmaps)
                comboBox_Dithering.Enabled = true;
            else
                comboBox_Dithering.Enabled = false;

            if (_state.GbixId != null)
            {
                checkBox_GBIX.Checked = true;
                numericUpDown_GBIX.Enabled = true;
                button_LoadGBIXFromFile.Enabled = true;
                numericUpDown_GBIX.Value = (Decimal)_state.GbixId;
            }

            // Update PVR Metadata label
            if (_state.SettingsLoadedFromPVRSource)
            {
                label_PvrMetaLabel.Text = "Loaded PVR: " + _state.PuyoDataFormat.ToString() + " / " + _state.PuyoPixelFormat.ToString();
                if (_state.GbixId != null) label_PvrMetaLabel.Text += " / GBIX: " + _state.GbixId; //show loaded gbix id, when there in loaded file
            }

            pictureBox_PVRPreview.Image = _img; //dummy preview
            pictureBox_PVRPreview.Update();
        }

        private void GBIXStateChanged(object sender, EventArgs e)
        {
            if (checkBox_GBIX.Checked)
            {
                numericUpDown_GBIX.Enabled = true;
                button_LoadGBIXFromFile.Enabled = true;
            }
            else
            {
                numericUpDown_GBIX.Enabled = false;
                button_LoadGBIXFromFile.Enabled = false;
            }
        }

        private void DitheringCheck(object sender, EventArgs e)
        {
            if ((PvrDataFormatEncodeOnly)comboBox_DataFormat.SelectedItem == PvrDataFormatEncodeOnly.Vq ||
                (PvrDataFormatEncodeOnly)comboBox_DataFormat.SelectedItem == PvrDataFormatEncodeOnly.VqMipmaps)
            {
                comboBox_Dithering.Enabled = true;
                checkBox_eyeMode.Enabled = true;
            }
            else
            {
                comboBox_Dithering.Enabled = false;
                checkBox_eyeMode.Enabled = false;
            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            _state.PuyoDataFormat = (PvrDataFormatEncodeOnly)comboBox_DataFormat.SelectedItem;
            _state.PuyoPixelFormat = (PvrPixelFormat)comboBox_PixelFormat.SelectedItem;

            _state.Dithering = comboBox_Dithering.SelectedIndex; // enum cast for poor people

            if (checkBox_GBIX.Checked)
                _state.GbixId = (uint?)numericUpDown_GBIX.Value;
            else
                _state.GbixId = null;

            _state.EyeWeightMode = checkBox_eyeMode.Checked;

            this.Close();
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class OpenFileName
        {
            public int structSize = 0;
            public IntPtr dlgOwner = IntPtr.Zero;
            public IntPtr instance = IntPtr.Zero;

            public String filter = null;
            public String customFilter = null;
            public int maxCustFilter = 0;
            public int filterIndex = 0;

            public String file = null;
            public int maxFile = 0;

            public String fileTitle = null;
            public int maxFileTitle = 0;

            public String initialDir = null;

            public String title = null;

            public int flags = 0;
            public short fileOffset = 0;
            public short fileExtension = 0;

            public String defExt = null;

            public IntPtr custData = IntPtr.Zero;
            public IntPtr hook = IntPtr.Zero;

            public String templateName = null;

            public IntPtr reservedPtr = IntPtr.Zero;
            public int reservedInt = 0;
            public int flagsEx = 0;
        }

        [DllImport("Comdlg32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetOpenFileName([In, Out] OpenFileName ofn);

        private void LoadExtraPVRStuff(bool md)
        {
            //HACK: because PDN plugin is capsulated and OpenFileDialog creates a new thread and other memes, it will crash
            // So we go full madlad and make our own openfiledialog from Comdlg32.dll
            // i bet this works 100% fine on all those .NET platforms out there that are not windows believe :^)
            OpenFileName gbixDialog = new OpenFileName();
            gbixDialog.structSize = Marshal.SizeOf(gbixDialog);
            gbixDialog.file = new String(new char[256]);
            gbixDialog.maxFile = gbixDialog.file.Length;
            gbixDialog.filter = "PVR file\0*.PVR";
            gbixDialog.defExt = "PVR";
            gbixDialog.title = "Load GBIX from PVR file";
            //TODO: this does not work because handle is generated at init but the function waits for return
            // internet says to create a dummy handle and then assign  it to  the ofn but whatever good enough
            //SetWindowPos(gbixDialog.instance, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);

            this.Enabled = false; // disable plugin dialog
            if (GetOpenFileName(gbixDialog) == true)
            {
                try
                {
                    PvrTextureDecoder puyoPvr;
                    using (FileStream fs = File.Open(gbixDialog.file, FileMode.Open))
                    {
                        puyoPvr = new PvrTextureDecoder(fs);
                    }
                    
                    uint? gbixCase = puyoPvr.GlobalIndex;

                    try
                    {

                        if (md)
                        {
                            comboBox_DataFormat.SelectedItem = (PvrDataFormatEncodeOnly)puyoPvr.DataFormat;
                            comboBox_PixelFormat.SelectedItem = (PvrPixelFormat)puyoPvr.PixelFormat;
                        }

                        //try to update gbix case
                        if (gbixCase != null)
                        {
                            numericUpDown_GBIX.Value = (decimal)gbixCase;
                            checkBox_GBIX.Checked = true;
                        }
                        else
                        {
                            // reset when file had no gbix
                            numericUpDown_GBIX.Value = 0;
                            checkBox_GBIX.Checked = false;
                        }
                            
                    }
                    catch (Exception f)
                    {
                        MessageBox.Show("ShenmueDK could not parse the GBIX ID. Abort."
                            + Environment.NewLine + f);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }

            this.Enabled = true;  // enable plugin dialog
        }

        private void button_LoadGBIXFromFile_Click(object sender, EventArgs e)
        {
            LoadExtraPVRStuff(false);
        }

        private void button_loadSettingsFromPVR_Click(object sender, EventArgs e)
        {
            LoadExtraPVRStuff(true);
        }

        private void button_genPrev_Click(object sender, EventArgs e)
        {
            SixLabors.ImageSharp.Image<Bgra32> tmpImg = ImageSharpExtensions.ToImageSharpImage(_img);

            var pf = (PvrPixelFormat)comboBox_PixelFormat.SelectedItem;
            var df = (PvrDataFormat)comboBox_DataFormat.SelectedItem;
            var dr = comboBox_Dithering.SelectedIndex;
            var em = checkBox_eyeMode.Checked;

            using (var ms = new MemoryStream())
            {
                // Temp encode to pvr
                PvrTextureEncoder tmpImgRaw = new PvrTextureEncoder(tmpImg, pf, df);
                tmpImgRaw.DitheringMode = dr;
                if (em == false)
                    tmpImgRaw.MetricMode = 0;
                else
                    tmpImgRaw.MetricMode = 1;

                tmpImgRaw.Save(ms);
                ms.Seek(0, SeekOrigin.Begin);

                //Tmp decode for preview
                var tmpPreview = new PvrTextureDecoder(ms);
                var img = tmpPreview.GetImage();
                var imgNative = ImageSharpExtensions.ToBitmap(img);

                pictureBox_PVRPreview.Image = imgNative;

                pictureBox_PVRPreview.Update();
                panel1.Update();
            }

        }

        //TODO zoom picturebox - i didnt finished it but maybe in future
        // https://www.codeproject.com/Articles/21097/PictureBox-Zoom
    }
    public class SaveDialogSettingsState
    {
        //Settings puyotools
        public PvrDataFormatEncodeOnly PuyoDataFormat { get; set; }
        public PvrPixelFormat PuyoPixelFormat { get; set; }

        //Generic Settings
        public uint? GbixId { get; set; }
        public int Dithering { get; set; } = 0;
        public bool EyeWeightMode { get; set; } = false;

        public bool SettingsLoadedFromPVRSource { get; set; } = false;
    }
}
