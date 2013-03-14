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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Simulator());

            //SpikingNeuron sn = new SpikingNeuron(20, 50, 1, 0.1, 0.9, "A-I", "fitness-prop", "time");
            //sn.EvolutionLoop();
            //sn = new SpikingNeuron(20, 50, 1, 0.1, 0.9, "A-I", "sigma", "interval");
            //sn.EvolutionLoop();
            //sn = new SpikingNeuron(20, 50, 1, 0.1, 0.9, "A-I", "tournament", "waveform");
            //sn.EvolutionLoop();
        }
    }
}