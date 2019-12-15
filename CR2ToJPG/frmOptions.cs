using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using structure;

namespace CR2ToJPG
{
    public partial class frmOptions : Form
    {
        public bool silence = false;

        public frmOptions()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            AppOptions options = new AppOptions()
            {
                Quality = (int)numQualityLevel.Value,
                Subfolders = chkSubfolders.Checked,
                Duplicates = chkDuplicates.Checked
            };

            frmMain.settings = options;
            this.Close();
        }

        private void frmOptions_Load(object sender, EventArgs e)
        {
            silence = true;
            AppOptions options = frmMain.settings;
            chkSubfolders.Checked = options.Subfolders;
            numQualityLevel.Value = options.Quality;
            chkDuplicates.Checked = options.Duplicates;
            silence = false;
        }
    }
}
