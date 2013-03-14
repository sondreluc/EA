using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvolutionaryAlgorithm.EvolutionaryAlgorithms;

namespace EvolutionaryAlgorithm.Evaluators.MinCogSimulator
{
    public class MinCogSimulator
    {
        public int[,] Board = new int[15,30];
        public int GoodHits;
        public int BadHits;
        public MinCogAgent Agent;

        public void CheckForHit()
        {
            for (int i = 0; i < Board.GetLength(1); i++)
            {
                if (Board[14, i]<1)
                {
                    
                }
            }
        }

    }
}
