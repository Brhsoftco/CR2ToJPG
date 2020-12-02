using CR2ToJPG.Properties;
using renderer;
using structure;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CR2ToJPG.UI.Forms
{
    public partial class FrmWatermark : Form
    {
        public WatermarkContext GlobalWmContext = FrmMain.WmContext;

        public ImageRenderer ImageRenderer = new ImageRenderer();

        public bool ImageSelected;

        public bool RadDoNothing;

        public FrmWatermark()
        {
            InitializeComponent();
        }

        private async void RenderPreview()
        {
            //show rendering label
            ShowRendering();

            //render the image
            var preview = await Task.Run(RenderPreviewImage);

            //apply preview image
            SetPreviewImage(preview);

            //hide rendering label
            HideRendering();
        }

        private Bitmap RenderPreviewImage()
        {
            //the base preview is what the watermark will be added to
            var basePreview = Resources.flower_preview;
            ImageRenderer.WmContext = GlobalWmContext;

            //rendering procedure will change depending on the watermarking type
            switch (GlobalWmContext.BetaWatermarkType)
            {
                case WatermarkType.Text when txtImageText.Text != string.Empty:
                    {
                        //render image
                        var result = ImageRenderer.RenderTextWatermark(txtImageText.Text, basePreview);

                        //return the resulting watermarked preview
                        return result;
                    }

                case WatermarkType.Image:
                    {
                        if (ImageSelected)
                        {
                            //the watermark is loaded into memory
                            var watermark = (Bitmap)Image.FromFile(txtImageURI.Text);

                            //render image
                            var result = ImageRenderer.RenderImageWatermark(watermark, basePreview);

                            //return the resulting watermarked preview
                            return result;
                        }

                        break;
                    }
            }

            //default
            return basePreview;
        }

        private void SetPreviewImage(Image image)
        {
            if (InvokeRequired)
                BeginInvoke((MethodInvoker)delegate
               {
                   SetPreviewImage(image);
               });
            else
                picPreview.BackgroundImage = image;
        }

        private void PositionRenderingLabel()
        {
            //hide it
            lblRendering.Visible = false;

            //required parameters
            var pic = picPreview.Location;
            var picW = picPreview.Width;
            var picH = picPreview.Height;
            var lblW = lblRendering.Width;
            var lblH = lblRendering.Height;

            //calculate centered coordinates
            var x = picW / 2 - lblW / 2 + pic.X;
            var y = picH / 2 - lblH / 2 + pic.Y;

            //apply centered coordinates
            var lblNew = new Point(x, y);
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
                BeginInvoke((MethodInvoker)ShowRendering);
            else
            {
                picPreview.Visible = false;
                lblRendering.Visible = true;
            }
        }

        private void HideRendering()
        {
            if (InvokeRequired)
                BeginInvoke((MethodInvoker)HideRendering);
            else
            {
                picPreview.Visible = true;
                lblRendering.Visible = false;
            }
        }

        private void FrmWatermark_Load(object sender, EventArgs e)
        {
            //setup the default GUI values
            RadDoNothing = true;
            tabText.Enabled = false;
            tabImage.Enabled = false;
            btnFontSelector.ForeColor = GlobalWmContext.BetaWatermarkFont.GetColor();
            btnFontSelector.Font = GlobalWmContext.BetaWatermarkFont.GetFont(true);

            //realign 'Rendering...' label
            PositionRenderingLabel();

            //reset values to config
            numWatermarkScale.Value = (decimal)GlobalWmContext.BetaWatermarkScale;
            numWatermarkOffsetX.Value = GlobalWmContext.BetaWatermarkOffset.X;
            numWatermarkOffsetY.Value = GlobalWmContext.BetaWatermarkOffset.Y;

            //setup rendering information using the watermark type
            switch (GlobalWmContext.BetaWatermarkType)
            {
                case WatermarkType.None:
                    radWatermarkNone.Checked = true;
                    break;

                case WatermarkType.Text:
                    SetTypeText();

                    txtImageText.Text = GlobalWmContext.BetaWatermarkInfo.WatermarkText;
                    btnFontSelector.Text = GlobalWmContext.BetaWatermarkInfo.WatermarkText;
                    radWatermarkText.Checked = true;
                    break;

                case WatermarkType.Image:
                    {
                        SetTypeImage();
                        radWatermarkImage.Checked = true;

                        if (File.Exists(GlobalWmContext.BetaWatermarkInfo.WatermarkPath))
                        {
                            var img = ImageInfo.FromFile(GlobalWmContext.BetaWatermarkInfo.WatermarkPath);
                            txtImageURI.Text = GlobalWmContext.BetaWatermarkInfo.WatermarkPath;
                            ImageSelected = true;
                            lblWidthValue.Text = $@"{img.Width}px";
                            lblHeightValue.Text = $@"{img.Height}px";
                            lblFileSizeValue.Text = img.ByteString();

                            LoadWatermarkImagePreview(GlobalWmContext.BetaWatermarkInfo.WatermarkPath);
                            RevertWatermarkImagePreview();
                            RenderPreview();
                        }
                        else
                            RevertWatermarkImagePreview();

                        break;
                    }
            }

            RadDoNothing = false;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            GlobalWmContext.BetaWatermarkInfo = new WatermarkInformation
            {
                WatermarkText = txtImageText.Text,
                WatermarkPath = txtImageURI.Text
            };

            FrmMain.WmContext = GlobalWmContext;

            Close();
        }

        private void RadWatermarkNone_CheckedChanged(object sender, EventArgs e)
        {
            if (!RadDoNothing)
                SetTypeNone();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoadWatermarkImagePreview(string fileName)
        {
            var prev = (Bitmap)Image.FromFile(fileName);

            picWatermark.BorderStyle = BorderStyle.None;
            picWatermark.BackgroundImage = prev;
        }

        private void BtnBrowseImage_Click(object sender, EventArgs e)
        {
            if (ofdWatermarkImage.ShowDialog() == DialogResult.OK)
            {
                txtImageURI.Text = ofdWatermarkImage.FileName;
                LoadWatermarkImagePreview(ofdWatermarkImage.FileName);

                var img = ImageInfo.FromFile(ofdWatermarkImage.FileName);

                lblWidthValue.Text = $@"{img.Width}px";
                lblHeightValue.Text = $@"{img.Height}px";
                lblFileSizeValue.Text = img.ByteString();

                //globalWmContext.BetaWatermarkImageBase64 = watermarkImageToBase64((Bitmap)Bitmap.FromFile(ofdWatermarkImage.FileName));
                ImageSelected = true;
                RenderPreview();
            }
        }

        private void RadWatermarkImage_CheckedChanged(object sender, EventArgs e)
        {
            if (!RadDoNothing)
            {
                SetTypeImage();
                RenderPreview();
            }
        }

        private void RadWatermarkText_CheckedChanged(object sender, EventArgs e)
        {
            if (!RadDoNothing)
            {
                SetTypeText();
                RenderPreview();
            }
        }

        private void RadTopLeft_CheckedChanged(object sender, EventArgs e)
        {
            if (!RadDoNothing)
            {
                GlobalWmContext.BetaWatermarkLocation = WatermarkLocation.TopLeft;
                RenderPreview();
            }
        }

        private void RadTopCenter_CheckedChanged(object sender, EventArgs e)
        {
            if (!RadDoNothing)
            {
                GlobalWmContext.BetaWatermarkLocation = WatermarkLocation.TopCenter;
                RenderPreview();
            }
        }

        private void RadTopRight_CheckedChanged(object sender, EventArgs e)
        {
            if (!RadDoNothing)
            {
                GlobalWmContext.BetaWatermarkLocation = WatermarkLocation.TopRight;
                RenderPreview();
            }
        }

        private void RadLeft_CheckedChanged(object sender, EventArgs e)
        {
            if (!RadDoNothing)
            {
                GlobalWmContext.BetaWatermarkLocation = WatermarkLocation.Left;
                RenderPreview();
            }
        }

        private void RadCenter_CheckedChanged(object sender, EventArgs e)
        {
            if (!RadDoNothing)
            {
                GlobalWmContext.BetaWatermarkLocation = WatermarkLocation.Center;
                RenderPreview();
            }
        }

        private void RadRight_CheckedChanged(object sender, EventArgs e)
        {
            if (!RadDoNothing)
            {
                GlobalWmContext.BetaWatermarkLocation = WatermarkLocation.Right;
                RenderPreview();
            }
        }

        private void RadBottomLeft_CheckedChanged(object sender, EventArgs e)
        {
            if (!RadDoNothing)
            {
                GlobalWmContext.BetaWatermarkLocation = WatermarkLocation.BottomLeft;
                RenderPreview();
            }
        }

        private void RadBottomCenter_CheckedChanged(object sender, EventArgs e)
        {
            if (!RadDoNothing)
            {
                GlobalWmContext.BetaWatermarkLocation = WatermarkLocation.BottomCenter;
                RenderPreview();
            }
        }

        private void RadBottomRight_CheckedChanged(object sender, EventArgs e)
        {
            if (!RadDoNothing)
            {
                GlobalWmContext.BetaWatermarkLocation = WatermarkLocation.BottomRight;
                RenderPreview();
            }
        }

        private void BwRenderer_DoWork(object sender, DoWorkEventArgs e)
        {
            ShowRendering();
            RenderPreview();
            HideRendering();
        }

        private void NumImageOffsetX_ValueChanged(object sender, EventArgs e)
        {
            GlobalWmContext.BetaWatermarkOffset.X = (int)numWatermarkOffsetX.Value;
            RenderPreview();
        }

        private void NumImageOffsetY_ValueChanged(object sender, EventArgs e)
        {
            GlobalWmContext.BetaWatermarkOffset.Y = (int)numWatermarkOffsetY.Value;
            RenderPreview();
        }

        private void NumWatermarkScale_ValueChanged(object sender, EventArgs e)
        {
            GlobalWmContext.BetaWatermarkScale = (double)numWatermarkScale.Value;
            RenderPreview();
        }

        private void TxtImageText_TextChanged(object sender, EventArgs e)
        {
            btnFontSelector.Text = txtImageText.Text;
            tmrTextRender.Stop();
            tmrTextRender.Start();
        }

        private void TmrTextRender_Tick(object sender, EventArgs e)
        {
            tmrTextRender.Stop();
            RenderPreview();
        }

        private void BtnFontSelector_Click(object sender, EventArgs e)
        {
            if (dlgWatermarkFont.ShowDialog() == DialogResult.OK)
            {
                var font = new WatermarkFont
                {
                    ArgbFontColor = WatermarkFont.ArgbColorToString(dlgWatermarkFont.Color),
                    FontFamily = dlgWatermarkFont.Font.FontFamily.Name,
                    PointSize = dlgWatermarkFont.Font.Size,
                    FontStyle = dlgWatermarkFont.Font.Style
                };

                GlobalWmContext.BetaWatermarkFont = font;
                btnFontSelector.Font = GlobalWmContext.BetaWatermarkFont.GetFont(true);
                btnFontSelector.ForeColor = GlobalWmContext.BetaWatermarkFont.GetColor();
                RenderPreview();
            }
        }

        private void NumWatermarkTransparency_ValueChanged(object sender, EventArgs e)
        {
            GlobalWmContext.BetaWatermarkTransparency = (double)numWatermarkTransparency.Value;
            RenderPreview();
        }

        private void PicPreview_DoubleClick(object sender, EventArgs e)
        {
            using (var frm = new FullPreview())
            {
                frm.Preview = (Bitmap)picPreview.BackgroundImage;
                frm.ShowDialog();
            }
        }
    }
}