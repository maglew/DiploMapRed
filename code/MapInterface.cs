using System;
using System.Drawing;


namespace MapRedPc.code
{
    class MapInterface
    {
     public  static String regime = "move";
        public static int chosedObjId = -1;
        public static String typeObj = "null";
       public static  int schot=0;
        public static int coun = 0;
        public static bool opened = false;
        public static bool dragged = false;
        Point touch = new Point(0, 0);
        EdgeChangeForm objRedForm;
        Point razn = new Point(0, 0);
        int A=-1;
        int B=-1;
        public MapInterface()
        { }
        public  void tick()
        {
           
            switch (regime)
            {
                case "delete":
                    
                    if (MyMouseManager.left)
                    {   typeObj = "";
                        MapManager.map.floors[DrawMap.selectedfloor].drawObjects.delobj(MapManager.map.floors[DrawMap.selectedfloor].drawObjects.searchObjByCoord(MapCamera.lefttouch));
                        chosedObjId = MapManager.map.floors[DrawMap.selectedfloor].drawObjects.searchObjByCoord(MapCamera.lefttouch);
                        typeObj = "";
                    }
                    break;
                case "create":

                    if (typeObj == "Edge" && MyMouseManager.left && schot == 0)
                    {
                        MapManager.map.floors[DrawMap.selectedfloor].drawObjects.addNewEdge(new Point(MapCamera.lefttouch.X - MapCamera.worldlocation.X, MapCamera.lefttouch.Y - MapCamera.worldlocation.Y));
                        schot++;
                    }
                    if (typeObj == "Room" && MyMouseManager.left && schot == 0)
                    {
                        MapManager.map.floors[DrawMap.selectedfloor].drawObjects.addNewRoom(new Point(MapCamera.lefttouch.X - MapCamera.worldlocation.X, MapCamera.lefttouch.Y - MapCamera.worldlocation.Y));
                        schot++;
                    }
                    if (typeObj == "Wall" && MyMouseManager.left && schot == 0)
                    {

                        chosedObjId = MapManager.map.floors[DrawMap.selectedfloor].drawObjects.searchObjByCoord(MapCamera.lefttouch);
                        if (chosedObjId!=-1&& MapManager.map.floors[DrawMap.selectedfloor].drawObjects.getElement(chosedObjId) is Edge)
                        {
                            if (A == -1)
                            { A = chosedObjId;
                                chosedObjId = -1;
                            }
                            else
                            { B = chosedObjId; }
                            if (B != -1 && A != -1&&B!=A)
                            {
                                MapManager.map.floors[DrawMap.selectedfloor].drawObjects.addNewWall(A,B);
                                schot++;
                                chosedObjId = -1;
                                
                            }
                        }
                        
                    }

                    if (schot > 0&&!MyMouseManager.left)
                    {
                        A = -1;
                        B = -1;
                        schot = 0;
                        break;
                    }
                  

                    break;
                case "change":
                    typeObj = "";
                    if (MyMouseManager.left)
                    {
                        chosedObjId = MapManager.map.floors[DrawMap.selectedfloor].drawObjects.searchObjByCoord(MapCamera.lefttouch);
                        if (chosedObjId != -1)
                        {

                            if (!opened && MapManager.map.floors[DrawMap.selectedfloor].drawObjects.getElement(chosedObjId) is Edge)
                            {
                                objRedForm = new EdgeChangeForm(chosedObjId);
                                objRedForm.ShowDialog();
                                MyMouseManager.left = false;

                                break;
                            }

                            if (!opened && MapManager.map.floors[DrawMap.selectedfloor].drawObjects.getElement(chosedObjId) is MapZone)
                            {
                                ZoneChangeForm roomChangeForm = new ZoneChangeForm(chosedObjId);
                                roomChangeForm.ShowDialog();
                                MyMouseManager.left = false;

                                break;
                            }
                            if (!opened && MapManager.map.floors[DrawMap.selectedfloor].drawObjects.getElement(chosedObjId) is Room)
                            {
                                RoomChangeForm roomChangeForm = new RoomChangeForm(chosedObjId);
                                roomChangeForm.ShowDialog();
                                MyMouseManager.left = false;

                                break;
                            }
                        }

                        
                    }
                        if (MyMouseManager.left==false)
                        {
                           // MyMouseManager.leftGrab = new Point(0, 0);
                           // MyMouseManager.left = false;
                            chosedObjId = -1;
                           //   MyMouseManager.lefttouch = new Point(0, 0);
                            opened = false;
                        }

                    break;
                case "move":

                    typeObj = "";
                    if (MyMouseManager.left)
                    {
                        if (!dragged)
                        {
                            chosedObjId = MapManager.map.floors[DrawMap.selectedfloor].drawObjects.searchObjByCoord(MapCamera.lefttouch);
                            dragged = true;
                            razn = new Point(0, 0);
                            if (chosedObjId != -1)
                            {
                                razn.X = MapCamera.lefttouch.X - MapManager.map.floors[DrawMap.selectedfloor].drawObjects.getElement(chosedObjId).relativeLocation.X;
                                razn.Y = MapCamera.lefttouch.Y - MapManager.map.floors[DrawMap.selectedfloor].drawObjects.getElement(chosedObjId).relativeLocation.Y;
                            }
                        }

                        if (chosedObjId != -1 && MyMouseManager.left)
                        {
                            MapManager.map.floors[DrawMap.selectedfloor].drawObjects.moveElement(chosedObjId, new Point(MyMouseManager.mousecoord.X - razn.X, MyMouseManager.mousecoord.Y - razn.Y));
                        }

                        
                    }
                        if (!MyMouseManager.left && dragged)
                        {
                        chosedObjId = -1;
                        dragged = false; }
                    break;

            }
        }

        public static void render(Graphics g) 
        {
            Font fnt = new Font("Arial", 10);
            SolidBrush brsh = new SolidBrush(Color.Yellow);

            g.DrawString("reg: " + regime +" obj: " +chosedObjId+" type: "+typeObj+" open: "+opened+" floor: "+DrawMap.selectedfloor, fnt, brsh, new Point(700, 250));

        }


    }
}
