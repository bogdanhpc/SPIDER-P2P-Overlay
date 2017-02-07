namespace SPIDER.VOD
{
    public class Slot
    {
        private int id;
        private int frameID;
        private double size;

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

        public int FrameID
        {
            get
            {
                return frameID;
            }

            set
            {
                frameID = value;
            }
        }

        public Slot(int id, int frameId)
        {
            Id = id;
            FrameID = frameId;
        }
    }

    
}