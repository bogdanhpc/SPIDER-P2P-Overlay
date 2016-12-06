namespace SPIDER
{

    public class EnireChainFlawScenario2 : IFlaw
    {
        public ISpiderOverlay Overlay { set; get; }
        public int CalculateNoOfOperations()
        {
            return 2 + 2 + 4 + 8 + (Overlay.getNoOfRings() - 3) * 2 + 3;
        }
    }

}
