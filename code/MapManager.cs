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
        MapInterface mapin;

        public MapManager()
        {
            drawObjects = new DrawObjects();
            mapin = new MapInterface();
            // mapCamera = new MapCamera();
           
        }

        public void render(Graphics g)
        {
            drawObjects.render(g);
            MapCamera.render(g);
            MapInterface.render(g);
        }

        public void tick()
        {
            MapCamera.tick();
            drawObjects.tick(MapCamera.getWorldLoc(), MapCamera.size);
            mapin.tick();
        }

    }
}
