using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using structure;
using ImageMagick;

namespace renderer
{
    public class ImageRenderer
    {
        public WatermarkContext wmContext { get; set; }

        public Bitmap renderBmpFromBase64(string b64)
        {
            byte[] bytes = Convert.FromBase64String(b64);
            System.IO.MemoryStream mem = new System.IO.MemoryStream(bytes);
            Bitmap prev = new Bitmap(mem);
            return prev;
        }

        //CREDIT: https://stackoverflow.com/questions/7350679/convert-a-bitmap-into-a-byte-array
        public static byte[] ImageToByte(Image img)
        {
            using (var stream = new System.IO.MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }

        string watermarkImageToBase64(Bitmap bmpWatermark)
        {
            byte[] bytes = ImageToByte(bmpWatermark);
            System.IO.MemoryStream mem = new System.IO.MemoryStream(bytes);
            string val = Convert.ToBase64String(bytes);
            return val;
        }

        public static string GetBuildInfo(bool includeDateTime)
        {
            Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            DateTime buildDate = new DateTime(2000, 1, 1)
                                    .AddDays(version.Build).AddSeconds(version.Revision * 2);
            string displayableVersion;

            if (includeDateTime)
            {
                displayableVersion = $"{version} ({buildDate})";
            }
            else
            {
                displayableVersion = $"{version}";
            }

            return displayableVersion;
        }

        public Bitmap GetTextWatermark(string text, Bitmap originalImage)
        {
            Font m_font = wmContext.BetaWatermarkFont.getFont(false);
            Brush brush = new SolidBrush(wmContext.BetaWatermarkFont.getColor());
            SizeF size;

            // Figure out the size of the box to hold the watermarked text
            using (Graphics g = Graphics.FromImage(originalImage))
            {
                size = g.MeasureString(text, m_font);
            }

            // Create a new bitmap for the text, and, actually, draw the text
            Bitmap bitmap = new Bitmap((int)size.Width, (int)size.Height);
            bitmap.SetResolution(originalImage.HorizontalResolution, originalImage.VerticalResolution);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.DrawString(text, m_font, brush, 0, 0);
            }

            return bitmap;
        }

        public Bitmap renderTextWatermark(string text, Bitmap bmpImage)
        {
            Bitmap bmpWatermark = GetTextWatermark(text, bmpImage);
            Bitmap bmpFinal = renderImageWatermark(bmpWatermark,bmpImage);
            return bmpFinal;
        }

        public Bitmap renderImageWatermark(Bitmap bmpWatermark, Bitmap bmpImage)
        {
            // Read image that needs a watermark
            using (MagickImage image = new MagickImage(bmpImage))
            {
                // Read the watermark that will be put on top of the image
                using (MagickImage watermark = new MagickImage(bmpWatermark))
                {
                    watermark.Scale(new Percentage((double)wmContext.BetaWatermarkScale));

                    // Optionally make the watermark more transparent
                    watermark.Evaluate(Channels.Alpha, EvaluateOperator.Divide, wmContext.BetaWatermarkTransparency);

                    PointD offset = new PointD(wmContext.BetaWatermarkOffset.X, wmContext.BetaWatermarkOffset.Y);

                    switch (wmContext.BetaWatermarkLocation)
                    {
                        case WatermarkLocation.BottomRight:
                            // Draw the watermark in the bottom right corner
                            image.Composite(watermark, Gravity.Southeast, offset, CompositeOperator.Over);
                            break;
                        case WatermarkLocation.BottomLeft:
                            // Draw the watermark in the bottom left corner
                            image.Composite(watermark, Gravity.Southwest, offset, CompositeOperator.Over);
                            break;
                        case WatermarkLocation.BottomCenter:
                            // Draw the watermark in the bottom center
                            image.Composite(watermark, Gravity.South, offset, CompositeOperator.Over);
                            break;
                        case WatermarkLocation.TopRight:
                            // Draw the watermark in the top right corner
                            image.Composite(watermark, Gravity.Northeast, offset, CompositeOperator.Over);
                            break;
                        case WatermarkLocation.TopLeft:
                            // Draw the watermark in the top left corner
                            image.Composite(watermark, Gravity.Northwest, offset, CompositeOperator.Over);
                            break;
                        case WatermarkLocation.TopCenter:
                            // Draw the watermark in the top center
                            image.Composite(watermark, Gravity.North, offset, CompositeOperator.Over);
                            break;
                        case WatermarkLocation.Right:
                            // Draw the watermark on the right side
                            image.Composite(watermark, Gravity.East, offset, CompositeOperator.Over);
                            break;
                        case WatermarkLocation.Left:
                            // Draw the watermark on the left side
                            image.Composite(watermark, Gravity.West, offset, CompositeOperator.Over);
                            break;
                        case WatermarkLocation.Center:
                            // Draw the watermark in the center
                            image.Composite(watermark, Gravity.Center, offset, CompositeOperator.Over);
                            break;       
                    }
                }

                return image.ToBitmap();
            }
        }
    }
}
