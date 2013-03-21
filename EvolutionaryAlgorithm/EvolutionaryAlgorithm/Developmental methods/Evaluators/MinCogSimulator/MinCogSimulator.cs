using System;
using EvolutionaryAlgorithm.Phenotypes;
using EvolutionaryAlgorithm.EvolutionaryAlgorithms;

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
            Avoid = 0;
            Big = 0;
            Round = 0;
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
        public int Avoid { get; set; }
        public MinCogAgent Agent { get; set; }
        public int CurrentBlockSize { get; set; }
        public int CurrentBlockXPos { get; set; }
        public int CurrentBlockYPos { get; set; }
        public int Big { get; set; }
        public int Round { get; set; }

        /*
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

      

        public void Simulate11()
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
            Agent.SetNewPosition(sensorReadings);
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
*/
        // ------------- NEW VERSION ---------------------

        public void Simulate()
        {
            for(int blockNo = 0; blockNo < 40; blockNo++)           
            {
                SpawnBlock();
                int dx = MinCog.randomHorizontalVelocity ? -_random.Next(-1, 2) : 0;
                while (CurrentBlockYPos < 14)
                {
                    PassSensorReading();
                    FallOneStep(dx,1);
                }
                CheckHits(0.80);     
            }

        }

        public void SpawnBlock()
        {
            CurrentBlockSize = (Big > 12) ? _random.Next(1, 6) : _random.Next(1, 7);
            
            if (CurrentBlockSize == 6)
                Big++;

            if (Big <= 12 && (13-Big)>=(40 - Round))
            {
                CurrentBlockSize = 6;
                Big++;
            }
                
            Round++;
            CurrentBlockXPos = _random.Next(30);
            CurrentBlockYPos = 0;
            for (int x = CurrentBlockXPos; x < CurrentBlockXPos + CurrentBlockSize; x++)
                Board[0, x % Board.GetLength(1)] = 2;
        }

        public void FallOneStep(int dx, int dy)
        {
            for (int x = CurrentBlockXPos; x < CurrentBlockXPos + CurrentBlockSize; x++)
                Board[CurrentBlockYPos, modulo(x, 30)] = 0;

            CurrentBlockYPos += dy;
            CurrentBlockXPos += dx;

            for (int x = CurrentBlockXPos; x < CurrentBlockXPos + CurrentBlockSize; x++)
                Board[CurrentBlockYPos, modulo(x, 30)] += 2;      
        }

        public void PassSensorReading()
        {
            bool[] sensorReading = new bool[5];
            int index = 0;
            for (int x = Agent.CurrentPosition; x < Agent.CurrentPosition + 5; x++)
            {
                int y = CurrentBlockYPos;
                if (Board[y, x % 30] == 2)
                    sensorReading[index++] = true;
                else
                    sensorReading[index++] = false;
            }

            RedrawAgent(0);
            Agent.SetNewPosition(sensorReading);
            RedrawAgent(1);
        }

        public void RedrawAgent(int val)
        {
            for (int x = Agent.CurrentPosition; x < Agent.CurrentPosition + 5; x++)
            {
                int y = Board.GetLength(0)-1;
                Board[y, x % 30] = val;
            }
        }

        public void CheckHits(double threshold)
        {
            int hits = 0;

            for(int x = 0; x < Board.GetLength(1); x++)
            {
                int y = Board.GetLength(0)-1;
                if (Board[y, x] == 3)
                {
                    Board[y, x] = 1;
                    hits++;
                }
                if (Board[y, x] == 2)
                    Board[y, x] = 0;
            }

            double hitRatio = (double) hits / CurrentBlockSize;

            if (CurrentBlockSize == 6 && hits > 0)
                BadHits++;
            else if (CurrentBlockSize == 6)
                Avoid++;
            else if (hitRatio >= threshold)
                GoodHits++;
        }

        /// <summary>
        /// Modulo operator that handles negitive values properly
        /// </summary>
        /// <param name="val"></param>
        /// <param name="mod"></param>
        /// <returns></returns>
        private int modulo(int val, int mod)
        {
            return (val % mod + mod) % mod;
        }
    }  
}