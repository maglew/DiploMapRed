using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapRedPc.code
{
    class Wall : MapElement
    {
        Edge pointA;
        Edge pointB;
        int id;

        public Wall(Edge pointA, Edge pointB)
        {
            this.location = new Point(0, 0);
            base.movable = true;
            this.pointA = pointA;
            this.pointB = pointB;
            id++;
            this.pointA.relativeLocation = location;
            this.pointB.relativeLocation = location;
          
        }


        
    public override void tick(Point relativeLocation, int size)
        {
            base.tick(relativeLocation, size);
           

        }

        
    public override void render(Graphics g)
        {

           
            Pen pen = new Pen(Color.Green, 4);
            g.DrawLine(pen,pointA.relativeLocation.X, pointA.relativeLocation.Y, pointB.relativeLocation.X, pointB.relativeLocation.Y);
        }



        public int getId()
        {
            return id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

    }
}
