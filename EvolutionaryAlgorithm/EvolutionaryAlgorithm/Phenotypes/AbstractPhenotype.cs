using System;
using EvolutionaryAlgorithm.Genotypes;

namespace EvolutionaryAlgorithm.Phenotypes
{
    public abstract class AbstractPhenotype:IComparable<AbstractPhenotype>
    {
        public AbstractGenotype Genotype { get; set; }
        public double Fitness { get; set; }
        public double RouletteProportion { get; set; }

        public int CompareTo(AbstractPhenotype obj)
        {
            return Fitness.CompareTo(obj.Fitness);
        }
    }
}
