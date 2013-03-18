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
        public List<Node> InputNodes { get; set; }
        public Node BiasNode { get; set; }
        public List<Node> HiddenNodes { get; set; }
        public List<Node> OutputNodes { get; set; }
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
            createGraph();

            var translator = new MinCogTranslator(InputNodes, BiasNode, HiddenNodes, OutputNodes);

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


        private void createGraph()
        {
            // Input Nodes (Sensor)
            var in1 = new Node("in1");
            var in2 = new Node("in2");
            var in3 = new Node("in3");
            var in4 = new Node("in4");
            var in5 = new Node("in5");

            InputNodes = new List<Node> {in1, in2, in3, in4, in5};
            
            // Bias Node
            BiasNode = new Node("bias");
            BiasNode.Output = 1.0;

            // Hidden Nodes
            var hidden1 = new Node("hidden1");
            hidden1.ActivationLevel = 0;
            var hidden2 = new Node("hidden2");
            hidden2.ActivationLevel = 0;

            hidden1.addConnections(in1, in2, in3, in4, in5, hidden1, hidden2, BiasNode);
            hidden2.addConnections(in1, in2, in3, in4, in5, hidden1, hidden2, BiasNode);

            HiddenNodes = new List<Node> {hidden1, hidden2};

            //  Output Nodes (Motor)
            var out1 = new Node("out1");
            var out2 = new Node("out2");

            out1.addConnections(hidden1, hidden2, out1, out2, BiasNode);
            out2.addConnections(hidden1, hidden2, out1, out2, BiasNode);

            OutputNodes = new List<Node> {out1, out2};
        }

        //private void createGraph()
        //{
        //    //  Output Nodes (Motor)
        //    List<Node> nodes = new List<Node>();
        //    Node out1 = new Node();
        //    Node out2 = new Node();

        //    out1.addConnections(out1, out2);
        //    out2.addConnections(out2, out1);

        //    graph.Add(out1);
        //    graph.Add(out2);

        //    // Hidden Nodes
        //    Node hidden1 = new Node();
        //    Node hidden2 = new Node();

        //    hidden1.addConnections(hidden1, hidden2, out1, out2);
        //    hidden2.addConnections(hidden2, hidden1, out1, out2);

        //    graph.Add(hidden1);
        //    graph.Add(hidden2);

        //    // Input Nodes (Sensor)
        //    Node in1 = new Node();
        //    Node in2 = new Node();
        //    Node in3 = new Node();
        //    Node in4 = new Node();
        //    Node in5 = new Node();

        //    in1.addConnections(hidden1, hidden2);
        //    in2.addConnections(hidden1, hidden2);
        //    in3.addConnections(hidden1, hidden2);
        //    in4.addConnections(hidden1, hidden2);
        //    in5.addConnections(hidden1, hidden2);

        //    graph.Add(in1);
        //    graph.Add(in2);
        //    graph.Add(in3);
        //    graph.Add(in4);
        //    graph.Add(in5);

        //    // Bias Node
        //    Node bias = new Node();

        //    bias.addConnections(hidden1, hidden2, out1, out2);

        //    graph.Add(bias);

        //}
    }
}