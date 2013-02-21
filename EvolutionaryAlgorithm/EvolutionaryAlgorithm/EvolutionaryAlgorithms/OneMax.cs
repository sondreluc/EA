using System;
using System.Collections.Generic;
using System.Linq;
using EvolutionaryAlgorithm.Developmental_methods;
using EvolutionaryAlgorithm.Evaluators;
using EvolutionaryAlgorithm.Genetic_Operators;
using EvolutionaryAlgorithm.Genotypes;
using EvolutionaryAlgorithm.Phenotypes;
using EvolutionaryAlgorithm.Populations;
using EvolutionaryAlgorithm.Selection_Mechanisms;

namespace EvolutionaryAlgorithm.EvolutionaryAlgorithms
{
    public class OneMax:AbstractEA
    {
        public bool win = false;
        public OneMax(int populationSize, int generations, List<int> goalVector,
                      double mutationRate, double crossoverRate, string selectionProtocol, string selectionMechanism)
        {
            FitnessEvaluator = new OneMaxFitness(goalVector);
            GeneticOperators = new BinaryOperators();
            PopulationSize = populationSize;
            Generations = generations;
            MutationRate = mutationRate;
            CrossoverRate = crossoverRate;

            switch (selectionMechanism.ToLower())
            {
                case "fitness-prop":
                    ParentSelector = new FitnessProportionate();
                    SelectionMechanism = selectionMechanism;
                    break;
                case "sigma":
                    ParentSelector = new SigmaScaling();
                    SelectionMechanism = selectionMechanism;
                    break;
                case "tournament":
                    ParentSelector = new Tournament();
                    SelectionMechanism = selectionMechanism;
                    break;
                case "rank":
                    ParentSelector = new Rank();
                    SelectionMechanism = selectionMechanism;
                    break;
            }
            Population = new BinaryPopulation(PopulationSize, goalVector.Count, selectionProtocol, FitnessEvaluator, new OneMaxTranslator(), 0, 2);
            FitnessEvaluator.CalculatePopulationFitness(Population.CurrentPopulation);
        }


        public override void EvolutionLoop()
        {
            //System.Diagnostics.Debug.WriteLine("Running OneMax Evolutionary Algorithm.");
            //System.Diagnostics.Debug.WriteLine("Maximum number of generations: "+Generations);
            //System.Diagnostics.Debug.WriteLine("Population size: "+PopulationSize);
            //System.Diagnostics.Debug.WriteLine("Mutation rate: " + MutationRate);
            //System.Diagnostics.Debug.WriteLine("Selection protocol: " + Population.SelectionProtocol);
            //System.Diagnostics.Debug.WriteLine("Selection mechanism: " + SelectionMechanism);
            //System.Diagnostics.Debug.Write("[");
            ////foreach (int i in (OneMaxFitness)FitnessEvaluator.GoalVector)
            //{
            //    System.Diagnostics.Debug.Write(i+" ");
            //} 
            
            //System.Diagnostics.Debug.WriteLine("]");

            for (int i = 0; i < Generations; i++)
            {
                Evolve();
                //System.Diagnostics.Debug.WriteLine("Generation " + i);
                //System.Diagnostics.Debug.WriteLine("Highest fitness: " + High);
                //System.Diagnostics.Debug.WriteLine("Average fitness: " + Average);
                //System.Diagnostics.Debug.WriteLine("Standard deviation: " + SD);

                if ((Population.CurrentPopulation.Max(x => x.Fitness)) >= 1.0)
                {
                    //System.Diagnostics.Debug.WriteLine("Problem solved!");
                    win = true;
                    break;
                }
            }

        }
        public override void Evolve()
        {
            Population.SelectAdults();

            FitnessEvaluator.CalculatePopulationFitness(Population.CurrentPopulation);

            if (SelectionMechanism != "Tournament")
            {
                ParentSelector.NormalizeRouletteWheel(Population.CurrentPopulation);
            }

            GenerateOffspring();
            High = Population.CurrentPopulation.Max(x => x.Fitness);
            Average = Population.CurrentPopulation.Average(x => x.Fitness);
            SD =
                Math.Sqrt(Population.CurrentPopulation.Sum(x => Math.Pow((x.Fitness - Average), 2)) /
                          Population.CurrentPopulation.Count);
        }        
    }
}
