namespace PdnPvrFiletype
{
    partial class SaveDialogSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBox_PixelFormat = new System.Windows.Forms.ComboBox();
            this.label_PixelFormat = new System.Windows.Forms.Label();
            this.label_DataFormat = new System.Windows.Forms.Label();
            this.comboBox_DataFormat = new System.Windows.Forms.ComboBox();
            this.button_Save = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button_LoadGBIXFromFile = new System.Windows.Forms.Button();
            this.comboBox_Dithering = new System.Windows.Forms.ComboBox();
            this.numericUpDown_GBIX = new System.Windows.Forms.NumericUpDown();
            this.checkBox_GBIX = new System.Windows.Forms.CheckBox();
            this.label_PvrMetaLabel = new System.Windows.Forms.Label();
            this.checkBox_eyeMode = new System.Windows.Forms.CheckBox();
            this.button_genPrev = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox_PVRPreview = new System.Windows.Forms.PictureBox();
            this.button_loadSettingsFromPVR = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_GBIX)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_PVRPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox_PixelFormat
            // 
            this.comboBox_PixelFormat.Enabled = false;
            this.comboBox_PixelFormat.FormattingEnabled = true;
            this.comboBox_PixelFormat.Location = new System.Drawing.Point(15, 71);
            this.comboBox_PixelFormat.Name = "comboBox_PixelFormat";
            this.comboBox_PixelFormat.Size = new System.Drawing.Size(256, 21);
            this.comboBox_PixelFormat.TabIndex = 0;
            // 
            // label_PixelFormat
            // 
            this.label_PixelFormat.AutoSize = true;
            this.label_PixelFormat.Location = new System.Drawing.Point(277, 75);
            this.label_PixelFormat.Name = "label_PixelFormat";
            this.label_PixelFormat.Size = new System.Drawing.Size(61, 13);
            this.label_PixelFormat.TabIndex = 1;
            this.label_PixelFormat.Text = "Pixel format";
            // 
            // label_DataFormat
            // 
            this.label_DataFormat.AutoSize = true;
            this.label_DataFormat.Location = new System.Drawing.Point(277, 107);
            this.label_DataFormat.Name = "label_DataFormat";
            this.label_DataFormat.Size = new System.Drawing.Size(62, 13);
            this.label_DataFormat.TabIndex = 3;
            this.label_DataFormat.Text = "Data format";
            // 
            // comboBox_DataFormat
            // 
            this.comboBox_DataFormat.Enabled = false;
            this.comboBox_DataFormat.FormattingEnabled = true;
            this.comboBox_DataFormat.Location = new System.Drawing.Point(15, 103);
            this.comboBox_DataFormat.Name = "comboBox_DataFormat";
            this.comboBox_DataFormat.Size = new System.Drawing.Size(256, 21);
            this.comboBox_DataFormat.TabIndex = 2;
            this.comboBox_DataFormat.SelectedIndexChanged += new System.EventHandler(this.DitheringCheck);
            // 
            // button_Save
            // 
            this.button_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Save.Location = new System.Drawing.Point(15, 350);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(338, 48);
            this.button_Save.TabIndex = 7;
            this.button_Save.Text = "Save";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 26);
            this.label1.TabIndex = 8;
            this.label1.Text = "Not all combinations are compatible with eachother!\r\nBe careful, read the Dreamca" +
    "st DevBox Documentation for more.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(277, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 26);
            this.label2.TabIndex = 9;
            this.label2.Text = "Dithering\r\n(VQ Mode only)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 10;
            // 
            // button_LoadGBIXFromFile
            // 
            this.button_LoadGBIXFromFile.Enabled = false;
            this.button_LoadGBIXFromFile.Location = new System.Drawing.Point(236, 181);
            this.button_LoadGBIXFromFile.Name = "button_LoadGBIXFromFile";
            this.button_LoadGBIXFromFile.Size = new System.Drawing.Size(117, 22);
            this.button_LoadGBIXFromFile.TabIndex = 12;
            this.button_LoadGBIXFromFile.Text = "Load GBIX from PVR";
            this.button_LoadGBIXFromFile.UseVisualStyleBackColor = true;
            this.button_LoadGBIXFromFile.Click += new System.EventHandler(this.button_LoadGBIXFromFile_Click);
            // 
            // comboBox_Dithering
            // 
            this.comboBox_Dithering.Enabled = false;
            this.comboBox_Dithering.FormattingEnabled = true;
            this.comboBox_Dithering.Location = new System.Drawing.Point(15, 135);
            this.comboBox_Dithering.Name = "comboBox_Dithering";
            this.comboBox_Dithering.Size = new System.Drawing.Size(256, 21);
            this.comboBox_Dithering.TabIndex = 13;
            // 
            // numericUpDown_GBIX
            // 
            this.numericUpDown_GBIX.Enabled = false;
            this.numericUpDown_GBIX.Location = new System.Drawing.Point(140, 182);
            this.numericUpDown_GBIX.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.numericUpDown_GBIX.Name = "numericUpDown_GBIX";
            this.numericUpDown_GBIX.Size = new System.Drawing.Size(98, 20);
            this.numericUpDown_GBIX.TabIndex = 14;
            // 
            // checkBox_GBIX
            // 
            this.checkBox_GBIX.AutoSize = true;
            this.checkBox_GBIX.Location = new System.Drawing.Point(15, 184);
            this.checkBox_GBIX.Name = "checkBox_GBIX";
            this.checkBox_GBIX.Size = new System.Drawing.Size(119, 17);
            this.checkBox_GBIX.TabIndex = 15;
            this.checkBox_GBIX.Text = "Global Index (GBIX)";
            this.checkBox_GBIX.UseVisualStyleBackColor = true;
            this.checkBox_GBIX.CheckedChanged += new System.EventHandler(this.GBIXStateChanged);
            // 
            // label_PvrMetaLabel
            // 
            this.label_PvrMetaLabel.AutoSize = true;
            this.label_PvrMetaLabel.Location = new System.Drawing.Point(12, 45);
            this.label_PvrMetaLabel.Name = "label_PvrMetaLabel";
            this.label_PvrMetaLabel.Size = new System.Drawing.Size(100, 13);
            this.label_PvrMetaLabel.TabIndex = 17;
            this.label_PvrMetaLabel.Text = "Loaded PVR: None";
            // 
            // checkBox_eyeMode
            // 
            this.checkBox_eyeMode.AutoSize = true;
            this.checkBox_eyeMode.Location = new System.Drawing.Point(15, 162);
            this.checkBox_eyeMode.Name = "checkBox_eyeMode";
            this.checkBox_eyeMode.Size = new System.Drawing.Size(157, 17);
            this.checkBox_eyeMode.TabIndex = 18;
            this.checkBox_eyeMode.Text = "Eye Weight Mode (VQ only)";
            this.checkBox_eyeMode.UseVisualStyleBackColor = true;
            // 
            // button_genPrev
            // 
            this.button_genPrev.Location = new System.Drawing.Point(15, 278);
            this.button_genPrev.Name = "button_genPrev";
            this.button_genPrev.Size = new System.Drawing.Size(338, 48);
            this.button_genPrev.TabIndex = 21;
            this.button_genPrev.Text = "Update PVR preview";
            this.button_genPrev.UseVisualStyleBackColor = true;
            this.button_genPrev.Click += new System.EventHandler(this.button_genPrev_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pictureBox_PVRPreview);
            this.panel1.Location = new System.Drawing.Point(365, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(384, 384);
            this.panel1.TabIndex = 28;
            // 
            // pictureBox_PVRPreview
            // 
            this.pictureBox_PVRPreview.BackColor = System.Drawing.Color.Silver;
            this.pictureBox_PVRPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_PVRPreview.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBox_PVRPreview.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_PVRPreview.Name = "pictureBox_PVRPreview";
            this.pictureBox_PVRPreview.Size = new System.Drawing.Size(384, 384);
            this.pictureBox_PVRPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox_PVRPreview.TabIndex = 19;
            this.pictureBox_PVRPreview.TabStop = false;
            // 
            // button_loadSettingsFromPVR
            // 
            this.button_loadSettingsFromPVR.Location = new System.Drawing.Point(15, 209);
            this.button_loadSettingsFromPVR.Name = "button_loadSettingsFromPVR";
            this.button_loadSettingsFromPVR.Size = new System.Drawing.Size(336, 48);
            this.button_loadSettingsFromPVR.TabIndex = 29;
            this.button_loadSettingsFromPVR.Text = "Load Settings from PVR";
            this.button_loadSettingsFromPVR.UseVisualStyleBackColor = true;
            this.button_loadSettingsFromPVR.Click += new System.EventHandler(this.button_loadSettingsFromPVR_Click);
            // 
            // SaveDialogSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 411);
            this.ControlBox = false;
            this.Controls.Add(this.button_loadSettingsFromPVR);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button_genPrev);
            this.Controls.Add(this.checkBox_eyeMode);
            this.Controls.Add(this.label_PvrMetaLabel);
            this.Controls.Add(this.checkBox_GBIX);
            this.Controls.Add(this.numericUpDown_GBIX);
            this.Controls.Add(this.comboBox_Dithering);
            this.Controls.Add(this.button_LoadGBIXFromFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.label_DataFormat);
            this.Controls.Add(this.comboBox_DataFormat);
            this.Controls.Add(this.label_PixelFormat);
            this.Controls.Add(this.comboBox_PixelFormat);
            this.MinimumSize = new System.Drawing.Size(390, 450);
            this.Name = "SaveDialogSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "PVR Format Plugin v1.1 - Settings - by derplayer";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_GBIX)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_PVRPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_PixelFormat;
        private System.Windows.Forms.Label label_PixelFormat;
        private System.Windows.Forms.Label label_DataFormat;
        private System.Windows.Forms.ComboBox comboBox_DataFormat;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_LoadGBIXFromFile;
        private System.Windows.Forms.ComboBox comboBox_Dithering;
        private System.Windows.Forms.NumericUpDown numericUpDown_GBIX;
        private System.Windows.Forms.CheckBox checkBox_GBIX;
        private System.Windows.Forms.Label label_PvrMetaLabel;
        private System.Windows.Forms.CheckBox checkBox_eyeMode;
        private System.Windows.Forms.Button button_genPrev;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox_PVRPreview;
        private System.Windows.Forms.Button button_loadSettingsFromPVR;
    }
}