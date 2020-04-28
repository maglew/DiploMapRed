using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MapRedPc.code
{
    class MyMouseManager
    {
        static public bool left =false;
        static public bool right = false;
        static public bool enter =false;

        static public Point entercoord = new Point(0, 0);
        static public Point mousecoord = new Point(0, 0);
        static public Point rightGrab = new Point(0, 0);
        static public Point leftGrab = new Point(0, 0);
        static public Point righttouch = new Point(0, 0);
        static public Point lefttouch = new Point(0, 0);
        static public Point rightup = new Point(0, 0);
        static public Point leftup = new Point(0, 0);
        
       
        
       
        public MyMouseManager()
        {

           
        }



        public static void MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Left))
            {
                left = true;
                lefttouch = new Point(e.X, e.Y);
            }
            if (e.Button.Equals(MouseButtons.Right))
            {
                right = true;
                righttouch = new Point(e.X, e.Y);
            }

            


        }

        public static void MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Left))
            {
                left = false;
                    lefttouch = new Point(0, 0);
                leftup = new Point(e.X, e.Y);
            }
            if (e.Button.Equals(MouseButtons.Right))
            {
                right = false;
                righttouch = new Point(0, 0);
                rightup = new Point(e.X, e.Y);
            }

            if (!left)
            {
               
                leftGrab = new Point(0, 0);
            }
            if (!right)
            {
                
                rightGrab = new Point(0, 0);
            }
        }

      

       

        public static void MouseMove(object sender, MouseEventArgs e)
        {
            mousecoord = new Point(e.X, e.Y);
            if (left)
            {

                leftGrab = mousecoord;
            }
            if (right)
            {

                rightGrab = mousecoord;
            }
        }

        


    
    }
}
