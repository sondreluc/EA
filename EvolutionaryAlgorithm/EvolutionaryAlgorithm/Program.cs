﻿using EvolutionaryAlgorithm.EvolutionaryAlgorithms;
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

            //MinCog sn = new MinCog(100, 300, 0.1, 0.9, "A-I", "sigma");
            //sn.EvolutionLoop();
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Simulator(sn.TheOneAndOnly));


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Gui());
        }
    }
}