using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;


//using System.Windows.Media;
//using System.Windows.Shapes;

namespace MapRedPc.code
{
    class MapZone : MapElement
    {
        int number;
       // String name="";
       
        public List<Point> locpoints = new List<Point>();
        public List<Point> relpoints = new List<Point>();
        public List<Point> dest = new List<Point>();
        Point temp = new Point(0, 0);
        byte[] types = { 0, 1, 1, 1 };
        bool inPolygon = false;

        public MapZone(Point location)
        {
            bordType.AddRange(types);
            this.movable = true;
            this.id = Guid.NewGuid();
            this.location = location;
            this.relativeLocation = location;
            locpoints.Add(location);


            locpoints.Add(new Point(location.X+100, location.Y));
            locpoints.Add(new Point(location.X + 100, location.Y+200));
            locpoints.Add(new Point(location.X, location.Y + 200));

            


            relpoints.AddRange(locpoints);
            touchzone.AddRange(relpoints);

            for (int k = 0; k < relpoints.Count - 1; k++)
            {
                dest.Add(new Point(0, 0));
            }

            for (int k = 0; k < relpoints.Count - 1; k++)
            {
                dest[k] = new Point(locpoints[k + 1].X - locpoints[0].X, locpoints[k + 1].Y - locpoints[0].Y);
            }


        }

            public override void tick(Point wordloc, int size)
        {

            if (temp.X != wordloc.X || temp.Y != wordloc.Y)
            {
                relativeLocation = new Point(wordloc.X + location.X, wordloc.Y + location.Y);
                temp = wordloc;
            }

            relpoints[0] = relativeLocation;
            for (int i = 1; i < relpoints.Count; i++)
            {
                relpoints[i] = new Point(relativeLocation.X + dest[i - 1].X, relativeLocation.Y+ dest[i - 1].Y);

            }

            locpoints[0] = location;
            for (int i = 1; i < relpoints.Count; i++)
            {
                locpoints[i] = new Point(location.X + dest[i - 1].X, location.Y + dest[i - 1].Y);

            }

            //relativeLocation.X = relativeLocation.X * size;
            //relativeLocation.Y = relativeLocation.Y * size;
            for (int k = 0; k < relpoints.Count - 1; k++)
            {
                dest[k] = new Point(locpoints[k + 1].X - locpoints[0].X, locpoints[k + 1].Y - locpoints[0].Y);
            }


            for (int k = 0; k < touchzone.Count ; k++)
            {
                touchzone[k] = new Point(relpoints[k].X+5 , relpoints[k ].Y +5);
            }

            
        }

        public override void move(Point coord)
        {

            this.relativeLocation = coord;
            this.location = new Point(relativeLocation.X - MapCamera.getWorldLoc().X, relativeLocation.Y - MapCamera.getWorldLoc().Y);
          
        }

        public override String read()
        {
            //  text = this.location.ToString();
            return base.read();
           // return text;
        }

        public override void render(Graphics g)
        {
          
            Pen pen = new Pen(Color.Red, 4);
            Pen pen2 = new Pen(Color.Blue, 4);
          //  g.DrawPolygon(inPolygon ? pen : pen2, points);
            g.DrawPolygon(Pens.Bisque, touchzone.ToArray());
            //  g.FillPolygon(inPolygon ? Brushes.Red : Brushes.Blue, relpoints.ToArray());
            Font fnt = new Font("Arial", 10);
            SolidBrush brsh = new SolidBrush(Color.Red);
            g.DrawString( text, fnt, brsh, new Point(relativeLocation.X, relativeLocation.Y));

            

        }

       

        public override bool touchhit(Point coord)
        {
            return base.touchhit(coord);
        }
    }
}
