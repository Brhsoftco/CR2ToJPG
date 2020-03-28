using System.ComponentModel;
using System.Windows.Forms;

namespace CR2ToJPG
{
    partial class FrmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.picMain = new System.Windows.Forms.PictureBox();
            this.txtInputDirectory = new System.Windows.Forms.TextBox();
            this.btnSelectInputDirectory = new System.Windows.Forms.Button();
            this.lblCR2Folder = new System.Windows.Forms.Label();
            this.txtOutputDirectory = new System.Windows.Forms.TextBox();
            this.btnSelectOutputDirectory = new System.Windows.Forms.Button();
            this.lblJPEGFolder = new System.Windows.Forms.Label();
            this.btnProcess = new System.Windows.Forms.Button();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.itmProfile = new System.Windows.Forms.ToolStripMenuItem();
            this.itmProfileLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.itmProfileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.itmOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.itmPicture = new System.Windows.Forms.ToolStripMenuItem();
            this.itmWatermarking = new System.Windows.Forms.ToolStripMenuItem();
            this.itmHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.itmAboutViewInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.itmQuickGuide = new System.Windows.Forms.ToolStripMenuItem();
            this.itmCheckUpdates = new System.Windows.Forms.ToolStripMenuItem();
            this.itmAboutWebsite = new System.Windows.Forms.ToolStripMenuItem();
            this.statusMain = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatusValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblVersion = new System.Windows.Forms.Label();
            this.nfyMain = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).BeginInit();
            this.menuMain.SuspendLayout();
            this.statusMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // picMain
            // 
            this.picMain.Image = ((System.Drawing.Image)(resources.GetObject("picMain.Image")));
            this.picMain.Location = new System.Drawing.Point(12, 29);
            this.picMain.Name = "picMain";
            this.picMain.Size = new System.Drawing.Size(128, 128);
            this.picMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picMain.TabIndex = 0;
            this.picMain.TabStop = false;
            this.picMain.Click += new System.EventHandler(this.picMain_Click);
            // 
            // txtInputDirectory
            // 
            this.txtInputDirectory.Location = new System.Drawing.Point(166, 45);
            this.txtInputDirectory.Name = "txtInputDirectory";
            this.txtInputDirectory.ReadOnly = true;
            this.txtInputDirectory.Size = new System.Drawing.Size(289, 20);
            this.txtInputDirectory.TabIndex = 2;
            this.txtInputDirectory.TextChanged += new System.EventHandler(this.txtInputDirectory_TextChanged);
            // 
            // btnSelectInputDirectory
            // 
            this.btnSelectInputDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectInputDirectory.Location = new System.Drawing.Point(462, 43);
            this.btnSelectInputDirectory.Name = "btnSelectInputDirectory";
            this.btnSelectInputDirectory.Size = new System.Drawing.Size(31, 23);
            this.btnSelectInputDirectory.TabIndex = 3;
            this.btnSelectInputDirectory.Text = "...";
            this.btnSelectInputDirectory.UseVisualStyleBackColor = true;
            this.btnSelectInputDirectory.Click += new System.EventHandler(this.btnSelectInputDirectory_Click);
            // 
            // lblCR2Folder
            // 
            this.lblCR2Folder.AutoSize = true;
            this.lblCR2Folder.Location = new System.Drawing.Point(163, 29);
            this.lblCR2Folder.Name = "lblCR2Folder";
            this.lblCR2Folder.Size = new System.Drawing.Size(63, 13);
            this.lblCR2Folder.TabIndex = 1;
            this.lblCR2Folder.Text = "Input Folder";
            // 
            // txtOutputDirectory
            // 
            this.txtOutputDirectory.Location = new System.Drawing.Point(166, 91);
            this.txtOutputDirectory.Name = "txtOutputDirectory";
            this.txtOutputDirectory.ReadOnly = true;
            this.txtOutputDirectory.Size = new System.Drawing.Size(289, 20);
            this.txtOutputDirectory.TabIndex = 5;
            this.txtOutputDirectory.TextChanged += new System.EventHandler(this.txtOutputDirectory_TextChanged);
            // 
            // btnSelectOutputDirectory
            // 
            this.btnSelectOutputDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectOutputDirectory.Location = new System.Drawing.Point(462, 89);
            this.btnSelectOutputDirectory.Name = "btnSelectOutputDirectory";
            this.btnSelectOutputDirectory.Size = new System.Drawing.Size(31, 23);
            this.btnSelectOutputDirectory.TabIndex = 6;
            this.btnSelectOutputDirectory.Text = "...";
            this.btnSelectOutputDirectory.UseVisualStyleBackColor = true;
            this.btnSelectOutputDirectory.Click += new System.EventHandler(this.btnSelectOutputDirectory_Click);
            // 
            // lblJPEGFolder
            // 
            this.lblJPEGFolder.AutoSize = true;
            this.lblJPEGFolder.Location = new System.Drawing.Point(163, 75);
            this.lblJPEGFolder.Name = "lblJPEGFolder";
            this.lblJPEGFolder.Size = new System.Drawing.Size(71, 13);
            this.lblJPEGFolder.TabIndex = 4;
            this.lblJPEGFolder.Text = "Output Folder";
            this.lblJPEGFolder.Click += new System.EventHandler(this.lblJPEGFolder_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(418, 123);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 23);
            this.btnProcess.TabIndex = 8;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // pbProgress
            // 
            this.pbProgress.Location = new System.Drawing.Point(166, 123);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(245, 23);
            this.pbProgress.TabIndex = 7;
            this.pbProgress.Click += new System.EventHandler(this.pbProgress_Click);
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmProfile,
            this.itmOptions,
            this.itmPicture,
            this.itmHelp});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(505, 24);
            this.menuMain.TabIndex = 12;
            this.menuMain.Text = "menuStrip1";
            // 
            // itmProfile
            // 
            this.itmProfile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmProfileLoad,
            this.itmProfileSave});
            this.itmProfile.Name = "itmProfile";
            this.itmProfile.Size = new System.Drawing.Size(53, 20);
            this.itmProfile.Text = "Profile";
            // 
            // itmProfileLoad
            // 
            this.itmProfileLoad.Name = "itmProfileLoad";
            this.itmProfileLoad.ShortcutKeyDisplayString = "Ctrl+O";
            this.itmProfileLoad.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.itmProfileLoad.Size = new System.Drawing.Size(143, 22);
            this.itmProfileLoad.Text = "Load";
            this.itmProfileLoad.Click += new System.EventHandler(this.itmProfileLoad_Click);
            // 
            // itmProfileSave
            // 
            this.itmProfileSave.Name = "itmProfileSave";
            this.itmProfileSave.ShortcutKeyDisplayString = "Ctrl+S";
            this.itmProfileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.itmProfileSave.Size = new System.Drawing.Size(143, 22);
            this.itmProfileSave.Text = "Save";
            this.itmProfileSave.Click += new System.EventHandler(this.itmProfileSave_Click);
            // 
            // itmOptions
            // 
            this.itmOptions.Name = "itmOptions";
            this.itmOptions.Size = new System.Drawing.Size(61, 20);
            this.itmOptions.Text = "Options";
            this.itmOptions.Click += new System.EventHandler(this.optionToolStripMenuItem_Click);
            // 
            // itmPicture
            // 
            this.itmPicture.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmWatermarking});
            this.itmPicture.Name = "itmPicture";
            this.itmPicture.Size = new System.Drawing.Size(56, 20);
            this.itmPicture.Text = "Picture";
            // 
            // itmWatermarking
            // 
            this.itmWatermarking.Name = "itmWatermarking";
            this.itmWatermarking.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.itmWatermarking.Size = new System.Drawing.Size(194, 22);
            this.itmWatermarking.Text = "Watermarking";
            this.itmWatermarking.Click += new System.EventHandler(this.watermarkingWizardToolStripMenuItem_Click);
            // 
            // itmHelp
            // 
            this.itmHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmAboutViewInfo,
            this.itmQuickGuide,
            this.itmCheckUpdates,
            this.itmAboutWebsite});
            this.itmHelp.Name = "itmHelp";
            this.itmHelp.Size = new System.Drawing.Size(44, 20);
            this.itmHelp.Text = "Help";
            this.itmHelp.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // itmAboutViewInfo
            // 
            this.itmAboutViewInfo.Name = "itmAboutViewInfo";
            this.itmAboutViewInfo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.itmAboutViewInfo.Size = new System.Drawing.Size(213, 22);
            this.itmAboutViewInfo.Text = "About";
            this.itmAboutViewInfo.Click += new System.EventHandler(this.viewInfoToolStripMenuItem_Click);
            // 
            // itmQuickGuide
            // 
            this.itmQuickGuide.Name = "itmQuickGuide";
            this.itmQuickGuide.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.itmQuickGuide.Size = new System.Drawing.Size(213, 22);
            this.itmQuickGuide.Text = "Quick Guide";
            this.itmQuickGuide.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // itmCheckUpdates
            // 
            this.itmCheckUpdates.Name = "itmCheckUpdates";
            this.itmCheckUpdates.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.itmCheckUpdates.Size = new System.Drawing.Size(213, 22);
            this.itmCheckUpdates.Text = "Check for Updates";
            this.itmCheckUpdates.Click += new System.EventHandler(this.itmCheckUpdates_Click);
            // 
            // itmAboutWebsite
            // 
            this.itmAboutWebsite.Name = "itmAboutWebsite";
            this.itmAboutWebsite.Size = new System.Drawing.Size(213, 22);
            this.itmAboutWebsite.Text = "https://brharris.me/";
            this.itmAboutWebsite.Click += new System.EventHandler(this.itmAboutWebsite_Click);
            // 
            // statusMain
            // 
            this.statusMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblStatusValue});
            this.statusMain.Location = new System.Drawing.Point(0, 183);
            this.statusMain.Name = "statusMain";
            this.statusMain.Size = new System.Drawing.Size(505, 22);
            this.statusMain.TabIndex = 13;
            this.statusMain.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(42, 17);
            this.lblStatus.Text = "Status:";
            // 
            // lblStatusValue
            // 
            this.lblStatusValue.Name = "lblStatusValue";
            this.lblStatusValue.Size = new System.Drawing.Size(26, 17);
            this.lblStatusValue.Text = "Idle";
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVersion.AutoSize = true;
            this.lblVersion.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblVersion.Location = new System.Drawing.Point(9, 163);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(58, 13);
            this.lblVersion.TabIndex = 0;
            this.lblVersion.Text = "[lblVersion]";
            // 
            // nfyMain
            // 
            this.nfyMain.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.nfyMain.Icon = ((System.Drawing.Icon)(resources.GetObject("nfyMain.Icon")));
            this.nfyMain.Text = "CR2 To JPG";
            this.nfyMain.Visible = true;
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnProcess;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 205);
            this.Controls.Add(this.statusMain);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.lblJPEGFolder);
            this.Controls.Add(this.btnSelectOutputDirectory);
            this.Controls.Add(this.lblCR2Folder);
            this.Controls.Add(this.txtOutputDirectory);
            this.Controls.Add(this.btnSelectInputDirectory);
            this.Controls.Add(this.txtInputDirectory);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.picMain);
            this.Controls.Add(this.menuMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuMain;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CR2 To JPG";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).EndInit();
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.statusMain.ResumeLayout(false);
            this.statusMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox picMain;
        private Button btnSelectInputDirectory;
        private Label lblCR2Folder;
        private TextBox txtOutputDirectory;
        private Button btnSelectOutputDirectory;
        private Label lblJPEGFolder;
        private Button btnProcess;
        private ProgressBar pbProgress;
        private TextBox txtInputDirectory;
        private MenuStrip menuMain;
        private ToolStripMenuItem itmProfile;
        private ToolStripMenuItem itmHelp;
        private ToolStripMenuItem itmProfileSave;
        private ToolStripMenuItem itmProfileLoad;
        private ToolStripMenuItem itmOptions;
        private ToolStripMenuItem itmAboutViewInfo;
        private ToolStripMenuItem itmAboutWebsite;
        private ToolStripMenuItem itmCheckUpdates;
        private ToolStripMenuItem itmPicture;
        private ToolStripMenuItem itmWatermarking;
        private ToolStripMenuItem itmQuickGuide;
        private StatusStrip statusMain;
        private ToolStripStatusLabel lblStatus;
        private ToolStripStatusLabel lblStatusValue;
        private Label lblVersion;
        private NotifyIcon nfyMain;
    }
}

