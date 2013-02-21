using System;

namespace EvolutionaryAlgorithm.Genotypes
{
    public abstract class AbstractGenotype:IComparable<AbstractGenotype>
    {

        public int CompareTo(AbstractGenotype other)
        {
            throw new NotImplementedException();
        }
    }
}
