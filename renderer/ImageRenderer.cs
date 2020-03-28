using ImageMagick;
using structure;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;

namespace renderer
{
    public class ImageRenderer
    {
        public WatermarkContext WmContext { get; set; }

        public Bitmap RenderBmpFromBase64(string b64)
        {
            var bytes = Convert.FromBase64String(b64);
            var mem = new MemoryStream(bytes);
            var prev = new Bitmap(mem);
            return prev;
        }

        //CREDIT: https://stackoverflow.com/questions/7350679/convert-a-bitmap-into-a-byte-array
        public static byte[] ImageToByte(Image img)
        {
            using (var stream = new MemoryStream())
            {
                img.Save(stream, ImageFormat.Png);
                return stream.ToArray();
            }
        }

        public static string GetBuildInfo(bool includeDateTime)
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            var buildDate = new DateTime(2000, 1, 1)
            .AddDays(version.Build).AddSeconds(version.Revision * 2);
            string displayableVersion;

            if (includeDateTime)
                displayableVersion = $"{version} ({buildDate})";
            else
                displayableVersion = $"{version}";

            return displayableVersion;
        }

        public Bitmap GetTextWatermark(string text, Bitmap originalImage)
        {
            Font mFont = WmContext.BetaWatermarkFont.GetFont(false);
            Brush brush = new SolidBrush(WmContext.BetaWatermarkFont.GetColor());
            SizeF size;

            // Figure out the size of the box to hold the watermarked text
            using (var g = Graphics.FromImage(originalImage))
            {
                size = g.MeasureString(text, mFont);
            }

            // Create a new bitmap for the text, and, actually, draw the text
            var bitmap = new Bitmap((int)size.Width, (int)size.Height);
            bitmap.SetResolution(originalImage.HorizontalResolution, originalImage.VerticalResolution);

            using (var g = Graphics.FromImage(bitmap))
            {
                g.DrawString(text, mFont, brush, 0, 0);
            }

            return bitmap;
        }

        public Bitmap RenderTextWatermark(string text, Bitmap bmpImage)
        {
            var bmpWatermark = GetTextWatermark(text, bmpImage);
            var bmpFinal = RenderImageWatermark(bmpWatermark, bmpImage);
            return bmpFinal;
        }

        /// <summary>
        /// Renders a watermarked image, and then saves it to a file.
        /// </summary>
        /// <param name="bmpWatermark">The Watermark to be applied (Bitmap only)</param>
        /// <param name="bmpOriginal">The Original image (Bitmap only)</param>
        /// <param name="fileName">The path of the file to save the rendition to</param>
        public void RenderWatermarkFile(Bitmap bmpWatermark, Bitmap bmpOriginal, string fileName)
        {
            var render = RenderImageWatermark(bmpWatermark, bmpOriginal);
            render.Save(fileName);
        }

        public Bitmap RenderImageWatermark(Bitmap bmpWatermark, Bitmap bmpImage)
        {
            // Read image that needs a watermark
            using (var image = new MagickImage(bmpImage))
            {
                // Read the watermark that will be put on top of the image
                using (var watermark = new MagickImage(bmpWatermark))
                {
                    watermark.Scale(new Percentage(WmContext.BetaWatermarkScale));

                    watermark.Alpha(AlphaOption.Set);

                    watermark.Evaluate(Channels.Alpha, EvaluateOperator.Multiply, WmContext.BetaWatermarkTransparency / 100);

                    var offset = new PointD(WmContext.BetaWatermarkOffset.X, WmContext.BetaWatermarkOffset.Y);

                    switch (WmContext.BetaWatermarkLocation)
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