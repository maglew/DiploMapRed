using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapRedPc.code
{
    class DrawObjects
    {
       // public  Grid grid;

        public  List<MapElement> elements = new List<MapElement>();
        public  List<Edge> edges = new List<Edge>();
        public  List<MapZone> zones = new List<MapZone>();
        public List<Grid> grids = new List<Grid>();
        public DrawObjects()
        {

        //    addobj();
            rasst();
        }


        public  void addobj()
        {
          //  grid = new Grid(10, 10, 50);
        }


        public  void rasst()
        {
            elements.AddRange(grids);
            elements.AddRange(edges);
            elements.AddRange(zones);
            
           // elements.Add(grid);
        }


        public void tick(Point worldloc, int size)
        {
            foreach (MapElement me in elements)
            {
                me.tick(worldloc,size);
            }
        }

        public void render(Graphics g)
        {
            foreach (MapElement me in elements)
            {
                me.render(g);
            }
        }

        public String read()
        {
           
            String retext="";
            for (int i = 0; i < elements.Count; i++)
            {
                retext += "element(" + i + ")" + "=" + elements[i].GetType() + "\n";
                retext += elements[i].read() + "\n";
            }
           
            return retext;
        }

        public  void delobj(int id)
        {
            if (id != -1)
            { elements.Remove((elements[id])); }

        }

        public  int searchObjByCoord(Point touchcoord)
        {
            int i = 0;
           

             foreach (MapElement mo in elements)
            {
                if (mo.touchhit(touchcoord) && mo.deletable)
                {
                    return i;
                }
                i++;
            }

                return -1;
        }

        public  MapElement getElement(int id)
        {
            return elements[id];
        }

        public  void moveElement(int id, Point coord)
        {
            elements[id].move(coord);
        }

        public  void setElement(MapElement element)
        {
            for (int i = 0; i < elements.Count; i++)
            { 
             if (elements[i].id== element.id)
                {
                    elements[i] = element;
                }
            }
        }

        public  void addNewEdge(Point coord)
        {
            elements.Add(new Edge(coord));
        }

        public  void addNewZone(Point coord)
        {
            elements.Add(new MapZone(coord));
        }


       
        public static void addNewWall(int a, int b)
        {
           // if (a != -1 && b != -1)
              //  points.get(a).setOneNeighbor(points.get(b));
        }


    }
}
