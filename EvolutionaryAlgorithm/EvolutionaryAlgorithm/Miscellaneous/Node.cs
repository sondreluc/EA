using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionaryAlgorithm.Miscellaneous
{
    class Node
    {
        public PairList<Node, double> upstreamConnections { get; set; }
        public double gain { get; set; }
        public double timeConstant { get; set; }

        public void addConnections(params Node[] connections)
        {
            for (int i = 0; i < connections.Length; i++)
                this.upstreamConnections.Add(connections[i], -1);
        }
    }
}
