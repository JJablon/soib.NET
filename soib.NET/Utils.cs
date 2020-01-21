using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;

namespace soib
{
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
            foreach (List<NetworkNode> element in list)
            {
                NetworkNode n = (NetworkNode)getFirstListElement<NetworkNode>(element);
                NetworkNode n1 = getLastListElement(element);


                if (n.id == first && n1.id == last)
                    return element;



            }
            return null;


        }

    }


}