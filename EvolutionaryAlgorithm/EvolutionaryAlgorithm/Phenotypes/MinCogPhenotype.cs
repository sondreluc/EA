using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvolutionaryAlgorithm.Miscellaneous;

namespace EvolutionaryAlgorithm.Phenotypes
{
    class MinCogPhenotype:AbstractPhenotype
    {
        public List<Node> InputNodes { get; set; }
        public List<Node> HiddenNodes { get; set; }
        public List<Node> OutputNodes { get; set; }
        public Node BiasNode { get; set; }
    }






    //private class Node
    //{
    //    public TupleList<Node, double> connections { get; set; }
    //    public double gain { get; set; }
    //    public double timeConstant { get; set; }

    //}
}
