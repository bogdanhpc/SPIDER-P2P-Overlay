using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace SPIDER
{
    class Nod : INod
    {
        private string id;
        private bool isSuperPeer;
        private int chain;
        private int ring;
        private string content;
        private Neighbour status;
        private double trust;

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

        public string Content
        {
            get
            {
                return content;
            }

            set
            {
                content = value;
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



        public Nod()
        {
            Id = string.Empty;
            IsSuperPeer = false;
            Chain = -1;
            Ring = -1;
            Status = new Neighbour();
            
            Content = CreateContnt();
            Trust = 0.5;
        }
        public Nod(int chain, int ring, bool flag)
        {
            Chain = chain;
            Ring = ring;
            Id = chain.ToString() + "-" + ring.ToString() + " ";

            Content = CreateContnt();

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
        }

        private string CreateContnt()
        {
            byte[] data = new byte[4];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                for (int i = 0; i < 10; i++)
                {
                    // Fill buffer.
                    rng.GetBytes(data);

                }
            }
            SHA1Managed hashstring = new SHA1Managed();
            byte[] hash = hashstring.ComputeHash(data);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;
        }

        //public bool IsSuperPeer()
        //{
        //    if (isSuperPeer == true)
        //        return true;
        //    else
        //        return false;
        //}

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
                    writetext.WriteLine("Node ID: " + Id + "\r\nChain :" + Chain + "\r\nRing :" + Ring
           + "\r\nContent :" + Content + "\r\n****************\r\n");
                }
            }
        }

    }

}
