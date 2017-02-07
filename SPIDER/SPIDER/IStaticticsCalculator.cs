using System.Collections.Generic;

namespace SPIDER
{
    public interface IStaticticsCalculator
    {
        List<double> Samples { get; set; }

        double MediaAritmetica();
        double MediaGeometrica();
        double Variatia();
        double DeviatiaStandard();
        double CoeficientdeVariatie();
        double coficientulSkewness();
    }
}