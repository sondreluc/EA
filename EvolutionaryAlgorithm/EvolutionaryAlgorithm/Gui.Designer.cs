namespace EvolutionaryAlgorithm
{
    partial class Gui
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.FitnessChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.run_button = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.problemBox = new System.Windows.Forms.ComboBox();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.crossoverRate = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.genotypeSize = new System.Windows.Forms.TextBox();
            this.protocolBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.mechanismBox = new System.Windows.Forms.ComboBox();
            this.generations = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.mutationRate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.populationSize = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.problemComboBox1 = new System.Windows.Forms.ComboBox();
            this.problemTextBox6 = new System.Windows.Forms.TextBox();
            this.problemTextBox5 = new System.Windows.Forms.TextBox();
            this.probLabel6 = new System.Windows.Forms.Label();
            this.problemTextBox3 = new System.Windows.Forms.TextBox();
            this.probLabel3 = new System.Windows.Forms.Label();
            this.problemTextBox4 = new System.Windows.Forms.TextBox();
            this.probLabel4 = new System.Windows.Forms.Label();
            this.probLabel5 = new System.Windows.Forms.Label();
            this.problemTextBox2 = new System.Windows.Forms.TextBox();
            this.probLabel2 = new System.Windows.Forms.Label();
            this.probLabel1 = new System.Windows.Forms.Label();
            this.problemTextBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.FitnessChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // FitnessChart
            // 
            chartArea1.Name = "ChartArea1";
            chartArea2.Name = "ChartArea2";
            this.FitnessChart.ChartAreas.Add(chartArea1);
            this.FitnessChart.ChartAreas.Add(chartArea2);
            legend1.Name = "Legend1";
            this.FitnessChart.Legends.Add(legend1);
            this.FitnessChart.Location = new System.Drawing.Point(12, 12);
            this.FitnessChart.Name = "FitnessChart";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series1.Legend = "Legend1";
            series1.Name = "Highest fitness";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series2.Legend = "Legend1";
            series2.Name = "Average fitness";
            series3.BorderWidth = 2;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series3.Legend = "Legend1";
            series3.Name = "Standard deviation";
            series4.BorderWidth = 2;
            series4.ChartArea = "ChartArea2";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series4.Legend = "Legend1";
            series4.Name = "AvgEntropy";
            this.FitnessChart.Series.Add(series1);
            this.FitnessChart.Series.Add(series2);
            this.FitnessChart.Series.Add(series3);
            this.FitnessChart.Series.Add(series4);
            this.FitnessChart.Size = new System.Drawing.Size(971, 277);
            this.FitnessChart.TabIndex = 0;
            this.FitnessChart.Text = "Fitness Chart";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            title1.Text = "Fitness chart";
            this.FitnessChart.Titles.Add(title1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 295);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(492, 146);
            this.dataGridView1.TabIndex = 20;
            // 
            // run_button
            // 
            this.run_button.Location = new System.Drawing.Point(510, 492);
            this.run_button.Name = "run_button";
            this.run_button.Size = new System.Drawing.Size(473, 38);
            this.run_button.TabIndex = 15;
            this.run_button.Text = "Run";
            this.run_button.UseVisualStyleBackColor = true;
            this.run_button.Click += new System.EventHandler(this.RunButtonClick);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // problemBox
            // 
            this.problemBox.FormattingEnabled = true;
            this.problemBox.Items.AddRange(new object[] {
            "OneMax",
            "Colonel Blotto"});
            this.problemBox.Location = new System.Drawing.Point(597, 292);
            this.problemBox.Name = "problemBox";
            this.problemBox.Size = new System.Drawing.Size(110, 21);
            this.problemBox.TabIndex = 1;
            this.problemBox.SelectedIndexChanged += new System.EventHandler(this.ProblemBoxSelectedIndexChanged);
            // 
            // outputTextBox
            // 
            this.outputTextBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.outputTextBox.Location = new System.Drawing.Point(12, 447);
            this.outputTextBox.Multiline = true;
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputTextBox.Size = new System.Drawing.Size(492, 85);
            this.outputTextBox.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(514, 295);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Select problem";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.crossoverRate);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.genotypeSize);
            this.groupBox1.Controls.Add(this.protocolBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.mechanismBox);
            this.groupBox1.Controls.Add(this.generations);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.mutationRate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.populationSize);
            this.groupBox1.Location = new System.Drawing.Point(510, 318);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(222, 168);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "EA-Parameters";
            // 
            // crossoverRate
            // 
            this.crossoverRate.Location = new System.Drawing.Point(101, 100);
            this.crossoverRate.Name = "crossoverRate";
            this.crossoverRate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.crossoverRate.Size = new System.Drawing.Size(89, 20);
            this.crossoverRate.TabIndex = 6;
            this.crossoverRate.Text = "0,1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 101);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Crossover rate";
            // 
            // genotypeSize
            // 
            this.genotypeSize.Location = new System.Drawing.Point(101, 37);
            this.genotypeSize.Name = "genotypeSize";
            this.genotypeSize.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.genotypeSize.Size = new System.Drawing.Size(89, 20);
            this.genotypeSize.TabIndex = 3;
            this.genotypeSize.Text = "40";
            // 
            // protocolBox
            // 
            this.protocolBox.FormattingEnabled = true;
            this.protocolBox.Items.AddRange(new object[] {
            "A-I",
            "A-II",
            "A-III"});
            this.protocolBox.Location = new System.Drawing.Point(101, 122);
            this.protocolBox.Name = "protocolBox";
            this.protocolBox.Size = new System.Drawing.Size(89, 21);
            this.protocolBox.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Selection";
            // 
            // mechanismBox
            // 
            this.mechanismBox.FormattingEnabled = true;
            this.mechanismBox.Items.AddRange(new object[] {
            "Fitness-prop",
            "Rank",
            "Sigma",
            "Tournament"});
            this.mechanismBox.Location = new System.Drawing.Point(101, 144);
            this.mechanismBox.Name = "mechanismBox";
            this.mechanismBox.Size = new System.Drawing.Size(89, 21);
            this.mechanismBox.TabIndex = 8;
            // 
            // generations
            // 
            this.generations.Location = new System.Drawing.Point(101, 58);
            this.generations.Name = "generations";
            this.generations.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.generations.Size = new System.Drawing.Size(89, 20);
            this.generations.TabIndex = 4;
            this.generations.Text = "100";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Generations";
            // 
            // mutationRate
            // 
            this.mutationRate.Location = new System.Drawing.Point(101, 79);
            this.mutationRate.Name = "mutationRate";
            this.mutationRate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mutationRate.Size = new System.Drawing.Size(89, 20);
            this.mutationRate.TabIndex = 5;
            this.mutationRate.Text = "0,1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Mutation rate";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Protocol";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Genotype size";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Population size";
            // 
            // populationSize
            // 
            this.populationSize.Location = new System.Drawing.Point(101, 16);
            this.populationSize.Name = "populationSize";
            this.populationSize.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.populationSize.Size = new System.Drawing.Size(89, 20);
            this.populationSize.TabIndex = 2;
            this.populationSize.Tag = "";
            this.populationSize.Text = "20";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.problemComboBox1);
            this.groupBox2.Controls.Add(this.problemTextBox6);
            this.groupBox2.Controls.Add(this.problemTextBox5);
            this.groupBox2.Controls.Add(this.probLabel6);
            this.groupBox2.Controls.Add(this.problemTextBox3);
            this.groupBox2.Controls.Add(this.probLabel3);
            this.groupBox2.Controls.Add(this.problemTextBox4);
            this.groupBox2.Controls.Add(this.probLabel4);
            this.groupBox2.Controls.Add(this.probLabel5);
            this.groupBox2.Controls.Add(this.problemTextBox2);
            this.groupBox2.Controls.Add(this.probLabel2);
            this.groupBox2.Controls.Add(this.probLabel1);
            this.groupBox2.Controls.Add(this.problemTextBox1);
            this.groupBox2.Location = new System.Drawing.Point(738, 318);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(245, 168);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Problem-Parameters";
            // 
            // problemComboBox1
            // 
            this.problemComboBox1.FormattingEnabled = true;
            this.problemComboBox1.Location = new System.Drawing.Point(120, 120);
            this.problemComboBox1.Name = "problemComboBox1";
            this.problemComboBox1.Size = new System.Drawing.Size(89, 21);
            this.problemComboBox1.TabIndex = 11;
            this.problemComboBox1.Visible = false;
            // 
            // problemTextBox6
            // 
            this.problemTextBox6.Location = new System.Drawing.Point(120, 121);
            this.problemTextBox6.Name = "problemTextBox6";
            this.problemTextBox6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.problemTextBox6.Size = new System.Drawing.Size(89, 20);
            this.problemTextBox6.TabIndex = 15;
            this.problemTextBox6.Visible = false;
            // 
            // problemTextBox5
            // 
            this.problemTextBox5.Location = new System.Drawing.Point(120, 100);
            this.problemTextBox5.Name = "problemTextBox5";
            this.problemTextBox5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.problemTextBox5.Size = new System.Drawing.Size(89, 20);
            this.problemTextBox5.TabIndex = 14;
            this.problemTextBox5.Visible = false;
            // 
            // probLabel6
            // 
            this.probLabel6.AutoSize = true;
            this.probLabel6.Location = new System.Drawing.Point(7, 124);
            this.probLabel6.Name = "probLabel6";
            this.probLabel6.Size = new System.Drawing.Size(0, 13);
            this.probLabel6.TabIndex = 13;
            this.probLabel6.Visible = false;
            // 
            // problemTextBox3
            // 
            this.problemTextBox3.Location = new System.Drawing.Point(120, 58);
            this.problemTextBox3.Name = "problemTextBox3";
            this.problemTextBox3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.problemTextBox3.Size = new System.Drawing.Size(89, 20);
            this.problemTextBox3.TabIndex = 11;
            this.problemTextBox3.Visible = false;
            // 
            // probLabel3
            // 
            this.probLabel3.AutoSize = true;
            this.probLabel3.Location = new System.Drawing.Point(7, 61);
            this.probLabel3.Name = "probLabel3";
            this.probLabel3.Size = new System.Drawing.Size(0, 13);
            this.probLabel3.TabIndex = 10;
            // 
            // problemTextBox4
            // 
            this.problemTextBox4.Location = new System.Drawing.Point(120, 79);
            this.problemTextBox4.Name = "problemTextBox4";
            this.problemTextBox4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.problemTextBox4.Size = new System.Drawing.Size(89, 20);
            this.problemTextBox4.TabIndex = 9;
            this.problemTextBox4.Visible = false;
            // 
            // probLabel4
            // 
            this.probLabel4.AutoSize = true;
            this.probLabel4.Location = new System.Drawing.Point(7, 80);
            this.probLabel4.Name = "probLabel4";
            this.probLabel4.Size = new System.Drawing.Size(0, 13);
            this.probLabel4.TabIndex = 8;
            this.probLabel4.Visible = false;
            // 
            // probLabel5
            // 
            this.probLabel5.AutoSize = true;
            this.probLabel5.Location = new System.Drawing.Point(7, 101);
            this.probLabel5.Name = "probLabel5";
            this.probLabel5.Size = new System.Drawing.Size(0, 13);
            this.probLabel5.TabIndex = 6;
            this.probLabel5.Visible = false;
            // 
            // problemTextBox2
            // 
            this.problemTextBox2.Location = new System.Drawing.Point(120, 37);
            this.problemTextBox2.Name = "problemTextBox2";
            this.problemTextBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.problemTextBox2.Size = new System.Drawing.Size(89, 20);
            this.problemTextBox2.TabIndex = 10;
            this.problemTextBox2.Visible = false;
            // 
            // probLabel2
            // 
            this.probLabel2.AutoSize = true;
            this.probLabel2.Location = new System.Drawing.Point(7, 40);
            this.probLabel2.Name = "probLabel2";
            this.probLabel2.Size = new System.Drawing.Size(0, 13);
            this.probLabel2.TabIndex = 4;
            // 
            // probLabel1
            // 
            this.probLabel1.AutoSize = true;
            this.probLabel1.Location = new System.Drawing.Point(7, 19);
            this.probLabel1.Name = "probLabel1";
            this.probLabel1.Size = new System.Drawing.Size(0, 13);
            this.probLabel1.TabIndex = 2;
            // 
            // problemTextBox1
            // 
            this.problemTextBox1.Location = new System.Drawing.Point(120, 16);
            this.problemTextBox1.Name = "problemTextBox1";
            this.problemTextBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.problemTextBox1.Size = new System.Drawing.Size(89, 20);
            this.problemTextBox1.TabIndex = 9;
            this.problemTextBox1.Tag = "";
            this.problemTextBox1.Visible = false;
            // 
            // Gui
            // 
            this.ClientSize = new System.Drawing.Size(995, 544);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.problemBox);
            this.Controls.Add(this.run_button);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.FitnessChart);
            this.Name = "Gui";
            ((System.ComponentModel.ISupportInitialize)(this.FitnessChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart FitnessChart;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button run_button;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox problemBox;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox crossoverRate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox genotypeSize;
        private System.Windows.Forms.ComboBox protocolBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox mechanismBox;
        private System.Windows.Forms.TextBox generations;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox mutationRate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox populationSize;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox problemComboBox1;
        private System.Windows.Forms.TextBox problemTextBox6;
        private System.Windows.Forms.TextBox problemTextBox5;
        private System.Windows.Forms.Label probLabel6;
        private System.Windows.Forms.TextBox problemTextBox3;
        private System.Windows.Forms.Label probLabel3;
        private System.Windows.Forms.TextBox problemTextBox4;
        private System.Windows.Forms.Label probLabel4;
        private System.Windows.Forms.Label probLabel5;
        private System.Windows.Forms.TextBox problemTextBox2;
        private System.Windows.Forms.Label probLabel2;
        private System.Windows.Forms.Label probLabel1;
        private System.Windows.Forms.TextBox problemTextBox1;

    }
}

