using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;



namespace MapRedPc.code
{
    abstract class MapElement
    {
        // public Rectangle touchrect = new Rectangle(0, 0, 0, 0);
       protected string text = "";
        public List<Point> touchzone = new List<Point>();
        public List<byte> bordType = new List<byte>();
        

        public bool deletable = true;
        public Point location = new Point(0, 0);
        public Point relativeLocation = new Point(0, 0);
       
        public int width = 10;
        public Guid id;

        public int size = 0;
      //  public int rotation;
        public bool movable = true;


        public virtual void tick(Point wordloc, int size)
        {
            this.size = size;
            this.relativeLocation = wordloc;

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
            text +="loc="+ this.location.ToString()+"\n";
            text += "rel=" + this.relativeLocation.ToString() + "\n";
            text += "del=" + this.deletable.ToString() + "\n";
            text += "mov=" + this.movable.ToString() + "\n";
            text += "id=" + this.id.ToString() + "\n";
            text += "touchz=" + this.touchzone.ToString() + "\n";
            text += "bordtype=" + this.bordType.ToString() + "\n";
            return text;
        }


        public virtual bool touchhit(Point coord)
        {
            bool inpol = false;
            using (var p = new GraphicsPath(touchzone.ToArray(),bordType.ToArray()))
            {
                var newVal = p.IsVisible(coord);
                if (newVal != inpol)
                {
                    inpol = newVal;
                }
            }
            return inpol;
        }


        

    }
}
