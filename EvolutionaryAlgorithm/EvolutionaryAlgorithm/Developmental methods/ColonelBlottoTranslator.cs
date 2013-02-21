using System;
using System.Collections.Generic;
using System.Linq;
using EvolutionaryAlgorithm.Genotypes;
using EvolutionaryAlgorithm.Phenotypes;

namespace EvolutionaryAlgorithm.Developmental_methods
{
    public class ColonelBlottoTranslator:AbstractTranslator
    {
        public override AbstractPhenotype Translate(BitVector genom)
        {
            var battles = new List<double>();
            for (int i = 0; i < genom.Vector.Count; i=i+4)
            {
                var binaryStrength = genom.Vector[i].ToString() + genom.Vector[i + 1].ToString() + genom.Vector[i + 2].ToString() + genom.Vector[i + 3].ToString();
                var armyStrength = (double)Convert.ToInt32(binaryStrength, 2);
                battles.Add(armyStrength);
            }
            double sum = battles.Sum();
            List<double> army = battles.Select(battleStrength => (battleStrength/sum)).ToList();
            var cbp = new ColonelBlottoPhenotype {Genotype = genom, Army = army, Strength = 1.0, Wins = 0, Ties = 0};
            cbp.CalculateEntropy();
            return cbp;
        }
    }
}
