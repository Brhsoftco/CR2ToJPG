using System;
using System.Drawing;

namespace structure
{
    public class WatermarkFont
    {
        public double PointSize = 10;
        public string FontFamily = System.Drawing.FontFamily.GenericSansSerif.Name;
        public string ArgbFontColor = ArgbColorToString(Color.Black);
        public FontStyle FontStyle = FontStyle.Regular;

        public Font GetFont(bool defaultPointSize)
        {
            if (!defaultPointSize)
            {
                return new Font(FontFamily, (float)PointSize);
            }

            return new Font(FontFamily, (float)8.25);
        }

        public Color GetColor()
        {
            return ArgbColorFromString(ArgbFontColor);
        }

        public static string ArgbColorToString(Color argbColour)
        {
            return argbColour.ToArgb().ToString();
        }

        public static Color ArgbColorFromString(string argbColour)
        {
            return Color.FromArgb(Convert.ToInt32(argbColour));
        }
    }
}