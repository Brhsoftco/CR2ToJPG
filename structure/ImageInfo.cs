using System;
using System.Drawing;
using System.IO;

namespace structure
{
    public class ImageInfo
    {
        public int Width;
        public int Height;
        public int Bytes;

        public string ByteString()
        {
            return BytesToString(Bytes);
        }

        public static ImageInfo FromFile(string fileName)
        {
            ImageInfo obj = new ImageInfo();
            Bitmap bmp = (Bitmap)Image.FromFile(fileName);
            obj.Width = bmp.Width;
            obj.Height = bmp.Height;
            obj.Bytes = File.ReadAllBytes(fileName).Length;
            return obj;
        }

        private string BytesToString(long byteCount)
        {
            string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" }; //Longs run out around EB
            if (byteCount == 0)
                return "0" + suf[0];
            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(byteCount) * num) + suf[place];
        }
    }
}