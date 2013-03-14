using System.Collections.Generic;
using EvolutionaryAlgorithm.Evaluators;
using EvolutionaryAlgorithm.Genetic_Operators;
using EvolutionaryAlgorithm.Genotypes;
using EvolutionaryAlgorithm.Phenotypes;
using EvolutionaryAlgorithm.Populations;
using EvolutionaryAlgorithm.Selection_Mechanisms;

namespace EvolutionaryAlgorithm.EvolutionaryAlgorithms
{
    public abstract class AbstractEA
    {
        public AbstractSelectionMechanism ParentSelector { get; set; }
        public string SelectionMechanism { get; set; }
        public AbstractFitnessEvaluator FitnessEvaluator { get; set; }
        public BinaryOperators GeneticOperators { get; set; }
        public int PopulationSize { get; set; }
        public int Generations { get; set; }
        public double High { get; set; }
        public double Average { get; set; }
        public double SD { get; set; }
        public BinaryPopulation Population { get; set; }
        public double MutationRate { get; set; }
        public double CrossoverRate { get; set; }
        public abstract void EvolutionLoop();
        public abstract void Evolve();

        public void GenerateOffspring()
        {
            int size;
            if (Population.SelectionProtocol == "A-II")
            {
                size = PopulationSize;
            }
            else
            {
                size = PopulationSize/2;
            }
            for (int i = 0; i < size; i++)
            {
                List<AbstractPhenotype> parents = SelectionMechanism == "Tournament"
                                                      ? ParentSelector.TournamentSelection(
                                                          Population.CurrentPopulation, 2, 2, 0.25)
                                                      : ParentSelector.SelectParents(Population.CurrentPopulation, 2);
                List<BitVector> offsprings = GeneticOperators.Crossover(parents[0], parents[1], CrossoverRate);

                GeneticOperators.Mutate(MutationRate, offsprings[0]);
                GeneticOperators.Mutate(MutationRate, offsprings[1]);

                Population.Offsprings.AddRange(offsprings);
            }
        }
    }
}