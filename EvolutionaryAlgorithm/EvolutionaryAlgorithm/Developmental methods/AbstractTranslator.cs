using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvolutionaryAlgorithm.Genotypes;
using EvolutionaryAlgorithm.Phenotypes;

namespace EvolutionaryAlgorithm.Developmental_methods
{
    public abstract class AbstractTranslator
    {
        public abstract AbstractPhenotype Translate(BitVector genom);
    }
}
