using System;

using System.Drawing;

using System.Windows.Forms;
using MapRedPc.code;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Threading;

namespace MapRedPc
{
    public partial class UserControl2 : UserControl
    {
        Point xy = new Point(0, 0);

        //  Point worldloc = new Point(100, 100);
        DrawObjects obj;
        bool drawning = true;
        Pen pen = new Pen(Color.Yellow, 2);
        // Font font = new Font("Verdana", 10);
        // SolidBrush myTrub = new SolidBrush(Color.Red);

        Bitmap btm;
        Graphics g;
        Graphics fg;
        Thread th;

        public UserControl2()
        {
            InitializeComponent();
      
        }

        private void UserControl2_Load(object sender, EventArgs e)
        {
            obj = new DrawObjects();

            btm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(btm);
            fg = pictureBox1.CreateGraphics();

            th = new Thread(draw);
            th.IsBackground = true;
            th.Start();

        }

        

        void draw()
        {
            Pen myWind = new Pen(Color.Yellow, 2);
            fg.Clear(Color.Black);

            while (drawning)
            {
                g.Clear(Color.Black);
                obj.tick(new Point(xy.X, xy.Y), 1);
                obj.render(g);
                xy.X++;
                xy.Y++;
                fg.DrawImage(btm, new Point(0, 0));
            }

        }


        private void button2_Click(object sender, EventArgs e)
        {
            xy.X = 0;
            xy.Y = 0;
        }

    }
}