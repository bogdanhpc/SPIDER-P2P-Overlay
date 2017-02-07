using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPIDER.VOD
{
    class VodNod : INod, IManageStorage
    {
        private string id;
        private bool isSuperPeer;
        private int chain;
        private int ring;
        private Neighbour status;
        private double trust;

        private double availableStorage;

        private List<Slot> ownSlots;
        private List<Slot> neighborSlot;

        public VodNod(int chain, int ring, bool flag)
        {
            Chain = chain;
            Ring = ring;
            Id = chain.ToString() + "-" + ring.ToString() + " ";

            if (flag == true)
            {
                IsSuperPeer = true;
            }
            else
            {
                IsSuperPeer = false;
            }

            Status = new Neighbour();
            Trust = 0.5;

            OwnSlots = new List<Slot>();
            NeighborSlot = new List<Slot>();

            //myFrame = new Frame();

            availableStorage = 8000;
        }
        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public bool IsSuperPeer
        {
            get
            {
                return isSuperPeer;
            }

            set
            {
                isSuperPeer = value;
            }
        }

        public int Chain
        {
            get
            {
                return chain;
            }

            set
            {
                chain = value;
            }
        }

        public int Ring
        {
            get
            {
                return ring;
            }

            set
            {
                ring = value;
            }
        }

        

        public Neighbour Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public double Trust
        {
            get
            {
                return trust;
            }

            set
            {
                trust = value;
            }
        }

        public List<Slot> OwnSlots
        {
            get
            {
                return ownSlots;
            }

            set
            {
                ownSlots = value;
            }
        }

        public List<Slot> NeighborSlot
        {
            get
            {
                return neighborSlot;
            }

            set
            {
                neighborSlot = value;
            }
        }

       

        public double Size
        {
            get
            {
                return availableStorage;
            }

            set
            {
                availableStorage = value;
            }
        }

        public void PrintNod()
        {
            using (StreamWriter writetext = new StreamWriter("Output.txt", true))
            {
                if (IsSuperPeer)
                {
                    writetext.WriteLine("Node ID: " + Id + "SUPER PEER" + "\r\n****************\r\n");
                }
                else
                {
                    writetext.WriteLine("Node ID: " + Id + "\r\nChain :" + Chain + "\r\nRing :" + Ring + "\r\nContent :\r\n");
                    //foreach (var item in MyFrame.Slots)
                    //{
                    //    writetext.WriteLine("item :" + item.Id + " " + item.FrameID );
                    //}      
                }
            }
        }

        //public void ReceiveSlot(Slot slot)
        //{
        //    MyFrame.Slots.Add(slot);
        //    Decrease(slot);
        //}

        public void Decrease(Slot slot)
        {
            Size = Size - (double)slot.Size;
        }

        public void Increase(Slot slot)
        {
            Size = Size + (double)slot.Size;
        }
    }
}
