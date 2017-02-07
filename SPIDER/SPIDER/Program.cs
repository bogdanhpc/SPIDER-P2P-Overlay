using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using StatisticsLibrary;
using System.Windows.Forms;

namespace SPIDER
{

    class Program
    {
        static void Main(string[] args)
        {
            if (File.Exists("Output.txt"))
            {
                File.Delete("Output.txt");
            }
            var spiderOverlay = new SpiderOverlay(60,100);
            spiderOverlay.CreateOverlay();

            for (int i=0;i<spiderOverlay.getMaximumNumberOfPeers();i++)
            {
                if (spiderOverlay.Peers.Count != 0)
                {
                    Nod existingNode = spiderOverlay.GetLastNode();
                    spiderOverlay.JoinOverlay(existingNode);
                }
            }

            
            //    spiderOverlay.PopulateOverlay();
            spiderOverlay.DisplayOverlay();

            Nod n = spiderOverlay.GetLastNode();
            spiderOverlay.LeaveOverlay(n);

            //spiderOverlay.DisplayOverlay();
            //spiderOverlay.DisplayOverlayAsMatrix();

            Console.WriteLine("Nr of peers in Overlay : " + spiderOverlay.getMaximumNumberOfPeers() + "\r\n");

            if (File.Exists("Hops.txt"))
            {
                File.Delete("Hops.txt");
            }
            List<int> hopsValueList = new List<int>();
            using (StreamWriter writetext = new StreamWriter("Hops.txt", true))
            {
                for (int i = 1; i < spiderOverlay.Peers.Count; i++)
                {
                    for (int j = 1; j < spiderOverlay.Peers.Count; j++)
                    {

                        var item = spiderOverlay.getNrHops(spiderOverlay.Peers[i], spiderOverlay.Peers[j]);
                        hopsValueList.Add(item);

                        
                        //writetext.WriteLine("Nr of hops between " + i + " and " + j + " : " + 
                        //spiderOverlay.getNrHops(spiderOverlay.peers[i], spiderOverlay.peers[j]) + "\r\n");
                    }

                }
            }

            Console.WriteLine("Maximum number of hops in Overlay : " + hopsValueList.Max() + "\r\n");

            if (File.Exists("Values.txt"))
            {
                File.Delete("Values.txt");
            }
            // rezolutie 1280x1014, video quality Hight, Framerate 30 Fps, 1 camera
            //using (StreamWriter writetext = new StreamWriter("Values.txt", true))
            //{
            //    writetext.WriteLine("Bandwidth for H.264 with SPIDER: " + hopsValueList.Max() * 6.37 + " Mbps \r\n");
            //    writetext.WriteLine("Bandwidth for H.264 without SPIDER: " + spiderOverlay.Peers.Count * 6.37 + " Mbps \r\n");
            //    writetext.WriteLine("Bandwidth for MPEG-4 with SPIDER: " + hopsValueList.Max() * 9.90 + " Mbps \r\n");
            //    writetext.WriteLine("Bandwidth for MPEG-4 without SPIDER: " + spiderOverlay.Peers.Count * 6.37 + " Mbps \r\n");
            //    writetext.WriteLine("Bandwidth for MJPEG with SPIDER: " + hopsValueList.Max() * 89.12 + " Mbps \r\n");
            //    writetext.WriteLine("Bandwidth for MJPEG without SPIDER: " + spiderOverlay.Peers.Count * 89.12 + " Mbps \r\n");
            //}

            if (File.Exists("Valuesrezolutiistandard.txt"))
            {
                File.Delete("Valuesrezolutiistandard.txt");
            }
            using (StreamWriter writetext = new StreamWriter("Valuesrezolutiistandard.txt", true))
            {
                writetext.WriteLine("Bandwidth for general 240p with SPIDER: " + hopsValueList.Max() * 0.64 + " Mbps \r\n");
                writetext.WriteLine("Bandwidth for general 240p without SPIDER: " + spiderOverlay.Peers.Count * 0.64 + " Mbps \r\n");

                writetext.WriteLine("Bandwidth for general 360 with SPIDER: " + hopsValueList.Max() * 0.96 + " Mbps \r\n");
                writetext.WriteLine("Bandwidth for general 360 without SPIDER: " + spiderOverlay.Peers.Count * 0.64 + " Mbps \r\n");

                writetext.WriteLine("Bandwidth for general 480 with SPIDER: " + hopsValueList.Max() * 1.15 + " Mbps \r\n");
                writetext.WriteLine("Bandwidth for general 480 without SPIDER: " + spiderOverlay.Peers.Count *1.15 + " Mbps \r\n");

                writetext.WriteLine("Bandwidth for general 720 with SPIDER: " + hopsValueList.Max() * 2.56 + " Mbps \r\n");
                writetext.WriteLine("Bandwidth for general 720 without SPIDER: " + spiderOverlay.Peers.Count * 2.56 + " Mbps \r\n");

                writetext.WriteLine("Bandwidth for general 720 hq with SPIDER: " + hopsValueList.Max() * 3.20 + " Mbps \r\n");
                writetext.WriteLine("Bandwidth for general 720 hq without SPIDER: " + spiderOverlay.Peers.Count * 3.20 + " Mbps \r\n");

                writetext.WriteLine("Bandwidth for general 1080  with SPIDER: " + hopsValueList.Max() * 5.12 + " Mbps \r\n");
                writetext.WriteLine("Bandwidth for general 1080  without SPIDER: " + spiderOverlay.Peers.Count * 5.12 + " Mbps \r\n");

                writetext.WriteLine("Bandwidth for general 1080 hq with SPIDER: " + hopsValueList.Max() * 7.68 + " Mbps \r\n");
                writetext.WriteLine("Bandwidth for general 1080 hq without SPIDER: " + spiderOverlay.Peers.Count * 7.68 + " Mbps \r\n");

            }

            var providers = new List<Provider>();

            providers.Add(new Provider("Itunes", 240, null,null));
            providers.Add(new Provider("Itunes", 360, null,null));
            providers.Add(new Provider("Itunes", 480, 1.46, 1.46/8));
            providers.Add(new Provider("Itunes", 720, 3.90,3.9/8));
            providers.Add(new Provider("Itunes", 1080, 4.88,4.88/8));

            providers.Add(new Provider("Netflix", 240, 0.24,0.24/8));
            providers.Add(new Provider("Netflix", 360, 0.54,0.54/8));
            providers.Add(new Provider("Netflix", 480, 1.02,1.02/8));
            providers.Add(new Provider("Netflix2", 480, 1.70,1.70/8));
            providers.Add(new Provider("Netflix", 720, 2.29,2.29/8));
            providers.Add(new Provider("Netflix2", 720, 3.51,3.51/8));
            providers.Add(new Provider("Netflix", 1080, 4.68,4.68/8));

            providers.Add(new Provider("Vimeo", 240, null,null));
            providers.Add(new Provider("Vimeo", 360, 0.78,0.78/8));
            providers.Add(new Provider("Vimeo", 480, null,null));
            providers.Add(new Provider("Vimeo", 720, 1.95,1.95/8));
            providers.Add(new Provider("Vimeo", 1080, 4.39,4.39/8));

            providers.Add(new Provider("Youtube", 240, 0.24,0.24/8));
            providers.Add(new Provider("Youtube", 360, 0.48,0.48/8));
            providers.Add(new Provider("Youtube", 480, 0.97,097/8));
            providers.Add(new Provider("Youtube", 720, 1.95,195/8));
            providers.Add(new Provider("Youtube", 1080, 3.41,3.41/8));

            var medie = providers.Average(item => item.Bitrate);

            var list240 = providers.Where(item => item.Rezolution == 240);
            var list360 = providers.Where(item => item.Rezolution == 360);
            var list480 = providers.Where(item => item.Rezolution == 480);
            var list720 = providers.Where(item => item.Rezolution == 720);
            var list1080 = providers.Where(item => item.Rezolution == 1080);


            var mean240 = list240.Average(item => item.Bitrate);
            var mean360 = list360.Average(item => item.Bitrate);
            var mean480 = list480.Average(item => item.Bitrate);
            var mean720 = list720.Average(item => item.Bitrate);
            var mean1080 = list1080.Average(item => item.Bitrate);





            if (File.Exists("Valuesrezolutiiprovideri.txt"))
            {
                File.Delete("Valuesrezolutiiprovideri.txt");
            }

            var lspider = new List<double>();
            var lfspider = new List<double>();

            using (StreamWriter writetext = new StreamWriter("Valuesrezolutiiprovideri.txt", true))
            {

                foreach (var item in providers)
                {

                    var spiderValue = hopsValueList.Max() * item.Bitrate /8;
                    var noSpiderValue = spiderOverlay.Peers.Count * item.Bitrate / 8 ;

                    var ratio = spiderValue / noSpiderValue;

                    writetext.WriteLine("Bandwidth for " + item.Name + " rezolutie " + item.Rezolution + " is " + spiderValue *8  + " Mbps \r\n");
                    writetext.WriteLine("Bandwidth for " + item.Name + "fara SPIDER rezolutie " + item.Rezolution + " is " + noSpiderValue *8  + " Mbps \r\n");
                    writetext.WriteLine("Ratio Spider / noSpideris " + ratio);
                    writetext.WriteLine("Size on disk for " + item.Name + " 1 seconds of streaming is " + item.RequiredSize + "MB\r\n");

                    //

                    if (spiderValue != null && noSpiderValue!=null)
                    {
                        lspider.Add((double)spiderValue);
                        lfspider.Add((double)noSpiderValue);

                    }



                    //writetext.WriteLine("Size on disk for " + item.Name + " 10 seconds of streaming is " + hopsValueList.Max() * item.Bitrate * 1/8 + "MB\r\n");
                    //writetext.WriteLine("Size on disk for " + item.Name + " 1 seconds of streaming is " + hopsValueList.Max() * item.Bitrate * 1 / 8 + "MB\r\n");

                    writetext.WriteLine("@@@@\r\n");


                }

                //writetext.WriteLine("Max disk size is " + lspider.Max());

                var mediaSpider = lspider.Average();
                var mediafaraSpider = lfspider.Average();

                var statisticsAnalyzer = new Analysis();
                var staticticsCalculatorCuSpider = new StaticticsCalculator(lspider);
                var staticticsCalculatorFaraSpider = new StaticticsCalculator(lfspider);



                writetext.WriteLine("media cu SPIDER = " + statisticsAnalyzer.DataAnalysis(lspider));
                writetext.WriteLine("Coef de variatie cu SPIDER = " + staticticsCalculatorCuSpider.CoeficientdeVariatie());
                writetext.WriteLine("media fara  SPIDER = " + statisticsAnalyzer.DataAnalysis(lfspider));
                writetext.WriteLine("Coef de variatie fara  SPIDER = " + staticticsCalculatorFaraSpider.CoeficientdeVariatie());



            }

            //var plot = new XYScatter(true, lspider.ToArray(), new double[18,18], "titlu", "x", "y", new Panel());

            //}

            //SPIDER.FlawAnalysis.RunExamples.Run();
        }
    }
}
                                        