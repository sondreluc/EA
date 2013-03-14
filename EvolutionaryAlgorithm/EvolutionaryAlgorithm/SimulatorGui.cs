using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;
using EvolutionaryAlgorithm.Evaluators.MinCogSimulator;

namespace EvolutionaryAlgorithm
{
    public partial class Simulator : Form
    {

        public Pen p = new Pen(Color.Black);
        public Brush RedBrush = new SolidBrush(Color.Red);
        public Brush BlueBrush = new SolidBrush(Color.Blue);
        public Rectangle Bot;
        public Rectangle Drop;
        private Random _random;
        public MinCogSimulator sim;
        
        public Simulator()
        {
            InitializeComponent();
            _random = new Random();
            sim = new MinCogSimulator(null);
        }

        private void Run(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                int count = 0;
                while (count < 40)
                {
                    sim.CurrentBlockSize = _random.Next(1, 6);
                    sim.CurrentBlockXPos = _random.Next(30 - sim.CurrentBlockSize);

                    for (int j = 0; j < sim.Board.GetLength(0); j++)
                    {
                        sim.TimeStep(sim.CurrentBlockXPos, sim.CurrentBlockSize, j);
                        DrawArray(e.Graphics, sim.Board);
                        Thread.Sleep(100);
                    }

                    for (int j = sim.CurrentBlockSize; j < sim.CurrentBlockSize; j++)
                    {
                        sim.Board[sim.Board.GetLength(0) - 1, i] = 0;
                    }
                    count++;
                }
            }
        }

        public void DrawArray(Graphics g, int [,] array)
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

        private void Drawings_Load(object sender, System.EventArgs e)
        {

        }
    }
}