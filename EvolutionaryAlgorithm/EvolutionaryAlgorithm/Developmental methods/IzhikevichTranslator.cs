using EvolutionaryAlgorithm.Genotypes;
using EvolutionaryAlgorithm.Phenotypes;

namespace EvolutionaryAlgorithm.Developmental_methods
{
    internal class IzhikevichTranslator : AbstractTranslator
    {
        public override AbstractPhenotype Translate(BitVector genom)
        {
            //NB: Requires explicit size genom size of 33
            double a = binaryToDoubleRange(genom.GetRange(0, 7), 0.001, 0.2); //200 values : 8 bit
            double b = binaryToDoubleRange(genom.GetRange(7, 7), 0.01, 0.3); // 30 values : 5 bit
            double c = binaryToDoubleRange(genom.GetRange(14, 7), -80.0, -30.0); // 51 values : 6 bit
            double d = binaryToDoubleRange(genom.GetRange(21, 7), 0.1, 10.0); // 100 values : 7 bit
            double k = binaryToDoubleRange(genom.GetRange(28, 7), 0.01, 1.0); // 100 values : 7 bit

            return new IzhikevichPhenotype(a, b, c, d, k) {Genotype = genom, Fitness = 0.0, RouletteProportion = 0.0};
        }
    }
}