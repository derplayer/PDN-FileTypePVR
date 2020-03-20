using PaintDotNet;
using PaintDotNet.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShenmueDKSharp.Files.Images;
using PaintDotNet.IO;
using System.Windows.Forms;

namespace PdnPvrFiletype
{
    public class PvrFiletype : FileType
    {
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

        protected override Document OnLoad(Stream input)
        {
            PVRT.EnableBuffering = false;
            loadedPvr = new PVRT(input);
            return Document.FromImage(loadedPvr.CreateBitmap());
        }

        protected override void OnSave(Document input, Stream output, SaveConfigToken token, Surface scratchSurface, ProgressEventHandler callback)
        {
            RenderArgs ra = new RenderArgs(new Surface(input.Size));
            input.Render(ra, true);
            var test = token.ToString();

            using (var ms = new MemoryStream())
            {
                PVRT tmpPvr = new PVRT(new BMP(ra.Bitmap));

                if(loadedPvr != null) {
                    tmpPvr.PixelFormat = loadedPvr.PixelFormat;
                    tmpPvr.DataFormat = loadedPvr.DataFormat;
                    tmpPvr.CompressionFormat = loadedPvr.CompressionFormat;
                }

                //Dialog for settings
                tmpPvr = ShowSetupDialogBox(tmpPvr);

                //GuardedStream workaround (forums.getpaint.net/topic/114912-i-can-not-save-my-work/)
                tmpPvr.Write(ms);
                byte[] tmpBfr = ms.ToArray(); 

                output.Write(tmpBfr, 0, tmpBfr.Length);
            }

        }

        public PVRT ShowSetupDialogBox(PVRT actPvr)
        {
            SaveDialogSettings setupDlg = new SaveDialogSettings(actPvr);
            setupDlg.ShowDialog();
            setupDlg.Dispose();

            return setupDlg.tmpPvr;
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
