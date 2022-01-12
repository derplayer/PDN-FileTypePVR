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
            this.label_CompressionFormat = new System.Windows.Forms.Label();
            this.comboBox_CompressionFormat = new System.Windows.Forms.ComboBox();
            this.button_Save = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_Engine = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // comboBox_PixelFormat
            // 
            this.comboBox_PixelFormat.Enabled = false;
            this.comboBox_PixelFormat.FormattingEnabled = true;
            this.comboBox_PixelFormat.Location = new System.Drawing.Point(12, 77);
            this.comboBox_PixelFormat.Name = "comboBox_PixelFormat";
            this.comboBox_PixelFormat.Size = new System.Drawing.Size(221, 21);
            this.comboBox_PixelFormat.TabIndex = 0;
            // 
            // label_PixelFormat
            // 
            this.label_PixelFormat.AutoSize = true;
            this.label_PixelFormat.Location = new System.Drawing.Point(239, 81);
            this.label_PixelFormat.Name = "label_PixelFormat";
            this.label_PixelFormat.Size = new System.Drawing.Size(61, 13);
            this.label_PixelFormat.TabIndex = 1;
            this.label_PixelFormat.Text = "Pixel format";
            // 
            // label_DataFormat
            // 
            this.label_DataFormat.AutoSize = true;
            this.label_DataFormat.Location = new System.Drawing.Point(239, 113);
            this.label_DataFormat.Name = "label_DataFormat";
            this.label_DataFormat.Size = new System.Drawing.Size(62, 13);
            this.label_DataFormat.TabIndex = 3;
            this.label_DataFormat.Text = "Data format";
            // 
            // comboBox_DataFormat
            // 
            this.comboBox_DataFormat.Enabled = false;
            this.comboBox_DataFormat.FormattingEnabled = true;
            this.comboBox_DataFormat.Location = new System.Drawing.Point(12, 109);
            this.comboBox_DataFormat.Name = "comboBox_DataFormat";
            this.comboBox_DataFormat.Size = new System.Drawing.Size(221, 21);
            this.comboBox_DataFormat.TabIndex = 2;
            // 
            // label_CompressionFormat
            // 
            this.label_CompressionFormat.AutoSize = true;
            this.label_CompressionFormat.Location = new System.Drawing.Point(239, 143);
            this.label_CompressionFormat.Name = "label_CompressionFormat";
            this.label_CompressionFormat.Size = new System.Drawing.Size(99, 13);
            this.label_CompressionFormat.TabIndex = 5;
            this.label_CompressionFormat.Text = "Compression format";
            // 
            // comboBox_CompressionFormat
            // 
            this.comboBox_CompressionFormat.Enabled = false;
            this.comboBox_CompressionFormat.FormattingEnabled = true;
            this.comboBox_CompressionFormat.Location = new System.Drawing.Point(12, 139);
            this.comboBox_CompressionFormat.Name = "comboBox_CompressionFormat";
            this.comboBox_CompressionFormat.Size = new System.Drawing.Size(221, 21);
            this.comboBox_CompressionFormat.TabIndex = 4;
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(12, 166);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(326, 23);
            this.button_Save.TabIndex = 7;
            this.button_Save.Text = "Save";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(295, 26);
            this.label1.TabIndex = 8;
            this.label1.Text = "Not all combinations are compatible with eachother!\r\nPlease read the Dreamcast De" +
    "vBox Documentation for more.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(239, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Encoding engine";
            // 
            // comboBox_Engine
            // 
            this.comboBox_Engine.FormattingEnabled = true;
            this.comboBox_Engine.Items.AddRange(new object[] {
            "PuyoTools",
            "ShennmueDK (not recommended)"});
            this.comboBox_Engine.Location = new System.Drawing.Point(15, 12);
            this.comboBox_Engine.Name = "comboBox_Engine";
            this.comboBox_Engine.Size = new System.Drawing.Size(218, 21);
            this.comboBox_Engine.TabIndex = 10;
            this.comboBox_Engine.SelectedIndexChanged += new System.EventHandler(this.comboBox_EngineChanged);
            // 
            // SaveDialogSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 201);
            this.ControlBox = false;
            this.Controls.Add(this.comboBox_Engine);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.label_CompressionFormat);
            this.Controls.Add(this.comboBox_CompressionFormat);
            this.Controls.Add(this.label_DataFormat);
            this.Controls.Add(this.comboBox_DataFormat);
            this.Controls.Add(this.label_PixelFormat);
            this.Controls.Add(this.comboBox_PixelFormat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SaveDialogSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "PVR Format Plugin v1.1 - Settings - by derplayer";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_PixelFormat;
        private System.Windows.Forms.Label label_PixelFormat;
        private System.Windows.Forms.Label label_DataFormat;
        private System.Windows.Forms.ComboBox comboBox_DataFormat;
        private System.Windows.Forms.Label label_CompressionFormat;
        private System.Windows.Forms.ComboBox comboBox_CompressionFormat;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_Engine;
    }
}