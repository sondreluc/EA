using System;
using System.Collections.Generic;
using System.Linq;
using EvolutionaryAlgorithm.Developmental_methods;
using EvolutionaryAlgorithm.Evaluators;
using EvolutionaryAlgorithm.Genotypes;
using EvolutionaryAlgorithm.Phenotypes;

namespace EvolutionaryAlgorithm.Populations
{
    public class BinaryPopulation
    {

        private readonly Random _random;
        public AbstractTranslator Translator { get; set; }
        public List<AbstractPhenotype> CurrentPopulation { get; set; }
        public List<BitVector> Offsprings { get; set; }
        public string SelectionProtocol { get; set; }
        public AbstractFitnessEvaluator Evaluator { get; set; }


        public BinaryPopulation(int populationSize, int genotypeSize, string selectionProtocol, AbstractFitnessEvaluator evaluator, AbstractTranslator translator, int intervalStart, int intervalEnd)
        {
            _random = new Random();
            Evaluator = evaluator;
            Translator = translator;
            var individuals = new List<AbstractPhenotype>();
            for (int i = 0; i < populationSize; i++)
            {
                var genotype = new BitVector();
                for (int j = 0; j < genotypeSize; j++)
                {
                    var number = _random.Next(intervalStart, intervalEnd);
                    string binary = Convert.ToString(number, 2);
                    string binaryDigits = Convert.ToString(intervalEnd-1, 2);
                    while (binary.Length < binaryDigits.Length)
                    {
                        binary = "0"+binary;
                    }
                       
                    
                    for (var k = 0; k < binary.Length; k++)
                    {
                        genotype.Vector.Add(Convert.ToInt32(binary[k].ToString(), 2));
                    }
                    
                }

                individuals.Add(Translator.Translate(genotype));
            }
            
            CurrentPopulation = individuals;
            Offsprings = new List<BitVector>();
            SelectionProtocol = selectionProtocol;
        }

        public void SelectAdults()
        {
            if (Offsprings.Count != 0)
            {
                List<AbstractPhenotype> phenoOffsprings = Offsprings.Select(offspring => Translator.Translate(offspring)).ToList();
                var size = CurrentPopulation.Count;
                switch (SelectionProtocol)
                {
                    case "A-I":
                        CurrentPopulation.Clear();
                        CurrentPopulation.AddRange(phenoOffsprings);
                        Offsprings.Clear();
                        break;
                    case "A-II":
                        CurrentPopulation.Clear();
                        CurrentPopulation.AddRange(phenoOffsprings);
                        Offsprings.Clear();
                        Evaluator.CalculatePopulationFitness(CurrentPopulation);
                        CurrentPopulation.Sort();
                        CurrentPopulation = CurrentPopulation.GetRange(CurrentPopulation.Count - size - 1,size);
                        break;
                    case "A-III":
                        Evaluator.CalculatePopulationFitness(phenoOffsprings);

                        CurrentPopulation.AddRange(phenoOffsprings);
                        CurrentPopulation.Sort();
                        CurrentPopulation = CurrentPopulation.GetRange(CurrentPopulation.Count - size-1, size);
                        break;
                }
            }
        }
    }
}
