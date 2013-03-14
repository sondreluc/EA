﻿using System;
using System.Collections.Generic;

namespace EvolutionaryAlgorithm.Phenotypes
{
    internal class IzhikevichPhenotype : AbstractPhenotype
    {
        public IzhikevichPhenotype(double a, double b, double c, double d, double k)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
            this.k = k;
            Train = new List<double>();
        }

        public double a { get; private set; }
        public double b { get; private set; }
        public double c { get; private set; }
        public double d { get; private set; }
        public double k { get; private set; }
        public List<double> Train { get; set; }
        public List<int> SpikeTimes { get; set; }

        public void MakeTrain()
        {
            const int timeSteps = 1000;
            double v = -60.0;
            double u = 0.0;
            const double threshold = 35.0;
            const double I = 10;
            const double tau = 10;
            Train.Add(v);
            for (int j = 1; j <= timeSteps; j++)
            {
                if (v > threshold)
                {
                    v = c;
                    u = u + d;
                }
                else
                {
                    double kv2 = (k*Math.Pow(v, 2));
                    double v5 = (5*v);
                    double vDt = (kv2 + v5 + 140 - u + I)/tau;
                    double uDt = (a*((b*v) - u))/tau;
                    v = v + vDt;
                    u = u + uDt;
                }
                Train.Add(v);
            }
        }
    }
}