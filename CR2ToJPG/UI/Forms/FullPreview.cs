using System;
using System.Drawing;
using System.Windows.Forms;

namespace CR2ToJPG.UI.Forms
{
    public partial class FullPreview : Form
    {
        public Bitmap Preview { get; set; } = null;

        public FullPreview()
        {
            InitializeComponent();
        }

        private void FullPreview_Load(object sender, EventArgs e)
        {
            picPreview.BackgroundImage = Preview;
        }
    }
}