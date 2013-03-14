using System.Collections.Generic;
using EvolutionaryAlgorithm.Miscellaneous;

namespace EvolutionaryAlgorithm.Phenotypes
{
    public class MinCogPhenotype : AbstractPhenotype
    {
        public List<Node> InputNodes { get; set; }
        public List<Node> HiddenNodes { get; set; }
        public List<Node> OutputNodes { get; set; }
        public Node BiasNode { get; set; }

        public MinCogPhenotype(List<Node> inputNodes, List<Node> hiddenNodes, List<Node> outputNodes, Node bias)
        {
            InputNodes = inputNodes;
            HiddenNodes = hiddenNodes;
            OutputNodes = outputNodes;
            BiasNode = bias;
        }

       
    }


    //private class Node
    //{
    //    public TupleList<Node, double> connections { get; set; }
    //    public double gain { get; set; }
    //    public double timeConstant { get; set; }

    //}
}