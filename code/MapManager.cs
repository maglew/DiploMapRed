using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapRedPc.code
{
    class MapManager
    {
       // MapCamera mapCamera;
      static  DrawObjects drawObjects;
      public static DrawMap map { get; set; }
      static  MapInterface mapin;

        public  MapManager()
        {
            drawObjects = new DrawObjects();
            mapin = new MapInterface();
           map=new DrawMap();
            // mapCamera = new MapCamera();
           
        }

        public static void render(Graphics g)
        {
            // drawObjects.render(g);
            map.render(g);
            MapCamera.render(g);
            MapInterface.render(g);
        }

        public static void tick()
        {
            MapCamera.tick();
            map.tick(MapCamera.getWorldLoc(), MapCamera.size);
            //  drawObjects.tick(MapCamera.getWorldLoc(), MapCamera.size);
            mapin.tick();
        }



    }
}
