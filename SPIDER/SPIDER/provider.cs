namespace SPIDER
{
    public class Provider
    {
        private string name;
        private int rezolution;
        private double? bitrate;


        public Provider(string name, int rezolution, double? bitrate )
        {
            Name = name;
            Rezolution = rezolution;
            Bitrate = bitrate;
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
    }
}