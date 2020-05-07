using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
//using System.Runtime.Serialization.Formatters.Soap;

namespace MapRedPc.code
{
    [Serializable]
    class DrawMap
    {
        public static int selectedfloor = 0;
        public  List<DrawMapFloor> floors = new List<DrawMapFloor>();


        public DrawMap()
        {
            for (int i = 0; i < 3; i++)
            { floors.Add(new DrawMapFloor()); }
          //  load();
        }

        public void tick(Point wordloc, int size)
        {
            floors[selectedfloor].tick(wordloc, size);
        }

        public void render(Graphics g)
        {
            floors[selectedfloor].render(g);
        }

        public void save(String path)
        {


            FileStream savestream = null;
            String text = "";
            try
            {
                savestream = new FileStream(path, FileMode.Create);
                for (int i = 0; i < floors.Count; i++)
                {
                    text += "floor[" + i + "]" + "\n";
                    text += floors[i].drawObjects.read();


                }
                savestream.Write(System.Text.Encoding.Default.GetBytes(text), 0, text.Length);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (savestream != null)
                    savestream.Close();
            }

            if (savestream != null)
                savestream.Close();

        }
        public void saveSer(String path)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream savestream = null;
            //SoapFormatter formatter = new SoapFormatter();
            String text = "";
            using (FileStream fs = new FileStream(path + "TcMap.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, MapManager.map);
                 formatter.Serialize(fs, MapManager.map.floors);
                

            }
            
        }
        public static void load()
        {

            //floors[0].drawObjects.grids.Add(new Grid(10, 10, 50));
            //floors[0].drawObjects.edges.Add(new Edge(new Point(100, 100)));
            //floors[0].drawObjects.edges.Add(new Edge(new Point(200, 200)));
            //floors[0].drawObjects.edges.Add(new Edge(new Point(100, 200)));
            //floors[0].drawObjects.edges.Add(new Edge(new Point(200, 100)));


            //floors[1].drawObjects.grids.Add(new Grid(10, 10, 50));



            //floors[2].drawObjects.grids.Add(new Grid(10, 10, 50));


            //floors[2].drawObjects.edges.Add(new Edge(new Point(100, 100)));
            //floors[2].drawObjects.edges.Add(new Edge(new Point(200, 100)));
            //floors[2].drawObjects.edges.Add(new Edge(new Point(200, 200)));
            //floors[2].drawObjects.edges.Add(new Edge(new Point(100, 200)));


            //floors[2].drawObjects.rooms.Add(new Room(floors[2].drawObjects.edges[0], floors[2].drawObjects.edges[1],
            //floors[2].drawObjects.edges[2], floors[2].drawObjects.edges[3]));




            //floors[0].drawObjects.rasst();
            //floors[1].drawObjects.rasst();
            //floors[2].drawObjects.rasst();
        }

        public  void loadSer(String path)
        {
            DrawMap newMap;
           // SoapFormatter formatter = new SoapFormatter();
            BinaryFormatter formatter = new BinaryFormatter();
            //using (FileStream fs = new FileStream(path + "TcMap.dat", FileMode.OpenOrCreate))
            //{
            //     newMap = (DrawMap)formatter.Deserialize(fs);
            //    MapManager.map = newMap;

            //}

            using (FileStream fs = new FileStream(path + "TcMap.dat", FileMode.OpenOrCreate))
            {
                 newMap = (DrawMap)formatter.Deserialize(fs);
                
                    newMap.floors= formatter.Deserialize(fs) as List<DrawMapFloor>;
                
                MapManager.map = newMap;
            }

        }
    }
}
