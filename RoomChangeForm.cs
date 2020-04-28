using MapRedPc.code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapRedPc
{
    public partial class RoomChangeForm : Form
    {
        int objId = -1;
        MapElement mapel;
        Room room;

        public RoomChangeForm(int objId)
        {
            InitializeComponent();
            this.objId = objId;
            mapel = DrawObjects.getElement(objId);
            
        }

        private void RoomChangeForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = mapel.location.X.ToString();
            textBox2.Text = mapel.location.Y.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mapel.location = new Point(Int32.Parse(textBox1.Text), Int32.Parse(textBox2.Text));
            DrawObjects.setElement(mapel);
            this.Close();
        }

        private void RoomChangeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MapInterface.opened = false;
            MapInterface.chosedObjId = -1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Point coord= new Point(Int32.Parse(textBox3.Text), Int32.Parse(textBox4.Text));
           
            this.Close();
        }
    }
}
