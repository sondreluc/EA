using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using EvolutionaryAlgorithm.EvolutionaryAlgorithms;

namespace EvolutionaryAlgorithm
{
    public partial class Gui : Form
    {
        private static readonly Random Random = new Random();

        public Gui()
        {
            InitializeComponent();
            var col1 = new DataGridViewTextBoxColumn();
            var col2 = new DataGridViewTextBoxColumn();
            var col3 = new DataGridViewTextBoxColumn();
            var col4 = new DataGridViewTextBoxColumn();
            var col5 = new DataGridViewTextBoxColumn();
            col1.HeaderText = "Generation";
            col2.HeaderText = "Highest fitness";
            col3.HeaderText = "Average fitness";
            col4.HeaderText = "Standard deviation";
            col5.Name = "Average strategy entropy";
            col5.HeaderText = "Average strategy entropy";
            dataGridView1.Columns.Add(col1);
            dataGridView1.Columns.Add(col2);
            dataGridView1.Columns.Add(col3);
            dataGridView1.Columns.Add(col4);
            dataGridView1.Columns.Add(col5);
            dataGridView1.ShowEditingIcon = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            FitnessChart.ChartAreas["ChartArea2"].Visible = false;
        }

        private void RunButtonClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(problemBox.Text))
            {
                errorProvider1.SetError(problemBox, "Select a problem");
            }
            else if (string.IsNullOrEmpty(populationSize.Text))
            {
                errorProvider1.SetError(populationSize, "Fill inn a integer");
            }
            else if (string.IsNullOrEmpty(genotypeSize.Text))
            {
                errorProvider1.SetError(genotypeSize, "Fill inn a integer");
            }
            else if (string.IsNullOrEmpty(generations.Text))
            {
                errorProvider1.SetError(generations, "Fill inn a integer");
            }
            else if (string.IsNullOrEmpty(protocolBox.Text))
            {
                errorProvider1.SetError(protocolBox, "Select a selection-protocol");
            }
            else if (string.IsNullOrEmpty(mutationRate.Text))
            {
                errorProvider1.SetError(mutationRate, "Fill inn a double( 0 < x < 1 )");
            }
            else if (string.IsNullOrEmpty(crossoverRate.Text))
            {
                errorProvider1.SetError(crossoverRate, "Fill inn a double( 0 < x < 1 )");
            }
            else if (string.IsNullOrEmpty(mechanismBox.Text))
            {
                errorProvider1.SetError(mechanismBox, "Select a selection-mechanism");
            }
            else if (problemBox.Text == "OneMax" && string.IsNullOrEmpty(problemComboBox1.Text))
            {
                errorProvider1.SetError(problemComboBox1, "Select a goal vector");
            }
            else if (problemBox.Text == "Colonel Blotto" && string.IsNullOrEmpty(problemTextBox1.Text))
            {
                errorProvider1.SetError(problemTextBox1, "Fill in a double( 0 < x < 1 )");
            }
            else if (problemBox.Text == "Colonel Blotto" && string.IsNullOrEmpty(problemTextBox2.Text))
            {
                errorProvider1.SetError(problemTextBox2, "Fill in a double( 0 < x < 1 )");
            }
            else if (problemBox.Text == "Izhikevich Spiking Neuron" && string.IsNullOrEmpty(problemComboBox1.Text))
            {
                errorProvider1.SetError(problemComboBox1, "Select spike distence metric");
            }
            else
            {
                errorProvider1.Clear();

                int popSize = 0;
                int genoSize = 0;
                int genes = 0;
                double mutRate = 0.0;
                double xOverRate = 0.0;
                double lossfract = 0.0;
                double replacfract = 0.0;

                try
                {
                    popSize = Convert.ToInt16(populationSize.Text);
                    genoSize = Convert.ToInt16(genotypeSize.Text);
                    genes = Convert.ToInt16(generations.Text);
                    mutRate = Convert.ToDouble(mutationRate.Text.Replace('.', ','));
                    xOverRate = Convert.ToDouble(crossoverRate.Text.Replace('.', ','));
                    replacfract = Convert.ToDouble(problemTextBox1.Text.Replace('.', ','));
                    lossfract = Convert.ToDouble(problemTextBox2.Text.Replace('.', ','));
                }
                catch (Exception)
                {
                }

                string prot = protocolBox.Text;
                string mech = mechanismBox.Text;


                dataGridView1.Rows.Clear();
                FitnessChart.ResetText();

                int sleepTime = 1000/genes;
                if (sleepTime < 1) sleepTime = 0;

                OneMax oneMax = null;
                ColonelBlotto colonelBlotto = null;
                SpikingNeuron sn = null;
                MinCog mc = null;
                var oneMaxGoalVector = new List<int>();
                if (problemBox.Text == "OneMax")
                {
                    if (problemComboBox1.Text == "Random vector")
                    {
                        for (int j = 0; j < genoSize; j++)
                        {
                            oneMaxGoalVector.Add(Random.Next(0, 2));
                        }
                    }
                    else
                    {
                        for (int j = 0; j < genoSize; j++)
                        {
                            oneMaxGoalVector.Add(1);
                        }
                    }

                    oneMax = new OneMax(popSize, genes, oneMaxGoalVector, mutRate, xOverRate, prot, mech);
                }

                else if (problemBox.Text == "Colonel Blotto")
                {
                    colonelBlotto = new ColonelBlotto(popSize, genes, genoSize, mutRate, xOverRate, prot, mech,
                                                      replacfract, lossfract);
                }

                else if (problemBox.Text == "Izhikevich Spiking Neuron")
                {
                    sn = new SpikingNeuron(popSize, genes, Convert.ToInt16(problemComboBox2.Text), mutRate, xOverRate,
                                           prot, mech, problemComboBox1.Text);
                }
                else
                {
                    mc = new MinCog(popSize, genes, mutRate, xOverRate, prot, mech);  
                }

                FitnessChart.Series["Highest fitness"].Points.Clear();
                FitnessChart.Series["Average fitness"].Points.Clear();
                FitnessChart.Series["Standard deviation"].Points.Clear();
                FitnessChart.Series["AvgEntropy"].Points.Clear();
                outputTextBox.Clear();

                outputTextBox.Text += "# Running " + problemBox.Text + " Evolutionary Algorithm." + Environment.NewLine;
                outputTextBox.Text += "# Maximum number of generations: " + genes + Environment.NewLine;
                outputTextBox.Text += "# Population size: " + popSize + Environment.NewLine;
                outputTextBox.Text += "# Mutation rate: " + mutRate + Environment.NewLine;
                outputTextBox.Text += "# Crossover rate: " + xOverRate + Environment.NewLine;
                outputTextBox.Text += "# Selection protocol: " + prot + Environment.NewLine;
                outputTextBox.Text += "# Selection mechanism: " + mech + Environment.NewLine;

                if (problemBox.Text == "OneMax")
                {
                    outputTextBox.Text += "# " + Environment.NewLine;
                    outputTextBox.Text += "# The goal vector is: [";

                    foreach (int i in oneMaxGoalVector)
                    {
                        outputTextBox.Text += i + " ";
                    }
                    outputTextBox.Text += "]" + Environment.NewLine;
                }
                else if (problemBox.Text == "Colonel Blotto")
                {
                    outputTextBox.Text += "# Replacement fraction: " + replacfract + Environment.NewLine;
                    outputTextBox.Text += "# Loss fraction: " + lossfract + Environment.NewLine;
                }
                else if (problemBox.Text == "Izhikevich Spiking Neuron" && sn != null)
                {
                    SpikeTrainChart.Series["Goal Train"].Points.Clear();
                    for (int i = 0; i < sn.GoalSpike.Count - 1; i++)
                    {
                        SpikeTrainChart.Series["Goal Train"].Points.AddXY(i, sn.GoalSpike.ElementAt(i));
                    }
                    Update();
                }


                double best = 0.0;
                for (int i = 0; i < genes; i++)
                {
                    Thread.Sleep(sleepTime);
                    if (problemBox.Text == "OneMax" && oneMax != null)
                    {
                        oneMax.Evolve();
                        FitnessChart.Series["Highest fitness"].Points.AddXY
                            (i, oneMax.High);
                        FitnessChart.Series["Average fitness"].Points.AddXY
                            (i, oneMax.Average);
                        FitnessChart.Series["Standard deviation"].Points.AddXY
                            (i, oneMax.SD);
                        dataGridView1.Rows.Add(i + 1, oneMax.High, oneMax.Average, oneMax.SD);
                        dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
                        dataGridView1.Refresh();

                        Update();
                        //outputTextBox.Text += "# Generation " + i + Environment.NewLine;
                        //outputTextBox.Text += "# Highest fitness: " + oneMax.High + Environment.NewLine;
                        //outputTextBox.Text += "# Average fitness: " + oneMax.Average + Environment.NewLine;
                        //outputTextBox.Text += "# Standard deviation: " + oneMax.SD + Environment.NewLine;
                        if ((oneMax.Population.CurrentPopulation.Max(x => x.Fitness)) >= 1.0)
                        {
                            outputTextBox.Text += "# Problem solved in " + (i + 1) + " generations! " +
                                                  Environment.NewLine;
                            break;
                        }
                        if (!((oneMax.Population.CurrentPopulation.Max(x => x.Fitness)) >= 1.0) && i == genes - 1)
                        {
                            outputTextBox.Text += "# Problem was not solved in " + (i + 1) + " generations. " +
                                                  Environment.NewLine;
                            outputTextBox.Text += "# Highest fitness reached: " + oneMax.High + Environment.NewLine;
                            outputTextBox.Text += "# Average fitness last generation : " + oneMax.Average +
                                                  Environment.NewLine;
                            outputTextBox.Text += "# Standard deviation last generation: " + oneMax.SD +
                                                  Environment.NewLine;
                            break;
                        }
                    }
                    else if (problemBox.Text == "Colonel Blotto" && colonelBlotto != null)
                    {
                        colonelBlotto.Evolve();
                        outputTextBox.Text += "# Generation " + i + Environment.NewLine;
                        outputTextBox.Text += "# The winning strategy is: ";
                        outputTextBox.Text += colonelBlotto.Winner.ArmyToString() + Environment.NewLine;
                        outputTextBox.Text += "# Entropy of winner: " + colonelBlotto.Winner.Entropy +
                                              Environment.NewLine;

                        FitnessChart.Series["Highest fitness"].Points.AddXY
                            (i, colonelBlotto.High);
                        FitnessChart.Series["Average fitness"].Points.AddXY
                            (i, colonelBlotto.Average);
                        FitnessChart.Series["Standard deviation"].Points.AddXY
                            (i, colonelBlotto.SD);
                        FitnessChart.Series["AvgEntropy"].Points.AddXY
                            (i, colonelBlotto.AverageEntropy);
                        dataGridView1.Rows.Add(i + 1, colonelBlotto.High, colonelBlotto.Average, colonelBlotto.SD,
                                               colonelBlotto.AverageEntropy);
                        dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
                        dataGridView1.Refresh();


                        //outputTextBox.Text += "# Highest fitness: " + colonelBlotto.High + Environment.NewLine;
                        //outputTextBox.Text += "# Average fitness: " + colonelBlotto.Average + Environment.NewLine;
                        //outputTextBox.Text += "# Standard deviation: " + colonelBlotto.SD + Environment.NewLine;
                        //outputTextBox.Text += "# Average strategy entropy: " + colonelBlotto.AverageEntropy + Environment.NewLine;

                        Update();
                    }
                    else if (problemBox.Text == "Izhikevich Spiking Neuron" && sn != null)
                    {
                        sn.Evolve();

                        FitnessChart.Series["Highest fitness"].Points.AddXY
                            (i, sn.High);
                        FitnessChart.Series["Average fitness"].Points.AddXY
                            (i, sn.Average);
                        FitnessChart.Series["Standard deviation"].Points.AddXY
                            (i, sn.SD);
                        dataGridView1.Rows.Add(i + 1, sn.High, sn.Average, sn.SD);
                        dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
                        dataGridView1.Refresh();
                        //foreach (IzhikevichPhenotype phenotype in sn.Population.CurrentPopulation)
                        //{
                        //    SpikeTrainChart.Series["Best of run Spike Train"].Points.Clear();
                        //    for (var j = 0; j < phenotype.Train.Count - 1; j++)
                        //    {
                        //        SpikeTrainChart.Series["Best of run Spike Train"].Points.AddXY(j,
                        //                                                                       phenotype.Train
                        //                                                                         .ElementAt(j));
                        //    }
                        //    SpikeTrainChart.Legends.FindByName("Legend1").CustomItems.FirstOrDefault(x => x.Name == "Fitness").Cells.Last().Text = phenotype.Fitness.ToString();
                        //    SpikeTrainChart.Legends.FindByName("Legend1").CustomItems.FirstOrDefault(x => x.Name == "a").Cells.Last().Text = phenotype.a.ToString();
                        //    SpikeTrainChart.Legends.FindByName("Legend1").CustomItems.FirstOrDefault(x => x.Name == "b").Cells.Last().Text = phenotype.b.ToString();
                        //    SpikeTrainChart.Legends.FindByName("Legend1").CustomItems.FirstOrDefault(x => x.Name == "c").Cells.Last().Text = phenotype.c.ToString();
                        //    SpikeTrainChart.Legends.FindByName("Legend1").CustomItems.FirstOrDefault(x => x.Name == "d").Cells.Last().Text = phenotype.d.ToString();
                        //    SpikeTrainChart.Legends.FindByName("Legend1").CustomItems.FirstOrDefault(x => x.Name == "k").Cells.Last().Text = phenotype.k.ToString();
                        //    Update();
                        //}

                        if (best < sn.BestOfRun.Fitness)
                        {
                            best = sn.BestOfRun.Fitness;
                            SpikeTrainChart.Series["Best of run Spike Train"].Points.Clear();
                            for (int j = 0; j < sn.BestOfRun.Train.Count - 1; j++)
                            {
                                SpikeTrainChart.Series["Best of run Spike Train"].Points.AddXY(j,
                                                                                               sn.BestOfRun.Train
                                                                                                 .ElementAt(j));
                            }
                            SpikeTrainChart.Legends.FindByName("Legend1")
                                           .CustomItems.FirstOrDefault(x => x.Name == "Fitness")
                                           .Cells.Last()
                                           .Text = sn.BestOfRun.Fitness.ToString();
                            SpikeTrainChart.Legends.FindByName("Legend1")
                                           .CustomItems.FirstOrDefault(x => x.Name == "a")
                                           .Cells.Last()
                                           .Text = sn.BestOfRun.a.ToString();
                            SpikeTrainChart.Legends.FindByName("Legend1")
                                           .CustomItems.FirstOrDefault(x => x.Name == "b")
                                           .Cells.Last()
                                           .Text = sn.BestOfRun.b.ToString();
                            SpikeTrainChart.Legends.FindByName("Legend1")
                                           .CustomItems.FirstOrDefault(x => x.Name == "c")
                                           .Cells.Last()
                                           .Text = sn.BestOfRun.c.ToString();
                            SpikeTrainChart.Legends.FindByName("Legend1")
                                           .CustomItems.FirstOrDefault(x => x.Name == "d")
                                           .Cells.Last()
                                           .Text = sn.BestOfRun.d.ToString();
                            SpikeTrainChart.Legends.FindByName("Legend1")
                                           .CustomItems.FirstOrDefault(x => x.Name == "k")
                                           .Cells.Last()
                                           .Text = sn.BestOfRun.k.ToString();
                        }

                        Update();
                    }
                    else if (problemBox.Text == "MinCog" && mc != null)
                    {
                        mc.Evolve();
                        FitnessChart.Series["Highest fitness"].Points.AddXY
                            (i, mc.High);
                        FitnessChart.Series["Average fitness"].Points.AddXY
                            (i, mc.Average);
                        FitnessChart.Series["Standard deviation"].Points.AddXY
                            (i, mc.SD);
                        dataGridView1.Rows.Add(i + 1, mc.High, mc.Average, mc.SD);
                        dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
                        dataGridView1.Refresh();

                        Update();
                        if (i == genes-1)
                        {
                            var simulator = new Simulator(mc.BestOfRun);
                            simulator.Show();
                        }
                    }
                    

                    outputTextBox.Select(outputTextBox.Text.Length - 1, 0);
                    outputTextBox.ScrollToCaret();
                }
                outputTextBox.Text += "#" + Environment.NewLine + "#" + Environment.NewLine + "#" + Environment.NewLine;
                outputTextBox.Select(outputTextBox.Text.Length - 1, 0);
                outputTextBox.ScrollToCaret();
            }
        }

        private void ProblemBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            switch (problemBox.Text)
            {
                case "OneMax":
                    label2.Text = "Genotype size";
                    genotypeSize.Text = "40";
                    genotypeSize.ReadOnly = false;
                    probLabel1.Text = "Goal vector";
                    probLabel1.Visible = true;
                    problemComboBox1.Location = problemTextBox1.Location;
                    problemComboBox1.Visible = true;
                    problemComboBox1.Items.Clear();
                    problemComboBox1.Items.Add("Ones(1) vector");
                    problemComboBox1.Items.Add("Random vector");
                    problemTextBox2.Visible =
                        problemTextBox3.Visible =
                        problemTextBox4.Visible = problemTextBox5.Visible = problemTextBox6.Visible = false;
                    probLabel2.Text = probLabel3.Text = probLabel4.Text = probLabel5.Text = probLabel6.Text = "";
                    FitnessChart.Series.FindByName("AvgEntropy").Enabled = false;
                    dataGridView1.Columns["Average strategy entropy"].Visible = false;
                    FitnessChart.ChartAreas["ChartArea2"].Visible = false;
                    FitnessChart.Width = 980;
                    SpikeTrainChart.Visible = false;
                    break;
                case "Colonel Blotto":
                    label2.Text = "Number of battles";
                    genotypeSize.Text = "10";
                    genotypeSize.ReadOnly = false;
                    probLabel1.Text = "Reployment fraction";
                    problemTextBox1.Visible = true;
                    problemTextBox1.Text = "1,0";
                    probLabel2.Text = "Loss fraction";
                    problemTextBox2.Visible = true;
                    problemTextBox2.Text = "0,1";
                    problemComboBox1.Visible = false;
                    probLabel3.Text = probLabel4.Text = probLabel5.Text = probLabel6.Text = "";
                    FitnessChart.Series.FindByName("AvgEntropy").Enabled = true;
                    dataGridView1.Columns["Average strategy entropy"].Visible = true;
                    FitnessChart.ChartAreas["ChartArea2"].Visible = true;
                    FitnessChart.Width = 980;
                    SpikeTrainChart.Visible = false;
                    break;
                case "Izhikevich Spiking Neuron":
                    FitnessChart.ChartAreas["ChartArea2"].Visible = true;
                    FitnessChart.Series.FindByName("AvgEntropy").Enabled = false;
                    probLabel1.Text = "SDM";
                    probLabel1.Visible = true;
                    problemComboBox1.Location = problemTextBox1.Location;
                    problemComboBox1.Visible = true;
                    problemComboBox1.Items.Clear();
                    problemComboBox1.Items.Add("Time");
                    problemComboBox1.Items.Add("Interval");
                    problemComboBox1.Items.Add("Waveform");
                    problemComboBox2.Location = problemTextBox2.Location;
                    problemComboBox2.Visible = true;
                    problemComboBox2.Items.Clear();
                    problemComboBox2.Items.Add("1");
                    problemComboBox2.Items.Add("2");
                    problemComboBox2.Items.Add("3");
                    problemComboBox2.Items.Add("4");
                    probLabel2.Text = "Dataset";
                    probLabel2.Visible = true;
                    FitnessChart.ChartAreas["ChartArea2"].Visible = false;
                    FitnessChart.Width = 492;
                    SpikeTrainChart.Visible = true;
                    dataGridView1.Columns["Average strategy entropy"].Visible = false;
                    genotypeSize.Text = "35";
                    genotypeSize.ReadOnly = true;
                    break;
                case "MinCog":
                    label2.Text = "Genotype size";
                    genotypeSize.Text = "272";
                    genotypeSize.ReadOnly = false;
                    probLabel1.Visible = false;
                    problemComboBox1.Location = problemTextBox1.Location;
                    problemComboBox1.Visible = false;
                    problemComboBox1.Items.Clear();
                    problemTextBox2.Visible =
                        problemTextBox3.Visible =
                        problemTextBox4.Visible = problemTextBox5.Visible = problemTextBox6.Visible = false;
                    probLabel2.Text = probLabel3.Text = probLabel4.Text = probLabel5.Text = probLabel6.Text = "";
                    FitnessChart.Series.FindByName("AvgEntropy").Enabled = false;
                    dataGridView1.Columns["Average strategy entropy"].Visible = false;
                    FitnessChart.ChartAreas["ChartArea2"].Visible = false;
                    FitnessChart.Width = 980;
                    SpikeTrainChart.Visible = false;
                    break;
            }
        }
    }
}