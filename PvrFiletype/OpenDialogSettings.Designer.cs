
namespace PdnPvrFiletype
{
    partial class OpenDialogSettings
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
            this.button_puyoDecode = new System.Windows.Forms.Button();
            this.button_shenmueDecode = new System.Windows.Forms.Button();
            this.label_Compression = new System.Windows.Forms.Label();
            this.label_Pixel = new System.Windows.Forms.Label();
            this.label_Data = new System.Windows.Forms.Label();
            this.label_Id = new System.Windows.Forms.Label();
            this.label_extra = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_puyoDecode
            // 
            this.button_puyoDecode.Location = new System.Drawing.Point(11, 98);
            this.button_puyoDecode.Name = "button_puyoDecode";
            this.button_puyoDecode.Size = new System.Drawing.Size(226, 54);
            this.button_puyoDecode.TabIndex = 0;
            this.button_puyoDecode.Text = "PuyoTools decoding engine";
            this.button_puyoDecode.UseVisualStyleBackColor = true;
            this.button_puyoDecode.Click += new System.EventHandler(this.button_puyoDecode_Click);
            // 
            // button_shenmueDecode
            // 
            this.button_shenmueDecode.Location = new System.Drawing.Point(11, 43);
            this.button_shenmueDecode.Name = "button_shenmueDecode";
            this.button_shenmueDecode.Size = new System.Drawing.Size(226, 54);
            this.button_shenmueDecode.TabIndex = 1;
            this.button_shenmueDecode.Text = "ShenmueDK decoding engine";
            this.button_shenmueDecode.UseVisualStyleBackColor = true;
            this.button_shenmueDecode.Click += new System.EventHandler(this.button_shenmueDecode_Click);
            // 
            // label_Compression
            // 
            this.label_Compression.AutoSize = true;
            this.label_Compression.Location = new System.Drawing.Point(268, 10);
            this.label_Compression.Name = "label_Compression";
            this.label_Compression.Size = new System.Drawing.Size(117, 13);
            this.label_Compression.TabIndex = 4;
            this.label_Compression.Text = "INFO_COMPRESSION";
            // 
            // label_Pixel
            // 
            this.label_Pixel.AutoSize = true;
            this.label_Pixel.Location = new System.Drawing.Point(268, 60);
            this.label_Pixel.Name = "label_Pixel";
            this.label_Pixel.Size = new System.Drawing.Size(68, 13);
            this.label_Pixel.TabIndex = 5;
            this.label_Pixel.Text = "INFO_PIXEL";
            // 
            // label_Data
            // 
            this.label_Data.AutoSize = true;
            this.label_Data.Location = new System.Drawing.Point(268, 35);
            this.label_Data.Name = "label_Data";
            this.label_Data.Size = new System.Drawing.Size(67, 13);
            this.label_Data.TabIndex = 8;
            this.label_Data.Text = "INFO_DATA";
            // 
            // label_Id
            // 
            this.label_Id.AutoSize = true;
            this.label_Id.Location = new System.Drawing.Point(268, 85);
            this.label_Id.Name = "label_Id";
            this.label_Id.Size = new System.Drawing.Size(80, 13);
            this.label_Id.TabIndex = 9;
            this.label_Id.Text = "INFO_GBIX_ID";
            // 
            // label_extra
            // 
            this.label_extra.AutoSize = true;
            this.label_extra.Location = new System.Drawing.Point(268, 111);
            this.label_extra.Name = "label_extra";
            this.label_extra.Size = new System.Drawing.Size(74, 13);
            this.label_extra.TabIndex = 10;
            this.label_extra.Text = "INFO_EXTRA";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(12, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(184, 26);
            this.label4.TabIndex = 11;
            this.label4.Text = "Note: Choice will be remembered until\r\nPaint.NET is closed!";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(205, 26);
            this.label5.TabIndex = 12;
            this.label5.Text = "Info: ShenmueDK can read more Formats.\r\nPuyoTools does not support some.";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // OpenDialogSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 195);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label_extra);
            this.Controls.Add(this.label_Id);
            this.Controls.Add(this.label_Data);
            this.Controls.Add(this.label_Pixel);
            this.Controls.Add(this.label_Compression);
            this.Controls.Add(this.button_shenmueDecode);
            this.Controls.Add(this.button_puyoDecode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OpenDialogSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "PVR Format Plugin v1.1 - by derplayer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OpenDialogSettings_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_puyoDecode;
        private System.Windows.Forms.Button button_shenmueDecode;
        private System.Windows.Forms.Label label_Compression;
        private System.Windows.Forms.Label label_Pixel;
        private System.Windows.Forms.Label label_Data;
        private System.Windows.Forms.Label label_Id;
        private System.Windows.Forms.Label label_extra;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}