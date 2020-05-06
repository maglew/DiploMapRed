using System;
using System.Collections.Generic;
using System.Drawing;


namespace MapRedPc.code
{
    class Edge : MapElement
    {
      //  int num = 0;
      
        List<Edge> neighbors = new List<Edge>();
        List<Wall> walls = new List<Wall>();
        Point temp = new Point(0, 0);
        byte[] types = { 0, 1, 1, 1 };
        public Edge(Point coord)
        {
          //  bordType.AddRange(types);
            this.movable = true;
            this.id = Guid.NewGuid();
            location = coord;
            relativeLocation = location;
            //locpoints.Add(coord);
            //relpoints.Add(locpoints[0]);
            //this.location = coord;
            //this.relativeLocation = location;

            this.touchzone.Add(new Point(relativeLocation.X - width / 2-5, relativeLocation.Y - width / 2-5));
                this.touchzone.Add(new Point(relativeLocation.X - width / 2 + 5, relativeLocation.Y - width / 2 - 5));
                this.touchzone.Add(new Point(relativeLocation.X - width / 2 + 5, relativeLocation.Y - width / 2 + 5));
            this.touchzone.Add(new Point(relativeLocation.X - width / 2 - 5, relativeLocation.Y - width / 2 + 5));

            bordType.Add(0);
            bordType.Add(1);
            bordType.Add(1);
            bordType.Add(1);
        }

        
    public override void tick(Point wordloc, int size)
        {
            if (temp.X != wordloc.X || temp.Y != wordloc.Y)
            {
                relativeLocation = new Point(wordloc.X + location.X, wordloc.Y + location.Y );
                temp = wordloc;
            }
            else
            {
          //      relativeLocation = new Point(wordloc.X + location.X, wordloc.Y + location.Y);
            }
            //relativeLocation.X = relativeLocation.X * size;
            //relativeLocation.Y = relativeLocation.Y * size;

            this.touchzone[0]=(new Point(relativeLocation.X   - 10, relativeLocation.Y   - 10));
            this.touchzone[1] = (new Point(relativeLocation.X   + 10, relativeLocation.Y  - 10));
            this.touchzone[2] = (new Point(relativeLocation.X   + 10, relativeLocation.Y   + 10));
            this.touchzone[3] = (new Point(relativeLocation.X   - 10, relativeLocation.Y   + 10));

            foreach (Wall wall in walls)
            {
                wall.tick(wordloc, size);

            }

        }

    
    public override void render(Graphics g)
        {
          
            Pen pen = new Pen(Color.Red, 1);

            g.DrawRectangle(pen, relativeLocation.X - width / 4, relativeLocation.Y - width / 4, width / 2, width / 2);
             pen = new Pen(Color.Pink, 1);
           
              g.DrawPolygon( pen , touchzone.ToArray());
            foreach (Wall wall in walls)
            {
                wall.render(g);
            }


        }


        public override void move(Point coord)
        {
            this.relativeLocation = coord;
            this.location = new Point(relativeLocation.X- MapCamera.getWorldLoc().X, relativeLocation.Y - MapCamera.getWorldLoc().Y);
          
        }

        public override String read()
        {
            // text = this.location.ToString();
            return base.read();
            //return text;
        }
        public override bool touchhit(Point coord)
        {

            return base.touchhit(coord);
        }

        public void setNeighbors()
        {

        }

        public void setOneNeighbor(Edge edge)
        {
            this.walls.Add(new Wall(this, edge));
            this.neighbors.Add(edge);
            edge.neighbors.Add(this);
        }


    }
}
