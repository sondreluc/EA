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
        public List<double> Train { get; set; }
        public List<double> SpikeTimes { get; set; } 

        public IzhikevichPhenotype(double a, double b, double c, double d, double k)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
            this.k = k;
            Train = new List<double>();
        }

        public void MakeTrain()
        {
            const int timeSteps = 1000;
            double v = -60.0;
            double u = 0.0;
            const double threshold = 35.0;
            const double I = 10;
            const double tau = 10;
            for (int j = 0; j <= timeSteps; j++)
            {
                Train.Add(v);
                if (v > threshold)
                {
                    v = c;
                    u = u + d;
                }
                else
                {
                    double vDt = ((k*Math.Pow(v, 2)) + 5*v + 140 - u + I)/tau;
                    double uDt = (a*(b*v - u))/tau;
                    v = v + vDt;
                    u = u + uDt;
                }
                
            }
        }

    }
}
