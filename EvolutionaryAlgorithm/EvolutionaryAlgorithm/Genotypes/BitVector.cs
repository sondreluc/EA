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

        public List<int> GetRange(int index, int count)
        {
            return Vector.GetRange(index, count);
        }
    }
}
