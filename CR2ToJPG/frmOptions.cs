using structure;
using structure.Enums;
using System;
using System.Windows.Forms;

namespace CR2ToJPG
{
    public partial class FrmOptions : Form
    {
        public bool Silence;

        public FrmOptions()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            AppOptions options = new AppOptions
            {
                Quality = (int)numQualityLevel.Value,
                Subfolders = chkSubfolders.Checked,
                Duplicates = chkDuplicates.Checked,
                ProcessJpeg = chkProcessJPEG.Checked
            };

            if (radMagickNet.Checked)
                options.ImageProcessor = ImageProcType.MagickNet;
            else if (radNative.Checked)
                options.ImageProcessor = ImageProcType.Native;

            FrmMain.Settings = options;
            Close();
        }

        private void frmOptions_Load(object sender, EventArgs e)
        {
            Silence = true;
            AppOptions options = FrmMain.Settings;
            chkSubfolders.Checked = options.Subfolders;
            numQualityLevel.Value = options.Quality;
            chkDuplicates.Checked = options.Duplicates;
            chkProcessJPEG.Checked = options.ProcessJpeg;

            if (options.ImageProcessor == ImageProcType.MagickNet)
                radMagickNet.Checked = true;
            else if (options.ImageProcessor == ImageProcType.Native)
                radNative.Checked = true;

            Silence = false;
        }
    }
}