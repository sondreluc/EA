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
        public List<double> SpikeTimesDataSet { get; set; }
        public List<double> DataSet { get; set; }
        public IzhikevichFitness(string sdm, List<double> dataSet)
        {
            SDM = sdm;
            DataSet = dataSet;
            SpikeTimesDataSet = CalculateSpikeTimes(dataSet);
        }
        public override void CalculateFitness(AbstractPhenotype phenotype)
        {
            var pheno = (IzhikevichPhenotype) phenotype;
            pheno.Train = new List<double>();
            pheno.SpikeTimes = new List<double>();
            pheno.MakeTrain();
            pheno.SpikeTimes = CalculateSpikeTimes(pheno.Train);
            const int p = 2;
            switch (SDM.ToLower())
            {
                case "time":
                    pheno.Fitness = TimeDistanceMetric(SpikeTimesDataSet, pheno.SpikeTimes, p);              
                    break;
                case "interval":
                    pheno.Fitness = IntervalDistanceMetric(SpikeTimesDataSet, pheno.SpikeTimes, p);
                    break;
                case "waveform":
                    pheno.Fitness = WaveformDistanceMetric(pheno.Train, DataSet, p);
                    break;
            }
        }

        public override void CalculatePopulationFitness(List<AbstractPhenotype> phenotypes)
        {
            foreach (var abstractPhenotype in phenotypes)
            {
                CalculateFitness(abstractPhenotype);
            }
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

        public double TimeDistanceMetric(List<double> trainA, List<double> trainB, int p)
        {
            var minCount = Math.Min(trainA.Count, trainB.Count);
            var maxCount = Math.Max(trainA.Count, trainB.Count);
            var sum = (double)((maxCount - minCount) * DataSet.Count) / (2 * minCount);

            for (int i = 0; i < minCount; i++)
            {
                var ta = trainA.ElementAt(i);
                var tb = trainB.ElementAt(i);
                var abs = Math.Abs(ta - tb);
                sum += Math.Pow(abs, p);
            }
            var root = Math.Pow(sum, 1.0 / p);
            var dst = root / minCount;
            var fitness = 0.0;
            if (minCount != 0)
            {
                fitness = (1.0 / (1.0 + dst));
            }
            return fitness;
        }

        public double IntervalDistanceMetric(List<double> trainA, List<double> trainB, int p)
        {
            var minCount = Math.Min(trainA.Count, trainB.Count);
            var maxCount = Math.Max(trainA.Count, trainB.Count);
            var sum = (double)((maxCount - minCount)*DataSet.Count)/(2*minCount);

            for (int i = 1; i < minCount; i++)
            {
                var ta = trainA.ElementAt(i);
                var ta1 = trainA.ElementAt(i-1);
                var tb = trainB.ElementAt(i);
                var tb1 = trainB.ElementAt(i-1);
                var abs = Math.Abs((ta-ta1) - (tb-tb1));
                sum += Math.Pow(abs, p);
            }
            var root = Math.Pow(sum, 1.0 / p);
            var dst = ( root / (minCount-1));
            var fitness = 0.0;
            if (minCount > 1 )
            {
                fitness = (1.0 / (1.0 + dst));
            }
            return fitness;
        }

        public double WaveformDistanceMetric(List<double> trainA, List<double> trainB, int p)
        {
            var sum = 0.0;

            for (int i = 0; i < trainA.Count-1; i++)
            {
                var va = trainA.ElementAt(i);
                var vb = trainB.ElementAt(i);
                var abs = Math.Abs(va-vb);
                sum += Math.Pow(abs, p);
            }
            var root = Math.Pow(sum, 1.0 / p);
            var dst = root / trainA.Count;
            var fitness = (1.0 / (1.0 + dst));

            return fitness;
        }
    }
}
