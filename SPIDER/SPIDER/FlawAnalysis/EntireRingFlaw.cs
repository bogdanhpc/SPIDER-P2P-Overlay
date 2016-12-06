namespace SPIDER
{


    public class EntireRingFlaw : IFlaw
    {
        public ISpiderOverlay Overlay { set; get; }
        public int CalculateNoOfOperations()
        {
            return Overlay.getNoOfChains();
        }
    }
}
