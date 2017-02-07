namespace SPIDER
{
    public class Provider
    {
        private string name;
        private int rezolution;
        private double? bitrate;
        private double? requiredSize; // required size on disk for 1 second


        public Provider(string name, int rezolution, double? bitrate, double? requiredSize )
        {
            Name = name;
            Rezolution = rezolution;
            Bitrate = bitrate;
            RequiredSize = requiredSize;
        }
        public double? Bitrate
        {
            get
            {
                return bitrate;
            }

            set
            {
                bitrate = value;
            }
        }

        public int Rezolution
        {
            get
            {
                return rezolution;
            }

            set
            {
                rezolution = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public double? RequiredSize
        {
            get
            {
                return requiredSize;
            }

            set
            {
                requiredSize = value;
            }
        }
    }
}