using System;
using System.Collections.Generic;
using System.Linq;
using EvolutionaryAlgorithm.Phenotypes;

namespace EvolutionaryAlgorithm.Selection_Mechanisms
{
    public abstract class AbstractSelectionMechanism
    {
        private readonly Random _random;

        public AbstractSelectionMechanism()
        {
            _random = new Random();
        }

        public List<AbstractPhenotype> SelectParents(List<AbstractPhenotype> adults, int numberToSelect)
        {
            
            List<AbstractPhenotype> selectedParents = new List<AbstractPhenotype>();

            for (int i = 0; i < numberToSelect; i++ )
            {
                double randomPropotion = _random.NextDouble();
                selectedParents.Add(adults.FirstOrDefault(x => x.RouletteProportion > randomPropotion));
            }

            return selectedParents;
        }
        public abstract void NormalizeRouletteWheel(List<AbstractPhenotype> adults);
        public abstract List<AbstractPhenotype> TournamentSelection(List<AbstractPhenotype> adults, int numberToSelect, int k, double e);
    }
}
