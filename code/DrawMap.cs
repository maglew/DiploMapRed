using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace MapRedPc.code
{
   
    class DrawMap
    {
      public static int selectedfloor = 0;
        public static List<DrawMapFloor> floors = new List<DrawMapFloor>();


        public DrawMap()
        {
            for (int i = 0; i < 3; i++)
            { floors.Add(new DrawMapFloor()); }
            load();
        }

        public static void tick(Point wordloc, int size)
        {
            floors[selectedfloor].tick(wordloc, size);
        }

        public static void render(Graphics g)
        {
            floors[selectedfloor].render(g);
        }

        public static void save(String path)
        {
            

            FileStream savestream = null;
            String text ="";
            try
            {
                 savestream = new FileStream(path, FileMode.Create);
                for (int i = 0; i < floors.Count; i++)
                {
                    text += "floor[" + i+"]" + "\n";
                    text += floors[i].drawObjects.read();

                   
                }
                    savestream.Write(System.Text.Encoding.Default.GetBytes(text),0,text.Length);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (savestream != null)
                    savestream.Close();
            }
           


        }

        public static void load()
        {

            floors[0].drawObjects.grids.Add(new Grid(10, 10, 50));
            floors[0].drawObjects.edges.Add(new Edge(new Point(100, 100)));
            floors[0].drawObjects.edges.Add(new Edge(new Point(200, 200)));
            floors[0].drawObjects.edges.Add(new Edge(new Point(100, 200)));
            floors[0].drawObjects.edges.Add(new Edge(new Point(200, 100)));
           // floors[0].drawObjects.elements.AddRange(floors[0].drawObjects.edges);
           // floors[0].drawObjects.elements.AddRange(floors[0].drawObjects.grids);

            floors[1].drawObjects.grids.Add(new Grid(10, 10, 50));
         
         //   floors[1].drawObjects.elements.AddRange(floors[1].drawObjects.zones);
         //   floors[1].drawObjects.elements.AddRange(floors[1].drawObjects.grids);

            floors[2].drawObjects.grids.Add(new Grid(10, 10, 50));
           

            floors[2].drawObjects.edges.Add(new Edge(new Point(100, 100)));
            floors[2].drawObjects.edges.Add(new Edge(new Point(200, 100)));
            floors[2].drawObjects.edges.Add(new Edge(new Point(200, 200)));
            floors[2].drawObjects.edges.Add(new Edge(new Point(100, 200)));
            

            floors[2].drawObjects.rooms.Add(new Room(floors[2].drawObjects.edges[0], floors[2].drawObjects.edges[1],
            floors[2].drawObjects.edges[2], floors[2].drawObjects.edges[3]));

            //    floors[2].drawObjects.elements.AddRange(floors[2].drawObjects.rooms);
            //    floors[2].drawObjects.elements.AddRange(floors[2].drawObjects.edges);
            //    floors[2].drawObjects.elements.AddRange(floors[2].drawObjects.grids);


            floors[0].drawObjects.rasst();
            floors[1].drawObjects.rasst();
            floors[2].drawObjects.rasst();
        }

       
    }
}
