using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MapRedPc.code;
using System.Threading;
namespace MapRedPc
{
    public partial class UserControl3 : UserControl
    {

        Bitmap btm;
        Graphics g;
        Graphics fg;
      
        Point mousecoord = new Point(0, 0);
        MainThread thread;

        public UserControl3()
        {
            InitializeComponent();
        }
        private void UserControl3_Load(object sender, EventArgs e)
        {

          
            btm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(btm);
            fg = pictureBox1.CreateGraphics();

            thread = new MainThread(pictureBox1);
            thread.start();

            comboBox1.Items.Add("Edge");
            comboBox1.Items.Add("Wall");
            comboBox1.Items.Add("Zone");
        }
      

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            MyMouseManager.MouseDown(sender, e);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            MyMouseManager.MouseUp(sender, e);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            MyMouseManager.MouseMove(sender, e);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MapCamera.setWorldLoc(new Point(0, 0));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MapCamera.size++;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MapInterface.regime = "create";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MapInterface.regime = "delete";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MapInterface.regime = "change";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedType = comboBox1.SelectedItem.ToString();
            MapInterface.typeObj = selectedType;

        }

        private void button8_Click(object sender, EventArgs e)
        {
            MapInterface.regime = "move";
        }

      
    }





}
