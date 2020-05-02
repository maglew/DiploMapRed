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
        DrawObjects drawObjects;
      //  DrawMap map;
       MapInterface mapin;

        public MapManager()
        {
            drawObjects = new DrawObjects();
            mapin = new MapInterface();
             new DrawMap();
            // mapCamera = new MapCamera();
           
        }

        public void render(Graphics g)
        {
            // drawObjects.render(g);
            DrawMap.render(g);
            MapCamera.render(g);
            MapInterface.render(g);
        }

        public void tick()
        {
            MapCamera.tick();
            DrawMap.tick(MapCamera.getWorldLoc(), MapCamera.size);
            //  drawObjects.tick(MapCamera.getWorldLoc(), MapCamera.size);
            mapin.tick();
        }



    }
}
