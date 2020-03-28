using CR2ToJPG.Properties;
using ImageMagick;
using renderer;
using structure;
using structure.Enums;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace CR2ToJPG.Common
{
    public static class Converter
    {
        private static int _bufferSize = 512 * 1024;
        private static byte[] _buffer = new byte[_bufferSize];
        private static readonly ImageCodecInfo JpgImageCodec = GetJpegCodec();
        private static readonly ImageRenderer ImageRenderer = new ImageRenderer();
        public static WatermarkContext WmContext = FrmMain.WmContext;

        // thing xD
        internal static string GetSimpleExtension(string fileName)
        {
            return Path.GetExtension(fileName)?.Replace(".", "");
        }

        public static void ConvertImage(string fileName, string outputFolder, AppOptions options)
        {
            if (options.ImageProcessor == ImageProcType.Native)
                ConvertImageNative(fileName, outputFolder, options);
            else if (options.ImageProcessor == ImageProcType.MagickNet)
                ConvertImageMagickNet(fileName, outputFolder, options);
        }

        public static void ConvertImageMagickNet(string fileName, string outputFolder, AppOptions options)
        {
            try
            {
                using (FileStream fi = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read, _bufferSize, FileOptions.None))
                {
                    string baseName = Path.GetFileNameWithoutExtension(fileName);
                    string jpgName = Path.Combine(outputFolder, baseName + ".jpg");
                    string wmkName = Path.Combine(outputFolder, baseName + "_watermarked.jpg");
                    string extName = GetSimpleExtension(fileName).ToLower();

                    Bitmap bitmap = Resources.flower_preview;

                    if (extName == "cr2")
                    {
                        MagickImage img = new MagickImage(fi);
                        bitmap = img.ToBitmap();
                    }
                    else if (options.ProcessJpeg)
                    {
                        //MessageBox.Show("Yee");
                        if (extName == "jpg")
                        {
                            //MessageBox.Show(extName);
                            bitmap = (Bitmap)Image.FromFile(fileName);
                        }
                    }

                    EncoderParameters ep = new EncoderParameters(1);
                    ep.Param[0] = new EncoderParameter(Encoder.Quality, options.Quality);

                    ImageRenderer.WmContext = WmContext;

                    if (WmContext.BetaWatermarkType == WatermarkType.Image)
                    {

                        Bitmap watermark = (Bitmap)Image.FromFile(WmContext.BetaWatermarkInfo.WatermarkPath);
                        Bitmap image = ImageRenderer.RenderImageWatermark(watermark, bitmap);
                        image.Save(wmkName, JpgImageCodec, ep);

                        if (options.Duplicates)
                        {
                            bitmap.Save(jpgName, JpgImageCodec, ep);
                        }
                    }
                    else if (WmContext.BetaWatermarkType == WatermarkType.Text)
                    {
                        string watermark = WmContext.BetaWatermarkInfo.WatermarkText;
                        Bitmap image = ImageRenderer.RenderTextWatermark(watermark, bitmap);
                        image.Save(wmkName, JpgImageCodec, ep);

                        if (options.Duplicates)
                        {
                            bitmap.Save(jpgName, JpgImageCodec, ep);
                        }
                    }
                    else if (WmContext.BetaWatermarkType == WatermarkType.None)
                    {
                        bitmap.Save(jpgName, JpgImageCodec, ep);
                    }

                    GC.Collect();
                }
            }
            catch (ThreadAbortException ex)
            {
                //do absolutely nil
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error whilst converting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (FrmMain.BwConverter.IsBusy)
                {
                    FrmMain.BwConverter.Abort();
                }
            }
        }

        public static void ConvertImageNative(string fileName, string outputFolder, AppOptions options)
        {
            try
            {
                using (FileStream fi = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read, _bufferSize, FileOptions.None))
                {

                    // Start address is at offset 0x62, file size at 0x7A, orientation at 0x6E
                    fi.Seek(0x62, SeekOrigin.Begin);
                    BinaryReader br = new BinaryReader(fi);
                    UInt32 jpgStartPosition = br.ReadUInt32();  // 62
                    br.ReadUInt32();  // 66
                    br.ReadUInt32();  // 6A
                    UInt32 orientation = br.ReadUInt32() & 0x000000FF; // 6E
                    br.ReadUInt32();  // 72
                    br.ReadUInt32();  // 76
                    Int32 fileSize = br.ReadInt32();  // 7A

                    fi.Seek(jpgStartPosition, SeekOrigin.Begin);

                    string baseName = Path.GetFileNameWithoutExtension(fileName);
                    string jpgName = Path.Combine(outputFolder, baseName + ".jpg");
                    string wmkName = Path.Combine(outputFolder, baseName + "_watermarked.jpg");
                    string extName = GetSimpleExtension(fileName).ToLower();

                    Bitmap bitmap = Resources.flower_preview;

                    if (extName == "cr2")
                    {
                        bitmap = new Bitmap(new PartialStream(fi, jpgStartPosition, fileSize));
                    }
                    else if (options.ProcessJpeg)
                    {
                        //MessageBox.Show("Yee");
                        if (extName == "jpg")
                        {
                            //MessageBox.Show(extName);
                            bitmap = (Bitmap)Image.FromFile(fileName);
                        }
                    }

                    try
                    {
                        if (JpgImageCodec != null && (orientation == 8 || orientation == 6))
                        {
                            if (orientation == 8)
                                bitmap.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            else
                                bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Image Skipped
                    }
                    EncoderParameters ep = new EncoderParameters(1);
                    ep.Param[0] = new EncoderParameter(Encoder.Quality, options.Quality);

                    ImageRenderer.WmContext = WmContext;

                    if (WmContext.BetaWatermarkType == WatermarkType.Image)
                    {

                        Bitmap watermark = (Bitmap)Image.FromFile(WmContext.BetaWatermarkInfo.WatermarkPath);
                        Bitmap image = ImageRenderer.RenderImageWatermark(watermark, bitmap);
                        image.Save(wmkName, JpgImageCodec, ep);

                        if (options.Duplicates)
                        {
                            bitmap.Save(jpgName, JpgImageCodec, ep);
                        }
                    }
                    else if (WmContext.BetaWatermarkType == WatermarkType.Text)
                    {
                        string watermark = WmContext.BetaWatermarkInfo.WatermarkText;
                        Bitmap image = ImageRenderer.RenderTextWatermark(watermark, bitmap);
                        image.Save(wmkName, JpgImageCodec, ep);

                        if (options.Duplicates)
                        {
                            bitmap.Save(jpgName, JpgImageCodec, ep);
                        }
                    }
                    else if (WmContext.BetaWatermarkType == WatermarkType.None)
                    {
                        bitmap.Save(jpgName, JpgImageCodec, ep);
                    }

                    GC.Collect();
                }
            }
            catch (ThreadAbortException ex)
            {
                //do absolutely nil
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error whilst converting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (FrmMain.BwConverter.IsBusy)
                {
                    FrmMain.BwConverter.Abort();
                }
            }
        }

        private static ImageCodecInfo GetJpegCodec()
        {
            foreach (ImageCodecInfo c in ImageCodecInfo.GetImageEncoders())
            {
                if (c.CodecName.ToLower().Contains("jpeg")
                    || c.FilenameExtension.ToLower().Contains("*.jpg")
                    || c.FormatDescription.ToLower().Contains("jpeg")
                    || c.MimeType.ToLower().Contains("image/jpeg"))
                    return c;
            }

            return null;
        }
    }
}