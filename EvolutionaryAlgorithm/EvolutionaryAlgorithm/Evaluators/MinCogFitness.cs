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
            phenotype.Fitness = sim.GoodHits + sim.BadHits;
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