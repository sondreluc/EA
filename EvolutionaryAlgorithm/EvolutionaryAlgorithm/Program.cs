using EvolutionaryAlgorithm.EvolutionaryAlgorithms;
using System;
using System.Windows.Forms;

namespace EvolutionaryAlgorithm
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Simulator());
            MinCog sn = new MinCog(20, 50, 0.1, 0.9, "A-I", "fitness-prop");
            sn.EvolutionLoop();

        }
    }
}