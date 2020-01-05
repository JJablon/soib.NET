using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace soib
{
    public class Packet
    {
        public int node_from;
        public int node_to;
        public List<int> node_through;
        public string payload;

        public Packet (int node_from, int node_to, List<int> node_through)
        {
            this.node_from = node_from;
            this.node_to = node_to;
            this.node_through = node_through;


    }

        public void AddRoute(List<int> route)
        {
            int[] array = new int[0];
            route.CopyTo(array);
            this.node_through = array.ToList<int>();
        }

        public Packet copy(Packet source)
        {
            return new Packet(source.node_from, source.node_to, Utils.copyList<int>(source.node_through));

        }




    }

    public class NetworkNode 
    {
        public int id;
        public int left_neighbor_id;
        public int right_neighbor_id;
        public int down_neighbor_id;
        public int up_neighbor_id;
        public Queue<Packet> buffer_in;
        public Queue<Packet> buffer_out;

        //counters for statistics
        //this node general stats
        public int stat_packets_trans = 0; //packets forwarded count
        public int stat_packets_gen = 0; //packets introduced to network in this node count
        public int stat_packets_term = 0; //packets which reached destination in this node

        //sum of TTL of packets terminated
        public int stat_reached_dest_TTL_sum = 0;//this is the sum of 'TTL_current' fields (in all nodes) of packets which so reached destination in the node

        //packets deleted due to exceeded TTL:
        public int stat_TTL_exceeded_packet_count = 0;

        public NetworkNode(int node_id, int node_left_neighbor_id, int node_right_neighbor_id, int node_up_neighbor_id, int node_down_neighbor_id)
        {
            this.id = node_id;
            this.left_neighbor_id = node_left_neighbor_id;
            this.right_neighbor_id = node_right_neighbor_id;
            this.down_neighbor_id = node_down_neighbor_id;
            this.up_neighbor_id = node_up_neighbor_id;
            this.buffer_in = new Queue<Packet>();
            this.buffer_out = new Queue<Packet>();

            this.stat_packets_trans = 0;
            this.stat_packets_gen = 0;
            this.stat_packets_term = 0;
            this.stat_reached_dest_TTL_sum = 0;
            this.stat_TTL_exceeded_packet_count = 0;





        }
        public int getId()
        {
            return this.id;
        }
    }

    public static class Utils
    {
        public static List<T> copyList<T>(List<T> list)
        {
            if (list.Count > 0)
            {
                T[] array = new T[list.Count];
                list.CopyTo(array);
                return array.ToList<T>();
            }
            else throw new ArgumentNullException();
        }

        public static List<T> getListFromListOfLists<T>(List<List<T>> list, int id)
        {
            if (id >= 0 && id < list.Count)
                return list[id];
            else
                throw new IndexOutOfRangeException();

        }
        public static T getLastListElement<T>(List<T> list)
        {
            if (list.Count > 0)
                return list[list.Count];
            else
                throw new ArgumentNullException();

        }
        public static T getFirstListElement<T>(List<T> list)
        {
            if (list.Count > 0)
                return list[0];
            else
                throw new ArgumentNullException();

        }
        public static List<NetworkNode> findInNodeListByFirstLastElement(List<List<NetworkNode>> list, int first, int last)
        {
            foreach(List<NetworkNode> element in list)
            {
                NetworkNode n = (NetworkNode)getFirstListElement<NetworkNode>(element);
                NetworkNode n1 = getLastListElement(element);

                
                if (n.id== first && n1.id == last)
                    return element;
               


            }
            return null;


        }
        public static List<int> findManualRoute(List<List<int>> list, int from, int to)
        {

            foreach (List<int> element in list)
            {
                if (element.Contains<int>(from) && element.Contains<int>(to))
                    return element;

            }
            return null;


        }
        public static List<int> returnManualRoute(List<List<int>> list, int from, int to)
        {
            foreach (List<int> element in list)
            {
                throw new NotImplementedException();
                if (element.Contains<int>(from) && element.Contains<int>(to))
                    return element;






            }
            return null;


        }

    }




    public class NodeController
    {
        public List<NetworkNode> nodes = new List<NetworkNode>();
        public  List<List<int>> manual_routes;

        public NodeController(List<NetworkNode> nodes)
        {
            this.nodes = Utils.copyList<NetworkNode>(nodes);
            manual_routes = new List<List<int>>();
        }

        public void addManualRoute(List<int> added_route)
        {
            manual_routes.Add(Utils.copyList<int>(added_route));
        }
        public void clearManualRoutes()
        {
            manual_routes.Clear();
        }

        public bool checkManualRoutingAllNodesConnectivity()
        {
            foreach (var nodeA in nodes)
            {
                foreach(var nodeB in nodes)
                {
                    if(!checkManualRoutingNodesConnectivity(nodeA.id, nodeB.id)) return false;
                }
            }
            return true; //all nodes can be reached from each other
        }

        public bool checkManualRoutingNodesConnectivity(int nodeA, int nodeB)
        {
            if(Utils.findManualRoute(this.manual_routes, nodeA, nodeB) ==null) return false;
            return true;


        }

    }

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

        //sum of TTL of packets terminated
        public static int total_reached_dest_TTL_sum = 0;//this is the sum of 'TTL_current' fields (in all nodes) of packets which so reached destination in the node
    }

    public class Simulation
    {

        public NodeController nc;
        public Simulation() {
            List<NetworkNode> nodes = new List<NetworkNode>();
           
            int id = 0;
            //i - rows
            //j - columns
            //up, down, right, left - ids of neighbours
            if (SimulationParams.network_size > 0) {
                for (int i = 1; i <= SimulationParams.network_size; i++) {
                    for (int j = 1; j <= SimulationParams.network_size; j++) {
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

                        //add node
                        nodes.Add(new NetworkNode(id, left, right, up, down));
                        
                    }
                }
                nc = new NodeController(nodes);
            }
        }

        public void addManualRoute(List<int> route)
        {
            if(nc != null)
            {
                nc.addManualRoute(route);
            }
            else
            {
                throw new Exception();
            }

        }

        public bool checkManualRoutingAllRoutesConnectivity()
        {
            return nc.checkManualRoutingAllNodesConnectivity();
        }

    }


    public class Test1
    {
        public Test1()
        {
            int[] parameters = new int[] { 5, 0, 0, 0, 0 };
            SimulationParams.network_size = parameters[0];
            SimulationParams.lambda = parameters[1];
            SimulationParams.TTL = parameters[2];
            SimulationParams.buffer_size = parameters[3];
            SimulationParams.routing_algorithm = parameters[4];

           




            Simulation sim5 = new Simulation();
            List<int> route1 = new List<int>() { 1, 2, 3, 4, 5, 10, 9, 8, 7, 6, 11, 12, 13, 14, 15, 20, 19, 18, 17, 16, 21, 22, 23, 24, 25 };
            sim5.addManualRoute(route1);
            route1.Reverse();
            sim5.addManualRoute(route1);
            bool b = sim5.checkManualRoutingAllRoutesConnectivity();



            Simulation sim4 = new Simulation();

        }

        


    }


    
}
