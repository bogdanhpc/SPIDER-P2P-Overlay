using System;

namespace SPIDER
{

    public class TwoRandomNodesFromTheSameRingFlaw : IFlaw
    {
        public ISpiderOverlay Overlay { set; get; }
        public int CalculateNoOfOperations()
        {
            return 4 * 2 - 2;
        }
    }
}
