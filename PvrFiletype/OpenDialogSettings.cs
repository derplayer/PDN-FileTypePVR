using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PdnPvrFiletype
{
    public partial class OpenDialogSettings : Form
    {
        public OpenDialogSettings()
        {
            InitializeComponent();
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
    }
}
