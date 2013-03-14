﻿using System;
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

        public MinCogAgent(MinCogPhenotype pheno)
        {
            this.Pheno = pheno;
            this.CurrentPosition = 0;
        }

        /// <summary>
        /// Gets a velocity from the neural net and returns the agents new position
        /// </summary>
        /// <param name="node">input from sensors</param>
        public int GetNewPosition(bool[] inputs)
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
            CurrentPosition = CurrentPosition + velocity;
            return CurrentPosition;
        }

        /// <summary>
        /// Updates Activation level and output on a node
        /// </summary>
        /// <param name="node">Node to be updated</param>
        private void updateNode(Node node)
        {
            double s = 0.0; // Sum of weighted input
            double dy = 0.0; // Change in activation level
            foreach (Pair<Node, double> upstreamConnection in node.UpstreamConnections)
            {
                s += upstreamConnection.left.Output * upstreamConnection.right;
            }
            dy = (-node.ActivationLevel + s) / node.TimeConstant; // Bias included in s
            node.ActivationLevel = node.ActivationLevel + dy;
            node.Output = 1 / (1 + Math.Pow(Math.E, (node.Gain * node.ActivationLevel)));
        }

        /// <summary>
        /// Calculates a velocity from the outputs of the motor nodes
        /// </summary>
        /// <param name="left">Output of left node</param>
        /// /// <param name="right">Output of right node</param>
        public int getVelocity(double left, double right)
        {
            double vote = left - right;
            vote = vote *  4.0;
            Double velocity =  Math.Round(vote);
            return Convert.ToInt32(velocity);
        }
    }
}