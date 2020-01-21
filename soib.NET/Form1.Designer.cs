namespace soib
{
    public partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.Transmitted = new System.Windows.Forms.ToolStripStatusLabel();
            this.DroppedTTL = new System.Windows.Forms.ToolStripStatusLabel();
            this.DroppedBufferSize = new System.Windows.Forms.ToolStripStatusLabel();
            this.DropRatio = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.RandSeed = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.BufferSize = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lambdaParam = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.networkSize2 = new System.Windows.Forms.NumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.RoutingRandom = new System.Windows.Forms.RadioButton();
            this.RoutingShortest = new System.Windows.Forms.RadioButton();
            this.RoutingManual = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.simulationTime = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.stepTime = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.simulationLength = new System.Windows.Forms.NumericUpDown();
            this.Step = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Stop = new System.Windows.Forms.Button();
            this.Run = new System.Windows.Forms.Button();
            this.Pause = new System.Windows.Forms.Button();
            this.networkSize = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.TTL = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.Packets_received = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BufferSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lambdaParam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.networkSize2)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.simulationTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stepTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simulationLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.networkSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TTL)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.Transmitted,
            this.DroppedTTL,
            this.DroppedBufferSize,
            this.DropRatio,
            this.Packets_received,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 590);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1009, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // Transmitted
            // 
            this.Transmitted.Name = "Transmitted";
            this.Transmitted.Size = new System.Drawing.Size(109, 17);
            this.Transmitted.Text = "Packets generated: ";
            // 
            // DroppedTTL
            // 
            this.DroppedTTL.Name = "DroppedTTL";
            this.DroppedTTL.Size = new System.Drawing.Size(169, 17);
            this.DroppedTTL.Text = "Packets dropped (due to TTL): ";
            // 
            // DroppedBufferSize
            // 
            this.DroppedBufferSize.Name = "DroppedBufferSize";
            this.DroppedBufferSize.Size = new System.Drawing.Size(203, 17);
            this.DroppedBufferSize.Text = "Packets dropped (due to buffer size): ";
            // 
            // DropRatio
            // 
            this.DropRatio.Name = "DropRatio";
            this.DropRatio.Size = new System.Drawing.Size(66, 17);
            this.DropRatio.Text = "Drop ratio: ";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox5);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.richTextBox1);
            this.splitContainer1.Size = new System.Drawing.Size(1009, 590);
            this.splitContainer1.SplitterDistance = 365;
            this.splitContainer1.TabIndex = 3;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.RandSeed);
            this.groupBox5.Location = new System.Drawing.Point(13, 541);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(268, 46);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Random generator seed";
            // 
            // RandSeed
            // 
            this.RandSeed.Location = new System.Drawing.Point(19, 20);
            this.RandSeed.Name = "RandSeed";
            this.RandSeed.Size = new System.Drawing.Size(243, 20);
            this.RandSeed.TabIndex = 0;
            this.RandSeed.Text = "123";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.BufferSize);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.lambdaParam);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.networkSize2);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.networkSize);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TTL);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 526);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Simulation";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(194, 96);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(45, 13);
            this.label14.TabIndex = 20;
            this.label14.Text = "packets";
            // 
            // BufferSize
            // 
            this.BufferSize.Location = new System.Drawing.Point(68, 94);
            this.BufferSize.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.BufferSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.BufferSize.Name = "BufferSize";
            this.BufferSize.Size = new System.Drawing.Size(120, 20);
            this.BufferSize.TabIndex = 19;
            this.BufferSize.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(10, 97);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 13);
            this.label15.TabIndex = 18;
            this.label15.Text = "Buffer size";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(194, 70);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 13);
            this.label13.TabIndex = 17;
            this.label13.Text = "packets/step";
            // 
            // lambdaParam
            // 
            this.lambdaParam.Location = new System.Drawing.Point(68, 68);
            this.lambdaParam.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.lambdaParam.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.lambdaParam.Name = "lambdaParam";
            this.lambdaParam.Size = new System.Drawing.Size(120, 20);
            this.lambdaParam.TabIndex = 16;
            this.lambdaParam.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 72);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(12, 13);
            this.label12.TabIndex = 15;
            this.label12.Text = "λ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(190, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "nodes";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(194, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "nodes";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(111, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "x";
            // 
            // networkSize2
            // 
            this.networkSize2.Location = new System.Drawing.Point(124, 19);
            this.networkSize2.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.networkSize2.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.networkSize2.Name = "networkSize2";
            this.networkSize2.Size = new System.Drawing.Size(60, 20);
            this.networkSize2.TabIndex = 10;
            this.networkSize2.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.networkSize2.ValueChanged += new System.EventHandler(this.networkSize2_ValueChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.RoutingRandom);
            this.groupBox3.Controls.Add(this.RoutingShortest);
            this.groupBox3.Controls.Add(this.RoutingManual);
            this.groupBox3.Location = new System.Drawing.Point(11, 275);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(257, 245);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Routing";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(78, 67);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(13, 13);
            this.label18.TabIndex = 23;
            this.label18.Text = "3";
            this.label18.Visible = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(79, 44);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(13, 13);
            this.label17.TabIndex = 22;
            this.label17.Text = "2";
            this.label17.Visible = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(78, 21);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(13, 13);
            this.label16.TabIndex = 21;
            this.label16.Text = "1";
            this.label16.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(8, 172);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(243, 67);
            this.textBox2.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(10, 89);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(241, 77);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "1, 2, 3, 4, 5,  25,  20,19,18,17,16,  11,12,13,14,15,  10,9,8,7,6,  1,  21,22,23," +
    "24,25,\r\n21,16,11,6,\r\n1, 2, 3, 4, 5,  25,  20,19,18,17,16,  11,12,13,14,15,  10,9" +
    ",8,7,6,  1,  21,22,23,24,25\r\n";
            // 
            // RoutingRandom
            // 
            this.RoutingRandom.AutoSize = true;
            this.RoutingRandom.Location = new System.Drawing.Point(8, 42);
            this.RoutingRandom.Name = "RoutingRandom";
            this.RoutingRandom.Size = new System.Drawing.Size(65, 17);
            this.RoutingRandom.TabIndex = 2;
            this.RoutingRandom.Text = "Random";
            this.RoutingRandom.UseVisualStyleBackColor = true;
            this.RoutingRandom.CheckedChanged += new System.EventHandler(this.RoutingRandom_CheckedChanged);
            // 
            // RoutingShortest
            // 
            this.RoutingShortest.AutoSize = true;
            this.RoutingShortest.Location = new System.Drawing.Point(8, 19);
            this.RoutingShortest.Name = "RoutingShortest";
            this.RoutingShortest.Size = new System.Drawing.Size(64, 17);
            this.RoutingShortest.TabIndex = 1;
            this.RoutingShortest.Text = "Shortest";
            this.RoutingShortest.UseVisualStyleBackColor = true;
            this.RoutingShortest.CheckedChanged += new System.EventHandler(this.RoutingShortest_CheckedChanged);
            // 
            // RoutingManual
            // 
            this.RoutingManual.AutoSize = true;
            this.RoutingManual.Checked = true;
            this.RoutingManual.Location = new System.Drawing.Point(8, 65);
            this.RoutingManual.Name = "RoutingManual";
            this.RoutingManual.Size = new System.Drawing.Size(60, 17);
            this.RoutingManual.TabIndex = 0;
            this.RoutingManual.TabStop = true;
            this.RoutingManual.Text = "Manual";
            this.RoutingManual.UseVisualStyleBackColor = true;
            this.RoutingManual.CheckedChanged += new System.EventHandler(this.RoutingManula_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.simulationTime);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.stepTime);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.simulationLength);
            this.groupBox2.Controls.Add(this.Step);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.Stop);
            this.groupBox2.Controls.Add(this.Run);
            this.groupBox2.Controls.Add(this.Pause);
            this.groupBox2.Location = new System.Drawing.Point(6, 116);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(262, 153);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Timing";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(188, 73);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(12, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "s";
            // 
            // simulationTime
            // 
            this.simulationTime.DecimalPlaces = 3;
            this.simulationTime.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.simulationTime.Location = new System.Drawing.Point(96, 71);
            this.simulationTime.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.simulationTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            393216});
            this.simulationTime.Name = "simulationTime";
            this.simulationTime.ReadOnly = true;
            this.simulationTime.Size = new System.Drawing.Size(85, 20);
            this.simulationTime.TabIndex = 17;
            this.simulationTime.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 73);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "Simulation time";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(188, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "ms";
            // 
            // stepTime
            // 
            this.stepTime.Location = new System.Drawing.Point(96, 46);
            this.stepTime.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.stepTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.stepTime.Name = "stepTime";
            this.stepTime.Size = new System.Drawing.Size(85, 20);
            this.stepTime.TabIndex = 14;
            this.stepTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.stepTime.ValueChanged += new System.EventHandler(this.stepTime_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Step time";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(186, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "steps";
            // 
            // simulationLength
            // 
            this.simulationLength.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.simulationLength.Location = new System.Drawing.Point(96, 19);
            this.simulationLength.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.simulationLength.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.simulationLength.Name = "simulationLength";
            this.simulationLength.Size = new System.Drawing.Size(85, 20);
            this.simulationLength.TabIndex = 7;
            this.simulationLength.ThousandsSeparator = true;
            this.simulationLength.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.simulationLength.ValueChanged += new System.EventHandler(this.simulationLength_ValueChanged);
            // 
            // Step
            // 
            this.Step.Enabled = false;
            this.Step.Location = new System.Drawing.Point(13, 123);
            this.Step.Name = "Step";
            this.Step.Size = new System.Drawing.Size(202, 23);
            this.Step.TabIndex = 7;
            this.Step.Text = "Step";
            this.Step.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Simulation length";
            // 
            // Stop
            // 
            this.Stop.Enabled = false;
            this.Stop.Location = new System.Drawing.Point(154, 97);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(61, 23);
            this.Stop.TabIndex = 6;
            this.Stop.Text = "Stop";
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // Run
            // 
            this.Run.Location = new System.Drawing.Point(13, 98);
            this.Run.Name = "Run";
            this.Run.Size = new System.Drawing.Size(54, 23);
            this.Run.TabIndex = 4;
            this.Run.Text = "Run";
            this.Run.UseVisualStyleBackColor = true;
            this.Run.Click += new System.EventHandler(this.Run_Click);
            // 
            // Pause
            // 
            this.Pause.Enabled = false;
            this.Pause.Location = new System.Drawing.Point(73, 97);
            this.Pause.Name = "Pause";
            this.Pause.Size = new System.Drawing.Size(75, 23);
            this.Pause.TabIndex = 5;
            this.Pause.Text = "Pause";
            this.Pause.UseVisualStyleBackColor = true;
            this.Pause.Click += new System.EventHandler(this.Pause_Click);
            // 
            // networkSize
            // 
            this.networkSize.Location = new System.Drawing.Point(49, 19);
            this.networkSize.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.networkSize.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.networkSize.Name = "networkSize";
            this.networkSize.Size = new System.Drawing.Size(60, 20);
            this.networkSize.TabIndex = 3;
            this.networkSize.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.networkSize.ValueChanged += new System.EventHandler(this.networkSize_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nodes";
            // 
            // TTL
            // 
            this.TTL.Location = new System.Drawing.Point(68, 43);
            this.TTL.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.TTL.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TTL.Name = "TTL";
            this.TTL.Size = new System.Drawing.Size(120, 20);
            this.TTL.TabIndex = 1;
            this.TTL.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.TTL.ValueChanged += new System.EventHandler(this.TTL_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "TTL";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(640, 590);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // Packets_received
            // 
            this.Packets_received.Name = "Packets_received";
            this.Packets_received.Size = new System.Drawing.Size(100, 17);
            this.Packets_received.Text = "Packets received: ";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 612);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BufferSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lambdaParam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.networkSize2)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.simulationTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stepTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simulationLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.networkSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TTL)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown networkSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown TTL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Step;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.Button Pause;
        private System.Windows.Forms.Button Run;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown simulationLength;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown networkSize2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton RoutingRandom;
        private System.Windows.Forms.RadioButton RoutingShortest;
        private System.Windows.Forms.RadioButton RoutingManual;
        private System.Windows.Forms.NumericUpDown stepTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown simulationTime;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown lambdaParam;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ToolStripStatusLabel Transmitted;
        private System.Windows.Forms.ToolStripStatusLabel DroppedTTL;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown BufferSize;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ToolStripStatusLabel DroppedBufferSize;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ToolStripStatusLabel DropRatio;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox RandSeed;
        private System.Windows.Forms.ToolStripStatusLabel Packets_received;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}

