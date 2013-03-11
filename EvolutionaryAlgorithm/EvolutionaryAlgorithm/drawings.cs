using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;

namespace EvolutionaryAlgorithm
{
    public partial class Drawings : Form
    {

        public Pen p = new Pen(Color.Black);
        public Brush RedBrush = new SolidBrush(Color.Red);
        public Brush BlueBrush = new SolidBrush(Color.Blue);
        public Rectangle Bot;
        public Rectangle Drop;
        
        public Drawings()
        {
            InitializeComponent();
        }

        private void Test(object sender, PaintEventArgs e)
        {
            //Canvas
            var testArray = new int[15,30];
            for (int i = 0; i < testArray.GetLength(0); i++)
            {
                for (int j = 0; j < testArray.GetLength(1); j++)
                {
                    testArray[i, j] = 0;
                }
            }

            
            for (int i = 0; i < 10; i++)
            {
                testArray[14, i] = 1;
                testArray[14, i+1] = 1;
                testArray[14, i+1] = 1;

                testArray[i, 15] = -1;
                testArray[i, 17] = -1;
                testArray[i, 16] = -1;
                DrawArray(e.Graphics, testArray);
                Thread.Sleep(100);
            }
            
        }

        private void DrawArray(Graphics g, int [,] array)
        {
            g.Clear(Color.White);
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == 1)
                    {
                        g.FillRectangle(RedBrush, j*10, i*10, 9, 10);
                    }
                    else if(array[i, j] == -1)
                    {
                        g.FillRectangle(BlueBrush, j*10, i*10, 9, 10);
                    }
                }
            }

        }
    }
}