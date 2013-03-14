using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvolutionaryAlgorithm.Phenotypes;
using EvolutionaryAlgorithm.Miscellaneous;

namespace EvolutionaryAlgorithm.Evaluators.MinCogSimulator
{
    public class MinCogAgent
    {
        public MinCogPhenotype Pheno;
        public int CurrentPosition { get; set; }

        public int GetNewPosition(bool[] inputs)
        {
            Pheno.BiasNode.ActivationLevel = 1.0;

            for (int i = 0; i < inputs.Length; i++)
            {
                Pheno.InputNodes[i].ActivationLevel = inputs[i] ? 1.0 : 0.0;
            }

            foreach (Node hiddenNode in Pheno.HiddenNodes)
            {
                updateNode(hiddenNode);
            }

            foreach (Node motorNode in Pheno.OutputNodes)
            {
                updateNode(motorNode);
            }

            int velocity = getVelocity(Pheno.OutputNodes[0].ActivationLevel, Pheno.OutputNodes[1].ActivationLevel);
            CurrentPosition = CurrentPosition + velocity;
            return CurrentPosition;
        }

        private void updateNode(Node node)
        {
            double s = 0.0;
            double dy = 0.0;
            foreach (Pair<Node, double> upstreamConnection in node.UpstreamConnections)
            {
                s += upstreamConnection.left.ActivationLevel * upstreamConnection.right;
            }
            dy = (-node.ActivationLevel + s) / node.TimeConstant;
            node.ActivationLevel = 1 / (1 + Math.Pow(Math.E, (node.Gain * node.ActivationLevel)));
        }

        public int getVelocity(double left, double right)
        {

            return 0;
        }
    }
}
