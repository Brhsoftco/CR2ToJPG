using System.ComponentModel;
using System.Windows.Forms;

namespace CR2ToJPG
{
    partial class FrmOptions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOptions));
            this.chkSubfolders = new System.Windows.Forms.CheckBox();
            this.gbConversionSettings = new System.Windows.Forms.GroupBox();
            this.chkProcessJPEG = new System.Windows.Forms.CheckBox();
            this.chkDuplicates = new System.Windows.Forms.CheckBox();
            this.numQualityLevel = new System.Windows.Forms.NumericUpDown();
            this.btnOK = new System.Windows.Forms.Button();
            this.radNative = new System.Windows.Forms.RadioButton();
            this.radMagickNet = new System.Windows.Forms.RadioButton();
            this.gbQuality = new System.Windows.Forms.GroupBox();
            this.gbImageProcessor = new System.Windows.Forms.GroupBox();
            this.gbConversionSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQualityLevel)).BeginInit();
            this.gbQuality.SuspendLayout();
            this.gbImageProcessor.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkSubfolders
            // 
            this.chkSubfolders.AutoSize = true;
            this.chkSubfolders.Location = new System.Drawing.Point(6, 19);
            this.chkSubfolders.Name = "chkSubfolders";
            this.chkSubfolders.Size = new System.Drawing.Size(114, 17);
            this.chkSubfolders.TabIndex = 12;
            this.chkSubfolders.Text = "Include Subfolders";
            this.chkSubfolders.UseVisualStyleBackColor = true;
            // 
            // gbConversionSettings
            // 
            this.gbConversionSettings.Controls.Add(this.chkProcessJPEG);
            this.gbConversionSettings.Controls.Add(this.chkDuplicates);
            this.gbConversionSettings.Controls.Add(this.chkSubfolders);
            this.gbConversionSettings.Location = new System.Drawing.Point(12, 112);
            this.gbConversionSettings.Name = "gbConversionSettings";
            this.gbConversionSettings.Size = new System.Drawing.Size(200, 85);
            this.gbConversionSettings.TabIndex = 13;
            this.gbConversionSettings.TabStop = false;
            this.gbConversionSettings.Text = "Conversion Settings";
            // 
            // chkProcessJPEG
            // 
            this.chkProcessJPEG.AutoSize = true;
            this.chkProcessJPEG.Location = new System.Drawing.Point(6, 65);
            this.chkProcessJPEG.Name = "chkProcessJPEG";
            this.chkProcessJPEG.Size = new System.Drawing.Size(94, 17);
            this.chkProcessJPEG.TabIndex = 17;
            this.chkProcessJPEG.Text = "Process JPEG";
            this.chkProcessJPEG.UseVisualStyleBackColor = true;
            // 
            // chkDuplicates
            // 
            this.chkDuplicates.AutoSize = true;
            this.chkDuplicates.Checked = true;
            this.chkDuplicates.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDuplicates.Location = new System.Drawing.Point(6, 42);
            this.chkDuplicates.Name = "chkDuplicates";
            this.chkDuplicates.Size = new System.Drawing.Size(110, 17);
            this.chkDuplicates.TabIndex = 16;
            this.chkDuplicates.Text = "Create Duplicates";
            this.chkDuplicates.UseVisualStyleBackColor = true;
            // 
            // numQualityLevel
            // 
            this.numQualityLevel.Location = new System.Drawing.Point(6, 19);
            this.numQualityLevel.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numQualityLevel.Name = "numQualityLevel";
            this.numQualityLevel.Size = new System.Drawing.Size(188, 20);
            this.numQualityLevel.TabIndex = 15;
            this.numQualityLevel.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(12, 203);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(200, 23);
            this.btnOK.TabIndex = 14;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // radNative
            // 
            this.radNative.AutoSize = true;
            this.radNative.Checked = true;
            this.radNative.Location = new System.Drawing.Point(6, 19);
            this.radNative.Name = "radNative";
            this.radNative.Size = new System.Drawing.Size(56, 17);
            this.radNative.TabIndex = 19;
            this.radNative.TabStop = true;
            this.radNative.Text = "Native";
            this.radNative.UseVisualStyleBackColor = true;
            // 
            // radMagickNet
            // 
            this.radMagickNet.AutoSize = true;
            this.radMagickNet.Location = new System.Drawing.Point(68, 19);
            this.radMagickNet.Name = "radMagickNet";
            this.radMagickNet.Size = new System.Drawing.Size(85, 17);
            this.radMagickNet.TabIndex = 20;
            this.radMagickNet.Text = "Magick.NET";
            this.radMagickNet.UseVisualStyleBackColor = true;
            // 
            // gbQuality
            // 
            this.gbQuality.Controls.Add(this.numQualityLevel);
            this.gbQuality.Location = new System.Drawing.Point(12, 59);
            this.gbQuality.Name = "gbQuality";
            this.gbQuality.Size = new System.Drawing.Size(200, 47);
            this.gbQuality.TabIndex = 21;
            this.gbQuality.TabStop = false;
            this.gbQuality.Text = "Quality (%)";
            // 
            // gbImageProcessor
            // 
            this.gbImageProcessor.Controls.Add(this.radNative);
            this.gbImageProcessor.Controls.Add(this.radMagickNet);
            this.gbImageProcessor.Location = new System.Drawing.Point(12, 12);
            this.gbImageProcessor.Name = "gbImageProcessor";
            this.gbImageProcessor.Size = new System.Drawing.Size(200, 41);
            this.gbImageProcessor.TabIndex = 22;
            this.gbImageProcessor.TabStop = false;
            this.gbImageProcessor.Text = "Image Processor";
            // 
            // frmOptions
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(225, 236);
            this.Controls.Add(this.gbImageProcessor);
            this.Controls.Add(this.gbQuality);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gbConversionSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmOptions";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.frmOptions_Load);
            this.gbConversionSettings.ResumeLayout(false);
            this.gbConversionSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQualityLevel)).EndInit();
            this.gbQuality.ResumeLayout(false);
            this.gbImageProcessor.ResumeLayout(false);
            this.gbImageProcessor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CheckBox chkSubfolders;
        private GroupBox gbConversionSettings;
        private Button btnOK;
        private NumericUpDown numQualityLevel;
        private CheckBox chkDuplicates;
        private CheckBox chkProcessJPEG;
        private RadioButton radNative;
        private RadioButton radMagickNet;
        private GroupBox gbQuality;
        private GroupBox gbImageProcessor;
    }
}