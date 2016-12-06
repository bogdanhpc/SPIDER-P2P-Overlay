using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

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
            var spiderOverlay = new SpiderOverlay(3, 3);
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

            spiderOverlay.DisplayOverlay();
            spiderOverlay.DisplayOverlayAsMatrix();

            //    Console.WriteLine("Nr of peers in Overlay : " + spiderOverlay.getMaximumNumberOfPeers() + "\r\n");

            //    if (File.Exists("Hops.txt"))
            //    {
            //        File.Delete("Hops.txt");
            //    }
            //    List<int> hopsValueList = new List<int>();
            //    using (StreamWriter writetext = new StreamWriter("Hops.txt", true))
            //    {
            //        for (int i = 1; i <= spiderOverlay.getMaximumNumberOfPeers(); i++)
            //        {
            //            for (int j = 1; j <= spiderOverlay.getMaximumNumberOfPeers(); j++)
            //            {

            //                hopsValueList.Add(spiderOverlay.getNrHops(spiderOverlay.peers[i], spiderOverlay.peers[j]));
            //                //writetext.WriteLine("Nr of hops between " + i + " and " + j + " : " + 
            //                //spiderOverlay.getNrHops(spiderOverlay.peers[i], spiderOverlay.peers[j]) + "\r\n");
            //            }

            //        }
            //    }

            //    Console.WriteLine("Maximum number of hops in Overlay : " + hopsValueList.Max() + "\r\n");

            //    if (File.Exists("Values.txt"))
            //    {
            //        File.Delete("Values.txt");
            //    }
            //    // rezolutie 1280x1014, video quality Hight, Framerate 30 Fps, 1 camera
            //    using (StreamWriter writetext = new StreamWriter("Values.txt", true))
            //    {
            //        writetext.WriteLine("Bandwidth for H.264 with SPIDER: " + hopsValueList.Max() * 6.37 + " Mbps \r\n");
            //        writetext.WriteLine("Bandwidth for H.264 without SPIDER: " + spiderOverlay.getMaximumNumberOfPeers() * 6.37 + " Mbps \r\n");
            //        writetext.WriteLine("Bandwidth for MPEG-4 with SPIDER: " + hopsValueList.Max() * 9.90 + " Mbps \r\n");
            //        writetext.WriteLine("Bandwidth for MPEG-4 without SPIDER: " + spiderOverlay.getMaximumNumberOfPeers() * 6.37 + " Mbps \r\n");
            //        writetext.WriteLine("Bandwidth for MJPEG with SPIDER: " + hopsValueList.Max() * 89.12 + " Mbps \r\n");
            //        writetext.WriteLine("Bandwidth for MJPEG without SPIDER: " + spiderOverlay.getMaximumNumberOfPeers() * 89.12 + " Mbps \r\n");
            //    }

            //}

            SPIDER.FlawAnalysis.RunExamples.Run();
        }
    }
}
                                        