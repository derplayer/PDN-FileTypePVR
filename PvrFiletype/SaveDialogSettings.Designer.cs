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
            this.checkBox_FastMode = new System.Windows.Forms.CheckBox();
            this.button_Save = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox_PixelFormat
            // 
            this.comboBox_PixelFormat.FormattingEnabled = true;
            this.comboBox_PixelFormat.Location = new System.Drawing.Point(12, 10);
            this.comboBox_PixelFormat.Name = "comboBox_PixelFormat";
            this.comboBox_PixelFormat.Size = new System.Drawing.Size(221, 21);
            this.comboBox_PixelFormat.TabIndex = 0;
            // 
            // label_PixelFormat
            // 
            this.label_PixelFormat.AutoSize = true;
            this.label_PixelFormat.Location = new System.Drawing.Point(239, 14);
            this.label_PixelFormat.Name = "label_PixelFormat";
            this.label_PixelFormat.Size = new System.Drawing.Size(61, 13);
            this.label_PixelFormat.TabIndex = 1;
            this.label_PixelFormat.Text = "PixelFormat";
            // 
            // label_DataFormat
            // 
            this.label_DataFormat.AutoSize = true;
            this.label_DataFormat.Location = new System.Drawing.Point(239, 46);
            this.label_DataFormat.Name = "label_DataFormat";
            this.label_DataFormat.Size = new System.Drawing.Size(62, 13);
            this.label_DataFormat.TabIndex = 3;
            this.label_DataFormat.Text = "DataFormat";
            // 
            // comboBox_DataFormat
            // 
            this.comboBox_DataFormat.FormattingEnabled = true;
            this.comboBox_DataFormat.Location = new System.Drawing.Point(12, 42);
            this.comboBox_DataFormat.Name = "comboBox_DataFormat";
            this.comboBox_DataFormat.Size = new System.Drawing.Size(221, 21);
            this.comboBox_DataFormat.TabIndex = 2;
            // 
            // label_CompressionFormat
            // 
            this.label_CompressionFormat.AutoSize = true;
            this.label_CompressionFormat.Location = new System.Drawing.Point(239, 76);
            this.label_CompressionFormat.Name = "label_CompressionFormat";
            this.label_CompressionFormat.Size = new System.Drawing.Size(99, 13);
            this.label_CompressionFormat.TabIndex = 5;
            this.label_CompressionFormat.Text = "CompressionFormat";
            // 
            // comboBox_CompressionFormat
            // 
            this.comboBox_CompressionFormat.FormattingEnabled = true;
            this.comboBox_CompressionFormat.Location = new System.Drawing.Point(12, 72);
            this.comboBox_CompressionFormat.Name = "comboBox_CompressionFormat";
            this.comboBox_CompressionFormat.Size = new System.Drawing.Size(221, 21);
            this.comboBox_CompressionFormat.TabIndex = 4;
            // 
            // checkBox_FastMode
            // 
            this.checkBox_FastMode.AutoSize = true;
            this.checkBox_FastMode.Location = new System.Drawing.Point(13, 133);
            this.checkBox_FastMode.Name = "checkBox_FastMode";
            this.checkBox_FastMode.Size = new System.Drawing.Size(277, 17);
            this.checkBox_FastMode.TabIndex = 6;
            this.checkBox_FastMode.Text = "Fast vector quantization - lowers quality, saves faster ";
            this.checkBox_FastMode.UseVisualStyleBackColor = true;
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(12, 151);
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
            this.label1.Location = new System.Drawing.Point(10, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(295, 26);
            this.label1.TabIndex = 8;
            this.label1.Text = "Not all combinations are compatible with eachother!\r\nPlease read the Dreamcast De" +
    "vBox Documentation for more.";
            // 
            // SaveDialogSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 186);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.checkBox_FastMode);
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
            this.Text = "PVR Format Plugin v1.0 - Settings - by derplayer";
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
        private System.Windows.Forms.CheckBox checkBox_FastMode;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Label label1;
    }
}