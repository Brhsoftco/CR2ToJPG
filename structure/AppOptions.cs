namespace structure
{
    public class AppOptions
    {
        /// <summary>
        /// Do we include subfolders and their files when scanning for CR2s?
        /// </summary>
        public bool Subfolders { get; set; } = false;

        /// <summary>
        /// Do we process JPEG files in the CR2 folder?
        /// </summary>
        public bool ProcessJpeg { get; set; } = false;

        public Enums.ImageProcType ImageProcessor { get; set; } = Enums.ImageProcType.Native;

        /// <summary>
        /// How compressed is the outputted JPEG?
        /// </summary>
        public int Quality { get; set; } = 100;

        public bool Duplicates { get; set; } = true;
    }
}