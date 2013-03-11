using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvolutionaryAlgorithm.Miscellaneous;

namespace EvolutionaryAlgorithm.EvolutionaryAlgorithms
{
    class MinCogAgent:AbstractEA
    {
        //public List<Node> graph { get; set; }
        public List<Node> InputNodes { get; set; }
        public Node BiasNode { get; set; }
        public List<Node> HiddenNodes { get; set; }
        public List<Node> OutPutNodes { get; set; }

        public MinCogAgent(int populationSize, int generations, double mutationRate, 
            double crossoverRate, string selectionProtocol, string selectionMechanism)
        {
            createGraph();
        }

        private void createGraph()
        {
            // Input Nodes (Sensor)
            Node in1 = new Node();
            Node in2 = new Node();
            Node in3 = new Node();
            Node in4 = new Node();
            Node in5 = new Node();

            InputNodes = new List<Node>(){ in1, in2, in3, in4, in5 };

            // Bias Node
            BiasNode = new Node();

            // Hidden Nodes
            Node hidden1 = new Node();
            Node hidden2 = new Node();

            hidden1.addConnections(in1, in2, in3, in4, in5, hidden1, hidden2, BiasNode);
            hidden2.addConnections(in1, in2, in3, in4, in5, hidden1, hidden2, BiasNode);

            HiddenNodes = new List<Node>() { hidden1, hidden2 };

            //  Output Nodes (Motor)
            Node out1 = new Node();
            Node out2 = new Node();

            out1.addConnections(hidden1, hidden2, out1, out2, BiasNode);
            out2.addConnections(hidden1, hidden2, out1, out2, BiasNode);

            OutPutNodes = new List<Node>() { out1, out2 };
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
