using System.Collections.Generic;

namespace EvolutionaryAlgorithm.Genotypes
{
    public class BitVector : AbstractGenotype
    {
        public BitVector()
        {
            Vector = new List<int>();
        }

        public List<int> Vector { get; set; }

        public List<int> GetRange(int index, int count)
        {
            return Vector.GetRange(index, count);
        }
    }
}