using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPIDER.VOD
{
    public class VideoFile
    {
        private int id;
        private List<Frame> frames;
        private double size;

        public VideoFile(int id)
        {
            Id = id;
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

        public List<Frame> Frames
        {
            get
            {
                return frames;
            }

            set
            {
                frames = value;
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
