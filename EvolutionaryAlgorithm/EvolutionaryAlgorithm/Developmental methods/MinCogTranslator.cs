using EvolutionaryAlgorithm.Genotypes;
using EvolutionaryAlgorithm.Miscellaneous;
using EvolutionaryAlgorithm.Phenotypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionaryAlgorithm.Developmental_methods
{
    class MinCogTranslator:AbstractTranslator
    {
        List<Node> InputNodes;
        Node BiasNode;
        List<Node> HiddenNodes;
        List<Node> OutPutNodes;

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
                foreach (Pair<Node, double> neighbour in hiddenNode.UpstreamConnections)
                {
                    if (neighbour.left == BiasNode)
                        neighbour.right = binaryToDoubleRange(genom.GetRange(index++ * 8, 8), -10.0, 0.0);
                    else
                        neighbour.right = binaryToDoubleRange(genom.GetRange(index++ * 8, 8), -5.0, 5.0);
                }
                hiddenNode.Gain = binaryToDoubleRange(genom.GetRange(index++ * 8, 8), 1.0, 5.0);
                hiddenNode.timeConstant = binaryToDoubleRange(genom.GetRange(index++ * 8, 8), 1.0, 2.0);
            }
            foreach (Node outputNode in OutPutNodes)
            {
                foreach (Pair<Node, double> neighbour in outputNode.UpstreamConnections)
                {
                    if (neighbour.left == BiasNode)
                        neighbour.right = binaryToDoubleRange(genom.GetRange(index++ * 8, 8), -10.0, 0.0);
                    else
                        neighbour.right = binaryToDoubleRange(genom.GetRange(index++ * 8, 8), -5.0, 5.0);
                }
                outputNode.Gain = binaryToDoubleRange(genom.GetRange(index++ * 8, 8), 1.0, 5.0);
                outputNode.timeConstant = binaryToDoubleRange(genom.GetRange(index++ * 8, 8), 1.0, 2.0);
            }

                return new MinCogPhenotype
                    {
                        InputNodes = this.InputNodes,
                        HiddenNodes = this.HiddenNodes,
                        OutputNodes = this.OutPutNodes,
                        BiasNode = this.BiasNode

                    };
        }
    }
}
