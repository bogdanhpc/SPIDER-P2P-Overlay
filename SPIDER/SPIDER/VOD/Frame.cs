using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPIDER.VOD
{
    public class Frame
    {
        private double size; 
        private int id;
        private int fileID;
        private List<Slot> slots;

        public Frame(int id, int fileId)
        {
            slots = new List<Slot>();
            Id = id;
            FileID = fileId;
        }

        public Frame()
        {
            slots = new List<Slot>();
        }

        public int FileID
        {
            get
            {
                return fileID;
            }

            set
            {
                fileID = value;
            }
        }

        public int Id
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

        public List<Slot> Slots
        {
            get
            {
                return slots;
            }

            set
            {
                slots = value;
            }
        }

        public double Size
        {
            get
            {
                return size;
            }

            set
            {
                size = value;
            }
        }
    }
}
