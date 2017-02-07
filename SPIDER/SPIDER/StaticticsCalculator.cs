using System;
using System.Collections.Generic;
using System.Linq;

namespace SPIDER
{
    internal class StaticticsCalculator:IStaticticsCalculator
    {
        private List<double> samples = new List<double>();

        public StaticticsCalculator(List<double> samples)
        {
            Samples = samples;
        }

        public List<double> Samples
        {
            get
            {
                return samples;
            }

            set
            {
                samples = value;
            }
        }

        public double CoeficientdeVariatie()
        {
            return DeviatiaStandard() / MediaAritmetica(); 
        }

        public double coficientulSkewness()
        {
            throw new NotImplementedException();
        }

        public double DeviatiaStandard()
        {
            double ret = 0;
            int count = Samples.Count();
            if (count > 1)
            {
                //Compute the Average
                double avg = Samples.Average();

                //Perform the Sum of (value-avg)^2
                double sum = Samples.Sum(d => (d - avg) * (d - avg));

                //Put it all together
                ret = Math.Sqrt(sum / count-1);
            }
            return ret;
        }

        public double MediaAritmetica()
        {
            return Samples.Average();
        }

        public double MediaGeometrica()
        {
            return Math.Pow(Samples.Aggregate((prod, item) => prod * item), ((double)1.0 / Samples.Count()));
        }


        public double Variatia()
        {
            throw new NotImplementedException();
        }
    }
}