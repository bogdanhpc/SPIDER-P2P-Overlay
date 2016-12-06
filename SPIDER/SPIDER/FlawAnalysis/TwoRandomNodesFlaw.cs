using System;

namespace SPIDER
{

    public class TwoRandomNodesFlaw : IFlaw
    {
        public ISpiderOverlay Overlay { set; get; }
        public int CalculateNoOfOperations()
        {
            return 8;
        }
    }
}
