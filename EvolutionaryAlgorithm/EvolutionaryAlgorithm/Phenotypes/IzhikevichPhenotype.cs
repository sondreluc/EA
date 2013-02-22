using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionaryAlgorithm.Phenotypes
{
    class IzhikevichPhenotype:AbstractPhenotype
    {
        public double a { get; private set; }
        public double b { get; private set; }
        public double c { get; private set; }
        public double d { get; private set; }
        public double k { get; private set; }

        public IzhikevichPhenotype(double a, double b, double c, double d, double k)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
            this.k = k;
        }
    }
}
