using EvolutionaryAlgorithm.Developmental_methods;
using EvolutionaryAlgorithm.Genetic_Operators;
using EvolutionaryAlgorithm.Populations;
using EvolutionaryAlgorithm.Selection_Mechanisms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionaryAlgorithm.EvolutionaryAlgorithms
{
    class SpikingNeuron:AbstractEA
    {
        public List<double> goalSpike;

        public SpikingNeuron(int populationSize, int generations, int dataSetNumber,
                      double mutationRate, double crossoverRate, string selectionProtocol, string selectionMechanism)
        {
            //FitnessEvaluator = new OneMaxFitness(goalVector);
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
            goalSpike = readDataSet(dataSetNumber);
            Population = new BinaryPopulation(PopulationSize, 33, selectionProtocol, FitnessEvaluator, new IzhikevichTranslator(), 0, 2);
            FitnessEvaluator.CalculatePopulationFitness(Population.CurrentPopulation);
        }

        private List<double> readDataSet(int number)
        {
            string filename = @"\TrainingData\izzy-train" + number + ".dat";

            string filepath = Environment.CurrentDirectory + filename;
            filepath = filepath.Replace(@"\bin\Debug", "");

            List<double> data = new List<double>();
            foreach (string line in File.ReadLines(filepath))
                foreach (string value in line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    double d = 0.0;
                    double.TryParse(value, out d);
                    data.Add(d);
                }

            return data;
        }
    }
}
