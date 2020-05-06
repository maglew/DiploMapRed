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
       
                public List<Wall> walls = new List<Wall>();
                public List<Edge> edges = new List<Edge>();
                 public List<Point> dest = new List<Point>();
      

        public Room(Edge A, Edge B, Edge C, Edge D)
        {
            location = new Point((A.location.X+ C.location.X)/2, (A.location.Y + C.location.Y) / 2);
            relativeLocation = location;

            this.movable = true;
            this.id = Guid.NewGuid();
            
            this.edges.Add(A);
            this.edges.Add(B);
            this.edges.Add(C);
            this.edges.Add(D);

            walls.Add(new Wall(A, B));
            walls.Add(new Wall(B, C));
            walls.Add(new Wall(C, D));
            walls.Add(new Wall(D, A));

            touchzone.Add(edges[0].relativeLocation);
            touchzone.Add(edges[1].relativeLocation);
            touchzone.Add(edges[2].relativeLocation);
            touchzone.Add(edges[3].relativeLocation);

            bordType.Add(0);
            bordType.Add(1);
            bordType.Add(1);
            bordType.Add(1);

            dest.Add(new Point(0, 0));
            dest.Add(new Point(0, 0));
            dest.Add(new Point(0, 0));
            dest.Add(new Point(0, 0));

            for (int i = 0; i < dest.Count; i++)
            {
                dest[i] = new Point(location.X - edges[i].location.X, location.Y - edges[i].location.Y);
            }
        }

       
        public override void tick(Point wordloc, int size)
        {
           
          
            relativeLocation = new Point(wordloc.X + location.X, wordloc.Y + location.Y);

            for (int i = 0; i < dest.Count; i++)
            {
                dest[i] = new Point(location.X - edges[i].location.X, location.Y - edges[i].location.Y);
            }

            for (int j = 0; j < edges.Count ; j++)
            {
                //edges[j].location= new Point(center.X + dest[j].X, center.Y + dest[j].Y);
                //edges[j].relativeLocation = new Point(wordloc.X + edges[j].location.X,  wordloc.Y + edges[j].location.Y);
                edges[j].tick(wordloc,size);

            }

          

            for (int j = 0; j < walls.Count ; j++)
            {
                walls[j].tick(wordloc, size);

            }
            for (int j = 0; j < touchzone.Count ; j++)
            {
                touchzone[j] = edges[j].relativeLocation;

            }

        }


        public override void render(Graphics g)
        {
            Pen pen = new Pen(Color.Red, 1);
            g.DrawRectangle(pen,new Rectangle(relativeLocation.X-5, relativeLocation.Y - 5, 10, 10));
            for (int j = 0; j < edges.Count ; j++)
            {
                edges[j].render(g);
               
            }
            for (int j = 0; j < walls.Count ; j++)
            {
                walls[j].render(g);

            }

   
        }
        public override void move(Point coord)
        {
                relativeLocation = coord;
                location = new Point(relativeLocation.X - MapCamera.getWorldLoc().X, relativeLocation.Y - MapCamera.getWorldLoc().Y);

            for (int j = 0; j < edges.Count; j++)
            {
                edges[j].move(new Point(coord.X-dest[j].X, coord.Y - dest[j].Y));
            }
        }

        public override bool touchhit(Point coord)
        {
            return base.touchhit(coord);
        }

        public override void setedgescount(int count)
        {
            if (count == edges.Count)
            { return; }
            if (count > edges.Count)
            {
                for (int i = 0; i < count - edges.Count; i++)
                {
                DrawMap.floors[DrawMap.selectedfloor].drawObjects.elements.Add(new Edge(new Point(edges[edges.Count - 1].location.X - 15, edges[edges.Count - 1].location.Y - 15)));
                    
                    DrawMap.floors[DrawMap.selectedfloor].drawObjects.edges.Add(new Edge(new Point(edges[edges.Count-1].location.X-10, edges[edges.Count - 1].location.Y - 10)));
                    DrawMap.floors[DrawMap.selectedfloor].drawObjects.rasst();
                    edges.Add(DrawMap.floors[DrawMap.selectedfloor].drawObjects.edges[DrawMap.floors[DrawMap.selectedfloor].drawObjects.edges.Count-1]);
                    walls.RemoveAt(walls.Count-1);
                    walls.Add(new Wall(edges[edges.Count-2], edges[edges.Count - 1]));
                    walls.Add(new Wall(edges[edges.Count - 1], edges[0]));

                    dest.Add(new Point(0,0));
                    touchzone.Add(edges[edges.Count-1].relativeLocation);
                    bordType.Add(1);


                }
            }
            if (count < edges.Count)
            {
                for (int i = edges.Count - 1; i > count - 1; i--)
                {
                    edges.RemoveAt(i);
                    dest.RemoveAt(i);
                    touchzone.RemoveAt(i);
                    bordType.RemoveAt(i);

                }
            }
        }
    }
}
