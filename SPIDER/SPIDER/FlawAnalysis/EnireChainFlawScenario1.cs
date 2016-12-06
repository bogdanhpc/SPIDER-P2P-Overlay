using System;

namespace SPIDER
{

    public class EnireChainFlawScenario1 : IFlaw
    {
        public ISpiderOverlay Overlay { set; get; }

        public int CalculateNoOfOperations()
        {
            return Overlay.getNoOfRings() * 2;
        }
    }
}
