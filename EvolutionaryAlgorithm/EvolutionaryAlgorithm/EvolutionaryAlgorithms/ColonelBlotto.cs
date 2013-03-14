using System;
using System.Diagnostics;
using System.Linq;
using EvolutionaryAlgorithm.Developmental_methods;
using EvolutionaryAlgorithm.Evaluators;
using EvolutionaryAlgorithm.Genetic_Operators;
using EvolutionaryAlgorithm.Phenotypes;
using EvolutionaryAlgorithm.Populations;
using EvolutionaryAlgorithm.Selection_Mechanisms;

namespace EvolutionaryAlgorithm.EvolutionaryAlgorithms
{
    public class ColonelBlotto : AbstractEA
    {
        public double AverageEntropy;
        public double LossFraction;
        public int NumberOfBattles;
        public double RedeploymentFraction;
        public ColonelBlottoPhenotype Winner;

        public ColonelBlotto(int populationSize, int generations, int numberOfBattles,
                             double mutationRate, double crossoverRate, string selectionProtocol,
                             string selectionMechanism, double redeploymentFraction, double lossFraction)
        {
            FitnessEvaluator = new ColonelBlottoFitness();
            GeneticOperators = new BinaryOperators();
            PopulationSize = populationSize;
            Generations = generations;
            MutationRate = mutationRate;
            CrossoverRate = crossoverRate;
            NumberOfBattles = numberOfBattles;
            RedeploymentFraction = redeploymentFraction;
            LossFraction = lossFraction;
            AverageEntropy = 0.0;

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
            Population = new BinaryPopulation(PopulationSize, NumberOfBattles, selectionProtocol, FitnessEvaluator,
                                              new ColonelBlottoTranslator(), 0, 11);
        }

        public override void EvolutionLoop()
        {
            Debug.WriteLine("Running Colonel Blotto Evolutionary Algorithm.");
            Debug.WriteLine("Number of generations: " + Generations);
            Debug.WriteLine("Population size: " + PopulationSize);
            Debug.WriteLine("Mutation rate: " + MutationRate);
            Debug.WriteLine("Selection protocol: " + Population.SelectionProtocol);
            Debug.WriteLine("Selection mechanism: " + SelectionMechanism);
            Debug.WriteLine("Number of battles: " + NumberOfBattles);
            Debug.WriteLine("Loss fraction: " + LossFraction);
            Debug.WriteLine("Redeployment Fraction: " + RedeploymentFraction);

            for (int i = 0; i < Generations; i++)
            {
                Debug.WriteLine("Generation " + i);
                Evolve();
            }
        }

        public override void Evolve()
        {
            Population.SelectAdults();
            AverageEntropy = CalculateAverageEntropy();

            //System.Diagnostics.Debug.WriteLine("Average Entropy before war: " + AverageEntropy);
            RunWars();
            FitnessEvaluator.CalculatePopulationFitness(Population.CurrentPopulation);
            if (SelectionMechanism != "Tournament")
            {
                ParentSelector.NormalizeRouletteWheel(Population.CurrentPopulation);
            }
            GenerateOffspring();

            High = Population.CurrentPopulation.Max(x => x.Fitness);
            Average = Population.CurrentPopulation.Average(x => x.Fitness);
            SD =
                Math.Sqrt(Population.CurrentPopulation.Sum(x => Math.Pow((x.Fitness - Average), 2))/
                          Population.CurrentPopulation.Count);
            GetWinner();

            //System.Diagnostics.Debug.WriteLine("Highest fitness: " + High);
            //System.Diagnostics.Debug.WriteLine("Average fitness: " + Average);
            //System.Diagnostics.Debug.WriteLine("Standard deviation: " + SD);
            //System.Diagnostics.Debug.WriteLine("The winning strategy is:");
            Debug.WriteLine(Winner.ArmyToString());
        }

        public void War(ColonelBlottoPhenotype army1, ColonelBlottoPhenotype army2)
        {
            for (int i = 0; i < army1.Army.Count; i++)
            {
                if ((army1.Army[i]*army1.Strength) > (army2.Army[i]*army2.Strength))
                {
                    army1.Wins++;
                    army1.Redeployment(i, (army1.Army[i] - army2.Army[i]), RedeploymentFraction);
                    army2.Strength -= LossFraction;
                }
                else if ((army2.Army[i]*army2.Strength) > (army1.Army[i]*army1.Strength))
                {
                    army2.Wins++;
                    army2.Redeployment(i, (army2.Army[i] - army1.Army[i]), RedeploymentFraction);
                    army1.Strength -= LossFraction;
                }
                else
                {
                    army1.Ties++;
                    army2.Ties++;
                }
            }
            army1.Strength = 1.0;
            army2.Strength = 1.0;
        }

        public void RunWars()
        {
            for (int i = 0; i < Population.CurrentPopulation.Count - 1; i++)
            {
                for (int j = i + 1; j < Population.CurrentPopulation.Count; j++)
                {
                    War((ColonelBlottoPhenotype) Population.CurrentPopulation[i],
                        (ColonelBlottoPhenotype) Population.CurrentPopulation[j]);
                }
            }
        }

        public double CalculateAverageEntropy()
        {
            return Population.CurrentPopulation.Cast<ColonelBlottoPhenotype>().Average(phenotype => phenotype.Entropy);
        }

        public void GetWinner()
        {
            double max = Population.CurrentPopulation.Cast<ColonelBlottoPhenotype>().Max(x => x.Fitness);
            Winner = Population.CurrentPopulation.Cast<ColonelBlottoPhenotype>().FirstOrDefault(x => x.Fitness >= max);
        }
    }
}