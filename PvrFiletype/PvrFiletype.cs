using PaintDotNet;
using PaintDotNet.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShenmueDKSharp.Files.Images;
using PuyoTools;
using PuyoTools.Core;
using PaintDotNet.IO;
using System.Windows.Forms;
using PuyoTools.Core.Textures.Pvr;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp;
using System.Drawing;

namespace PdnPvrFiletype
{
    public class PvrFiletype : FileType
    {
        public enum PvrEngineEnum : byte
        {
            None = 0,
            ShenmueDK,
            PuyoTools
        }

        public static PvrEngineEnum LoadEngineMode { get; set; } = PvrEngineEnum.None;
        public static SaveDialogSettingsState pvrMetaDataCache;

        public PvrFiletype()
            : base("SEGA Dreamcast PVR file",
                   new FileTypeOptions()
                   {
                       LoadExtensions = new string[] { ".PVR" },
                       SaveExtensions = new string[] { ".PVR" },
                   })
        {
        }
        private PVRT loadedPvr;
        private PvrTextureDecoder loadedPvrPuyo;

        protected override Document OnLoad(Stream input)
        {
            // reset settings cache on fresh loaded files
            pvrMetaDataCache = null;

            // Setup loading engine
            if (LoadEngineMode == PvrEngineEnum.None)
                ShowLoadSetupDialogBox();

            if (LoadEngineMode == PvrEngineEnum.PuyoTools)
            {
                loadedPvrPuyo = new PvrTextureDecoder(input);
                var img = loadedPvrPuyo.GetImage();
                var imgNative = ImageSharpExtensions.ToBitmap(img);
                return Document.FromImage(imgNative);
            }
            else if (LoadEngineMode == PvrEngineEnum.ShenmueDK)
            {
                PVRT.EnableBuffering = false;
                loadedPvr = new PVRT(input);
                return Document.FromImage(loadedPvr.CreateBitmap());
            }
            else
            {
                throw new Exception("User canceled the operation!");
            }
        }

        protected override void OnSave(Document input, Stream output, SaveConfigToken token, Surface scratchSurface, ProgressEventHandler callback)
        {
            RenderArgs ra = new RenderArgs(new Surface(input.Size));
            input.Render(ra, true);

            // Show dialog and setup engine parameters
            SaveDialogSettingsState pvrMetaData;

            if (pvrMetaDataCache != null) 
                pvrMetaData = ShowSetupDialogBox(pvrMetaDataCache, ra.Bitmap); //load from cache when there
            else { // no cache make clear instance of settings dialog
                switch (LoadEngineMode)
                {
                    case PvrEngineEnum.None:
                        pvrMetaData = ShowSetupDialogBox(loadedPvrPuyo, ra.Bitmap); //null
                        break;
                    case PvrEngineEnum.ShenmueDK:
                        pvrMetaData = ShowSetupDialogBox(loadedPvr, ra.Bitmap);
                        break;
                    case PvrEngineEnum.PuyoTools:
                        pvrMetaData = ShowSetupDialogBox(loadedPvrPuyo, ra.Bitmap);
                        break;
                    default:
                        pvrMetaData = ShowSetupDialogBox(loadedPvrPuyo, ra.Bitmap); //null
                        break;
                }
            }
            using (var ms = new MemoryStream())
            {
                Image<Bgra32> image = ImageSharpExtensions.ToImageSharpImage(ra.Bitmap);
                var tmpPvrPuyo = new PvrTextureEncoder(image, pvrMetaData.PuyoPixelFormat, (PvrDataFormat)pvrMetaData.PuyoDataFormat);
                
                // optiona global id
                if(pvrMetaData.GbixId != null)
                    tmpPvrPuyo.GlobalIndex = pvrMetaData.GbixId;

                // dithering
                tmpPvrPuyo.DitheringMode = pvrMetaData.Dithering;

                // EyeWeightMode
                if (pvrMetaData.EyeWeightMode) tmpPvrPuyo.MetricMode = 1;
                else tmpPvrPuyo.MetricMode = 0;

                //GuardedStream workaround (forums.getpaint.net/topic/114912-i-can-not-save-my-work/)?
                tmpPvrPuyo.Save(ms);

                byte[] tmpBfr = ms.ToArray();
                output.Write(tmpBfr, 0, tmpBfr.Length);
                pvrMetaDataCache = pvrMetaData; // update settings cache
            }
        }

        public SaveDialogSettingsState ShowSetupDialogBox(SaveDialogSettingsState cache, Bitmap preview)
        {
            SaveDialogSettings setupDlg = new SaveDialogSettings(cache);

            setupDlg._img = preview;
            setupDlg.ShowDialog();
            setupDlg.Dispose();

            SaveDialogSettingsState info = setupDlg._state;
            return info;
        }

        public SaveDialogSettingsState ShowSetupDialogBox(PvrTextureDecoder puyoPvr, Bitmap preview)
        {
            SaveDialogSettings setupDlg;

            if (puyoPvr != null)
                setupDlg = new SaveDialogSettings((PvrDataFormatEncodeOnly)puyoPvr.DataFormat, puyoPvr.PixelFormat, true, puyoPvr.GlobalIndex);
            else
                setupDlg = new SaveDialogSettings(PvrDataFormatEncodeOnly.Vq, PvrPixelFormat.Argb1555, false, null); //default when no file

            setupDlg._img = preview;
            setupDlg.ShowDialog();
            setupDlg.Dispose();

            SaveDialogSettingsState info = setupDlg._state;
            return info;
        }

        public SaveDialogSettingsState ShowSetupDialogBox(PVRT shendkPvr, Bitmap preview)
        {
            SaveDialogSettings setupDlg;

            uint? gbixCase = null;

            try
            {
                // Who was so smart to report a empty gbix over HasGlobalIndex in ShenmueDK as true
                // when there is none in file...  oh right that was me
                // TODO: fix it in ShenmueDKSharp...
                if (shendkPvr.GlobalIndex[0] != 0x00 || shendkPvr.GlobalIndex[1] != 0x00 ||
                    shendkPvr.GlobalIndex[2] != 0x00 || shendkPvr.GlobalIndex[3] != 0x00)
                {
                    gbixCase = BitConverter.ToUInt32(new byte[]{
                        shendkPvr.GlobalIndex[0], shendkPvr.GlobalIndex[1], shendkPvr.GlobalIndex[2], shendkPvr.GlobalIndex[3],
                    }, 0);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("ShenmueDK could not parse the GBIX ID. Please enter your own or use PuyoTools Load engine."
                    + Environment.NewLine + e );
            }

            if (shendkPvr != null)
                setupDlg = new SaveDialogSettings(shendkPvr.DataFormat, shendkPvr.PixelFormat, true, gbixCase);
            else
                setupDlg = new SaveDialogSettings(
                    ShenmueDKSharp.Files.Images._PVRT.PvrDataFormat.VECTOR_QUANTIZATION,
                    ShenmueDKSharp.Files.Images._PVRT.PvrPixelFormat.ARGB1555, false, null); //default when no file

            setupDlg._img = preview;
            setupDlg.ShowDialog();
            setupDlg.Dispose();

            SaveDialogSettingsState info = setupDlg._state;
            return info;
        }

        public void ShowLoadSetupDialogBox()
        {
            OpenDialogSettings setupDlg = new OpenDialogSettings();
            setupDlg.ShowDialog();
            setupDlg.Dispose();

            return;
        }

    }

    public class PvrFiletypeFactory : IFileTypeFactory
    {
        public FileType[] GetFileTypeInstances()
        {
            return new FileType[] { new PvrFiletype() };
        }
    }
}
