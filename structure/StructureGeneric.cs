using System;
using System.Reflection;

namespace structure
{
    public class StructureGeneric
    {
        public static string GetBuildInfo(bool includeDateTime)
        {
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
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
}