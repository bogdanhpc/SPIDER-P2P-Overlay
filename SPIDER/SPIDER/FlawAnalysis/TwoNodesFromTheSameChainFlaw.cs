using System;

namespace SPIDER
{

    public class TwoNodesFromTheSameChainFlaw : IFlaw
    {
        public ISpiderOverlay Overlay { set; get; }
        public int CalculateNoOfOperations()
        {
            return 6;
        }
    }
}
