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
        Edge A;
        Edge B;
        int id;
        Point dest;

        public Wall(Edge A, Edge B)
        {
            base.movable = true;
            this.A = A;
            this.B = B;
            id++;
            dest = new Point(Math.Abs(B.relativeLocation.X - A.relativeLocation.X), Math.Abs(B.relativeLocation.Y - A.relativeLocation.Y));

            touchzone.Add(new Point(A.relativeLocation.X + 3, A.relativeLocation.Y - 3));
            touchzone.Add(new Point(B.relativeLocation.X + 3, B.relativeLocation.Y - 3));
            touchzone.Add(new Point(B.relativeLocation.X - 3, B.relativeLocation.Y + 3));
            touchzone.Add(new Point(A.relativeLocation.X - 3, A.relativeLocation.Y + 3));

            bordType.Add(0);
            bordType.Add(1);
            bordType.Add(1);
            bordType.Add(1);

        }


        
    public override void tick(Point relativeLocation, int size)
        {
            base.tick(relativeLocation, size);
               dest = new Point(Math.Abs(B.relativeLocation.X - A.relativeLocation.X), Math.Abs(B.relativeLocation.Y - A.relativeLocation.Y));
            A.tick(relativeLocation, size);
            B.tick(relativeLocation, size);
            touchzone[0]=new Point(A.relativeLocation.X + 3, A.relativeLocation.Y - 3);
            touchzone[1] = new Point(B.relativeLocation.X + 3, B.relativeLocation.Y - 3);
            touchzone[2] = new Point(B.relativeLocation.X - 3, B.relativeLocation.Y + 3);
            touchzone[3] = new Point(A.relativeLocation.X - 3, A.relativeLocation.Y + 3);
        }


        public override void render(Graphics g)
        {

           
            Pen pen = new Pen(Color.Green, 3);
            Pen pen2 = new Pen(Color.Red, 1);
            g.DrawLine(pen,A.relativeLocation.X, A.relativeLocation.Y, B.relativeLocation.X, B.relativeLocation.Y);
            g.DrawPolygon(pen2, touchzone.ToArray());
        }



        public int getId()
        {
            return id;
        }

        public void setId(int id)
        {
            this.id = id;
        }
        public override String read()
        {
            // text = this.location.ToString();
            return base.read();
            //return text;
        }
    }
}
