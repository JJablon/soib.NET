using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;

namespace soib
{

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
                            List<int> returned = Utils.copyList<int>(element.GetRange(findIndicies(element, from).Min(), findIndicies(element, to).Max() - findIndicies(element, from).Min()));
                            returned.Add(to);
                            return returned;

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
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] == value) returned.Add(i);
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



}