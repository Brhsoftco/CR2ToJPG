using CR2ToJPG.Properties;
using renderer;
using structure;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CR2ToJPG
{
    public partial class FrmWatermark : Form
    {
        public FrmWatermark()
        {
            InitializeComponent();
        }

        public WatermarkContext GlobalWmContext = FrmMain.WmContext;

        public bool ImageSelected;

        public bool RadDoNothing;

        public ImageRenderer ImageRenderer = new ImageRenderer();

        private void RenderPreview()
        {

            Bitmap basePreview = Resources.flower_preview;
            ImageRenderer.WmContext = GlobalWmContext;

            ShowRendering(); ;

            if (GlobalWmContext.BetaWatermarkType == WatermarkType.None)
            {
                SetPreviewImage(basePreview);
            }
            else if (GlobalWmContext.BetaWatermarkType == WatermarkType.Text)
            {
                if (txtImageText.Text != string.Empty)
                {
                    Bitmap result = ImageRenderer.RenderTextWatermark(txtImageText.Text, basePreview);
                    SetPreviewImage(result);
                }
                else
                {
                    SetPreviewImage(basePreview);
                }
            }
            else if (GlobalWmContext.BetaWatermarkType == WatermarkType.Image)
            {
                if (ImageSelected)
                {
                    Bitmap watermark = (Bitmap)Bitmap.FromFile(txtImageURI.Text);
                    Bitmap result = ImageRenderer.RenderImageWatermark(watermark, basePreview);
                    SetPreviewImage(result);
                }
            }

            HideRendering();
        }

        private void SetPreviewImage(Bitmap image)
        {
            if (InvokeRequired)
            {
                BeginInvoke((MethodInvoker)delegate
                {
                    picPreview.BackgroundImage = image;
                });
            }
            else
            {
                picPreview.BackgroundImage = image;
            }
        }

        private void PositionRenderingLabel()
        {
            Point pic = picPreview.Location;
            Point lbl = lblRendering.Location;
            int picW = picPreview.Width;
            int picH = picPreview.Height;
            int lblW = lblRendering.Width;
            int lblH = lblRendering.Height;

            int x = ((picW / 2) - (lblW / 2)) + pic.X;
            int y = ((picH / 2) - (lblH / 2)) + pic.Y;

            Point lblNew = new Point(x, y);
            lblRendering.Location = lblNew;
        }

        private void RevertWatermarkImagePreview()
        {
            picPreview.BackgroundImage = null;
            picPreview.BorderStyle = BorderStyle.FixedSingle;
        }

        private void SetTypeImage()
        {
            tabImage.Enabled = true;
            tabText.Enabled = false;
            txtImageText.Text = @"DefaultWatermark";
            btnFontSelector.Text = @"DefaultWatermark";
            GlobalWmContext.BetaWatermarkType = WatermarkType.Image;
        }

        private void SetTypeText()
        {
            tabImage.Enabled = false;
            tabText.Enabled = true;
            GlobalWmContext.BetaWatermarkType = WatermarkType.Text;
        }

        private void SetTypeNone()
        {
            tabImage.Enabled = false;
            tabText.Enabled = false;
            txtImageText.Text = @"DefaultWatermark";
            btnFontSelector.Text = @"DefaultWatermark";
            ofdWatermarkImage.FileName = "";
            GlobalWmContext.BetaWatermarkType = WatermarkType.None;
        }

        private void ShowRendering()
        {
            if (InvokeRequired)
            {
                BeginInvoke((MethodInvoker)delegate
                {
                    picPreview.Visible = false;
                    lblRendering.Visible = true;
                });
            }
            else
            {
                picPreview.Visible = false;
                lblRendering.Visible = true;
            }
        }

        private void HideRendering()
        {
            if (InvokeRequired)
            {
                BeginInvoke((MethodInvoker)delegate
                {
                    picPreview.Visible = true;
                    lblRendering.Visible = false;
                });
            }
            else
            {
                picPreview.Visible = true;
                lblRendering.Visible = false;
            }
        }

        private void frmWatermark_Load(object sender, EventArgs e)
        {
            WatermarkContext wmContext = GlobalWmContext;

            RadDoNothing = true;
            tabText.Enabled = false;
            tabImage.Enabled = false;
            btnFontSelector.ForeColor = wmContext.BetaWatermarkFont.GetColor();
            btnFontSelector.Font = wmContext.BetaWatermarkFont.GetFont(true);

            PositionRenderingLabel();

            numWatermarkScale.Value = (decimal)GlobalWmContext.BetaWatermarkScale;
            numWatermarkOffsetX.Value = GlobalWmContext.BetaWatermarkOffset.X;
            numWatermarkOffsetY.Value = GlobalWmContext.BetaWatermarkOffset.Y;

            if (wmContext.BetaWatermarkType == WatermarkType.None)
            {
                radWatermarkNone.Checked = true;
            }
            else if (wmContext.BetaWatermarkType == WatermarkType.Text)
            {
                SetTypeText();
                txtImageText.Text = wmContext.BetaWatermarkInfo.WatermarkText;
                btnFontSelector.Text = wmContext.BetaWatermarkInfo.WatermarkText;
                radWatermarkText.Checked = true;
            }
            else if (wmContext.BetaWatermarkType == WatermarkType.Image)
            {
                SetTypeImage();
                radWatermarkImage.Checked = true;
                if (File.Exists(wmContext.BetaWatermarkInfo.WatermarkPath))
                {
                    ImageInfo img = ImageInfo.FromFile(wmContext.BetaWatermarkInfo.WatermarkPath);
                    txtImageURI.Text = wmContext.BetaWatermarkInfo.WatermarkPath;
                    ImageSelected = true;
                    lblWidthValue.Text = img.Width + "px";
                    lblHeightValue.Text = img.Height + "px";
                    lblFileSizeValue.Text = img.ByteString();

                    LoadWatermarkImagePreview(wmContext.BetaWatermarkInfo.WatermarkPath);
                    RevertWatermarkImagePreview();
                    RenderPreview();
                }
                else
                {
                    RevertWatermarkImagePreview();
                }
            }
            RadDoNothing = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            GlobalWmContext.BetaWatermarkInfo = new WatermarkInformation
            { WatermarkText = txtImageText.Text, WatermarkPath = txtImageURI.Text };
            FrmMain.WmContext = GlobalWmContext;

            Close();
        }

        private void gbWatermarkInfo_Enter(object sender, EventArgs e)
        {

        }

        private void radWatermarkNone_CheckedChanged(object sender, EventArgs e)
        {
            if (!RadDoNothing)
            {
                SetTypeNone();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoadWatermarkImagePreview(string fileName)
        {
            Bitmap prev = (Bitmap)Bitmap.FromFile(fileName);
            picWatermark.BorderStyle = BorderStyle.None;
            picWatermark.BackgroundImage = prev;
        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            if (ofdWatermarkImage.ShowDialog() == DialogResult.OK)
            {
                txtImageURI.Text = ofdWatermarkImage.FileName;
                LoadWatermarkImagePreview(ofdWatermarkImage.FileName);

                ImageInfo img = ImageInfo.FromFile(ofdWatermarkImage.FileName);

                lblWidthValue.Text = img.Width + "px";
                lblHeightValue.Text = img.Height + "px";
                lblFileSizeValue.Text = img.ByteString();

                //globalWmContext.BetaWatermarkImageBase64 = watermarkImageToBase64((Bitmap)Bitmap.FromFile(ofdWatermarkImage.FileName));
                ImageSelected = true;
                RenderPreview();
            }
        }

        private void radWatermarkImage_CheckedChanged(object sender, EventArgs e)
        {
            if (!RadDoNothing)
            {
                SetTypeImage();
                RenderPreview();
            }
        }

        private void radWatermarkText_CheckedChanged(object sender, EventArgs e)
        {
            if (!RadDoNothing)
            {
                SetTypeText();
                RenderPreview();
            }
        }

        private void radBottomRight_CheckedChanged(object sender, EventArgs e)
        {
            if (!RadDoNothing)
            {
                GlobalWmContext.BetaWatermarkLocation = WatermarkLocation.BottomRight;
                RenderPreview();
            }
        }

        private void radTopCenter_CheckedChanged(object sender, EventArgs e)
        {
            if (!RadDoNothing)
            {
                GlobalWmContext.BetaWatermarkLocation = WatermarkLocation.TopCenter;
                RenderPreview();
            }
        }

        private void radTopRight_CheckedChanged(object sender, EventArgs e)
        {
            if (!RadDoNothing)
            {
                GlobalWmContext.BetaWatermarkLocation = WatermarkLocation.TopRight;
                RenderPreview();
            }
        }

        private void radBottomLeft_CheckedChanged(object sender, EventArgs e)
        {
            if (!RadDoNothing)
            {
                GlobalWmContext.BetaWatermarkLocation = WatermarkLocation.BottomLeft;
                RenderPreview();
            }
        }

        private void radBottomCenter_CheckedChanged(object sender, EventArgs e)
        {
            if (!RadDoNothing)
            {
                GlobalWmContext.BetaWatermarkLocation = WatermarkLocation.BottomCenter;
                RenderPreview();
            }
        }

        private void radTopLeft_CheckedChanged(object sender, EventArgs e)
        {
            if (!RadDoNothing)
            {
                GlobalWmContext.BetaWatermarkLocation = WatermarkLocation.TopLeft;
                RenderPreview();
            }
        }

        private void bwRenderer_DoWork(object sender, DoWorkEventArgs e)
        {
            ShowRendering();
            RenderPreview();
            HideRendering();
        }

        private void numImageOffsetX_ValueChanged(object sender, EventArgs e)
        {
            GlobalWmContext.BetaWatermarkOffset.X = (int)numWatermarkOffsetX.Value;
            RenderPreview();
        }

        private void numImageOffsetY_ValueChanged(object sender, EventArgs e)
        {
            GlobalWmContext.BetaWatermarkOffset.Y = (int)numWatermarkOffsetY.Value;
            RenderPreview();
        }

        private void numWatermarkScale_ValueChanged(object sender, EventArgs e)
        {
            GlobalWmContext.BetaWatermarkScale = (double)numWatermarkScale.Value;
            RenderPreview();
        }

        private void txtImageText_TextChanged(object sender, EventArgs e)
        {
            btnFontSelector.Text = txtImageText.Text;
            tmrTextRender.Stop();
            tmrTextRender.Start();
        }

        private void tmrTextRender_Tick(object sender, EventArgs e)
        {
            tmrTextRender.Stop();
            RenderPreview();
        }

        private void btnFontSelector_Click(object sender, EventArgs e)
        {
            if (dlgWatermarkFont.ShowDialog() == DialogResult.OK)
            {

                WatermarkFont font = new WatermarkFont();
                font.ArgbFontColor = WatermarkFont.ArgbColorToString(dlgWatermarkFont.Color);
                font.FontFamily = dlgWatermarkFont.Font.FontFamily.Name;
                font.PointSize = dlgWatermarkFont.Font.Size;
                font.FontStyle = dlgWatermarkFont.Font.Style;

                GlobalWmContext.BetaWatermarkFont = font;
                btnFontSelector.Font = GlobalWmContext.BetaWatermarkFont.GetFont(true);
                btnFontSelector.ForeColor = GlobalWmContext.BetaWatermarkFont.GetColor();
                RenderPreview();
            }
        }

        private void radCenter_CheckedChanged(object sender, EventArgs e)
        {
            if (!RadDoNothing)
            {
                GlobalWmContext.BetaWatermarkLocation = WatermarkLocation.Center;
                RenderPreview();
            }
        }

        private void radLeft_CheckedChanged(object sender, EventArgs e)
        {
            if (!RadDoNothing)
            {
                GlobalWmContext.BetaWatermarkLocation = WatermarkLocation.Left;
                RenderPreview();
            }
        }

        private void radRight_CheckedChanged(object sender, EventArgs e)
        {
            if (!RadDoNothing)
            {
                GlobalWmContext.BetaWatermarkLocation = WatermarkLocation.Right;
                RenderPreview();
            }
        }

        private void numWatermarkTransparency_ValueChanged(object sender, EventArgs e)
        {
            GlobalWmContext.BetaWatermarkTransparency = (double)numWatermarkTransparency.Value;
            RenderPreview();
        }

        private void picPreview_DoubleClick(object sender, EventArgs e)
        {
            using (FrmFullPreview frm = new FrmFullPreview())
            {
                frm.Preview = (Bitmap)picPreview.BackgroundImage;
                frm.ShowDialog();
            }
        }

        private void picPreview_Click(object sender, EventArgs e)
        {

        }
    }
}