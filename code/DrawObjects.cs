using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapRedPc.code
{
    [Serializable]
    class DrawObjects
    {
       

        public  List<MapElement> elements = new List<MapElement>();
        public  List<Edge> edges = new List<Edge>();
       // public  List<MapZone> zones = new List<MapZone>();
        public List<Grid> grids = new List<Grid>();
        public List<Room> rooms = new List<Room>();
        public List<Wall> walls = new List<Wall>();

        public DrawObjects()
        {
            rasst();
        }


        public  void addobj()
        {
         
        }


        public  void rasst()
        {
            elements.Clear();
            elements.AddRange(grids);
            elements.AddRange(edges);
          //  elements.AddRange(zones);
            elements.AddRange(rooms);
            elements.AddRange(walls);

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
           // elements.Add(new Edge(coord));
            edges.Add(new Edge(coord));
            rasst();
        }

        public  void addNewZone(Point coord)
        {
            
           // elements.Add(new MapZone(coord));
           
        }

        public void addNewRoom(Point coord)
        {
           
            edges.Add(new Edge(new Point(coord.X - 50, coord.Y - 50)));
            edges.Add(new Edge(new Point(coord.X + 50, coord.Y - 50)));
            edges.Add(new Edge(new Point(coord.X + 50, coord.Y + 50)));
            edges.Add(new Edge(new Point(coord.X - 50, coord.Y + 50)));

            rooms.Add(new Room(edges[edges.Count-4], edges[edges.Count - 3], edges[edges.Count - 2], edges[edges.Count - 1]));

            rasst();
        }

        public  void addNewWall(int a, int b)
        {
            walls.Add(new Wall(edges[a-1],edges[b-1]));
            rasst();
        }


    }
}
