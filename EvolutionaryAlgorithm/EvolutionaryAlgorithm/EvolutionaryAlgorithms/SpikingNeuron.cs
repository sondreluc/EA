using EvolutionaryAlgorithm.Developmental_methods;
using EvolutionaryAlgorithm.Evaluators;
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
        public List<double> GoalSpike;
        public SpikingNeuron(int populationSize, int generations, int dataSetNumber,
                      double mutationRate, double crossoverRate, string selectionProtocol, string selectionMechanism, string sdm)
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
            GoalSpike = readDataSet(dataSetNumber);
            FitnessEvaluator = new IzhikevichFitness(sdm, GoalSpike);
            Population = new BinaryPopulation(PopulationSize, 33, selectionProtocol, FitnessEvaluator, new IzhikevichTranslator(), 0, 2);
            FitnessEvaluator.CalculatePopulationFitness(Population.CurrentPopulation);
        }

        private List<double> readDataSet(int number)
        {
            string filename = @"\Training Data\izzy-train" + number + ".dat";

            string filepath = Environment.CurrentDirectory + filename;
            filepath = filepath.Replace(@"\bin\Debug", "");

            List<double> data = new List<double>();
            foreach (string line in File.ReadLines(filepath))
                foreach (string value in line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    double d = Convert.ToDouble(value.Replace('.',','));
                    data.Add(d);
                }

            return data;
        }

        public override void EvolutionLoop()
        {
            for (int i = 0; i < Generations; i++)
            {
                var max = Population.CurrentPopulation.Max(x => x.Fitness);
                System.Diagnostics.Debug.WriteLine(max);
                Evolve();
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
        }
    }
}
