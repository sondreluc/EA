using EvolutionaryAlgorithm.Genotypes;
using EvolutionaryAlgorithm.Phenotypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionaryAlgorithm.Developmental_methods
{
    class IzhikevichTranslator:AbstractTranslator
    {
        public override AbstractPhenotype Translate(BitVector genom)
        {
            //NB: Requires explicit size genom size of 33
            double a = binaryToDoubleRange(genom.GetRange(0,7), 0.001, 0.2); //200 values : 8 bit
            double b = binaryToDoubleRange(genom.GetRange(7,7), 0.01, 0.3); // 30 values : 5 bit
            double c = binaryToDoubleRange(genom.GetRange(14,7), -80.0, -30.0); // 51 values : 6 bit
            double d = binaryToDoubleRange(genom.GetRange(21,7), 0.1, 10.0); // 100 values : 7 bit
            double k = binaryToDoubleRange(genom.GetRange(28,7), 0.01, 1.0); // 100 values : 7 bit

            return new IzhikevichPhenotype(a, b, c, d, k){Genotype = genom, Fitness = 0.0, RouletteProportion = 0.0};
        }


        //private double binaryToDoubleRange(List<int> bitVector, double min, double max)
        //{
        //    //Ref: p.17 Bio-Inspired AI
        //    //Convert to integer
        //    int pos = bitVector.Count;
        //    double maxInt = Math.Pow(2, pos) - 1;
        //    double value = 0;

        //    foreach (int b in bitVector)
        //    {
        //        pos--;
        //        value += Math.Pow(b * 2, pos);
        //    }
        //    // double equivalent in range [min, max]
        //    return min + (value / maxInt) * (max - min);
        //}

        //Get valid value for specified interval
        public double binaryToDoubleRange(List<int> list, double min, double max)
        {
            double difference = Math.Abs(max - min);
            double differenceDivided = difference / 127;



            string intString = list[0].ToString() + list[1].ToString() + list[2].ToString() + list[3].ToString() + list[4].ToString() + list[5].ToString() + list[6].ToString();
            int i = Convert.ToInt32(intString, 2);

            return min + (i * differenceDivided);

        }

    }
}
