using System;
using System.Collections.Generic;
using System.Linq;
using EvolutionaryAlgorithm.Phenotypes;

namespace EvolutionaryAlgorithm.Evaluators
{
    internal class IzhikevichFitness : AbstractFitnessEvaluator
    {
        public IzhikevichFitness(string sdm, List<double> dataSet)
        {
            SDM = sdm;
            DataSet = dataSet;
            SpikeTimesDataSet = CalculateSpikeTimes(dataSet);
        }

        public string SDM { get; set; }
        public List<int> SpikeTimesDataSet { get; set; }
        public List<double> DataSet { get; set; }

        public override void CalculateFitness(AbstractPhenotype phenotype)
        {
            var pheno = (IzhikevichPhenotype) phenotype;
            pheno.Train = new List<double>();
            pheno.SpikeTimes = new List<int>();
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
            foreach (AbstractPhenotype abstractPhenotype in phenotypes)
            {
                CalculateFitness(abstractPhenotype);
            }
        }

        public List<int> CalculateSpikeTimes(List<double> train, int k = 5)
        {
            const double threshold = 0.0;
            var spikeTimes = new List<int>();
            for (int i = 0; i < train.Count - k; i++)
            {
                List<double> interval = train.GetRange(i, k);
                double max = interval.Max();
                double mid = interval.ElementAt((k/2));
                if (mid >= max && mid > threshold)
                {
                    spikeTimes.Add(i + (k/2));
                }
            }
            return spikeTimes;
        }

        public double TimeDistanceMetric(List<int> trainA, List<int> trainB, int p)
        {
            int minCount = Math.Min(trainA.Count, trainB.Count);
            int maxCount = Math.Max(trainA.Count, trainB.Count);
            double sum = (double) ((maxCount - minCount)*DataSet.Count)/(2*minCount);

            for (int i = 0; i < minCount; i++)
            {
                int ta = trainA.ElementAt(i);
                int tb = trainB.ElementAt(i);
                int abs = Math.Abs(ta - tb);
                sum += Math.Pow(abs, p);
            }
            double root = Math.Pow(sum, 1.0/p);
            double dst = root/minCount;
            double fitness = 0.0;
            if (minCount != 0)
            {
                fitness = (1.0/(1.0 + dst));
            }
            else if (minCount == maxCount)
            {
                fitness = 1.0;
            }

            return fitness;
        }

        public double IntervalDistanceMetric(List<int> trainA, List<int> trainB, int p)
        {
            int minCount = Math.Min(trainA.Count, trainB.Count);
            int maxCount = Math.Max(trainA.Count, trainB.Count);
            double sum = (double) ((maxCount - minCount)*DataSet.Count)/(2*minCount);

            for (int i = 1; i < minCount; i++)
            {
                int ta = trainA.ElementAt(i);
                int ta1 = trainA.ElementAt(i - 1);
                int tb = trainB.ElementAt(i);
                int tb1 = trainB.ElementAt(i - 1);
                int abs = Math.Abs((ta - ta1) - (tb - tb1));
                sum += Math.Pow(abs, p);
            }
            double root = Math.Pow(sum, 1.0/p);
            double dst = (root/(minCount - 1));
            double fitness = 0.0;
            if (minCount > 1)
            {
                fitness = (1.0/(1.0 + dst));
            }

            return fitness;
        }

        public double WaveformDistanceMetric(List<double> trainA, List<double> trainB, int p)
        {
            double sum = 0.0;

            for (int i = 0; i < trainA.Count - 1; i++)
            {
                double va = trainA.ElementAt(i);
                double vb = trainB.ElementAt(i);
                double abs = Math.Abs(va - vb);
                sum += Math.Pow(abs, p);
            }
            double root = Math.Pow(sum, 1.0/p);
            double dst = root/trainA.Count;
            double fitness = (1.0/(1.0 + dst));

            return fitness;
        }
    }
}