using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPIDER
{

    class SpiderOverlay : ISpiderOverlay
    {
        public int NrChains { get; set; }
        public int NrRings { get; set; }
        public int NrPeers { get; set; }
        public List<Nod> Peers { get; set; }
        public Nod LastNode { get; set; }

        public int[,] OvelayMatrix { get; set; }

        public SpiderOverlay(int nrChains, int nrRings)
        {
            this.NrChains = nrChains;
            this.NrRings = nrRings;

            this.NrPeers = nrChains * nrRings;
            Peers = new List<Nod>();
            LastNode = new Nod();

            OvelayMatrix = new int[nrChains+1,nrRings+1];
            for (int i=0;i<=nrChains;i++)
                for (int j=0;j<=nrRings;j++)
                    OvelayMatrix[i,j] = 0;
        }

        public void PopulateOverlay()
        {
            Nod superPeer = new Nod(0, 0, true);
            Peers.Add(superPeer);
            for (int i = 1; i <= NrChains; i++)
            {
                for (int j = 1; j <= NrRings; j++)
                {
                    Nod newNode = new Nod(i, j, false);

                    Peers.Add(newNode);
                }
            }
        }


        public void CreateOverlay()
        {
            if (this.Peers.Count == 0)
            {
                //create overlay SP first
                Nod superPeer = new Nod(0, 0, true);
                Peers.Add(superPeer);
                LastNode = superPeer;

            }

        }
        public void JoinOverlay(Nod existingNode)
        {

            Nod newNode = new Nod();
            if (this.Peers.Count == 1)
            {
                // join with the SP
                newNode.Chain = 1;
                newNode.Ring = 1;
                newNode.Id = newNode.Chain.ToString() + "-" + newNode.Ring.ToString() + " ";
                newNode.Status = new Neighbour(false, true, false, false);
                if (!IsNodeInOverlay(newNode))
                    Peers.Add(newNode);
            }
            else
            {
                //rest of the cases
                Neighbour status = existingNode.GetStatus();
                if (!status.left)
                {
                    if (existingNode.Chain + 1 > NrChains)
                    {
                        newNode.Chain = existingNode.Chain + 1 - NrChains;
                    }
                    else
                    {
                        newNode.Chain = existingNode.Chain + 1;
                    }

                    newNode.Ring = existingNode.Ring;
                    newNode.Id = newNode.Chain.ToString() + "-" + newNode.Ring.ToString() + " ";
                    if (newNode.Chain == NrChains)
                    {
                        newNode.Status = new Neighbour(false, true, true, true);
                    }
                    else
                    {
                        newNode.Status = new Neighbour(false, true, false, true);
                    }

                    //existingNode.status.left = true;
                    Peers.Where(item => item.Id == existingNode.Id).ToList().ForEach(s => s.Status.left = true);
                    if (!IsNodeInOverlay(newNode))
                        Peers.Add(newNode);
                }
                else
                {
                    if (!status.right)
                    {

                        if (existingNode.Chain - 1 == 0)
                        {
                            newNode.Chain = NrChains;
                        }
                        else
                        {
                            newNode.Chain = existingNode.Chain - 1;
                        }

                        newNode.Ring = existingNode.Ring;
                        newNode.Id = newNode.Chain.ToString() + "-" + newNode.Ring.ToString() + " ";
                        if (newNode.Chain == NrChains)
                        {
                            newNode.Status = new Neighbour(false, true, true, true);
                        }
                        else
                        {
                            newNode.Status = new Neighbour(false, true, false, true);
                        }
                        Peers.Where(item => item.Id == existingNode.Id).ToList().ForEach(s => s.Status.right = true);
                        //existingNode.status.right = true;
                        if (!IsNodeInOverlay(newNode))
                            Peers.Add(newNode);
                    }
                    else
                    {
                        if (!status.up)
                        {
                            newNode.Chain = existingNode.Chain;
                            newNode.Ring = existingNode.Ring + 1;
                            newNode.Id = newNode.Chain.ToString() + "-" + newNode.Ring.ToString() + " ";
                            newNode.Status = new Neighbour(false, true, false, false);
                            Peers.Where(item => item.Id == existingNode.Id).ToList().ForEach(s => s.Status.up = true);
                            //existingNode.status.up = true;
                            if (!IsNodeInOverlay(newNode))
                                Peers.Add(newNode);
                        }
                    }
                }
            }
            LastNode = newNode;
        }

        public bool IsNodeInOverlay(Nod node)
        {
            var result = Peers.Find(item => node.Id == item.Id);
            if (result == null)
                return false;
            else
                return true;

        }

        //private void UpdateStatus(Nod node)
        //{
        //    List<Neighbour> neigbours = new List<Neighbour>();
        //    neigbours = GetAvailableNeighbours(node);

        //    peers.Where(item => item.ring == node.ring - 1).ToList().ForEach(s => s.status.up = false);
        //    peers.Where(item => item.Chain == node.Chain - 1).ToList().ForEach(s => s.status.left = false);
        //    peers.Where(item => item.Chain == node.Chain + 1).ToList().ForEach(s => s.status.right = false);
        //}

        public void UpdateAllNeihhbours(Nod node)
        {
            if (node.Ring == NrRings)
            {
                //pe ultimul ring
                Peers.Where(item => item.Ring == node.Ring - 1).ToList().ForEach(s => s.Status.up = false);
                if (node.Chain == 1)
                {
                    Peers.Where(item => item.Chain == NrChains).ToList().ForEach(s =>
                    {
                        if (IsNodeInOverlay(s)) s.Status.left = false;
                    });
                    Peers.Where(item => item.Chain == node.Chain + 1).ToList().ForEach(s =>
                    {
                        if (IsNodeInOverlay(s)) s.Status.right = false;
                    });
                }
                else
                {
                    if (node.Chain == NrChains)
                    {
                        Peers.Where(item => item.Chain == 1).ToList().ForEach(s =>
                        {
                            if (IsNodeInOverlay(s)) s.Status.left = false;
                        });
                        Peers.Where(item => item.Chain == node.Chain - 1).ToList().ForEach(s =>
                        {
                            if (IsNodeInOverlay(s)) s.Status.right = false;
                        });
                    }
                    else
                    {
                        Peers.Where(item => item.Chain == NrChains + 1).ToList().ForEach(s =>
                        {
                            if (IsNodeInOverlay(s)) s.Status.left = false;
                        });
                        Peers.Where(item => item.Chain == node.Chain - 1).ToList().ForEach(s =>
                        {
                            if (IsNodeInOverlay(s)) s.Status.right = false;
                        });

                    }
                }
            }
            else
            {
                //in mijloc
                if (node.Ring == 1)
                {
                    //ne mai gandim
                    Console.WriteLine("Not implemented");
                }
                else
                {
                    Peers.Where(item => item.Ring == node.Ring - 1).ToList().ForEach(s => s.Status.up = false);
                    Peers.Where(item => item.Ring == node.Ring + 1).ToList().ForEach(s => s.Status.down = false);
                    if (node.Chain == 1)
                    {
                        Peers.Where(item => item.Chain == NrChains).ToList().ForEach(s =>
                        {
                            if (IsNodeInOverlay(s)) s.Status.left = false;
                        });
                        Peers.Where(item => item.Chain == node.Chain + 1).ToList().ForEach(s =>
                        {
                            if (IsNodeInOverlay(s)) s.Status.right = false;
                        });
                    }
                    else
                    {
                        if (node.Chain == NrChains)
                        {
                            Peers.Where(item => item.Chain == 1).ToList().ForEach(s =>
                            {
                                if (IsNodeInOverlay(s)) s.Status.left = false;
                            });
                            Peers.Where(item => item.Chain == node.Chain - 1).ToList().ForEach(s =>
                            {
                                if (IsNodeInOverlay(s)) s.Status.right = false;
                            });
                        }
                        else
                        {
                            Peers.Where(item => item.Chain == NrChains + 1).ToList().ForEach(s =>
                            {
                                if (IsNodeInOverlay(s)) s.Status.left = false;
                            });
                            Peers.Where(item => item.Chain == node.Chain - 1).ToList().ForEach(s =>
                            {
                                if (IsNodeInOverlay(s)) s.Status.right = false;
                            });

                        }
                    }
                }
            }

        }
        public void LeaveOverlay(Nod node)
        {
            if (node.IsSuperPeer)
            {
                Console.WriteLine("Not implemented");
            }

            UpdateAllNeihhbours(node);
            Peers.Remove(Peers.Single(x => x.Id == node.Id));

        }

        public void DisplayOverlay()
        {
            foreach (Nod n in Peers)
            {
                n.PrintNod();
            }
                
        }

        public void DisplayOverlayAsMatrix()
        {
            
            foreach (Nod n in Peers)
            {
                OvelayMatrix[n.Chain,n.Ring] = 1;
            }
            for (int i = 0; i <= NrChains; i++)
            {
                for (int j = 0; j <= NrRings; j++)
                {
                    Console.Write(OvelayMatrix[i,j] + "  ");
                }
                Console.WriteLine("\r\n");
            }

        }

        public Nod GetLastNode()
        {
            return LastNode;
        }

        public int getMaximumNumberOfPeers()
        {
            return NrPeers;
        }

        public int getNrHops(Nod a, Nod b)
        {
            int nrHops = 0;
            int chainDIF = 0;
            int ringDIF = 0;

            if (Math.Abs(a.Chain - b.Chain) <= NrPeers / 2)
            {
                chainDIF = Math.Abs(a.Chain - b.Chain);
            }
            else
            {
                chainDIF = NrPeers - Math.Abs(a.Chain - b.Chain);
            }

            ringDIF = Math.Abs(a.Ring - b.Ring);

            nrHops = chainDIF + ringDIF;
            return nrHops;
        }

    }

}
