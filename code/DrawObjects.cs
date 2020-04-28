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
        public static Grid grid;
        public static MapZone zone;
        public static List<MapElement> elements = new List<MapElement>();
        public static List<Edge> edges = new List<Edge>();
        public static List<Room> rooms = new List<Room>();
       
        public DrawObjects()
        {

            addobj();
            rasst();
        }


        public static void addobj()
        {
            grid = new Grid(10, 10, 50);
            edges.Add(new Edge(new Point(100, 100)));
            edges.Add(new Edge(new Point(200, 200)));
            edges.Add(new Edge(new Point(100, 200)));
            edges.Add(new Edge(new Point(200, 100)));

         
            //edges[0].setOneNeighbor(edges[1]);
            //rooms.Add(new Room(new Point(250, 250), new Point(300, 250), new Point(300, 300), new Point(250, 300)));
            zone = new MapZone(new Point(300,300));
            //    walls.add(new Wall(points.get(0),points.get(2)));
            //    walls.add(new Wall(points.get(1),points.get(2)));
            //   walls.add(new Wall(points.get(2),points.get(1)));
            //   walls.add(new Wall(points.get(0),points.get(3)));

            //rooms.add(new Room(new Rectangle(225, 244, 50, 50)));



            
        }


        public static void rasst()
        {

             elements.AddRange(edges);
            
            elements.Add(zone);
            elements.Add(grid);
           
            
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

        public static void delobj(int id)
        {
            if (id != -1)
            { elements.Remove((elements[id])); }

        }

        public static int searchObjByCoord(Point touchcoord)
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

        public static MapElement getElement(int id)
        {
            return elements[id];
        }

        public static void moveElement(int id, Point coord)
        {
            elements[id].move(coord);
        }

        public static void setElement(MapElement element)
        {
            for (int i = 0; i < elements.Count; i++)
            { 
             if (elements[i].id== element.id)
                {
                    elements[i] = element;
                    
                }
            }
        }

        public static void addNewEdge(Point coord)
        {
            elements.Add(new Edge(coord));
        }

        public static void addNewZone(Point coord)
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
