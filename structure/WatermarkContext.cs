namespace structure
{
    public class WatermarkContext
    {
        public int BetaWatermarkType = WatermarkType.None;
        public WatermarkInformation BetaWatermarkInfo = new WatermarkInformation();
        public int BetaWatermarkLocation = WatermarkLocation.BottomRight;
        public WatermarkOffset BetaWatermarkOffset = new WatermarkOffset();
        public double BetaWatermarkScale = 100;
        public WatermarkFont BetaWatermarkFont = new WatermarkFont();
        public double BetaWatermarkTransparency = 100.00;
    }
}