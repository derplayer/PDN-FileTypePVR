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
            if(LoadEngineMode == PvrEngineEnum.None)
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
            var test = token.ToString();

            // Show dialog and setup engine parameters
            SaveDialogSettingsState pvrMetaData;

            if (LoadEngineMode == PvrEngineEnum.PuyoTools)
                pvrMetaData = ShowSetupDialogBox(loadedPvr);
            else
                pvrMetaData = ShowSetupDialogBox(loadedPvrPuyo);

            using (var ms = new MemoryStream())
            {
                if (pvrMetaData.SaveEngineMode == PvrEnginePublic.PuyoTools)
                {
                    using (var ms1 = new MemoryStream())
                    {
                        //HACK: convert to PNG memorystream (the only thing thats accepted by puyotools)
                        ra.Bitmap.Save(ms1, System.Drawing.Imaging.ImageFormat.Png);

                        var tmpPvrPuyo = new PvrTextureEncoder(ms1, pvrMetaData.PuyoPixelFormat, pvrMetaData.PuyoDataFormat);
                        tmpPvrPuyo.Save(ms);
                    }
                }
                else
                {
                    PVRT tmpPvr = new PVRT(new BMP(ra.Bitmap));
                    tmpPvr.CompressionFormat = pvrMetaData.ShenDKCompressionFormat;
                    tmpPvr.PixelFormat = pvrMetaData.ShenDKPixelFormat;
                    tmpPvr.DataFormat = pvrMetaData.ShenDKDataFormat;

                    //GuardedStream workaround (forums.getpaint.net/topic/114912-i-can-not-save-my-work/)
                    tmpPvr.Write(ms);
                }

                byte[] tmpBfr = ms.ToArray(); 
                output.Write(tmpBfr, 0, tmpBfr.Length);
            }

        }

        public SaveDialogSettingsState ShowSetupDialogBox(PvrTextureDecoder puyoPvr)
        {
            SaveDialogSettings setupDlg;

            if (puyoPvr != null)
                setupDlg = new SaveDialogSettings(puyoPvr.CompressionFormat, puyoPvr.DataFormat, puyoPvr.PixelFormat);
            else
                setupDlg = new SaveDialogSettings(PuyoTools.Core.Textures.Pvr.PvrCompressionFormat.None,
                    PuyoTools.Core.Textures.Pvr.PvrDataFormat.Vq,
                    PuyoTools.Core.Textures.Pvr.PvrPixelFormat.Argb1555); //default when no file

            SaveDialogSettingsState info = setupDlg._state;
            setupDlg.ShowDialog();
            setupDlg.Dispose();

            return info;
        }

        public SaveDialogSettingsState ShowSetupDialogBox(PVRT shendkPvr)
        {
            SaveDialogSettings setupDlg;

            if(shendkPvr != null)
                setupDlg = new SaveDialogSettings(shendkPvr.CompressionFormat, shendkPvr.DataFormat, shendkPvr.PixelFormat);
            else
                setupDlg = new SaveDialogSettings(ShenmueDKSharp.Files.Images._PVRT.PvrCompressionFormat.NONE,
                    ShenmueDKSharp.Files.Images._PVRT.PvrDataFormat.VECTOR_QUANTIZATION,
                    ShenmueDKSharp.Files.Images._PVRT.PvrPixelFormat.ARGB1555); //default when no file

            SaveDialogSettingsState info = setupDlg._state;
            setupDlg.ShowDialog();
            setupDlg.Dispose();

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
