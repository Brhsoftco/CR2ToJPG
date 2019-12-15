using System;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace structure
{
    public class XMLProfile //this is an object (a public object; any other assembly can access it). Remember this object name "XMLProfile"
    {
        public AppOptions Options = new AppOptions();
        public AppLocations Locations = new AppLocations();
        public AppContext AppInfo = new AppContext();
        public WatermarkContext Watermark = new WatermarkContext();

        public static XMLProfile fromFile(string fileName)
        {
            XMLProfile subReq = null;

            XmlSerializer serializer = new XmlSerializer(typeof(XMLProfile));

            StreamReader reader = new StreamReader(fileName);
            subReq = (XMLProfile)serializer.Deserialize(reader);
            reader.Close();

            return subReq;
        }

        public static void saveFile(XMLProfile prof, string fileName)
        {
            XmlSerializer xsSubmit = new XmlSerializer(typeof(XMLProfile));
            XmlWriterSettings xmlSettings = new XmlWriterSettings();
            xmlSettings.Indent = true;
            xmlSettings.IndentChars = ("\t");
            xmlSettings.OmitXmlDeclaration = false;
            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww, xmlSettings))
                {
                    xsSubmit.Serialize(sww, prof);

                    File.WriteAllText(fileName, sww.ToString());
                }
            }

        }
    }

    public class CommandSwitches
    {
        public bool SaveEnabled = true;
        public bool LoadEnabled = true;
        public bool WtrmEnabled = true;
        public bool UpdaEnabled = true;
        public bool OptsEnabled = true;
        public bool GuidEnabled = true;
        public bool AbouEnabled = true;

        public static CommandSwitches loadFromArray(string[] arr)
        {
            CommandSwitches obj = new CommandSwitches();

            return obj;
        }
    }
    public class AppLocations
    {
        public string CR2Folder = "";
        public string JPGFolder = "";
    }

    public class ImageProcess
    {
        public string CR2File = "";
        public string JPGFile = "";
        public WatermarkContext WtrContext;
    }

    public class WatermarkLocation
    {
        public const int TopRight = 0;
        public const int TopCenter = 1;
        public const int TopLeft = 2;
        public const int BottomRight = 3;
        public const int BottomCenter = 4;
        public const int BottomLeft = 5;
        public const int Right = 6;
        public const int Center = 7;
        public const int Left = 8;
    }

    public class AppContext
    {
        public DateTime TimeCreated = DateTime.Now;
        public string AppVersion = "";
        public string UserName = Environment.UserName;
    }

    //just makes it a little easier :)
    public static class WatermarkType
    {
        public const int None = 0;
        public const int Text = 1;
        public const int Image = 2;
    }

    public class AppOptions
    {
        bool subf = false;
        int comp = 100;
        bool dupl = true;

        /// <summary>
        /// Do we include subfolders and their files when scanning for CR2s?
        /// </summary>
        public bool Subfolders
        {
            get
            {
                return subf;
            }
            set
            {
                subf = value;
            }
        }

        /// <summary>
        /// How compressed is the outputted JPEG?
        /// </summary>
        public int Quality
        {
            get
            {
                return comp;
            }
            set
            {
                comp = value;
            }
        }

        public bool Duplicates
        {
            get
            {
                return dupl;
            }
            set
            {
                dupl = value;
            }
        }
    }

    public class WatermarkOffset
    {
        public int X = 0;
        public int Y = 0;
    }

    public class WatermarkFont
    {
        public double pointSize = 10;
        public string fontFamily = System.Drawing.FontFamily.GenericSansSerif.Name;
        public string argbFontColor = argbColorToString(System.Drawing.Color.Black);
        public System.Drawing.FontStyle fontStyle = System.Drawing.FontStyle.Regular;

        public System.Drawing.Font getFont(bool defaultPointSize)
        {
            if (!defaultPointSize)
            {
                return new System.Drawing.Font(fontFamily, (float)pointSize);
            }
            else
            {
                return new System.Drawing.Font(fontFamily, (float)8.25);
            }
        }

        public System.Drawing.Color getColor()
        {
            return argbColorFromString(argbFontColor);
        }

        public static string argbColorToString(System.Drawing.Color argbColour)
        {
            return argbColour.ToArgb().ToString();
        }

        public static System.Drawing.Color argbColorFromString(string argbColour)
        {
            return System.Drawing.Color.FromArgb(Convert.ToInt32(argbColour));
        }
    }

    public class ImageInfo
    {
        public int width = 0;
        public int height = 0;
        public int bytes = 0;

        public string byteString()
        {
            return BytesToString(bytes);
        }

        public static ImageInfo fromFile(string fileName)
        {
            ImageInfo obj = new ImageInfo();
            System.Drawing.Bitmap bmp = (System.Drawing.Bitmap)System.Drawing.Bitmap.FromFile(fileName);
            obj.width = bmp.Width;
            obj.height = bmp.Height;
            obj.bytes = System.IO.File.ReadAllBytes(fileName).Length;
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
            return (Math.Sign(byteCount) * num).ToString() + suf[place];
        }
    }

    public class WatermarkInformation
    {
        public string WatermarkText = "DefaultWatermark";
        public string WatermarkPath = "";
    }

    public class StructureGeneric
    {
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
    }

    public class WatermarkContext
    {
        public int BetaWatermarkType = WatermarkType.None;
        public WatermarkInformation BetaWatermarkInfo = new WatermarkInformation();
        public int BetaWatermarkLocation = WatermarkLocation.BottomRight;
        public WatermarkOffset BetaWatermarkOffset = new WatermarkOffset();
        public double BetaWatermarkScale = 100;
        public string BetaWatermarkImageBase64 = "";
        public WatermarkFont BetaWatermarkFont = new WatermarkFont();
        public double BetaWatermarkTransparency = 4;
    }
}