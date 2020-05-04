using System;

using System.Threading;
using System.Drawing;
using System.Windows.Forms;

namespace MapRedPc.code
{
    class MainThread
    {
        
        
        private bool running = false;

        MapManager mapManager;
        private Thread th;
        
        Graphics g;
        Bitmap btm;
        Graphics fg;
     
        
        

        public MainThread(PictureBox picturebox)
        {
            btm = new Bitmap(picturebox.Width, picturebox.Height);
            g = Graphics.FromImage(btm);
            fg = picturebox.CreateGraphics();
            mapManager = new MapManager();
            

        }

        public void run()
        {

            while (running)
            {
                g.Clear(Color.Gray);
                tick();
                render();
                fg.DrawImage(btm, new Point(0, 0));

            }

            stop();
        }




        public void tick()
        {
            mapManager.tick();
            
            
        }

        public void render()
        {
            mapManager.render(g);
            
        }


        public  void start()
        {
            if (running)
            { return; }
            running = true;
            th = new Thread(run);
            th.IsBackground = true;
            th.Start();
        }


        public  void stop()
        {
            if (!running)
            { return; }
            running = false;
    
        }

        public static void sleepsome(int count)
        {
            Thread.Sleep(300);
        }
       


    }
}
