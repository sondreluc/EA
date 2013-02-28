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

            //SpikingNeuron sn = new SpikingNeuron(20, 50, 1, 0.1, 0.9, "A-I", "fitness-prop", "time");
            //sn.EvolutionLoop();
            //sn = new SpikingNeuron(20, 50, 1, 0.1, 0.9, "A-I", "sigma", "interval");
            //sn.EvolutionLoop();
            //sn = new SpikingNeuron(20, 50, 1, 0.1, 0.9, "A-I", "tournament", "waveform");
            //sn.EvolutionLoop();
          
        }
    }
}
