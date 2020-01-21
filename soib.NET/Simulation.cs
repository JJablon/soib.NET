using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;

namespace soib
{

    public static class SimulationParams
    {

        public static int network_size;
        public static int lambda;
        public static int TTL;
        public static int buffer_size;
        public static int routing_algorithm;


        public static void clearParams()
        {
            network_size = 0;
            lambda = 0;
            TTL = 0;
            buffer_size = 0;
            routing_algorithm = 0;
        }


    }
    public static class SimulationStats
    {
        //counts of packets
        public static int total_packets_trans_count = 0; //packets forwarded count (all nodes)
        public static int total_packets_gen_count = 0; //packets introduced to network (all nodes) count
        public static int total_packets_term_count = 0; //packets which reached destination (all nodes)
        public static int total_TTL_exceeded_packet_count = 0;
        public static int total_buffer_full_packet_count = 0;

        //sum of TTL of packets terminated
        public static int total_reached_dest_TTL_sum = 0;//this is the sum of 'TTL_current' fields (in all nodes) of packets which so reached destination in the node
        public static void clearStats()
        {
            total_packets_trans_count = 0;
            total_packets_gen_count = 0;
            total_packets_term_count = 0;
            total_TTL_exceeded_packet_count = 0;
            total_reached_dest_TTL_sum = 0;
            total_buffer_full_packet_count = 0;
        }
    }

    public class Enums
    {
        public enum direction { left, right, up, down };


    }

    public class Simulation
    {

        public NodeController nc;
        public void RefreshStats()
        {
            this.nc.RefreshStats();

        }
        public Simulation(int network_size, int seed=0)
        {
            SimulationStats.clearStats();
            SimulationParams.network_size = network_size;
            List<NetworkNode> nodes = new List<NetworkNode>();
            List<Link> links = new List<Link>();
            int link_id = 0;
            int id = 0;
            //i - rows
            //j - columns
            //up, down, right, left - ids of neighbours
            if (SimulationParams.network_size > 0)
            {
                for (int i = 1; i <= SimulationParams.network_size; i++)
                {
                    for (int j = 1; j <= SimulationParams.network_size; j++)
                    {
                        id++;
                        int right = SimulationParams.network_size * (i - 1) + j + 1;
                        int left = SimulationParams.network_size * (i - 1) + j - 1;
                        int up = SimulationParams.network_size * (i - 2) + j;
                        int down = SimulationParams.network_size * i + j;
                        //overwrite above values in special cases:
                        if (i == 1) up = SimulationParams.network_size * (SimulationParams.network_size - 1) + j;
                        if (i == SimulationParams.network_size) down = j;
                        if (j == 1) left = SimulationParams.network_size * i;
                        if (j == SimulationParams.network_size) right = SimulationParams.network_size * (i - 1) + 1;

                        //add links with proper directions
                        if (i % 2 == 1) links.Add(new Link(++link_id, id, right, Enums.direction.right));
                        if (i % 2 == 0) links.Add(new Link(++link_id, right, id, Enums.direction.left));

                        if (j % 2 == 1) links.Add(new Link(++link_id, id, up, Enums.direction.up));
                        if (j % 2 == 0) links.Add(new Link(++link_id, up, id, Enums.direction.down));

                        //add node
                        nodes.Add(new NetworkNode(id));

                    }
                }
                nc = new NodeController(nodes, links,seed);
            }
        }

        public void addManualRoute(List<int> route)
        {
            //if(nc != null)
            {
                nc.addManualRoute(route);
            }
            //else
            {
                // throw new Exception();
            }

        }

        public bool checkManualRoutingAllRoutesConnectivity(bool enable_logging = false)
        {
            return nc.checkManualRoutingAllNodesConnectivity(enable_logging);
        }

        public void SimulationTick(int tick_no)
        {
            nc.SimulationTick(tick_no);
        }

    }


    public class Test1
    {

        public Test1()
        {

            
            int[] parameters = new int[] { 0, 1000, 0, 0 };
            SimulationParams.lambda = 1000;
            SimulationParams.TTL = 1000;
            SimulationParams.buffer_size = 1000;
            SimulationParams.routing_algorithm = 1000;
            Simulation sim5 = new Simulation(5,123);

            //add zig-zag route                                  25
            List<int> route1 = new List<int>() { 1, 2, 3, 4, 5,  25,  20,19,18,17,16,  11,12,13,14,15,  10,9,8,7,6,  1,  21,22,23,24,25,
                //back
                21,16,11,6,
                //again
                1, 2, 3, 4, 5,  25,  20,19,18,17,16,  11,12,13,14,15,  10,9,8,7,6,  1,  21,22,23,24,25
                };


            sim5.addManualRoute(route1);
            //route1.Reverse();
            //sim5.addManualRoute(route1);
            bool b = sim5.checkManualRoutingAllRoutesConnectivity(true);



            Simulation sim4 = new Simulation(4,123);

        }



    }



}