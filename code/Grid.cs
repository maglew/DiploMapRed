using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapRedPc.code
{
    class Grid : MapElement
    {
        int rows;
        int columns;
        int length;
        int templength = 0;


        public Grid(int rows, int columns, int length)
        {
            this.deletable = false;
            this.rows = rows;
            this.columns = columns;
            this.length = length;
            this.location = new Point(0, 0);
            this.relativeLocation = new Point(0, 0);
        }

        
    public override void tick(Point relLocation, int size)
        {

            base.tick(relLocation, size);
            relativeLocation = new Point(relLocation.X + location.Y, relLocation.Y + location.Y);
            relativeLocation.X = relativeLocation.X * size;
            relativeLocation.Y = relativeLocation.Y * size;
            templength = length * size;


        }

        
    public override void render(Graphics g)
        {
           
            Pen pen = new Pen(Color.Cyan, 1);
            for (int i = 0; i <= rows; i++)
            {
                g.DrawLine(pen, relativeLocation.X, relativeLocation.Y + templength * i, relativeLocation.X + templength * rows, relativeLocation.Y + templength * i);
               
            }
            for (int i = 0; i <= columns; i++)
            {
                g.DrawLine(pen, relativeLocation.X + templength * i, relativeLocation.Y, relativeLocation.X + templength * i, relativeLocation.Y + templength * columns);
            }

        }

        public override bool touchhit(Point coord)
        {
            return false;
        }


    }
}
