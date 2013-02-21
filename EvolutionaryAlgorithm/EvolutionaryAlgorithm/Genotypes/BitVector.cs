using System.Collections.Generic;


namespace EvolutionaryAlgorithm.Genotypes
{
    public class BitVector:AbstractGenotype
    {
        public List<int> Vector { get; set; }

        public BitVector()
        {
            Vector = new List<int>();
        }

    }
}
