using EvolutionaryAlgorithm.Developmental_methods;
using EvolutionaryAlgorithm.Evaluators;
using EvolutionaryAlgorithm.Genetic_Operators;
using EvolutionaryAlgorithm.Phenotypes;
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
        public IzhikevichPhenotype BestOfRun { get; set; }
        public int K { get; set; }
        public int J { get; set; }
        public double PrevFitness { get; set; }

        public SpikingNeuron(int populationSize, int generations, int dataSetNumber,
                      double mutationRate, double crossoverRate, string selectionProtocol, string selectionMechanism, string sdm)
        {
            
            GeneticOperators = new BinaryOperators();
            PopulationSize = populationSize;
            Generations = generations;
            MutationRate = mutationRate;
            CrossoverRate = crossoverRate;

            K = 0;
            J = 0;
            PrevFitness = 0.0;
            
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
            Population = new BinaryPopulation(PopulationSize, 35, selectionProtocol, FitnessEvaluator, new IzhikevichTranslator(), 0, 2);
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
                Evolve();
                foreach (var value in BestOfRun.Train)
                {
                    System.Diagnostics.Debug.Write(value+" ");
                    
                }
                System.Diagnostics.Debug.WriteLine("");
                System.Diagnostics.Debug.WriteLine("A: " + BestOfRun.a + ", B: "+BestOfRun.b + ", C: "+BestOfRun.c + ", D: "+BestOfRun.d + ", K: "+BestOfRun.k);
                System.Diagnostics.Debug.WriteLine("");
                
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
            BestOfRun = (IzhikevichPhenotype)Population.CurrentPopulation.FirstOrDefault(x => x.Fitness >= High);
            updateMutationRate();
            Average = Population.CurrentPopulation.Average(x => x.Fitness);
            SD = Math.Sqrt(Population.CurrentPopulation.Sum(x => Math.Pow((x.Fitness - Average), 2)) /
                      Population.CurrentPopulation.Count);
        }

        private void updateMutationRate()
        {
            if (High == PrevFitness)
            {
                K++;
                J = 0;
            }
            else
            {
                J++;
                K = 0;
            }
            PrevFitness = High;

            if (K == 10)
            {
                MutationRate = Math.Min(MutationRate + 0.3, 1);
                K = 0;
            }
            if (J == 10)
            {
                MutationRate = Math.Max(MutationRate - 0.3, 0);
                J = 0;
            }
        }
    }
}
