using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvolutionaryAlgorithm.Genotypes;
using EvolutionaryAlgorithm.Phenotypes;

namespace EvolutionaryAlgorithm.Developmental_methods
{
    public abstract class AbstractTranslator
    {
        public abstract AbstractPhenotype Translate(BitVector genom);
        protected double binaryToDoubleRange(List<int> bitVector, double min, double max)
        {
            string bitString = String.Join(String.Empty, bitVector);
            double maxInt = Math.Pow(2, bitString.Length) - 1;

            int i = Convert.ToInt32(bitString, 2);

            return min + (i / maxInt) * (max - min);

        }
    }

}
