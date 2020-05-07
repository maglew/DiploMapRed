using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;



namespace MapRedPc.code
{
    [Serializable]
    abstract class MapElement
    {
        // public Rectangle touchrect = new Rectangle(0, 0, 0, 0);
       public string text = "";


        public List<Point> touchzone = new List<Point>();
        public List<byte> bordType = new List<byte>();
        

        public bool deletable = true;

        public Point location = new Point(0, 0);
        public Point relativeLocation = new Point(0, 0);

        //public List<Point> locpoints = new List<Point>();
        //public List<Point> relpoints = new List<Point>();


        public int width = 10;
        public Guid id;

        public int size = 0;
      //  public int rotation;
        public bool movable = true;


        public virtual void tick(Point wordloc, int size)
        {
            this.size = size;

          


        }

        public virtual void render(Graphics g)
        {
          

            
        }

        public virtual void move(Point coord)
        {



        }

        public virtual String read()
        {
            text = "";
          //  text +="loc="+ this.location.ToString()+"\n";
         //   text += "rel=" + this.relativeLocation.ToString() + "\n";
            text += "del=" + this.deletable.ToString() + "\n";
            text += "mov=" + this.movable.ToString() + "\n";
            text += "id=" + this.id.ToString() + "\n";
            text += "touchz=" + this.touchzone.ToString() + "\n";
            //text += "bordtype=" + this.bordType.ToString() + "\n";
            return text;
        }


        public virtual bool touchhit(Point coord)
        {
            bool inpol = false;

            using (var p = new GraphicsPath(touchzone.ToArray(), bordType.ToArray()))
            {
                var newVal = p.IsVisible(coord);
                if (newVal != inpol)
                {
                    inpol = newVal;
                }
            }

            return inpol;
        }

        public virtual void setedgescount(int count)
        {
            //if (count == locpoints.Count)
            //{ return; }
            //if (count > locpoints.Count)
            //{
            //    for (int i = 0; i < count - locpoints.Count; i++)
            //    {
            //        locpoints.Add(new Point(locpoints[locpoints.Count - 1].X + 15, locpoints[locpoints.Count - 1].Y + 15));
            //        relpoints.Add(new Point(locpoints[locpoints.Count - 1].X + MapCamera.worldlocation.X, locpoints[locpoints.Count - 1].Y + MapCamera.worldlocation.Y));
            //        touchzone.Add(locpoints[i]);
            //        bordType.Add(1);


            //    }
            //}
            //if (count < locpoints.Count)
            //{
            //    for (int i = locpoints.Count - 1; i > count - 1; i--)
            //    {
            //        locpoints.RemoveAt(i);
            //        relpoints.RemoveAt(i);
            //        touchzone.RemoveAt(i);
            //        bordType.RemoveAt(i);

            //    }
            //}
        }
        

    }
}
