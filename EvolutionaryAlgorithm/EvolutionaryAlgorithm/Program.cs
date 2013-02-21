using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EvolutionaryAlgorithm.EvolutionaryAlgorithms;

namespace EvolutionaryAlgorithm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Gui());
            //List<int> list = new List<int>();
            //for (int i = 0; i < 40; i++)
            //{
            //    list.Add(1);
            //}
            //int count = 0;
            //for (int i = 0; i < 100; i++)
            //{
            //    OneMax om = new OneMax(250, 100, list, 0.5, 0.2, "A-I", "fitness-prop");
            //    om.EvolutionLoop();
            //    if (om.win)
            //    {
            //        count++;
            //    }
            //}
            //System.Diagnostics.Debug.WriteLine(count);
            

            //ColonelBlotto cb = new ColonelBlotto(10, 100, 5, 0.1, 0.2, "A-I", "Sigma", 1.0, 0.1);
            //cb.EvolutionLoop();
          
        }
    }
}
