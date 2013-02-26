using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvolutionaryAlgorithm.Phenotypes;

namespace EvolutionaryAlgorithm.Evaluators
{
    class IzhikevichFitness:AbstractFitnessEvaluator
    {
        public string SDM { get; set; }
        public List<double> spikeTimesDataSet { get; set; } 
        public IzhikevichFitness(string SDM, List<double> dataSet)
        {
            SDM = SDM;
            spikeTimesDataSet = CalculateSpikeTimes(dataSet);
        }
        public override void CalculateFitness(AbstractPhenotype phenotype)
        {
            var pheno = (IzhikevichPhenotype) phenotype;
            pheno.MakeTrain();
            pheno.SpikeTimes = CalculateSpikeTimes(pheno.Train);
            const int p = 2;
            var minCount = Math.Min(spikeTimesDataSet.Count, pheno.SpikeTimes.Count);

            switch (SDM.ToLower())
            {
                case "time":
                    var sum = 0.0;
                    
                    for (int i = 0; i < minCount-1; i++)
                    {
                        sum += Math.Pow(Math.Abs(spikeTimesDataSet.ElementAt(i) - pheno.SpikeTimes.ElementAt(i)), p);
                    }
                    pheno.Fitness = Math.Pow(sum, 1.0/p)/minCount;
                    break;
                case "interval":

                    break;
                case "waveform":

                    break;
            }
        }

        public override void CalculatePopulationFitness(List<AbstractPhenotype> phenotypes)
        {
            throw new NotImplementedException();
        }

        public List<double> CalculateSpikeTimes(List<double> train, int k = 5)
        {
            const double threshold = 0;
            var spikeTimes = new List<double>();
            for (int i = 0; i < train.Count - k; i++)
            {
                List<double> interval = train.GetRange(i, k);
                var max = interval.Max();
                var mid = interval.ElementAt((k / 2) + 1);
                if (mid >= max && mid > threshold)
                {
                    spikeTimes.Add(i + (k / 2) + 1);
                }
            }
            return spikeTimes;
        }
    }
}
