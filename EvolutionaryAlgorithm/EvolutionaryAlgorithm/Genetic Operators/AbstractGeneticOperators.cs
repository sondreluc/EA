using System.Collections.Generic;
using EvolutionaryAlgorithm.Genotypes;
using EvolutionaryAlgorithm.Phenotypes;

namespace EvolutionaryAlgorithm.Genetic_Operators
{
    public abstract class AbstractGeneticOperators
    {
        public abstract void Mutate(double rate, BitVector genotype);

        public abstract List<BitVector> Crossover(AbstractPhenotype parent1, AbstractPhenotype parent2,
                                                  double crossoverRate);
    }
}