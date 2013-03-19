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
            double score = sim.GoodHits - sim.BadHits*(1.5);
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