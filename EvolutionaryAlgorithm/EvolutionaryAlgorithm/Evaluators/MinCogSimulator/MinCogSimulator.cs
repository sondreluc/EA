using System;
using EvolutionaryAlgorithm.Phenotypes;

namespace EvolutionaryAlgorithm.Evaluators.MinCogSimulator
{
    public class MinCogSimulator
    {
        private readonly Random _random;
        public int[,] Board = new int[15,30];

        public MinCogSimulator(MinCogPhenotype phenotype)
        {
            GoodHits = 0;
            BadHits = 0;
            Agent = new MinCogAgent(phenotype);
            CurrentBlockSize = 0;
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    Board[i, j] = 0;
                }
            }
            _random = new Random();
        }

        public int GoodHits { get; set; }
        public int BadHits { get; set; }
        public MinCogAgent Agent { get; set; }
        public int CurrentBlockSize { get; set; }
        public int CurrentBlockXPos { get; set; }
        public int CurrentBlockYPos { get; set; }

        public void CheckForHit()
        {
            if (CurrentBlockSize > 5)
            {
                if (CurrentBlockXPos + CurrentBlockSize >= Agent.CurrentPosition &&
                    CurrentBlockXPos <= Agent.CurrentPosition + 5)
                {
                    BadHits++;
                }
            }
            else
            {
                if (CurrentBlockXPos >= Agent.CurrentPosition &&
                    CurrentBlockXPos + CurrentBlockSize <= Agent.CurrentPosition + 5)
                {
                    GoodHits++;
                }
            }
        }

        public void Simulate()
        {
            int count = 0;
            while (count < 40)
            {
                CurrentBlockSize = _random.Next(1, 6);
                CurrentBlockXPos = _random.Next(30 - CurrentBlockSize);

                Drop(CurrentBlockXPos, CurrentBlockSize);

                for (int i = CurrentBlockXPos; i < CurrentBlockXPos; i++)
                {
                    Board[Board.GetLength(0) - 1, i] = 0;
                }
                count++;
            }
        }

        public void Drop(int pos, int size)
        {
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                TimeStep(pos, size, i);
            }
        }

        public void TimeStep(int brickPos, int brickSize, int lvl)
        {
            var sensorReadings = new bool[5];
            int sensorNr = 0;
            for (int j = Agent.CurrentPosition; j < Agent.CurrentPosition + 5; j++)
            {
                if (j >= CurrentBlockXPos && j <= CurrentBlockXPos + CurrentBlockSize)
                {
                    sensorReadings[sensorNr] = true;
                }
                else
                {
                    sensorReadings[sensorNr] = false;
                }
                sensorNr++;
            }
            for (int j = Agent.CurrentPosition; j < Agent.CurrentPosition + 5; j++)
            {
                if (j < Board.GetLength(1))
                {
                    Board[Board.GetLength(0) - 1, j] = 0;
                }
                else
                {
                    Board[Board.GetLength(0) - 1, j - Board.GetLength(1)] = 0;
                }
            }

            for (int j = Agent.CurrentPosition; j < Agent.CurrentPosition + 5; j++)
            {
                if (j < Board.GetLength(1))
                {
                    Board[Board.GetLength(0) - 1, j] = 1;
                }
                else
                {
                    Board[Board.GetLength(0) - 1, j - Board.GetLength(1)] = 1;
                }
            }
            if (lvl == 0)
            {
                for (int j = brickPos; j < brickPos + brickSize; j++)
                {
                    Board[lvl, j] = 2;
                }
                CurrentBlockYPos++;
            }
            else if (lvl == Board.GetLength(0) - 1)
            {
                for (int j = brickPos; j < brickPos + brickSize; j++)
                {
                    Board[lvl - 1, j] = 0;
                    Board[lvl, j] = 2;
                }
                CheckForHit();
                for (int j = brickPos; j < brickPos + brickSize; j++)
                {
                    Board[lvl, j] = 0;
                }
                CurrentBlockYPos++;
            }
            else
            {
                for (int j = brickPos; j < brickPos + brickSize; j++)
                {
                    Board[lvl - 1, j] = 0;
                    Board[lvl, j] = 2;
                }
                CurrentBlockYPos++;
            }
        }
    }
}