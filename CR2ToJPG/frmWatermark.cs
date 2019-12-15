using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using structure;
using renderer;
using ImageMagick;

namespace CR2ToJPG
{
    public partial class frmWatermark : Form
    {
        public frmWatermark()
        {
            InitializeComponent();
        }

        public WatermarkContext globalWmContext = frmMain.wmContext;

        public bool imageSelected = false;

        public bool radDoNothing = false;

        public renderer.ImageRenderer ImageRenderer = new renderer.ImageRenderer();

        private void renderPreview()
        {

            Bitmap basePreview = CR2ToJPG.Properties.Resources.flower_preview;
            ImageRenderer.wmContext = globalWmContext;
            
            if (globalWmContext.BetaWatermarkType == WatermarkType.None)
            {
                setPreviewImage(basePreview);
            }
            else if (globalWmContext.BetaWatermarkType == WatermarkType.Text)
            {
                if (txtImageText.Text != "")
                {
                    Bitmap result = ImageRenderer.renderTextWatermark(txtImageText.Text, basePreview);
                    setPreviewImage(result);
                }
                else
                {
                    setPreviewImage(basePreview);
                }
            }
            else if (globalWmContext.BetaWatermarkType == WatermarkType.Image)
            {
                if (imageSelected)
                {
                    Bitmap watermark = (Bitmap)Bitmap.FromFile(txtImageURI.Text);
                    Bitmap result = ImageRenderer.renderImageWatermark(watermark, basePreview);
                    setPreviewImage(result);
                }
            }
        }

