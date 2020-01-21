using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;

namespace soib
{



    public class Packet
    {
        public int node_from;
        public int node_to;
        public List<int> node_through;
        public List<int> route;
        public List<int> node_visited_history;
        public string payload;
        public int TTL = 0;
        public int last_tick_id_which_transitioned=0;
        public int stat_nodes_visited = 0;
        public static long uuid_counter=1;
        public long uuid;

        public Packet(int node_from, int node_to, List<int> node_through, int TTL, long uuid, List<int> node_history, List<int> route)
        {
            this.node_from = node_from;
            this.node_to = node_to;
            this.node_through = node_through;
            this.TTL = TTL;
            this.uuid = uuid;
            this.node_visited_history = node_history;
            this.route = route;

        }
        public Packet(int node_from, int node_to, List<int> node_through, int TTL)
        {
            this.node_from = node_from;
            this.node_to = node_to;
            this.node_through = node_through;
            this.TTL = TTL;
            this.uuid = uuid_counter++;
            node_visited_history = new List<int>();
            this.route = Utils.copyList<int>(this.node_through);
        }
        public Packet(int node_from, int node_to, List<int> node_through, int TTL, string payload, long uuid, List<int> node_history, List<int> route)
        {
            this.node_from = node_from;
            this.node_to = node_to;
            this.node_through = node_through;
            this.TTL = TTL;
            this.payload = payload;
            this.uuid = uuid;
            this.node_visited_history = node_history;
            this.route = route;
        }
        public Packet getPacketCopyWithLastTickSet(int last_tick_id_which_transitioned)
        {
            Packet p = this.copy();
            p.stat_nodes_visited++;
            p.last_tick_id_which_transitioned = last_tick_id_which_transitioned;
            return p;
        }

        public void AddRoute(List<int> route)
        {
            int[] array = new int[0];
            route.CopyTo(array);
            this.node_through = array.ToList<int>();
        }

        public Packet copy(Packet source)
        {
            return new Packet(source.node_from, source.node_to, 
                Utils.copyList<int>(source.node_through),source.TTL, source.uuid, source.node_visited_history, source.route);

        }
        public Packet copy()
        {
            return new Packet(node_from, node_to, Utils.copyList<int>(node_through),TTL, uuid, node_visited_history, route);

        }



    }




}