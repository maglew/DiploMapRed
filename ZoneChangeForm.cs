using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MapRedPc.code;

namespace MapRedPc
{
    public partial class ZoneChangeForm : Form
    {
        int objId = -1;
        MapElement mapel;
        MapZone zone;
        public ZoneChangeForm(int objId)
        {
            InitializeComponent();
            this.objId = objId;
            mapel = MapManager.map.floors[DrawMap.selectedfloor].drawObjects.getElement(objId);
        }

       

        private void ZoneChangeForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = mapel.location.X.ToString();
            textBox2.Text = mapel.location.Y.ToString();
            textBox5.Text = mapel.text.ToString();
            textBox6.Text = mapel.touchzone.Count.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            mapel.location = new Point(Int32.Parse(textBox1.Text), Int32.Parse(textBox2.Text));
            mapel.text = textBox5.Text;
            mapel.setedgescount(Int32.Parse(textBox6.Text));
            MapManager.map.floors[DrawMap.selectedfloor].drawObjects.setElement(mapel);
            this.Close();
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ZoneChangeForm_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            MapInterface.opened = false;
            MapInterface.chosedObjId = -1;
        }
    }
}
