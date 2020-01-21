using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;

namespace soib
{


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


}