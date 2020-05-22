using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CR2ToJPG
{
    public partial class FrmFullPreview : Form
    {
        public Bitmap Preview { get; set; } = null;

        public FrmFullPreview()
        {
            InitializeComponent();
        }

        private void frmFullPreview_Load(object sender, EventArgs e)
        {
            picPreview.BackgroundImage = Preview;
        }
    }
}
