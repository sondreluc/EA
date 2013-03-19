using System.Collections.Generic;
using EvolutionaryAlgorithm.Genotypes;
using EvolutionaryAlgorithm.Miscellaneous;
using EvolutionaryAlgorithm.Phenotypes;

namespace EvolutionaryAlgorithm.Developmental_methods
{
    internal class MinCogTranslator : AbstractTranslator
    {
        public override AbstractPhenotype Translate(BitVector genom)
        {
            Network network = new Network();
            network.createGraph();
            int index = 0;

            foreach (Node hiddenNode in network.HiddenNodes)
            {
                foreach (var neighbour in hiddenNode.UpstreamConnections)
                {
                    if (neighbour.left == network.BiasNode)
                        neighbour.right = binaryToDoubleRange(genom.GetRange(index++*8, 8), -10.0, 0.0);
                    else
                        neighbour.right = binaryToDoubleRange(genom.GetRange(index++*8, 8), -5.0, 5.0);
                }
                hiddenNode.Gain = binaryToDoubleRange(genom.GetRange(index++*8, 8), 1.0, 5.0);
                hiddenNode.TimeConstant = binaryToDoubleRange(genom.GetRange(index++*8, 8), 1.0, 2.0);
            }
            foreach (Node outputNode in network.OutputNodes)
            {
                foreach (var neighbour in outputNode.UpstreamConnections)
                {
                    if (neighbour.left == network.BiasNode)
                        neighbour.right = binaryToDoubleRange(genom.GetRange(index++*8, 8), -10.0, 0.0);
                    else
                        neighbour.right = binaryToDoubleRange(genom.GetRange(index++*8, 8), -5.0, 5.0);
                }
                outputNode.Gain = binaryToDoubleRange(genom.GetRange(index++*8, 8), 1.0, 5.0);
                outputNode.TimeConstant = binaryToDoubleRange(genom.GetRange(index++*8, 8), 1.0, 2.0);
            }

            MinCogPhenotype pheno = new MinCogPhenotype(network.InputNodes, network.HiddenNodes, network.OutputNodes, network.BiasNode)
            {
                Genotype = genom,
                Fitness = 0.0,
                RouletteProportion = 0.0
};
            return pheno;
        }
    }
}