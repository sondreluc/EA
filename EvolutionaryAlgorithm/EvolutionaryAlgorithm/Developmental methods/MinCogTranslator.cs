using System.Collections.Generic;
using EvolutionaryAlgorithm.Genotypes;
using EvolutionaryAlgorithm.Miscellaneous;
using EvolutionaryAlgorithm.Phenotypes;

namespace EvolutionaryAlgorithm.Developmental_methods
{
    internal class MinCogTranslator : AbstractTranslator
    {
        private readonly Node BiasNode;
        private readonly List<Node> HiddenNodes;
        private readonly List<Node> InputNodes;
        private readonly List<Node> OutPutNodes;

        public MinCogTranslator(List<Node> inputNodes, Node biasNode,
                                List<Node> hiddenNodes, List<Node> outputNodes)
        {
            InputNodes = inputNodes;
            BiasNode = biasNode;
            HiddenNodes = hiddenNodes;
            OutPutNodes = outputNodes;
        }

        public override AbstractPhenotype Translate(BitVector genom)
        {
            int index = 0;

            foreach (Node hiddenNode in HiddenNodes)
            {
                foreach (var neighbour in hiddenNode.UpstreamConnections)
                {
                    if (neighbour.left == BiasNode)
                        neighbour.right = binaryToDoubleRange(genom.GetRange(index++*8, 8), -10.0, 0.0);
                    else
                        neighbour.right = binaryToDoubleRange(genom.GetRange(index++*8, 8), -5.0, 5.0);
                }
                hiddenNode.Gain = binaryToDoubleRange(genom.GetRange(index++*8, 8), 1.0, 5.0);
                hiddenNode.TimeConstant = binaryToDoubleRange(genom.GetRange(index++*8, 8), 1.0, 2.0);
            }
            foreach (Node outputNode in OutPutNodes)
            {
                foreach (var neighbour in outputNode.UpstreamConnections)
                {
                    if (neighbour.left == BiasNode)
                        neighbour.right = binaryToDoubleRange(genom.GetRange(index++*8, 8), -10.0, 0.0);
                    else
                        neighbour.right = binaryToDoubleRange(genom.GetRange(index++*8, 8), -5.0, 5.0);
                }
                outputNode.Gain = binaryToDoubleRange(genom.GetRange(index++*8, 8), 1.0, 5.0);
                outputNode.TimeConstant = binaryToDoubleRange(genom.GetRange(index++*8, 8), 1.0, 2.0);
            }

            MinCogPhenotype pheno = new MinCogPhenotype(InputNodes, HiddenNodes, OutPutNodes, BiasNode){Genotype = genom, Fitness = 0.0, RouletteProportion= 0.0
};
            return pheno;
        }
    }
}