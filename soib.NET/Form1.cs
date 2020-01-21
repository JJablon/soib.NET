using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using soib;

namespace soib
{
    public partial class Form1 : Form
    {
        string transmitted_caption;
        string TTL_dropped_caption;
        string buffer_dropped_caption;
        string drop_ratio_text;

        public Form1()
        {
            InitializeComponent();
            //Test1 tst = new Test1();
            transmitted_caption = Transmitted.Text;
            TTL_dropped_caption = DroppedTTL.Text;
            buffer_dropped_caption = DroppedBufferSize.Text;
            drop_ratio_text = DropRatio.Text;
            this.Transmitted.Text = "";
            this.DroppedTTL.Text = "";
            this.DroppedBufferSize.Text = "";
            this.DropRatio.Text = "";

            
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void BlockAllFields()
        {
            this.textBox1.ReadOnly = true;
            this.textBox2.ReadOnly = true;

            networkSize.ReadOnly = true;
            networkSize2.ReadOnly = true;
            TTL.ReadOnly = true;
            this.lambdaParam.ReadOnly = true;
            this.BufferSize.ReadOnly = true;



            this.simulationLength.ReadOnly = true;
            this.stepTime.ReadOnly = true;
            this.RoutingManual.Enabled = false;
            this.RoutingRandom.Enabled = false;
            this.RoutingShortest.Enabled = false;

        }
        private void UnblockAllFields()
        {
            this.textBox1.ReadOnly = false;
            this.textBox2.ReadOnly = false;

            networkSize.ReadOnly = false;
            networkSize2.ReadOnly = false;
            TTL.ReadOnly = false;
            this.lambdaParam.ReadOnly = false;
            this.BufferSize.ReadOnly = false;



            this.simulationLength.ReadOnly = false;
            this.stepTime.ReadOnly = false;
            this.RoutingManual.Enabled = true;
            this.RoutingRandom.Enabled = true;
            this.RoutingShortest.Enabled = true;
        }


        private void TTL_ValueChanged(object sender, EventArgs e)
        {

        }

        private void networkSize_ValueChanged(object sender, EventArgs e)
        {

            this.networkSize2.Value = networkSize.Value;
            this.TTL.Value = (int)networkSize2.Value * (int)networkSize2.Value * 4;

        }

        private void networkSize2_ValueChanged(object sender, EventArgs e)
        {
            this.networkSize.Value = networkSize2.Value;
        }





        private void simulationLength_ValueChanged(object sender, EventArgs e)
        {
            simulationTime.Value = simulationLength.Value * stepTime.Value / 1000;
        }

        private void stepTime_ValueChanged(object sender, EventArgs e)
        {
            simulationTime.Value = simulationLength.Value * stepTime.Value / 1000;
            timer1.Interval = (int)stepTime.Value;
        }

        private void RoutingRandom_CheckedChanged(object sender, EventArgs e)
        {
            if (RoutingRandom.Checked == true)
            {
                RoutingShortest.Checked = false;
                RoutingRandom.Checked = true;
                RoutingManual.Checked = false;
                this.textBox1.Visible = false;
                this.textBox2.Visible = false;
            }
        }

        private void RoutingShortest_CheckedChanged(object sender, EventArgs e)
        {
            if (RoutingShortest.Checked == true)
            {
                RoutingShortest.Checked = true;
                RoutingRandom.Checked = false;
                RoutingManual.Checked = false;
                this.textBox1.Visible = false;
                this.textBox2.Visible = false;
            }
        }

        private void RoutingManula_CheckedChanged(object sender, EventArgs e)
        {
            if (RoutingManual.Checked == true)
            {
                RoutingShortest.Checked = false;
                RoutingRandom.Checked = false;
                RoutingManual.Checked = true;
                this.textBox1.Visible = true;
                this.textBox2.Visible = true;
            }
        }


        private bool isRunning = false;
        private bool isPaused = false;
        private int currentTick=0;
        Simulation simulation;

        private void Run_Click(object sender, EventArgs e)
        {
            
            
            
            if (!isRunning&&!isPaused)
            {
                int seed = 0;
                if (RandSeed.Text.Length > 0) seed = Int32.Parse(RandSeed.Text);
                this.simulation = new Simulation((int)this.networkSize.Value,seed);
                if (this.RoutingManual.Checked == true)
                {
                    if (textBox1.Text.Length == 0 && textBox2.Text.Length == 0)
                    {
                        MessageBox.Show("You need to specify at least one route");
                        return;
                    }
                    try
                    {
                        if (textBox1.Text.Length > 0)
                        {
                            string tmp = this.textBox1.Text.TrimEnd();
                            tmp = tmp.TrimStart();
                            tmp = tmp.Replace("\n", "");
                            tmp = tmp.Replace("\t", "");
                            tmp = tmp.Replace("\r", "");
                            tmp = tmp.Replace(" ", "");
                            if (tmp.Length > 0&& tmp[0] == ',') tmp = tmp.Remove(0, 1);
                            if (tmp.Length > 0 && tmp[tmp.Length - 1] == ',') tmp = tmp.Remove(tmp.Length - 1, 1);
                            
                            if (tmp.Length == 0)
                            {
                                MessageBox.Show("You need to specify at least one route");
                                return;
                            }
                            string[] tmp2 = tmp.Split(',');
                            List<int> route = new List<int>();
                            foreach (string text in tmp2)
                            {
                                route.Add(Int32.Parse(text));
                            }
                            simulation.addManualRoute(route);

                        }
                        if (textBox2.Text.Length > 0)
                        {
                            string tmp = this.textBox2.Text.TrimEnd();
                            tmp = tmp.TrimStart();
                            tmp = tmp.Replace("\n", "");
                            tmp = tmp.Replace("\t", "");
                            tmp = tmp.Replace("\r", "");
                            tmp = tmp.Replace(" ", "");
                            if (tmp.Length > 0 && tmp[0] == ',') tmp = tmp.Remove(0, 1);
                            if (tmp.Length > 0 && tmp[tmp.Length - 1] == ',') tmp = tmp.Remove(tmp.Length - 1, 1);

                            if (tmp.Length == 0)
                            {
                                MessageBox.Show("You need to specify at least one route");
                                return;
                            }
                            string[] tmp2 = tmp.Split(',');
                            List<int> route = new List<int>();
                            foreach (string text in tmp2)
                            {
                                route.Add(Int32.Parse(text));
                            }
                            simulation.addManualRoute(route);

                        }

                        if (!simulation.checkManualRoutingAllRoutesConnectivity(true))
                        {
                            MessageBox.Show("There is no connectivity between all nodes in the routing!");
                            return;
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("There was an error parsing the manual route"+ ex.ToString());
                        return;
                    }

                    SimulationParams.clearParams();
                    SimulationStats.clearStats();
                    SimulationParams.routing_algorithm = 3;
                }
                else if (this.RoutingRandom.Checked == true)
                {
                    SimulationParams.clearParams();
                    SimulationStats.clearStats();
                    SimulationParams.routing_algorithm = 2;
                }
                else if (this.RoutingShortest.Checked == true)
                {
                    SimulationParams.clearParams();
                    SimulationStats.clearStats();
                    SimulationParams.routing_algorithm = 1;
                }

                
                this.richTextBox1.Text += "Simulation started at " + DateTime.Now.ToLongTimeString()+"\n";
                

                isRunning = true;
                isPaused = false;
                SimulationParams.buffer_size = (int) this.BufferSize.Value;
                SimulationParams.lambda = (int)this.lambdaParam.Value;
                SimulationParams.network_size = (int)networkSize.Value;
                SimulationParams.TTL = (int)this.TTL.Value;



                timer1.Enabled = true;
                BlockAllFields();
                this.Run.Enabled = false;
                this.Pause.Enabled = true;
                this.Step.Enabled = false;
                this.Stop.Enabled = true;

            }
            else if (isPaused)
            {
                timer1.Enabled = true;
                isPaused = false;
                isRunning = true;
                this.Run.Enabled = false;
                this.Pause.Enabled = true;
                this.Step.Enabled = false;
                this.Stop.Enabled = true;
                this.richTextBox1.Text += "Simulation started at " + DateTime.Now.ToLongTimeString() + "\n";
            }


        }

        private void Pause_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (isRunning&&!isPaused)
            {
                this.richTextBox1.Text += "Simulation paused at " + DateTime.Now.ToLongTimeString() + "\n";
                isRunning = false;
                isPaused = true;
                this.Run.Enabled = true;
                this.Pause.Enabled = false;
                this.Step.Enabled = true;
                this.Stop.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            try
            {
                this.toolStripProgressBar1.Value = ((int)((double)((double)currentTick) * 100 / ((double)simulationLength.Value)));
            }
            catch (Exception) { }

            simulation.SimulationTick(currentTick++);
            simulation.RefreshStats();
            Transmitted.Text = transmitted_caption + SimulationStats.total_packets_gen_count + "   ";
            DroppedTTL.Text = TTL_dropped_caption + SimulationStats.total_TTL_exceeded_packet_count + "   "; 
            DroppedBufferSize.Text = buffer_dropped_caption + SimulationStats.total_buffer_full_packet_count + "   ";
            DropRatio.Text = drop_ratio_text +
                ((double)((double)SimulationStats.total_buffer_full_packet_count +
                (double)SimulationStats.total_TTL_exceeded_packet_count) / (double)SimulationStats.total_packets_gen_count).ToString("0.##")
                + "%    "
                ;
            Packets_received.Text = "Packets received: " + SimulationStats.total_packets_term_count;


        }

        private void Stop_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (isRunning || isPaused)
            {
                this.Run.Enabled = true;
                this.Pause.Enabled = false;
                this.Step.Enabled = false;
                this.Stop.Enabled = false;
                UnblockAllFields();
                isRunning = false;
                SimulationFinished();


            }

        }

        private void SimulationFinished()
        {
            this.richTextBox1.Text += "Simulation finished at " + DateTime.Now.ToLongTimeString() + "\n";
            richTextBox1.Text += transmitted_caption + SimulationStats.total_packets_gen_count + "\n";
            richTextBox1.Text += TTL_dropped_caption + SimulationStats.total_TTL_exceeded_packet_count + "\n";
            richTextBox1.Text += buffer_dropped_caption + SimulationStats.total_buffer_full_packet_count + "\n";
            richTextBox1.Text += drop_ratio_text +
                ((double)((double)SimulationStats.total_buffer_full_packet_count +
                (double)SimulationStats.total_TTL_exceeded_packet_count) / (double)SimulationStats.total_packets_gen_count).ToString("0.##")
                + "%\n"
                ;
            richTextBox1.Text += "Packets received: " + SimulationStats.total_packets_term_count+"\n";

        }

    }
}
