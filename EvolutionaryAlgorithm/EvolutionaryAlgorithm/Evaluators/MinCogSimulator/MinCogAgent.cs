using System;
using System.Diagnostics;
using EvolutionaryAlgorithm.Miscellaneous;
using EvolutionaryAlgorithm.Phenotypes;

namespace EvolutionaryAlgorithm.Evaluators.MinCogSimulator
{
    public class MinCogAgent
    {
        public MinCogPhenotype Pheno;
        public int CurrentPosition { get; set; }
        public int Velocity { get; set; }

        public MinCogAgent(MinCogPhenotype pheno)
        {
            Pheno = pheno;
            foreach (Node hiddenNode in pheno.HiddenNodes)
            {
                hiddenNode.InternalState = 0;
                hiddenNode.Output = 0;
            }

            foreach (Node motorNode in pheno.OutputNodes)
            {
                motorNode.InternalState = 0;
                motorNode.Output = 0;
            }
            Debug.Assert(pheno.HiddenNodes[0].InternalState == 0);
            CurrentPosition = 0;
        }

        /// <summary>
        ///     Gets a velocity from the neural net and returns the agents new position
        /// </summary>
        /// <param name="node">input from sensors</param>
        public void SetNewPosition(bool[] inputs)
        {


            for (int i = 0; i < inputs.Length; i++)
            {
                Pheno.InputNodes[i].Output = inputs[i] ? 1.0 : 0.0;
            }

            foreach (Node hiddenNode in Pheno.HiddenNodes)
            {
                updateNode(hiddenNode);
            }

            foreach (Node motorNode in Pheno.OutputNodes)
            {
                updateNode(motorNode);
            }

            int velocity = getVelocity(Pheno.OutputNodes[0].Output, Pheno.OutputNodes[1].Output);
            CurrentPosition = ((CurrentPosition + velocity) % 30 + 30) % 30;
        }


        /// <summary>
        ///     Updates Activation level and output on a node
        /// </summary>
        /// <param name="node">Node to be updated</param>
        private void updateNode(Node node)
        {
            double s = 0.0; // Sum of weighted input
            double dy = 0.0; // Change in activation level
            foreach (var upstreamConnection in node.UpstreamConnections)
            {
                s += upstreamConnection.left.Output*upstreamConnection.right;
            }
            dy = (-node.InternalState + s)/node.TimeConstant; // Bias included in s
            node.InternalState = node.InternalState + dy;
            node.Output = 1 / (1 + Math.Pow(Math.E, -(node.Gain * node.InternalState)));
        }

        /// <summary>
        ///     Calculates a velocity from the outputs of the motor nodes
        /// </summary>
        /// <param name="left">Output of left node</param>
        /// ///
        /// <param name="right">Output of right node</param>
        public int getVelocity(double left, double right)
        {
            double sum = left + right;
            left = left / sum;
            right = right / sum;

            int direction = (left > right) ? -1 : 1;

            double stopTreshold = 0.30;
            double step = 1 - stopTreshold / 4;
            double diff = left - right;
            double absoluteDifference = Math.Abs(left - right);

            if (absoluteDifference < stopTreshold)
            {
                this.Velocity = 0 * direction;
                return this.Velocity;
            }

            if (absoluteDifference < 0.5)
            {
                this.Velocity = 1 * direction;
                return this.Velocity;
            }
            if (absoluteDifference < 0.6)
            {
                this.Velocity = 2 * direction;
                return this.Velocity;
            }
            if (absoluteDifference < 0.8)
            {
                this.Velocity = 3 * direction;
                return this.Velocity;
            }

            this.Velocity = 4 * direction;
            return this.Velocity;

        }  
    }
}