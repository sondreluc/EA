using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionaryAlgorithm.Miscellaneous
{
    class Network
    {
        public List<Node> InputNodes { get; set; }
        public Node BiasNode { get; set; }
        public List<Node> HiddenNodes { get; set; }
        public List<Node> OutputNodes { get; set; }


        public void createGraph()
        {
            // Input Nodes (Sensor)
            var in1 = new Node("in1");
            var in2 = new Node("in2");
            var in3 = new Node("in3");
            var in4 = new Node("in4");
            var in5 = new Node("in5");

            InputNodes = new List<Node> { in1, in2, in3, in4, in5 };

            // Bias Node
            BiasNode = new Node("bias");
            BiasNode.Output = 1.0;

            // Hidden Nodes
            var hidden1 = new Node("hidden1");
            hidden1.InternalState = 0;
            var hidden2 = new Node("hidden2");
            hidden2.InternalState = 0;

            hidden1.addConnections(in1, in2, in3, in4, in5, hidden1, hidden2, BiasNode);
            hidden2.addConnections(in1, in2, in3, in4, in5, hidden1, hidden2, BiasNode);

            HiddenNodes = new List<Node> { hidden1, hidden2 };

            //  Output Nodes (Motor)
            var out1 = new Node("out1");
            var out2 = new Node("out2");

            out1.addConnections(hidden1, hidden2, out1, out2, BiasNode);
            out2.addConnections(hidden1, hidden2, out1, out2, BiasNode);

            OutputNodes = new List<Node> { out1, out2 };
        }
    }
}
