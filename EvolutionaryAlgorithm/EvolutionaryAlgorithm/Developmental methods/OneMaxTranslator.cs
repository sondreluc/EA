using EvolutionaryAlgorithm.Genotypes;
using EvolutionaryAlgorithm.Phenotypes;

namespace EvolutionaryAlgorithm.Developmental_methods
{
    public class OneMaxTranslator : AbstractTranslator
    {
        public override AbstractPhenotype Translate(BitVector genom)
        {
            return new OneMaxPhenotype(genom);
        }
    }
}