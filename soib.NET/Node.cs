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
    

    public class NetworkNode 
    {
        public int id;
        //public int left_neighbor_id;
        //public int right_neighbor_id;
        //public int down_neighbor_id;
        //public int up_neighbor_id;
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

        //packets deleted due to overloaded queue (buffer):
        public int stat_buffer_full_packet_count = 0;

        public int stat_total_hops_count;


        public NetworkNode(int node_id)
        {
            this.id = node_id;
            //this.left_neighbor_id = node_left_neighbor_id;
            //this.right_neighbor_id = node_right_neighbor_id;
            //this.down_neighbor_id = node_down_neighbor_id;
            //this.up_neighbor_id = node_up_neighbor_id;
            this.buffer_in = new Queue<Packet>();
            this.buffer_out = new Queue<Packet>();

            this.stat_packets_trans = 0;
            this.stat_packets_gen = 0;
            this.stat_packets_term = 0;
            this.stat_reached_dest_TTL_sum = 0;
            this.stat_TTL_exceeded_packet_count = 0;
            this.stat_buffer_full_packet_count = 0;
            this.stat_total_hops_count = 0;
        }
        public int getId()
        {
            return this.id;
        }
        

       // public void RelayPacket 
    }


    public class NodeController
    {
        public List<NetworkNode> nodes = new List<NetworkNode>();
        public List<Link> links = new List<Link>();

        public  List<List<int>> manual_routes;
        public Random random_gen_for_routing;
        public Random random_gen_for_packet_generation;
        public int invalid_termination = 0;
        public List<string> forward_history = new List<string>();


        public List<int> getBufferLoad()
        {
            List<int> load = new List<int>();
            foreach(NetworkNode n in nodes)
            {
                load.Add(n.buffer_in.Count );


            }
            return load;


        }

        public List<int> RefreshStats()
        {
            SimulationStats.clearStats();
            foreach (NetworkNode n in nodes)
            {
                SimulationStats.total_buffer_full_packet_count += n.stat_buffer_full_packet_count;
                SimulationStats.total_packets_gen_count += n.stat_packets_gen;
                SimulationStats.total_packets_term_count += n.stat_packets_term;
                SimulationStats.total_packets_trans_count += n.stat_packets_trans;
                SimulationStats.total_reached_dest_TTL_sum += n.stat_reached_dest_TTL_sum;
                SimulationStats.total_TTL_exceeded_packet_count += n.stat_TTL_exceeded_packet_count;
                SimulationStats.total_packets_remaining_in_buffers += (n.buffer_in.Count + n.buffer_out.Count);
                SimulationStats.total_sum_hops += n.stat_total_hops_count;

            }
            return getBufferLoad();


        }
        public NetworkNode getNodeById(int id)
        {
            foreach (NetworkNode n in nodes)
            {
                if (n.getId() == id)
                    return n;
            }
            return null;
        }

        public void SimulationTick(int tick_no)
        {
            for(int n = 0; n < SimulationParams.lambda; n++)
            {
                if (SimulationParams.network_size < 2) throw new IndexOutOfRangeException();
                int from = -1;
                int to = -1;
                while (true)
                {
                     from = random_gen_for_packet_generation.Next(1, nodes.Count);
                     to = random_gen_for_packet_generation.Next(1, nodes.Count);
                    if (from != to) break;
                }

                if (SimulationParams.routing_algorithm == 3 || SimulationParams.routing_algorithm == 2)
                {
                    int retries = 100;
                    List<int> route = new List<int>();
                    if (SimulationParams.routing_algorithm == 2) route = findRandomRoute(from, to, 10);
                    else
                         route = RoutingController.findAnyManualRoute(manual_routes, from, to);


                    getNodeById(from).buffer_in.Enqueue(new Packet(from, to, route, SimulationParams.TTL));
                    getNodeById(from).stat_packets_gen++;



                }
                else
                {
                    throw new NotImplementedException("not implemented");
                }

            }

            foreach (NetworkNode n in nodes)
            {
                //handle 1 packet from in queue
                if (n.buffer_in.Count>0 && n.buffer_in.Peek().last_tick_id_which_transitioned != tick_no)
                {
                    if (n.buffer_in.Peek().last_tick_id_which_transitioned > tick_no)
                        throw new Exception("invalid tick_no");

                    //packet was sent in one of previous ticks
                    Packet p = n.buffer_in.Dequeue().copy();
                    p.TTL--;
                    if (p.TTL <= 0) n.stat_TTL_exceeded_packet_count++;
                    else
                    {
                        if (p.uuid == 4)
                        {
                            int visited = p.stat_nodes_visited;
                            List<int> through = p.node_through;
                             long uuid = p.uuid;
                        }
                        //TTL indicates that packet can be forwarded
                        if (p.node_to == n.id) //packet reaches destination
                        {
                            n.stat_packets_term++;
                            n.stat_reached_dest_TTL_sum += p.TTL;
                            n.stat_total_hops_count += p.node_visited_history.Count;
                            //n.stat_total_hops_count += p.stat_nodes_visited;
                        }
                        else  //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!@#$
                        {
                            if (p.node_through.Count > 0 && p.node_through[0] == n.id)
                            {
                                p.node_through.RemoveAt(0);
                                if (p.uuid == 4)
                                {

                                }
                                p.stat_nodes_visited++;
                                n.stat_packets_trans++;
                                if (p.node_through.Count > 0)
                                    if (getNodeById(p.node_through[0]).buffer_in.Count >= SimulationParams.buffer_size)
                                    {
                                        getNodeById(p.node_through[0]).stat_buffer_full_packet_count++;


                                    }
                                    else
                                    {
                                        forward_history[p.node_through[0]] += p.uuid + ", ";
                                        p.node_visited_history.Add(n.id);
                                        getNodeById(p.node_through[0]).buffer_in.Enqueue(p.getPacketCopyWithLastTickSet(tick_no));

                                    }

                                else
                                    //throw new Exception("this packet should have been terminated");
                                    Console.WriteLine("this packet: " + p.uuid + " should have been terminated, count: "+(++invalid_termination));

                            }
                            else
                            {
                                throw new Exception("invalid node_through entry or structure");
                            }

                        }
                    }
                }
                else
                {
                    //do nothing; as the packet was sent in this tick and 
                    //because of that if could not have been received
                    //on the dest node already
                }
            }
        }



        public NodeController(List<NetworkNode> nodes, List<Link> links, int seed=0)
        {
            if (seed == 0)
                this.random_gen_for_routing = new Random();
            else
                this.random_gen_for_routing = new Random(seed);
            if (seed == 0)
                this.random_gen_for_packet_generation = new Random();
            else
                this.random_gen_for_packet_generation = new Random(seed);

            this.nodes = Utils.copyList<NetworkNode>(nodes);
            this.links = Utils.copyList<Link>(links);
            manual_routes = new List<List<int>>();
            foreach(NetworkNode n in nodes)
            {
                forward_history.Add("");
            }
            forward_history.Add("");
            /*
                int retries = 100;
            var a = findRandomRoute(1, 20, retries);
            var a1 = findRandomRoute(1, 20, retries);
            var a2 = findRandomRoute(1, 20, retries);
            var b = findRandomRoute(1, 1, retries);
            var b2 = findRandomRoute(1, 1, retries);
            var b3 = findRandomRoute(1, 1, retries);
            var c = findRandomRoute(1, 2, retries);
            var c1 = findRandomRoute(1, 2, retries);
            var c2 = findRandomRoute(1, 2, retries);

            var d = findRandomRoute(1, 3, retries);
            var e = findRandomRoute(1, 4, retries);
            var f = findRandomRoute(1, 5, retries);
            var g = findRandomRoute(5, 1, retries);
            var h = findRandomRoute(5, 2, retries);
            var i = findRandomRoute(5, 3, retries);
            var i1 = findRandomRoute(5, 3, retries);
            var i2 = findRandomRoute(5, 3, retries);
            var i3 = findRandomRoute(5, 3, retries);
            var i4 = findRandomRoute(5, 3, retries);
            var i5 = findRandomRoute(5, 3, retries);
            var i6 = findRandomRoute(5, 3, retries);
            var i7 = findRandomRoute(5, 3, retries);
            var i8 = findRandomRoute(5, 3, retries);
            var i9 = findRandomRoute(5, 3, retries);*/




        } 
        /// <summary>
        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="added_route"></param>
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

        public List<int> findRandomRoute(int from, int to, int retries)
        {
            List<int> route = new List<int>();
            while (true)
            {
                int current_node = from;
                int counter = 0;
                route.Clear();
                while (current_node != to)
                {
                    counter++;
                    route.Add(current_node);
                    current_node = getRandomNextNodeDirectlyConnectedTo(current_node);
                    if (counter > SimulationParams.TTL) break;
                }
                if (counter > SimulationParams.TTL) continue;
                if (from == to) return new List<int> { from };
                if (current_node == to) return route;
                if (route.Count == 0) throw new ArgumentNullException();
                retries--;
                if (retries <= 0) return null;
            }
        }



        public int getRandomNextNodeDirectlyConnectedTo(int node_id)
        {
            List<Link> links_from_node = new List<Link>();
            foreach (Link l in links)
            {
                if (l.node_from_id == node_id) links_from_node.Add(l);
            }
            if (links_from_node.Count == 0) throw new ArgumentNullException();
            int rand = random_gen_for_routing.Next(0, links_from_node.Count);
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



}
