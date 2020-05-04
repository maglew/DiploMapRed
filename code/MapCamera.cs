using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapRedPc.code
{
    class MapCamera
    {
      public static int size = 1;
        static Rectangle screenRect;
        static int attenuation = 10;
        static Point  vec = new Point(0, 0);
        static Point  razn = new Point(0, 0);
        public static Point  worldlocation = new Point(0, 0);
         public static  Point mousecoord = new Point(0, 0);
         public static Point rightGrab = new Point(0, 0);
        public static Point leftGrab = new Point(0, 0);
         public static Point righttouch = new Point(0, 0);
         public static Point lefttouch = new Point(0, 0);
         public static Point rightup = new Point(0, 0);
         public static Point leftup = new Point(0, 0);


        public MapCamera()
        {
            screenRect = new Rectangle(0, 0, 2, 2);
        }

        public static void tick()
        {

            mousecoord = MyMouseManager.mousecoord;

            if (MyMouseManager.right)
            {
                righttouch = MyMouseManager.righttouch;
                attenuation = 5;
            }

            leftGrab = MyMouseManager.leftGrab;
            rightGrab = MyMouseManager.rightGrab;

            if (rightGrab.X != 0 && rightGrab.Y != 0)
            {
                razn = new Point(rightGrab.X - worldlocation.X, rightGrab.Y - worldlocation.Y);
            }
            else
            {
                razn = new Point(0, 0);
                righttouch = new Point(0, 0);
            }


            vec = new Point(rightGrab.X - righttouch.X, rightGrab.Y - righttouch.Y);
            if (attenuation <= 0)
            { vec = new Point(0, 0); }

            if (worldlocation.X - razn.X != rightGrab.X && worldlocation.Y - razn.Y != rightGrab.Y)
            {
                worldlocation.X += vec.X /10;
                worldlocation.Y += vec.Y /10;
                attenuation--;
            }
            lefttouch = MyMouseManager.lefttouch;

            



            if (!MyMouseManager.right)
            {
                attenuation = 0;
            }

            screenRect = new Rectangle(mousecoord.X, mousecoord.Y, screenRect.Width, screenRect.Height);
            
        }

        public static void render(Graphics g)
        {



            Pen pen = new Pen(Color.Red, 2);
            g.DrawRectangle(pen, screenRect.X, screenRect.Y, screenRect.Width, screenRect.Height);
              Font fnt = new Font("Arial", 10);
              SolidBrush brsh = new SolidBrush(Color.Red);
            g.DrawString("WORLDLOC:" + worldlocation.X + "." + worldlocation.Y + "", fnt, brsh, new Point(700, 75));
            g.DrawString("mousecoord:" + mousecoord.X + "." + mousecoord.Y+"", fnt, brsh, new Point(700, 100));
            g.DrawString("Lefttouch:" + lefttouch.X + "." + lefttouch.Y + "", fnt, brsh, new Point(700, 115));
            g.DrawString("Righttouch:" + righttouch.X + "." + righttouch.Y + "", fnt, brsh, new Point(700, 130));
            g.DrawString("LeftGrab:" + leftGrab.X + "." + leftGrab.Y + "", fnt, brsh, new Point(700, 145));
            g.DrawString("Rightgrab:" + rightGrab.X + "." + rightGrab.Y + "", fnt, brsh, new Point(700, 160));
            g.DrawString("razn:" + razn.X + "." + razn.Y + "", fnt, brsh, new Point(700, 175));
            g.DrawString("vec:" + vec.X + "." + vec.Y + "", fnt, brsh, new Point(700, 190));
        }

        public static Point getWorldLoc()
        { return worldlocation; }

        public static void setWorldLoc(Point coord)
        { worldlocation = coord; }

    }
}
