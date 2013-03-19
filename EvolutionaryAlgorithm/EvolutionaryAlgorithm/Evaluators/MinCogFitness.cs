using System;
using System.Collections.Generic;
using EvolutionaryAlgorithm.Phenotypes;
using EvolutionaryAlgorithm.Evaluators.MinCogSimulator;

namespace EvolutionaryAlgorithm.Evaluators
{
    internal class MinCogFitness : AbstractFitnessEvaluator
    {
        public override void CalculateFitness(AbstractPhenotype phenotype)
        {
            var sim = new MinCogSimulator.MinCogSimulator((MinCogPhenotype)phenotype);
            sim.Simulate();
            int score = sim.GoodHits + sim.BadHits;
            phenotype.Fitness = (score > 0) ? score : 0;
        }

        public override void CalculatePopulationFitness(List<AbstractPhenotype> phenotypes)
        {
            foreach (AbstractPhenotype abstractPhenotype in phenotypes)
            {
                CalculateFitness(abstractPhenotype);
            }
        }
    }
}