namespace CR2ToJPG
{
    partial class frmOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOptions));
            this.chkSubfolders = new System.Windows.Forms.CheckBox();
            this.gbConversionSettings = new System.Windows.Forms.GroupBox();
            this.numQualityLevel = new System.Windows.Forms.NumericUpDown();
            this.lblQuality = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.chkDuplicates = new System.Windows.Forms.CheckBox();
            this.gbConversionSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQualityLevel)).BeginInit();
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
            this.gbConversionSettings.Controls.Add(this.chkDuplicates);
            this.gbConversionSettings.Controls.Add(this.numQualityLevel);
            this.gbConversionSettings.Controls.Add(this.lblQuality);
            this.gbConversionSettings.Controls.Add(this.chkSubfolders);
            this.gbConversionSettings.Location = new System.Drawing.Point(13, 13);
            this.gbConversionSettings.Name = "gbConversionSettings";
            this.gbConversionSettings.Size = new System.Drawing.Size(200, 114);
            this.gbConversionSettings.TabIndex = 13;
            this.gbConversionSettings.TabStop = false;
            this.gbConversionSettings.Text = "Conversion Settings";
            // 
            // numQualityLevel
            // 
            this.numQualityLevel.Location = new System.Drawing.Point(6, 85);
            this.numQualityLevel.Name = "numQualityLevel";
            this.numQualityLevel.Size = new System.Drawing.Size(185, 20);
            this.numQualityLevel.TabIndex = 15;
            this.numQualityLevel.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // lblQuality
            // 
            this.lblQuality.AutoSize = true;
            this.lblQuality.Location = new System.Drawing.Point(3, 66);
            this.lblQuality.Name = "lblQuality";
            this.lblQuality.Size = new System.Drawing.Size(85, 13);
            this.lblQuality.TabIndex = 14;
            this.lblQuality.Text = "Quality Level (%)";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(13, 133);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(200, 23);
            this.btnOK.TabIndex = 14;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
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
            // frmOptions
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(229, 165);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gbConversionSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOptions";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.frmOptions_Load);
            this.gbConversionSettings.ResumeLayout(false);
            this.gbConversionSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQualityLevel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkSubfolders;
        private System.Windows.Forms.GroupBox gbConversionSettings;
        private System.Windows.Forms.Label lblQuality;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.NumericUpDown numQualityLevel;
        private System.Windows.Forms.CheckBox chkDuplicates;
    }
}