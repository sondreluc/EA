using System;
using System.Collections.Generic;
using EvolutionaryAlgorithm.Genotypes;
using EvolutionaryAlgorithm.Phenotypes;

namespace EvolutionaryAlgorithm.Genetic_Operators
{
    public class BinaryOperators : AbstractGeneticOperators
    {
        private readonly Random _random;

        public BinaryOperators()
        {
            _random = new Random();
        }

        public override void Mutate(double mutationRate, BitVector genotype)
        {
            double randomDouble = _random.NextDouble();

            if (randomDouble <= mutationRate)
            {
                int randomIndex = _random.Next(0, genotype.Vector.Count);
                genotype.Vector[randomIndex] = (genotype.Vector[randomIndex] == 0 ? 1 : 0);
            }
        }

        public override List<BitVector> Crossover(AbstractPhenotype parent1, AbstractPhenotype parent2,
                                                  double crossoverRate)
        {
            var par1 = (BitVector) parent1.Genotype;
            var par2 = (BitVector) parent2.Genotype;

            var offspring = new List<BitVector>();

            int randomIndex = _random.Next(1, par1.Vector.Count);
            double randomDouble = _random.NextDouble();
            var child1 = new BitVector();
            var child2 = new BitVector();

            if (randomDouble <= crossoverRate)
            {
                for (int i = 0; i < par1.Vector.Count; i++)
                {
                    if (i <= par1.Vector.Count/2)
                    {
                        child1.Vector.Add(par1.Vector[i]);
                        child2.Vector.Add(par2.Vector[i]);
                    }
                    else
                    {
                        child1.Vector.Add(par2.Vector[i]);
                        child2.Vector.Add(par1.Vector[i]);
                    }
                }
            }
            else
            {
                child1.Vector = par1.Vector;
                child2.Vector = par2.Vector;
            }

            offspring.Add(child1);
            offspring.Add(child2);
            return offspring;
        }
    }
}