        private void setPreviewImage(Bitmap image)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate () {
                    picPreview.BackgroundImage = image;
                });
            }
            else
            {
                picPreview.BackgroundImage = image;
            }
        }

        private void positionRenderingLabel()
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

        private void revertWatermarkImagePreview()
        {
            picPreview.BackgroundImage = null;
            picPreview.BorderStyle = BorderStyle.FixedSingle;
        }

        private void setTypeImage()
        {
            tabImage.Enabled = true;
            tabText.Enabled = false;
            txtImageText.Text = "DefaultWatermark";
            btnFontSelector.Text = "DefaultWatermark";
            globalWmContext.BetaWatermarkType = WatermarkType.Image;
        }

        private void setTypeText()
        {
            tabImage.Enabled = false;
            tabText.Enabled = true;
            globalWmContext.BetaWatermarkType = WatermarkType.Text;
        }

        private void setTypeNone()
        {
            tabImage.Enabled = false;
            tabText.Enabled = false;
            txtImageText.Text = "DefaultWatermark";
            btnFontSelector.Text = "DefaultWatermark";
            ofdWatermarkImage.FileName = "";
            globalWmContext.BetaWatermarkType = WatermarkType.None;
        }

        private void showRendering()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate() {
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

        private void hideRendering()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate () {
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
            WatermarkContext wmContext = globalWmContext;

            radDoNothing = true;
            tabText.Enabled = false;
            tabImage.Enabled = false;
            btnFontSelector.ForeColor = wmContext.BetaWatermarkFont.getColor();
            btnFontSelector.Font = wmContext.BetaWatermarkFont.getFont(true);

            positionRenderingLabel();

            numWatermarkScale.Value = (decimal)globalWmContext.BetaWatermarkScale;
            numWatermarkOffsetX.Value = (decimal)globalWmContext.BetaWatermarkOffset.X;
            numWatermarkOffsetY.Value = (decimal)globalWmContext.BetaWatermarkOffset.Y;

            if (wmContext.BetaWatermarkType == WatermarkType.None)
            {
                radWatermarkNone.Checked = true;
            }
            else if (wmContext.BetaWatermarkType == WatermarkType.Text)
            {
                setTypeText();
                txtImageText.Text = wmContext.BetaWatermarkInfo.WatermarkText;
                btnFontSelector.Text = wmContext.BetaWatermarkInfo.WatermarkText;
                radWatermarkText.Checked = true;
            }
            else if (wmContext.BetaWatermarkType == WatermarkType.Image)
            {
                setTypeImage();
                radWatermarkImage.Checked = true;
                if (System.IO.File.Exists(wmContext.BetaWatermarkInfo.WatermarkPath))
                {
                    ImageInfo img = ImageInfo.fromFile(wmContext.BetaWatermarkInfo.WatermarkPath);
                    txtImageURI.Text = wmContext.BetaWatermarkInfo.WatermarkPath;
                    imageSelected = true;
                    lblWidthValue.Text = img.width + "px";
                    lblHeightValue.Text = img.height + "px";
                    lblFileSizeValue.Text = img.byteString();

                    loadWatermarkImagePreview(wmContext.BetaWatermarkInfo.WatermarkPath);
                    revertWatermarkImagePreview();
                    renderPreview();
                }
                else
                {
                    revertWatermarkImagePreview();
                }
            }
            radDoNothing = false;
        }

        private void loadWatermarkImagePreviewBase64(string b64)
        {
            
            picWatermark.BorderStyle = BorderStyle.None;
            picWatermark.BackgroundImage = ImageRenderer.renderBmpFromBase64(b64);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            globalWmContext.BetaWatermarkInfo = new WatermarkInformation() { WatermarkText = txtImageText.Text, WatermarkPath = txtImageURI.Text };
            frmMain.wmContext = globalWmContext;

            this.Close();
        }

        private void gbWatermarkInfo_Enter(object sender, EventArgs e)
        {

        }

        private void radWatermarkNone_CheckedChanged(object sender, EventArgs e)
        {
            if (!radDoNothing)
            {
                setTypeNone();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loadWatermarkImagePreview(string fileName)
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
                loadWatermarkImagePreview(ofdWatermarkImage.FileName);

                ImageInfo img = ImageInfo.fromFile(ofdWatermarkImage.FileName);

                lblWidthValue.Text = img.width + "px";
                lblHeightValue.Text = img.height + "px";
                lblFileSizeValue.Text = img.byteString();

                //globalWmContext.BetaWatermarkImageBase64 = watermarkImageToBase64((Bitmap)Bitmap.FromFile(ofdWatermarkImage.FileName));
                imageSelected = true;
                renderPreview();
            }
        }

        private void radWatermarkImage_CheckedChanged(object sender, EventArgs e)
        {
            if (!radDoNothing)
            {
                setTypeImage();
                renderPreview();
            }
        }

        private void radWatermarkText_CheckedChanged(object sender, EventArgs e)
        {
            if (!radDoNothing)
            {
                setTypeText();
                renderPreview();
            }
        }

        private void radBottomRight_CheckedChanged(object sender, EventArgs e)
        {
            if (!radDoNothing)
            {
                globalWmContext.BetaWatermarkLocation = WatermarkLocation.BottomRight;
                renderPreview();
            }
        }

        private void radTopCenter_CheckedChanged(object sender, EventArgs e)
        {
            if (!radDoNothing)
            {
                globalWmContext.BetaWatermarkLocation = WatermarkLocation.TopCenter;
                renderPreview();
            }
        }

        private void radTopRight_CheckedChanged(object sender, EventArgs e)
        {
            if (!radDoNothing)
            {
                globalWmContext.BetaWatermarkLocation = WatermarkLocation.TopRight;
                renderPreview();
            }
        }

        private void radBottomLeft_CheckedChanged(object sender, EventArgs e)
        {
            if (!radDoNothing)
            {
                globalWmContext.BetaWatermarkLocation = WatermarkLocation.BottomLeft;
                renderPreview();
            }
        }

        private void radBottomCenter_CheckedChanged(object sender, EventArgs e)
        {
            if (!radDoNothing)
            {
                globalWmContext.BetaWatermarkLocation = WatermarkLocation.BottomCenter;
                renderPreview();
            }
        }

        private void radTopLeft_CheckedChanged(object sender, EventArgs e)
        {
            if (!radDoNothing)
            {
                globalWmContext.BetaWatermarkLocation = WatermarkLocation.TopLeft;
                renderPreview();
            }
        }

        private void bwRenderer_DoWork(object sender, DoWorkEventArgs e)
        {
            showRendering();
            renderPreview();
            hideRendering();
        }

        private void numImageOffsetX_ValueChanged(object sender, EventArgs e)
        {
            PointD offset = new PointD((double)numWatermarkOffsetX.Value,(double)numWatermarkOffsetY.Value);
            globalWmContext.BetaWatermarkOffset = new WatermarkOffset() { X = (int)offset.X,Y= (int)offset.Y };
            renderPreview();
        }

        private void numImageOffsetY_ValueChanged(object sender, EventArgs e)
        {
            PointD offset = new PointD((double)numWatermarkOffsetX.Value, (double)numWatermarkOffsetY.Value);
            globalWmContext.BetaWatermarkOffset = new WatermarkOffset() { X = (int)offset.X, Y = (int)offset.Y };
            renderPreview();
        }

        private void numWatermarkScale_ValueChanged(object sender, EventArgs e)
        {
            globalWmContext.BetaWatermarkScale = (double)numWatermarkScale.Value;
            renderPreview();
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
            renderPreview();
        }

        private void btnFontSelector_Click(object sender, EventArgs e)
        {
            if (dlgWatermarkFont.ShowDialog() == DialogResult.OK)
            {

                WatermarkFont font = new WatermarkFont();
                font.argbFontColor = WatermarkFont.argbColorToString(dlgWatermarkFont.Color);
                font.fontFamily = dlgWatermarkFont.Font.FontFamily.Name;
                font.pointSize = dlgWatermarkFont.Font.Size;
                font.fontStyle = dlgWatermarkFont.Font.Style;

                globalWmContext.BetaWatermarkFont = font;
                btnFontSelector.Font = globalWmContext.BetaWatermarkFont.getFont(true);
                btnFontSelector.ForeColor = globalWmContext.BetaWatermarkFont.getColor();
                renderPreview();
            }
        }

        private void radCenter_CheckedChanged(object sender, EventArgs e)
        {
            if (!radDoNothing)
            {
                globalWmContext.BetaWatermarkLocation = WatermarkLocation.Center;
                renderPreview();
            }
        }

        private void radLeft_CheckedChanged(object sender, EventArgs e)
        {
            if (!radDoNothing)
            {
                globalWmContext.BetaWatermarkLocation = WatermarkLocation.Left;
                renderPreview();
            }
        }

        private void radRight_CheckedChanged(object sender, EventArgs e)
        {
            if (!radDoNothing)
            {
                globalWmContext.BetaWatermarkLocation = WatermarkLocation.Right;
                renderPreview();
            }
        }

        private void numWatermarkTransparency_ValueChanged(object sender, EventArgs e)
        {
            globalWmContext.BetaWatermarkTransparency = (double)numWatermarkTransparency.Value / 4;
            renderPreview();
        }
    }
}