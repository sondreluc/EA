using EvolutionaryAlgorithm.Genotypes;

namespace EvolutionaryAlgorithm.Phenotypes
{
    public class OneMaxPhenotype : AbstractPhenotype
    {
        public OneMaxPhenotype(BitVector genom)
        {
            Genotype = genom;
        }
    }
}