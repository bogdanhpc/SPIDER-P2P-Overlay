using System;

namespace SPIDER
{

    public class OnerRandomNodeFlaw : IFlaw
    {
        public ISpiderOverlay Overlay { set; get; }

        public int CalculateNoOfOperations()
        {
            return 4;
        }
    }
}
