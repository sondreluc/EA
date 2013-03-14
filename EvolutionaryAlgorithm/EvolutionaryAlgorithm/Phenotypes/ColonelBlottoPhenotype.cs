using System;
using System.Collections.Generic;
using System.Linq;

namespace EvolutionaryAlgorithm.Phenotypes
{
    public class ColonelBlottoPhenotype : AbstractPhenotype
    {
        public List<double> Army { get; set; }
        public int Wins { get; set; }
        public int Ties { get; set; }
        public double Strength { get; set; }
        public double Entropy { get; set; }

        public void Redeployment(int battleNumber, double redeployment, double redeploymentFraction)
        {
            double solidersPerRemainingBattle = (redeployment/(Army.Count - battleNumber + 1))*redeploymentFraction;
            Army[battleNumber] -= redeployment;
            for (int i = battleNumber + 1; i < Army.Count; i++)
            {
                Army[i] += solidersPerRemainingBattle;
            }
        }

        public void CalculateEntropy()
        {
            Entropy = -(Army.Where(x => x > 0.0).Sum(x => x*Math.Log(x, 2)));
        }

        public string ArmyToString()
        {
            string s = Army.Aggregate("[", (current, strength) => current + (strength + ",  "));
            s.Remove(s.Length - 2);
            s += "]";
            return s;
        }
    }
}