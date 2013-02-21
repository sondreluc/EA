using System.Collections.Generic;
using EvolutionaryAlgorithm.Genotypes;
using EvolutionaryAlgorithm.Phenotypes;

namespace EvolutionaryAlgorithm.Evaluators
{
    public class OneMaxFitness:AbstractFitnessEvaluator
    {
        public List<int> GoalVector;
 
        public OneMaxFitness(List<int> goalVector)
        {
            GoalVector = goalVector;
        }
        public override void CalculateFitness(AbstractPhenotype phenotype)
        {
            BitVector bitVector =(BitVector)phenotype.Genotype;
            int count = 0;
            for (int i = 0; i < GoalVector.Count; i++)
            {
                if (bitVector.Vector[i] == GoalVector[i])
                {
                    count++;
                }
            }
            
            phenotype.Fitness = ((double)count/bitVector.Vector.Count);

            

            
        }

        public override void CalculatePopulationFitness(List<AbstractPhenotype> phenotypes)
        {
            foreach (var phenotype in phenotypes)
            {
                CalculateFitness(phenotype);
            }
        }

    }
}
