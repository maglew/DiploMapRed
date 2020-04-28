using System;
using System.Drawing;


namespace MapRedPc.code
{
    class MapInterface
    {
     public  static String regime = "move";
        public static int chosedObjId = -1;
        public static String typeObj = "";
       public static  int schot=0;
        public static bool opened = false;
        public static bool dragged = false;
        Point touch = new Point(0, 0);
        EdgeChangeForm objRedForm;
        Point razn = new Point(0, 0);
        public MapInterface()
        { }
        public  void tick()
        {
           
            switch (regime)
            {
                case "delete":
                    typeObj = "";
                    DrawObjects.delobj(DrawObjects.searchObjByCoord(MapCamera.lefttouch));
                    chosedObjId = DrawObjects.searchObjByCoord(MapCamera.lefttouch);
                    typeObj = "";
                    break;
                case "create":

                    if (typeObj == "Edge" && MyMouseManager.left && schot == 0)
                    {
                        DrawObjects.addNewEdge(new Point(MapCamera.lefttouch.X - MapCamera.worldlocation.X, MapCamera.lefttouch.Y - MapCamera.worldlocation.Y));
                        schot++;
                    }
                    if (typeObj == "Zone" && MyMouseManager.left && schot == 0)
                    {
                        DrawObjects.addNewZone(new Point(MapCamera.lefttouch.X - MapCamera.worldlocation.X, MapCamera.lefttouch.Y - MapCamera.worldlocation.Y));
                        schot++;
                    }

                    if (schot > 0&&!MyMouseManager.left)
                    { 
                        schot = 0;
                        break;
                    }
                  

                    break;
                case "change":
                    typeObj = "";
                    chosedObjId = DrawObjects.searchObjByCoord(MapCamera.lefttouch);
                    if (chosedObjId != -1)
                    {

                        if (!opened&& DrawObjects.getElement(chosedObjId) is Edge)
                        {
                            objRedForm = new EdgeChangeForm(chosedObjId);
                            objRedForm.ShowDialog();


                              break;
                        }

                        if (!opened && DrawObjects.getElement(chosedObjId) is Room )
                        {
                            RoomChangeForm roomChangeForm = new RoomChangeForm(chosedObjId);
                            roomChangeForm.ShowDialog();
                           
                            
                            break;
                        }
                        /////////////////////////////////////////////
                        MyMouseManager.leftGrab = new Point(0, 0);/////
                        MyMouseManager.left = false;/////
                        
                        MapInterface.chosedObjId = -1;
                        MyMouseManager.lefttouch = new Point(0, 0);/////
                             MapInterface.opened = false;//////
                       //////////////////////////////////////////////

                    }
                    break;
                case "move":

                    typeObj = "";
                    if (!dragged)
                    { 
                        chosedObjId = DrawObjects.searchObjByCoord(MapCamera.lefttouch);
                        dragged = true;
                        razn = new Point(0, 0);
                        if (chosedObjId != -1)
                        {
                            razn.X = MapCamera.lefttouch.X - DrawObjects.getElement(chosedObjId).relativeLocation.X;
                            razn.Y = MapCamera.lefttouch.Y - DrawObjects.getElement(chosedObjId).relativeLocation.Y;
                        }
                    }

                    if (chosedObjId != -1 && MyMouseManager.left)
                    {           
                            DrawObjects.moveElement(chosedObjId,new Point( MyMouseManager.mousecoord.X-razn.X, MyMouseManager.mousecoord.Y - razn.Y ));
                    }

                    if (!MyMouseManager.left&&dragged)
                    { dragged = false; }

                    break;

            }
        }

        public static void render(Graphics g) 
        {
            Font fnt = new Font("Arial", 10);
            SolidBrush brsh = new SolidBrush(Color.Yellow);

            g.DrawString(regime +" / " +chosedObjId+" / "+typeObj+"/"+opened, fnt, brsh, new Point(700, 250));

        }


    }
}
