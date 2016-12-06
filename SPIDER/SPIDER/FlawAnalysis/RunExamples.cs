using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPIDER.FlawAnalysis
{
    public static class RunExamples
    {
        public static void Calculate(ISpiderOverlay overlay)
        {
            var flaw1 = new OnerRandomNodeFlaw { Overlay = overlay };
            Console.WriteLine(flaw1.CalculateNoOfOperations());

            var flaw2 = new TwoRandomNodesFlaw { Overlay = overlay };
            Console.WriteLine(flaw2.CalculateNoOfOperations());

            var flaw3 = new TwoNodesFromTheSameChainFlaw { Overlay = overlay };
            Console.WriteLine(flaw3.CalculateNoOfOperations());

            var flaw4 = new TwoRandomNodesFromTheSameRingFlaw { Overlay = overlay };
            Console.WriteLine(flaw4.CalculateNoOfOperations());

            var flaw5 = new EntireRingFlaw { Overlay = overlay };
            Console.WriteLine(flaw5.CalculateNoOfOperations());

            var flaw6 = new EnireChainFlawScenario1 { Overlay = overlay };
            Console.WriteLine(flaw6.CalculateNoOfOperations());

            var flaw7 = new EnireChainFlawScenario2 { Overlay = overlay };
            Console.WriteLine(flaw7.CalculateNoOfOperations());

            Console.WriteLine("#############################################");
        }

        public static void Run()
        {
            Calculate(new SpiderOverlay(2,2));
            Calculate(new SpiderOverlay(4, 2));
            Calculate(new SpiderOverlay(4, 6));
            Calculate(new SpiderOverlay(6, 10));
            Calculate(new SpiderOverlay(6, 20));
            Calculate(new SpiderOverlay(6, 100));
            Calculate(new SpiderOverlay(6, 1000));
            Calculate(new SpiderOverlay(6, 2000));









        }
    }
}
