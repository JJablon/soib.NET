using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;

namespace soib
{
    public partial class Form1 : Form
    {

    }
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
            else return null;
            //else throw new ArgumentNullException();
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

    }

    public static class RoutingController
    {

        public static List<int> findAnyManualRoute(List<List<int>> list, int from, int to)
        {
            if (from != to)
                foreach (List<int> element in list)
                {

                    if (element.Contains<int>(from) && element.Contains<int>(to))
                    {
                        List<int> from_ind = findIndicies(element, from);
                        List<int> to_ind = findIndicies(element, to);
                        if (from_ind.Min() < to_ind.Max())
                        {
                            return Utils.copyList<int>(element.GetRange(findIndicies(element, from).Min(), findIndicies(element, to).Max() - findIndicies(element, from).Min()));

                        }
                        
                        //return element;
                    }
                }
            else return new List<int> { from };
            return null;
        }

        public static List<int> findIndicies(List<int> list, int value)
        {
            List<int> returned = new List<int>();
            if (list.Count > 0) {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] == value) returned.Add( i) ;
                }
                if (returned.Count == 0) return null;
                return returned;

            }
            return null;

        }


        /*  public static List<int> returnShortestManualRoute(List<List<int>> list, int from, int to)
          {
              if (list.Count > 0&&from>=0&&to>=0&&from<list.Count&&to<list.Count) {
                  List<List<int>> routes = new List<List<int>>();
                  foreach (List<int> element in list)
                  {
                      if (element.Contains<int>(from) && element.Contains<int>(to))
                      {
                          if (findIndex(element, from) > findIndex(element, to)) { }



                  }
                      routes.Add(element);
                  }


                  if (routes.Count == 0) return null;
                  else
                  {
                      List<int> shortest_route = new List<int>();
                      foreach (List<int> element in routes)
                      {
                          if (shortest_route.Count == 0) shortest_route = Utils.copyList<int>(element);
                          if (shortest_route.Count > element.Count)
                          {
                              shortest_route = Utils.copyList<int>(element);
                          }

                      }


                  }

              }

              else return 0;


          }

      */
    }

    public class Link
    {
        public int id = 0;
        public int node_from_id = 0;
        public int node_to_id = 0;
        public Enums.direction direction;

        public Link(int id, int node_from_id, int node_to_id, Enums.direction direction)
        {
            this.id = id;
            this.node_from_id = node_from_id;
            this.node_to_id = node_to_id;
            this.direction = direction;
        }


    }

    public class NodeController
    {
        public List<NetworkNode> nodes = new List<NetworkNode>();
        public List<Link> links = new List<Link>();

        public  List<List<int>> manual_routes;
        public Random random;

        public NodeController(List<NetworkNode> nodes, List<Link> links, int seed=0)
        {
            if (seed == 0)
                this.random = new Random();
            else
                this.random = new Random(seed);
            this.nodes = Utils.copyList<NetworkNode>(nodes);
            this.links = Utils.copyList<Link>(links);
            manual_routes = new List<List<int>>();


            var a = findRandomRoute(1, 20);
            var a1 = findRandomRoute(1, 20);
            var a2 = findRandomRoute(1, 20);
            var b = findRandomRoute(1, 1);
            var b2 = findRandomRoute(1, 1);
            var b3 = findRandomRoute(1, 1);
            var c = findRandomRoute(1, 2);
            var c1 = findRandomRoute(1, 2);
            var c2 = findRandomRoute(1, 2);

            var d = findRandomRoute(1, 3);
            var e = findRandomRoute(1, 4);
            var f = findRandomRoute(1, 5);
            var g = findRandomRoute(5, 1);
            var h = findRandomRoute(5, 2);
            var i = findRandomRoute(5, 3);
            var i1 = findRandomRoute(5, 3);
            var i2 = findRandomRoute(5, 3);
            var i3 = findRandomRoute(5, 3);
            var i4 = findRandomRoute(5, 3);
            var i5 = findRandomRoute(5, 3);
            var i6 = findRandomRoute(5, 3);
            var i7 = findRandomRoute(5, 3);
            var i8 = findRandomRoute(5, 3);
            var i9 = findRandomRoute(5, 3);
        }

        public void addManualRoute(List<int> added_route)
        {
            manual_routes.Add(Utils.copyList<int>(added_route));
        }
        public void clearManualRoutes()
        {
            manual_routes.Clear();
        }





        public bool checkManualRoutingAllNodesConnectivity(bool enable_logging = false)
        {
            bool flag = true;
            foreach (var nodeA in nodes)
            {
                foreach(var nodeB in nodes)
                {
                    bool connectivity = checkManualRoutingNodesReachability(nodeA.id, nodeB.id);
                    if (!connectivity)
                    {
                        if (enable_logging == true) {
                            //Console.Beep();
                            Console.WriteLine("No route from node " + nodeA.id + " and " + nodeB.id);
                        }
                        //listBox1.Items.Add();
                        //return false;
                        flag = false;

                    }
                }
            }
            return flag; //all nodes can be reached from each other
        }

        public bool checkManualRoutingNodesReachability(int nodeA, int nodeB)
        {
            if(RoutingController.findAnyManualRoute(this.manual_routes, nodeA, nodeB) == null) return false;
            else
            {

                //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

            }
            return true;


        }

        public List<int> findRandomRoute(int from, int to)
        {
            int current_node = from;
            int counter = 0;
            List<int> route = new List<int>();
            while(current_node != to)
            {
                counter++;
                route.Add(current_node);
                current_node = getRandomNextNodeDirectlyConnectedTo(current_node);

                if (counter > SimulationParams.network_size * 100) return null;
            }
            if (from == to) return new List<int> { from };
            if (route.Count == 0) throw new ArgumentNullException();
            return route;
        }



        public int getRandomNextNodeDirectlyConnectedTo(int node_id)
        {
            List<Link> links_from_node = new List<Link>();
            foreach (Link l in links)
            {
                if (l.node_from_id == node_id) links_from_node.Add(l);
            }
            if (links_from_node.Count == 0) throw new ArgumentNullException();
            int rand = random.Next(0, links_from_node.Count);
            return links_from_node[rand].node_to_id;

            
        }

        /* TODO */
        /*
        public List<Link> getAllLinksTo(int to)
        {
            List<Link> returned = new List<Link>();
            foreach (Link l in links)
            {

            }



            if (returned.Count == 0) return null;
        }*/






        public bool verifyManualRoutingAllNodesConnectivity()
        {
            foreach (var nodeA in nodes)
            {
                foreach (var nodeB in nodes)
                {
                    if (!checkManualRoutingNodesReachability(nodeA.id, nodeB.id)) return false;

                    //List<int> nodes_through = Utils.

                //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
                }
            }
            return true; //all nodes can be reached from each other
        }



        


        public bool verifyManualRouting()
        {
            bool connectivity1 = checkManualRoutingAllNodesConnectivity();
            bool connectivity2 = false;


            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

            return connectivity1 & connectivity2; 
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

        //sum of TTL of packets terminated
        public static int total_reached_dest_TTL_sum = 0;//this is the sum of 'TTL_current' fields (in all nodes) of packets which so reached destination in the node
        public static void clearStats()
        {
            total_packets_trans_count = 0;
            total_packets_gen_count = 0;
            total_packets_term_count = 0;
            total_TTL_exceeded_packet_count = 0;
            total_reached_dest_TTL_sum = 0;
        }
    }

    public class Enums
    {
        public enum direction { left, right, up, down };


    }

    public class Simulation
    {

        public NodeController nc;
        public Simulation(int network_size) {
            SimulationParams.clearParams();
            SimulationStats.clearStats();
            SimulationParams.network_size = network_size;
            List<NetworkNode> nodes = new List<NetworkNode>();
            List<Link> links = new List<Link>();
            int link_id=0;
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

                        //add links with proper directions
                        if (i % 2 == 1) links.Add(new Link(++link_id, id, right, Enums.direction.right));
                        if (i % 2 == 0) links.Add(new Link(++link_id, right, id, Enums.direction.left));

                        if (j % 2 == 1) links.Add(new Link(++link_id, id, up, Enums.direction.up));
                        if (j % 2 == 0) links.Add(new Link(++link_id, up, id, Enums.direction.down));

                        //add node
                        nodes.Add(new NetworkNode(id, left, right, up, down));
                        
                    }
                }
                nc = new NodeController(nodes, links);
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

    }


        public class Test1
        {

            public Test1()
            {
              
                Simulation sim5 = new Simulation(5);
                int[] parameters = new int[] { 0, 0, 0, 0 };
                SimulationParams.lambda = parameters[0];
                SimulationParams.TTL = parameters[1];
                SimulationParams.buffer_size = parameters[2];
                SimulationParams.routing_algorithm = parameters[3];


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



                Simulation sim4 = new Simulation(4);

            }



    }


    
}
