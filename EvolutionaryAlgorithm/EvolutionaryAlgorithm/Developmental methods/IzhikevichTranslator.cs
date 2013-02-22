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
            double a = binaryToDoubleRange(genom.GetRange(0,8), 0.001, 0.2); //200 values : 8 bit
            double b = binaryToDoubleRange(genom.GetRange(8,13), 0.01, 0.3); // 30 values : 5 bit
            double c = binaryToDoubleRange(genom.GetRange(13,19), -80, -20); // 51 values : 6 bit
            double d = binaryToDoubleRange(genom.GetRange(19,26), 0.1, 10); // 100 values : 7 bit
            double k = binaryToDoubleRange(genom.GetRange(26,33), 0.01, 1); // 100 values : 7 bit

            return new IzhikevichPhenotype(a, b, c, d, k);
        }


        private double binaryToDoubleRange(List<int> bitVector, double min, double max)
        {
            //Ref: p.17 Bio-Inspired AI
            //Convert to integer
            int pos = bitVector.Count;
            double maxInt = Math.Pow(2, pos) - 1;
            double value = 0;

            foreach (int b in bitVector)
            {
                pos--;
                value += Math.Pow(b * 2, pos);
            }
            // double equivalent in range [min, max]
            return min + (value / maxInt) * (max - min);
        }
    }
}
