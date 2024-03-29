﻿using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EvolutionaryAlgorithm.Evaluators.MinCogSimulator;
using EvolutionaryAlgorithm.Miscellaneous;
using EvolutionaryAlgorithm.Phenotypes;
using EvolutionaryAlgorithm.EvolutionaryAlgorithms;

namespace EvolutionaryAlgorithm
{
    public partial class Simulator : Form
    {
        private readonly Random _random;
        public Brush BlueBrush = new SolidBrush(Color.Blue);
        public Rectangle Bot;
        public Rectangle Drop;
        public Brush RedBrush = new SolidBrush(Color.Red);
        public Pen p = new Pen(Color.Black);
        public MinCogSimulator sim;

        public Simulator(MinCogPhenotype phenotype) 
        {
            InitializeComponent();
            _random = new Random();
            sim = new MinCogSimulator(phenotype);
            foreach (var h in phenotype.HiddenNodes)
            {
                System.Diagnostics.Debug.WriteLine("Hidden");
                System.Diagnostics.Debug.WriteLine("g:" + h.Gain);
                System.Diagnostics.Debug.WriteLine("t:" + h.TimeConstant);
                foreach (var v in h.UpstreamConnections)
                {
                    System.Diagnostics.Debug.WriteLine(v.left.Name + " : " + v.right);
                }
            }
            foreach (var h in phenotype.OutputNodes)
            {
                System.Diagnostics.Debug.WriteLine("Output");
                System.Diagnostics.Debug.WriteLine("g:" + h.Gain);
                System.Diagnostics.Debug.WriteLine("t:" + h.TimeConstant);
                foreach (var v in h.UpstreamConnections)
                {
                    System.Diagnostics.Debug.WriteLine(v.left.Name + " : " + v.right);
                }
            }
            testNet(phenotype);
        }

        private void Run(object sender, PaintEventArgs e)
        {
            for (int blockNo = 0; blockNo < 40; blockNo++)
            {
                sim.SpawnBlock();
                int dx = MinCog.randomHorizontalVelocity ? -_random.Next(-1, 2) : 0;
                while (sim.CurrentBlockYPos < 14)
                {
                    sim.PassSensorReading();
                    sim.FallOneStep(dx, 1);
                   // sim.FallOneStep(0, 1);
                    Thread.Sleep(100);
                    DrawArray(e.Graphics, sim.Board);
                }
                sim.CheckHits(0.8);
                DrawArray(e.Graphics, sim.Board);
            }
            System.Diagnostics.Debug.WriteLine("Bad hits: "+sim.BadHits);
            System.Diagnostics.Debug.WriteLine("Avoid: " + sim.Avoid);
            System.Diagnostics.Debug.WriteLine("Good hits: "+sim.GoodHits);
        }

        public void DrawArray(Graphics g, int[,] array)
        {
            g.Clear(Color.White);
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    switch (array[i, j])
                    {
                        case 1:
                            g.FillRectangle(RedBrush, j*10, i*10, 9, 10);
                            break;
                        case 2:
                            g.FillRectangle(BlueBrush, j*10, i*10, 9, 10);
                            break;
                    }
                }
            }
        }


        public void testNet(MinCogPhenotype pheno)
        {
            MinCogAgent agent = new MinCogAgent(pheno);
            List<bool[]> testInputs = new List<bool[]>();
            bool[] input = new bool[5];
            input[0] = true;
            input[1] = true;
            input[2] = true;
            input[3] = true;
            input[4] = true;
            testInputs.Add(input);

            bool[] input2 = new bool[5];
            input[0] = false;
            input[1] = false;
            input[2] = false;
            input[3] = false;
            input[4] = false;
            testInputs.Add(input2);

            bool[] input3 = new bool[5];
            input[0] = true;
            input[1] = true;
            input[2] = false;
            input[3] = false;
            input[4] = false;
            testInputs.Add(input3);

            bool[] input4 = new bool[5];
            input[0] = false;
            input[1] = true;
            input[2] = true;
            input[3] = false;
            input[4] = false;
            testInputs.Add(input4);

            bool[] input5 = new bool[5];
            input[0] = false;
            input[1] = false;
            input[2] = false;
            input[3] = true;
            input[4] = true;
            testInputs.Add(input5);

            bool[] input6 = new bool[5];
            input[0] = false;
            input[1] = false;
            input[2] = true;
            input[3] = true;
            input[4] = true;
            testInputs.Add(input6);

            bool[] input7 = new bool[5];
            input[0] = false;
            input[1] = true;
            input[2] = true;
            input[3] = true;
            input[4] = true;
            testInputs.Add(input7);

            bool[] input8 = new bool[5];
            input[0] = true;
            input[1] = true;
            input[2] = true;
            input[3] = true;
            input[4] = false;
            testInputs.Add(input8);
            Debug.WriteLine("--------------------- Test -----------------------");
            foreach (bool[] it in testInputs)
            {
                Debug.Write("--------------- Next input --------------------");
                agent.SetNewPosition(input);
            }
        }
    }
}
