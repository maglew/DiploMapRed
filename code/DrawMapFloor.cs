using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapRedPc.code
{
    class DrawMapFloor
    {
       public DrawObjects drawObjects;

        public DrawMapFloor()
        {
            drawObjects = new DrawObjects();
        }

        public void tick(Point wordloc, int size)
        {
            drawObjects.tick(wordloc,size);
        }

        public void render(Graphics g)
        {
            drawObjects.render(g);
        }

        public DrawObjects getdraw()
        {
            return drawObjects;
        }

    }

  
}
