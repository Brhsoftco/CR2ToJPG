using System.ComponentModel;
using System.Windows.Forms;

namespace CR2ToJPG
{
    partial class FrmWatermark
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
            this.gbPreview = new System.Windows.Forms.GroupBox();
            this.lblRendering = new System.Windows.Forms.Label();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.gbWatermarkType = new System.Windows.Forms.GroupBox();
            this.pnlWatermarkType = new System.Windows.Forms.Panel();
            this.radWatermarkText = new System.Windows.Forms.RadioButton();
            this.radWatermarkNone = new System.Windows.Forms.RadioButton();
            this.radWatermarkImage = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.gbWatermarkInfo = new System.Windows.Forms.GroupBox();
            this.tabWatermarkInfo = new System.Windows.Forms.TabControl();
            this.tabText = new System.Windows.Forms.TabPage();
            this.btnFontSelector = new System.Windows.Forms.Button();
            this.lblFontSelector = new System.Windows.Forms.Label();
            this.pnlImageText = new System.Windows.Forms.Panel();
            this.lblWatermarkText = new System.Windows.Forms.Label();
            this.txtImageText = new System.Windows.Forms.TextBox();
            this.tabImage = new System.Windows.Forms.TabPage();
            this.pnlImageURL = new System.Windows.Forms.Panel();
            this.lblFileSizeValue = new System.Windows.Forms.Label();
            this.lblFileSize = new System.Windows.Forms.Label();
            this.lblHeightValue = new System.Windows.Forms.Label();
            this.lblWidthValue = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            this.lblWidth = new System.Windows.Forms.Label();
            this.lblInformation = new System.Windows.Forms.Label();
            this.picWatermark = new System.Windows.Forms.PictureBox();
            this.btnBrowseImage = new System.Windows.Forms.Button();
            this.txtImageURI = new System.Windows.Forms.TextBox();
            this.tabGeneric = new System.Windows.Forms.TabPage();
            this.numWatermarkTransparency = new System.Windows.Forms.NumericUpDown();
            this.lblWatermarkTransparency = new System.Windows.Forms.Label();
            this.lblWatermarkOffsetY = new System.Windows.Forms.Label();
            this.lblWatermarkOffsetX = new System.Windows.Forms.Label();
            this.numWatermarkOffsetY = new System.Windows.Forms.NumericUpDown();
            this.numWatermarkOffsetX = new System.Windows.Forms.NumericUpDown();
            this.lblWatermarkOffset = new System.Windows.Forms.Label();
            this.lblWatermarkScale = new System.Windows.Forms.Label();
            this.numWatermarkScale = new System.Windows.Forms.NumericUpDown();
            this.gbWatermarkLocation = new System.Windows.Forms.GroupBox();
            this.pnlWatermarkLocation = new System.Windows.Forms.Panel();
            this.radCenter = new System.Windows.Forms.RadioButton();
            this.radRight = new System.Windows.Forms.RadioButton();
            this.radLeft = new System.Windows.Forms.RadioButton();
            this.radBottomCenter = new System.Windows.Forms.RadioButton();
            this.radBottomRight = new System.Windows.Forms.RadioButton();
            this.radTopCenter = new System.Windows.Forms.RadioButton();
            this.radTopLeft = new System.Windows.Forms.RadioButton();
            this.radTopRight = new System.Windows.Forms.RadioButton();
            this.radBottomLeft = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ofdWatermarkImage = new System.Windows.Forms.OpenFileDialog();
            this.dlgWatermarkFont = new System.Windows.Forms.FontDialog();
            this.tmrTextRender = new System.Windows.Forms.Timer(this.components);
            this.bwRenderer = new CR2ToJPG.AbortableBackgroundWorker();
            this.gbPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.gbWatermarkType.SuspendLayout();
            this.pnlWatermarkType.SuspendLayout();
            this.gbWatermarkInfo.SuspendLayout();
            this.tabWatermarkInfo.SuspendLayout();
            this.tabText.SuspendLayout();
            this.pnlImageText.SuspendLayout();
            this.tabImage.SuspendLayout();
            this.pnlImageURL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWatermark)).BeginInit();
            this.tabGeneric.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWatermarkTransparency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWatermarkOffsetY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWatermarkOffsetX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWatermarkScale)).BeginInit();
            this.gbWatermarkLocation.SuspendLayout();
            this.pnlWatermarkLocation.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbPreview
            // 
            this.gbPreview.Controls.Add(this.lblRendering);
            this.gbPreview.Controls.Add(this.picPreview);
            this.gbPreview.Location = new System.Drawing.Point(13, 13);
            this.gbPreview.Name = "gbPreview";
            this.gbPreview.Size = new System.Drawing.Size(335, 217);
            this.gbPreview.TabIndex = 0;
            this.gbPreview.TabStop = false;
            this.gbPreview.Text = "Preview";
            // 
            // lblRendering
            // 
            this.lblRendering.AutoSize = true;
            this.lblRendering.Location = new System.Drawing.Point(239, 47);
            this.lblRendering.Name = "lblRendering";
            this.lblRendering.Size = new System.Drawing.Size(65, 13);
            this.lblRendering.TabIndex = 1;
            this.lblRendering.Text = "Rendering...";
            this.lblRendering.Visible = false;
            // 
            // picPreview
            // 
            this.picPreview.BackColor = System.Drawing.SystemColors.Control;
            this.picPreview.BackgroundImage = global::CR2ToJPG.Properties.Resources.flower_preview;
            this.picPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picPreview.Location = new System.Drawing.Point(9, 19);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(320, 192);
            this.picPreview.TabIndex = 0;
            this.picPreview.TabStop = false;
            this.picPreview.Click += new System.EventHandler(this.picPreview_Click);
            this.picPreview.DoubleClick += new System.EventHandler(this.picPreview_DoubleClick);
            // 
            // gbWatermarkType
            // 
            this.gbWatermarkType.Controls.Add(this.pnlWatermarkType);
            this.gbWatermarkType.Location = new System.Drawing.Point(13, 237);
            this.gbWatermarkType.Name = "gbWatermarkType";
            this.gbWatermarkType.Size = new System.Drawing.Size(335, 66);
            this.gbWatermarkType.TabIndex = 1;
            this.gbWatermarkType.TabStop = false;
            this.gbWatermarkType.Text = "Watermark Type";
            // 
            // pnlWatermarkType
            // 
            this.pnlWatermarkType.Controls.Add(this.radWatermarkText);
            this.pnlWatermarkType.Controls.Add(this.radWatermarkNone);
            this.pnlWatermarkType.Controls.Add(this.radWatermarkImage);
            this.pnlWatermarkType.Location = new System.Drawing.Point(6, 27);
            this.pnlWatermarkType.Name = "pnlWatermarkType";
            this.pnlWatermarkType.Size = new System.Drawing.Size(324, 23);
            this.pnlWatermarkType.TabIndex = 3;
            // 
            // radWatermarkText
            // 
            this.radWatermarkText.AutoSize = true;
            this.radWatermarkText.Location = new System.Drawing.Point(3, 3);
            this.radWatermarkText.Name = "radWatermarkText";
            this.radWatermarkText.Size = new System.Drawing.Size(101, 17);
            this.radWatermarkText.TabIndex = 0;
            this.radWatermarkText.Text = "Text Watermark";
            this.radWatermarkText.UseVisualStyleBackColor = true;
            this.radWatermarkText.CheckedChanged += new System.EventHandler(this.radWatermarkText_CheckedChanged);
            // 
            // radWatermarkNone
            // 
            this.radWatermarkNone.AutoSize = true;
            this.radWatermarkNone.Checked = true;
            this.radWatermarkNone.Location = new System.Drawing.Point(225, 3);
            this.radWatermarkNone.Name = "radWatermarkNone";
            this.radWatermarkNone.Size = new System.Drawing.Size(94, 17);
            this.radWatermarkNone.TabIndex = 2;
            this.radWatermarkNone.TabStop = true;
            this.radWatermarkNone.Text = "No Watermark";
            this.radWatermarkNone.UseVisualStyleBackColor = true;
            this.radWatermarkNone.CheckedChanged += new System.EventHandler(this.radWatermarkNone_CheckedChanged);
            // 
            // radWatermarkImage
            // 
            this.radWatermarkImage.AutoSize = true;
            this.radWatermarkImage.Location = new System.Drawing.Point(110, 3);
            this.radWatermarkImage.Name = "radWatermarkImage";
            this.radWatermarkImage.Size = new System.Drawing.Size(109, 17);
            this.radWatermarkImage.TabIndex = 1;
            this.radWatermarkImage.Text = "Image Watermark";
            this.radWatermarkImage.UseVisualStyleBackColor = true;
            this.radWatermarkImage.CheckedChanged += new System.EventHandler(this.radWatermarkImage_CheckedChanged);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(354, 309);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(335, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "Apply Settings";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // gbWatermarkInfo
            // 
            this.gbWatermarkInfo.Controls.Add(this.tabWatermarkInfo);
            this.gbWatermarkInfo.Location = new System.Drawing.Point(354, 114);
            this.gbWatermarkInfo.Name = "gbWatermarkInfo";
            this.gbWatermarkInfo.Size = new System.Drawing.Size(335, 189);
            this.gbWatermarkInfo.TabIndex = 4;
            this.gbWatermarkInfo.TabStop = false;
            this.gbWatermarkInfo.Text = "Watermark Information";
            this.gbWatermarkInfo.Enter += new System.EventHandler(this.gbWatermarkInfo_Enter);
            // 
            // tabWatermarkInfo
            // 
            this.tabWatermarkInfo.Controls.Add(this.tabText);
            this.tabWatermarkInfo.Controls.Add(this.tabImage);
            this.tabWatermarkInfo.Controls.Add(this.tabGeneric);
            this.tabWatermarkInfo.Location = new System.Drawing.Point(6, 19);
            this.tabWatermarkInfo.Name = "tabWatermarkInfo";
            this.tabWatermarkInfo.SelectedIndex = 0;
            this.tabWatermarkInfo.Size = new System.Drawing.Size(323, 164);
            this.tabWatermarkInfo.TabIndex = 0;
            // 
            // tabText
            // 
            this.tabText.Controls.Add(this.btnFontSelector);
            this.tabText.Controls.Add(this.lblFontSelector);
            this.tabText.Controls.Add(this.pnlImageText);
            this.tabText.Location = new System.Drawing.Point(4, 22);
            this.tabText.Name = "tabText";
            this.tabText.Padding = new System.Windows.Forms.Padding(3);
            this.tabText.Size = new System.Drawing.Size(315, 138);
            this.tabText.TabIndex = 0;
            this.tabText.Text = "Text";
            this.tabText.UseVisualStyleBackColor = true;
            // 
            // btnFontSelector
            // 
            this.btnFontSelector.Location = new System.Drawing.Point(6, 68);
            this.btnFontSelector.Name = "btnFontSelector";
            this.btnFontSelector.Size = new System.Drawing.Size(303, 36);
            this.btnFontSelector.TabIndex = 7;
            this.btnFontSelector.Text = "DefaultWatermark";
            this.btnFontSelector.UseVisualStyleBackColor = true;
            this.btnFontSelector.Click += new System.EventHandler(this.btnFontSelector_Click);
            // 
            // lblFontSelector
            // 
            this.lblFontSelector.AutoSize = true;
            this.lblFontSelector.Location = new System.Drawing.Point(9, 52);
            this.lblFontSelector.Name = "lblFontSelector";
            this.lblFontSelector.Size = new System.Drawing.Size(70, 13);
            this.lblFontSelector.TabIndex = 6;
            this.lblFontSelector.Text = "Font Selector";
            // 
            // pnlImageText
            // 
            this.pnlImageText.Controls.Add(this.lblWatermarkText);
            this.pnlImageText.Controls.Add(this.txtImageText);
            this.pnlImageText.Location = new System.Drawing.Point(6, 6);
            this.pnlImageText.Name = "pnlImageText";
            this.pnlImageText.Size = new System.Drawing.Size(303, 43);
            this.pnlImageText.TabIndex = 5;
            // 
            // lblWatermarkText
            // 
            this.lblWatermarkText.AutoSize = true;
            this.lblWatermarkText.Location = new System.Drawing.Point(3, 3);
            this.lblWatermarkText.Name = "lblWatermarkText";
            this.lblWatermarkText.Size = new System.Drawing.Size(111, 13);
            this.lblWatermarkText.TabIndex = 1;
            this.lblWatermarkText.Text = "Enter Watermark Text";
            // 
            // txtImageText
            // 
            this.txtImageText.Location = new System.Drawing.Point(3, 19);
            this.txtImageText.Name = "txtImageText";
            this.txtImageText.Size = new System.Drawing.Size(297, 20);
            this.txtImageText.TabIndex = 0;
            this.txtImageText.Text = "DefaultWatermark";
            this.txtImageText.TextChanged += new System.EventHandler(this.txtImageText_TextChanged);
            // 
            // tabImage
            // 
            this.tabImage.Controls.Add(this.pnlImageURL);
            this.tabImage.Location = new System.Drawing.Point(4, 22);
            this.tabImage.Name = "tabImage";
            this.tabImage.Padding = new System.Windows.Forms.Padding(3);
            this.tabImage.Size = new System.Drawing.Size(315, 138);
            this.tabImage.TabIndex = 1;
            this.tabImage.Text = "Image";
            this.tabImage.UseVisualStyleBackColor = true;
            // 
            // pnlImageURL
            // 
            this.pnlImageURL.Controls.Add(this.lblFileSizeValue);
            this.pnlImageURL.Controls.Add(this.lblFileSize);
            this.pnlImageURL.Controls.Add(this.lblHeightValue);
            this.pnlImageURL.Controls.Add(this.lblWidthValue);
            this.pnlImageURL.Controls.Add(this.lblHeight);
            this.pnlImageURL.Controls.Add(this.lblWidth);
            this.pnlImageURL.Controls.Add(this.lblInformation);
            this.pnlImageURL.Controls.Add(this.picWatermark);
            this.pnlImageURL.Controls.Add(this.btnBrowseImage);
            this.pnlImageURL.Controls.Add(this.txtImageURI);
            this.pnlImageURL.Location = new System.Drawing.Point(6, 6);
            this.pnlImageURL.Name = "pnlImageURL";
            this.pnlImageURL.Size = new System.Drawing.Size(303, 126);
            this.pnlImageURL.TabIndex = 4;
            // 
            // lblFileSizeValue
            // 
            this.lblFileSizeValue.AutoSize = true;
            this.lblFileSizeValue.Location = new System.Drawing.Point(170, 77);
            this.lblFileSizeValue.Name = "lblFileSizeValue";
            this.lblFileSizeValue.Size = new System.Drawing.Size(41, 13);
            this.lblFileSizeValue.TabIndex = 9;
            this.lblFileSizeValue.Text = "0 bytes";
            // 
            // lblFileSize
            // 
            this.lblFileSize.AutoSize = true;
            this.lblFileSize.Location = new System.Drawing.Point(129, 77);
            this.lblFileSize.Name = "lblFileSize";
            this.lblFileSize.Size = new System.Drawing.Size(27, 13);
            this.lblFileSize.TabIndex = 8;
            this.lblFileSize.Text = "Size";
            // 
            // lblHeightValue
            // 
            this.lblHeightValue.AutoSize = true;
            this.lblHeightValue.Location = new System.Drawing.Point(170, 61);
            this.lblHeightValue.Name = "lblHeightValue";
            this.lblHeightValue.Size = new System.Drawing.Size(24, 13);
            this.lblHeightValue.TabIndex = 7;
            this.lblHeightValue.Text = "0px";
            // 
            // lblWidthValue
            // 
            this.lblWidthValue.AutoSize = true;
            this.lblWidthValue.Location = new System.Drawing.Point(170, 45);
            this.lblWidthValue.Name = "lblWidthValue";
            this.lblWidthValue.Size = new System.Drawing.Size(24, 13);
            this.lblWidthValue.TabIndex = 6;
            this.lblWidthValue.Text = "0px";
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(129, 61);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(38, 13);
            this.lblHeight.TabIndex = 5;
            this.lblHeight.Text = "Height";
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(129, 45);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(35, 13);
            this.lblWidth.TabIndex = 4;
            this.lblWidth.Text = "Width";
            // 
            // lblInformation
            // 
            this.lblInformation.AutoSize = true;
            this.lblInformation.Location = new System.Drawing.Point(129, 29);
            this.lblInformation.Name = "lblInformation";
            this.lblInformation.Size = new System.Drawing.Size(59, 13);
            this.lblInformation.TabIndex = 3;
            this.lblInformation.Text = "Information";
            // 
            // picWatermark
            // 
            this.picWatermark.BackColor = System.Drawing.SystemColors.Control;
            this.picWatermark.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picWatermark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picWatermark.Location = new System.Drawing.Point(3, 29);
            this.picWatermark.Name = "picWatermark";
            this.picWatermark.Size = new System.Drawing.Size(120, 90);
            this.picWatermark.TabIndex = 2;
            this.picWatermark.TabStop = false;
            // 
            // btnBrowseImage
            // 
            this.btnBrowseImage.Location = new System.Drawing.Point(265, 2);
            this.btnBrowseImage.Name = "btnBrowseImage";
            this.btnBrowseImage.Size = new System.Drawing.Size(35, 22);
            this.btnBrowseImage.TabIndex = 1;
            this.btnBrowseImage.Text = "...";
            this.btnBrowseImage.UseVisualStyleBackColor = true;
            this.btnBrowseImage.Click += new System.EventHandler(this.btnBrowseImage_Click);
            // 
            // txtImageURI
            // 
            this.txtImageURI.Location = new System.Drawing.Point(3, 3);
            this.txtImageURI.Name = "txtImageURI";
            this.txtImageURI.ReadOnly = true;
            this.txtImageURI.Size = new System.Drawing.Size(256, 20);
            this.txtImageURI.TabIndex = 0;
            this.txtImageURI.Text = "No Image Selected";
            // 
            // tabGeneric
            // 
            this.tabGeneric.Controls.Add(this.numWatermarkTransparency);
            this.tabGeneric.Controls.Add(this.lblWatermarkTransparency);
            this.tabGeneric.Controls.Add(this.lblWatermarkOffsetY);
            this.tabGeneric.Controls.Add(this.lblWatermarkOffsetX);
            this.tabGeneric.Controls.Add(this.numWatermarkOffsetY);
            this.tabGeneric.Controls.Add(this.numWatermarkOffsetX);
            this.tabGeneric.Controls.Add(this.lblWatermarkOffset);
            this.tabGeneric.Controls.Add(this.lblWatermarkScale);
            this.tabGeneric.Controls.Add(this.numWatermarkScale);
            this.tabGeneric.Location = new System.Drawing.Point(4, 22);
            this.tabGeneric.Name = "tabGeneric";
            this.tabGeneric.Size = new System.Drawing.Size(315, 138);
            this.tabGeneric.TabIndex = 2;
            this.tabGeneric.Text = "Generic";
            this.tabGeneric.UseVisualStyleBackColor = true;
            // 
            // numWatermarkTransparency
            // 
            this.numWatermarkTransparency.DecimalPlaces = 2;
            this.numWatermarkTransparency.Location = new System.Drawing.Point(5, 103);
            this.numWatermarkTransparency.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWatermarkTransparency.Name = "numWatermarkTransparency";
            this.numWatermarkTransparency.Size = new System.Drawing.Size(304, 20);
            this.numWatermarkTransparency.TabIndex = 17;
            this.numWatermarkTransparency.Value = new decimal(new int[] {
            10000,
            0,
            0,
            131072});
            this.numWatermarkTransparency.ValueChanged += new System.EventHandler(this.numWatermarkTransparency_ValueChanged);
            // 
            // lblWatermarkTransparency
            // 
            this.lblWatermarkTransparency.AutoSize = true;
            this.lblWatermarkTransparency.Location = new System.Drawing.Point(2, 87);
            this.lblWatermarkTransparency.Name = "lblWatermarkTransparency";
            this.lblWatermarkTransparency.Size = new System.Drawing.Size(144, 13);
            this.lblWatermarkTransparency.TabIndex = 16;
            this.lblWatermarkTransparency.Text = "Watermark Transparency (%)";
            // 
            // lblWatermarkOffsetY
            // 
            this.lblWatermarkOffsetY.AutoSize = true;
            this.lblWatermarkOffsetY.Location = new System.Drawing.Point(159, 66);
            this.lblWatermarkOffsetY.Name = "lblWatermarkOffsetY";
            this.lblWatermarkOffsetY.Size = new System.Drawing.Size(14, 13);
            this.lblWatermarkOffsetY.TabIndex = 15;
            this.lblWatermarkOffsetY.Text = "Y";
            // 
            // lblWatermarkOffsetX
            // 
            this.lblWatermarkOffsetX.AutoSize = true;
            this.lblWatermarkOffsetX.Location = new System.Drawing.Point(5, 66);
            this.lblWatermarkOffsetX.Name = "lblWatermarkOffsetX";
            this.lblWatermarkOffsetX.Size = new System.Drawing.Size(14, 13);
            this.lblWatermarkOffsetX.TabIndex = 14;
            this.lblWatermarkOffsetX.Text = "X";
            // 
            // numWatermarkOffsetY
            // 
            this.numWatermarkOffsetY.Location = new System.Drawing.Point(173, 64);
            this.numWatermarkOffsetY.Maximum = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            this.numWatermarkOffsetY.Name = "numWatermarkOffsetY";
            this.numWatermarkOffsetY.Size = new System.Drawing.Size(136, 20);
            this.numWatermarkOffsetY.TabIndex = 13;
            this.numWatermarkOffsetY.ValueChanged += new System.EventHandler(this.numImageOffsetY_ValueChanged);
            // 
            // numWatermarkOffsetX
            // 
            this.numWatermarkOffsetX.Location = new System.Drawing.Point(19, 64);
            this.numWatermarkOffsetX.Maximum = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            this.numWatermarkOffsetX.Name = "numWatermarkOffsetX";
            this.numWatermarkOffsetX.Size = new System.Drawing.Size(136, 20);
            this.numWatermarkOffsetX.TabIndex = 12;
            this.numWatermarkOffsetX.ValueChanged += new System.EventHandler(this.numImageOffsetX_ValueChanged);
            // 
            // lblWatermarkOffset
            // 
            this.lblWatermarkOffset.AutoSize = true;
            this.lblWatermarkOffset.Location = new System.Drawing.Point(5, 47);
            this.lblWatermarkOffset.Name = "lblWatermarkOffset";
            this.lblWatermarkOffset.Size = new System.Drawing.Size(110, 13);
            this.lblWatermarkOffset.TabIndex = 11;
            this.lblWatermarkOffset.Text = "Watermark Offset (px)";
            // 
            // lblWatermarkScale
            // 
            this.lblWatermarkScale.AutoSize = true;
            this.lblWatermarkScale.Location = new System.Drawing.Point(5, 5);
            this.lblWatermarkScale.Name = "lblWatermarkScale";
            this.lblWatermarkScale.Size = new System.Drawing.Size(106, 13);
            this.lblWatermarkScale.TabIndex = 10;
            this.lblWatermarkScale.Text = "Watermark Scale (%)";
            // 
            // numWatermarkScale
            // 
            this.numWatermarkScale.Location = new System.Drawing.Point(5, 21);
            this.numWatermarkScale.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numWatermarkScale.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numWatermarkScale.Name = "numWatermarkScale";
            this.numWatermarkScale.Size = new System.Drawing.Size(304, 20);
            this.numWatermarkScale.TabIndex = 9;
            this.numWatermarkScale.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numWatermarkScale.ValueChanged += new System.EventHandler(this.numWatermarkScale_ValueChanged);
            // 
            // gbWatermarkLocation
            // 
            this.gbWatermarkLocation.Controls.Add(this.pnlWatermarkLocation);
            this.gbWatermarkLocation.Location = new System.Drawing.Point(354, 13);
            this.gbWatermarkLocation.Name = "gbWatermarkLocation";
            this.gbWatermarkLocation.Size = new System.Drawing.Size(335, 95);
            this.gbWatermarkLocation.TabIndex = 4;
            this.gbWatermarkLocation.TabStop = false;
            this.gbWatermarkLocation.Text = "Watermark Location";
            // 
            // pnlWatermarkLocation
            // 
            this.pnlWatermarkLocation.Controls.Add(this.radCenter);
            this.pnlWatermarkLocation.Controls.Add(this.radRight);
            this.pnlWatermarkLocation.Controls.Add(this.radLeft);
            this.pnlWatermarkLocation.Controls.Add(this.radBottomCenter);
            this.pnlWatermarkLocation.Controls.Add(this.radBottomRight);
            this.pnlWatermarkLocation.Controls.Add(this.radTopCenter);
            this.pnlWatermarkLocation.Controls.Add(this.radTopLeft);
            this.pnlWatermarkLocation.Controls.Add(this.radTopRight);
            this.pnlWatermarkLocation.Controls.Add(this.radBottomLeft);
            this.pnlWatermarkLocation.Location = new System.Drawing.Point(6, 19);
            this.pnlWatermarkLocation.Name = "pnlWatermarkLocation";
            this.pnlWatermarkLocation.Size = new System.Drawing.Size(324, 70);
            this.pnlWatermarkLocation.TabIndex = 3;
            // 
            // radCenter
            // 
            this.radCenter.AutoSize = true;
            this.radCenter.Location = new System.Drawing.Point(110, 26);
            this.radCenter.Name = "radCenter";
            this.radCenter.Size = new System.Drawing.Size(56, 17);
            this.radCenter.TabIndex = 8;
            this.radCenter.Text = "Center";
            this.radCenter.UseVisualStyleBackColor = true;
            this.radCenter.CheckedChanged += new System.EventHandler(this.radCenter_CheckedChanged);
            // 
            // radRight
            // 
            this.radRight.AutoSize = true;
            this.radRight.Location = new System.Drawing.Point(225, 26);
            this.radRight.Name = "radRight";
            this.radRight.Size = new System.Drawing.Size(50, 17);
            this.radRight.TabIndex = 7;
            this.radRight.Text = "Right";
            this.radRight.UseVisualStyleBackColor = true;
            this.radRight.CheckedChanged += new System.EventHandler(this.radRight_CheckedChanged);
            // 
            // radLeft
            // 
            this.radLeft.AutoSize = true;
            this.radLeft.Location = new System.Drawing.Point(4, 27);
            this.radLeft.Name = "radLeft";
            this.radLeft.Size = new System.Drawing.Size(43, 17);
            this.radLeft.TabIndex = 6;
            this.radLeft.Text = "Left";
            this.radLeft.UseVisualStyleBackColor = true;
            this.radLeft.CheckedChanged += new System.EventHandler(this.radLeft_CheckedChanged);
            // 
            // radBottomCenter
            // 
            this.radBottomCenter.AutoSize = true;
            this.radBottomCenter.Location = new System.Drawing.Point(109, 50);
            this.radBottomCenter.Name = "radBottomCenter";
            this.radBottomCenter.Size = new System.Drawing.Size(92, 17);
            this.radBottomCenter.TabIndex = 5;
            this.radBottomCenter.Text = "Bottom Center";
            this.radBottomCenter.UseVisualStyleBackColor = true;
            this.radBottomCenter.CheckedChanged += new System.EventHandler(this.radBottomCenter_CheckedChanged);
            // 
            // radBottomRight
            // 
            this.radBottomRight.AutoSize = true;
            this.radBottomRight.Checked = true;
            this.radBottomRight.Location = new System.Drawing.Point(224, 50);
            this.radBottomRight.Name = "radBottomRight";
            this.radBottomRight.Size = new System.Drawing.Size(86, 17);
            this.radBottomRight.TabIndex = 0;
            this.radBottomRight.TabStop = true;
            this.radBottomRight.Text = "Bottom Right";
            this.radBottomRight.UseVisualStyleBackColor = true;
            this.radBottomRight.CheckedChanged += new System.EventHandler(this.radBottomRight_CheckedChanged);
            // 
            // radTopCenter
            // 
            this.radTopCenter.AutoSize = true;
            this.radTopCenter.Location = new System.Drawing.Point(110, 3);
            this.radTopCenter.Name = "radTopCenter";
            this.radTopCenter.Size = new System.Drawing.Size(78, 17);
            this.radTopCenter.TabIndex = 4;
            this.radTopCenter.Text = "Top Center";
            this.radTopCenter.UseVisualStyleBackColor = true;
            this.radTopCenter.CheckedChanged += new System.EventHandler(this.radTopCenter_CheckedChanged);
            // 
            // radTopLeft
            // 
            this.radTopLeft.AutoSize = true;
            this.radTopLeft.Location = new System.Drawing.Point(4, 3);
            this.radTopLeft.Name = "radTopLeft";
            this.radTopLeft.Size = new System.Drawing.Size(65, 17);
            this.radTopLeft.TabIndex = 3;
            this.radTopLeft.Text = "Top Left";
            this.radTopLeft.UseVisualStyleBackColor = true;
            this.radTopLeft.CheckedChanged += new System.EventHandler(this.radTopLeft_CheckedChanged);
            // 
            // radTopRight
            // 
            this.radTopRight.AutoSize = true;
            this.radTopRight.Location = new System.Drawing.Point(225, 3);
            this.radTopRight.Name = "radTopRight";
            this.radTopRight.Size = new System.Drawing.Size(72, 17);
            this.radTopRight.TabIndex = 2;
            this.radTopRight.Text = "Top Right";
            this.radTopRight.UseVisualStyleBackColor = true;
            this.radTopRight.CheckedChanged += new System.EventHandler(this.radTopRight_CheckedChanged);
            // 
            // radBottomLeft
            // 
            this.radBottomLeft.AutoSize = true;
            this.radBottomLeft.Location = new System.Drawing.Point(3, 50);
            this.radBottomLeft.Name = "radBottomLeft";
            this.radBottomLeft.Size = new System.Drawing.Size(79, 17);
            this.radBottomLeft.TabIndex = 1;
            this.radBottomLeft.Text = "Bottom Left";
            this.radBottomLeft.UseVisualStyleBackColor = true;
            this.radBottomLeft.CheckedChanged += new System.EventHandler(this.radBottomLeft_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(13, 309);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(335, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.button1_Click);
            // 
            // ofdWatermarkImage
            // 
            this.ofdWatermarkImage.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.giff;*.tif;*.tiff;*.bmp";
            this.ofdWatermarkImage.Title = "Select Watermark Image";
            // 
            // dlgWatermarkFont
            // 
            this.dlgWatermarkFont.ShowColor = true;
            // 
            // tmrTextRender
            // 
            this.tmrTextRender.Interval = 500;
            this.tmrTextRender.Tick += new System.EventHandler(this.tmrTextRender_Tick);
            // 
            // bwRenderer
            // 
            this.bwRenderer.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwRenderer_DoWork);
            // 
            // FrmWatermark
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 350);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.gbWatermarkLocation);
            this.Controls.Add(this.gbWatermarkInfo);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gbWatermarkType);
            this.Controls.Add(this.gbPreview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmWatermark";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bulk Watermark";
            this.Load += new System.EventHandler(this.frmWatermark_Load);
            this.gbPreview.ResumeLayout(false);
            this.gbPreview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.gbWatermarkType.ResumeLayout(false);
            this.pnlWatermarkType.ResumeLayout(false);
            this.pnlWatermarkType.PerformLayout();
            this.gbWatermarkInfo.ResumeLayout(false);
            this.tabWatermarkInfo.ResumeLayout(false);
            this.tabText.ResumeLayout(false);
            this.tabText.PerformLayout();
            this.pnlImageText.ResumeLayout(false);
            this.pnlImageText.PerformLayout();
            this.tabImage.ResumeLayout(false);
            this.pnlImageURL.ResumeLayout(false);
            this.pnlImageURL.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWatermark)).EndInit();
            this.tabGeneric.ResumeLayout(false);
            this.tabGeneric.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWatermarkTransparency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWatermarkOffsetY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWatermarkOffsetX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWatermarkScale)).EndInit();
            this.gbWatermarkLocation.ResumeLayout(false);
            this.pnlWatermarkLocation.ResumeLayout(false);
            this.pnlWatermarkLocation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox gbPreview;
        private GroupBox gbWatermarkType;
        private RadioButton radWatermarkImage;
        private RadioButton radWatermarkText;
        private RadioButton radWatermarkNone;
        private Panel pnlWatermarkType;
        private Button btnOK;
        private PictureBox picPreview;
        private GroupBox gbWatermarkInfo;
        private GroupBox gbWatermarkLocation;
        private Panel pnlWatermarkLocation;
        private RadioButton radBottomRight;
        private RadioButton radTopRight;
        private RadioButton radBottomLeft;
        private RadioButton radTopLeft;
        private RadioButton radTopCenter;
        private RadioButton radBottomCenter;
        private Panel pnlImageURL;
        private Button btnBrowseImage;
        private TextBox txtImageURI;
        private Panel pnlImageText;
        private TextBox txtImageText;
        private TabControl tabWatermarkInfo;
        private TabPage tabText;
        private TabPage tabImage;
        private Button btnCancel;
        private PictureBox picWatermark;
        public OpenFileDialog ofdWatermarkImage;
        private Label lblWatermarkText;
        private Label lblRendering;
        private AbortableBackgroundWorker bwRenderer;
        private FontDialog dlgWatermarkFont;
        private Label lblFontSelector;
        private Timer tmrTextRender;
        private Button btnFontSelector;
        private TabPage tabGeneric;
        private NumericUpDown numWatermarkOffsetY;
        private NumericUpDown numWatermarkOffsetX;
        private Label lblWatermarkScale;
        private NumericUpDown numWatermarkScale;
        private Label lblInformation;
        private Label lblWidth;
        private Label lblHeight;
        private Label lblWidthValue;
        private Label lblHeightValue;
        private Label lblFileSize;
        private Label lblFileSizeValue;
        private Label lblWatermarkOffsetX;
        private Label lblWatermarkOffset;
        private Label lblWatermarkOffsetY;
        private RadioButton radLeft;
        private RadioButton radRight;
        private RadioButton radCenter;
        private Label lblWatermarkTransparency;
        private NumericUpDown numWatermarkTransparency;
    }
}