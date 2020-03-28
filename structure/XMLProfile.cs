using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace structure
{
    /// <summary>
    /// Stores all information relating to XML Profiles
    /// </summary>
    public class XmlProfile
    {
        public AppOptions Options = new AppOptions();
        public AppLocations Locations = new AppLocations();
        public AppContext AppInfo = new AppContext();
        public WatermarkContext Watermark = new WatermarkContext();

        /// <summary>
        /// Create a new XMLProfile from a CR2ToJPG *.prof file
        /// </summary>
        /// <param name="fileName">The *.prof file to load</param>
        /// <returns></returns>
        public static XmlProfile FromFile(string fileName)
        {
            XmlProfile subReq;

            XmlSerializer serializer = new XmlSerializer(typeof(XmlProfile));

            StreamReader reader = new StreamReader(fileName);
            subReq = (XmlProfile)serializer.Deserialize(reader);
            reader.Close();

            return subReq;
        }

        /// <summary>
        /// Save an existing XMLProfile object to a CR2ToJPG *.prof file
        /// </summary>
        /// <param name="prof">The XMLProfile object to save</param>
        /// <param name="fileName">Path of the file to save to</param>
        public static void SaveFile(XmlProfile prof, string fileName)
        {
            XmlSerializer xsSubmit = new XmlSerializer(typeof(XmlProfile));
            XmlWriterSettings xmlSettings = new XmlWriterSettings();
            xmlSettings.Indent = true;
            xmlSettings.IndentChars = ("\t");
            xmlSettings.OmitXmlDeclaration = false;
            using (var sww = new StringWriter())
            {
                using (XmlWriter.Create(sww, xmlSettings))
                {
                    xsSubmit.Serialize(sww, prof);

                    File.WriteAllText(fileName, sww.ToString());
                }
            }

        }
    }

    //just makes it a little easier :)
}