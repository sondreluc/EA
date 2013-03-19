using System.Collections.Generic;
using System.Linq;
using System;
using EvolutionaryAlgorithm.Developmental_methods;
using EvolutionaryAlgorithm.Evaluators;
using EvolutionaryAlgorithm.Genetic_Operators;
using EvolutionaryAlgorithm.Miscellaneous;
using EvolutionaryAlgorithm.Populations;
using EvolutionaryAlgorithm.Selection_Mechanisms;
using EvolutionaryAlgorithm.Phenotypes;

namespace EvolutionaryAlgorithm.EvolutionaryAlgorithms
{
    internal class MinCog : AbstractEA
    {
        //public List<Node> graph { get; set; }

        public MinCogPhenotype BestOfRun { get; set; }
        public MinCogPhenotype TheOneAndOnly { get; set; }

        public MinCog(int populationSize, int generations, double mutationRate,
                      double crossoverRate, string selectionProtocol, string selectionMechanism)
        {
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

            var translator = new MinCogTranslator();

            FitnessEvaluator = new MinCogFitness();
            Population = new BinaryPopulation(PopulationSize, 272, selectionProtocol, FitnessEvaluator, translator, 0, 2);
            FitnessEvaluator.CalculatePopulationFitness(Population.CurrentPopulation);
        }


        public override void EvolutionLoop()
        {
            for (int i = 0; i < Generations; i++)
            {
                
                Evolve();
                System.Diagnostics.Debug.WriteLine("Generation:" + i);
                System.Diagnostics.Debug.WriteLine("High:" + High);
                System.Diagnostics.Debug.WriteLine("AVG:" + Average);
                System.Diagnostics.Debug.WriteLine("SD:" + SD);
                System.Diagnostics.Debug.WriteLine("Best:" + BestOfRun.Fitness);
                if (TheOneAndOnly == null)
                {
                    TheOneAndOnly = BestOfRun;
                }

                if (BestOfRun.Fitness > TheOneAndOnly.Fitness)
                {
                    TheOneAndOnly = BestOfRun;
                }
            }
        }

        public override void Evolve()
        {
            Population.SelectAdults();
            if (Population.SelectionProtocol == "A-I")
            {
                FitnessEvaluator.CalculatePopulationFitness(Population.CurrentPopulation);
            }
            if (SelectionMechanism != "Tournament")
            {
                ParentSelector.NormalizeRouletteWheel(Population.CurrentPopulation);
            }
            GenerateOffspring();

            High = Population.CurrentPopulation.Max(x => x.Fitness);
            BestOfRun = (MinCogPhenotype)Population.CurrentPopulation.FirstOrDefault(x => x.Fitness >= High);
            Average = Population.CurrentPopulation.Average(x => x.Fitness);
            SD = Math.Sqrt(Population.CurrentPopulation.Sum(x => Math.Pow((x.Fitness - Average), 2)) /
                           Population.CurrentPopulation.Count);
        }
    }
}