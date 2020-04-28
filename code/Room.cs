using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapRedPc.code
{
    class Room : MapElement
    {
      public  List<Point> locpoints = new List<Point>();
        public List<Point> rellocpoints = new List<Point>();
        public List<Point> dest = new List<Point>();
        public Room(Point A, Point B, Point C, Point D)
        {
            this.movable = true;
            this.id = Guid.NewGuid();
            this.location =A;
            this.relativeLocation = location;
            this.locpoints.Add(A);
            this.locpoints.Add(B);
            this.locpoints.Add(C);
            this.locpoints.Add(D);
            rellocpoints.AddRange(locpoints);
            for (int k = 0; k < rellocpoints.Count -1; k++)
            {
                dest.Add(new Point(0, 0));
            }
        }
        public override void tick(Point wordloc, int size)
        {

            

            for (int i=0;i<rellocpoints.Count;i++)
            {
                rellocpoints[i] = new Point(locpoints[i].X+ wordloc.X, locpoints[i].Y+ wordloc.Y);
                
            }
            //relativeLocation.X = relativeLocation.X * size;
            //relativeLocation.Y = relativeLocation.Y * size;
            for (int k = 0; k < rellocpoints.Count-1; k++)
            {
                dest[k] = new Point(locpoints[k+1].X - locpoints[0].X, locpoints[k+1].Y - locpoints[0].Y);
            }

locpoints[0] = location;

            for (int i = 1; i < rellocpoints.Count; i++)
            {
                locpoints[i] = new Point(locpoints[0].X + dest[i - 1].X, locpoints[0].Y + dest[i - 1].Y);

            }


        }


        public override void render(Graphics g)
        {
           
            Pen pen = new Pen(Color.Red, 4);

           
            
            for (int j = 0; j < rellocpoints.Count-1; j++)
            {
                
                g.DrawLine(pen,rellocpoints[j], rellocpoints[j+1]);
                
               
            }
            
                g.DrawLine(pen, rellocpoints[0], rellocpoints[rellocpoints.Count-1]);

            pen = new Pen(Color.Blue, 2);
         //   g.DrawRectangle(pen,touchrect);


        }
        public override void move(Point coord)
        {
            location = coord;
            locpoints[0] = location ;
                
                for (int i = 1; i < rellocpoints.Count; i++)
                {
                    locpoints[i] = new Point(coord.X + dest[i - 1].X, coord.Y + dest[i - 1].Y);

                }

        }

        public override bool touchhit(Point coord)
        {
            return base.touchhit(coord);

        }

        public void addEdge(Point coord)
        {
            locpoints.Add(coord);
            rellocpoints.Add(coord);

        }
    }
}
