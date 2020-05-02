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
    public partial class EdgeChangeForm : Form
    {
        int objId=-1;

        MapElement tempElement;
        public EdgeChangeForm(int objId)
        {
            InitializeComponent();
            this.objId = objId;
        }

        private void ChangeForm_Load(object sender, EventArgs e)
        {
            //if (objId == -1)
            //{ this.Dispose(); }

            textBox1.Text = objId.ToString();
            MapInterface.opened = true;
            MapInterface.schot++;
                tempElement = DrawMap.floors[DrawMap.selectedfloor].drawObjects.getElement(objId);
                textBox2.Text = tempElement.location.X.ToString();
                textBox5.Text = tempElement.location.Y.ToString();
                textBox7.Text = tempElement.relativeLocation.X.ToString();
                textBox6.Text = tempElement.relativeLocation.Y.ToString();
            
        }

        private void EdgeChangeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // MapInterface.opened = false;
            MapCamera.lefttouch = new Point(0, 0);
            
              MapInterface.chosedObjId = -1;

            this.Dispose();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
                tempElement.location = new Point(Int32.Parse(textBox2.Text), Int32.Parse(textBox5.Text));
            DrawMap.floors[DrawMap.selectedfloor].drawObjects.setElement(tempElement);
            
           
           
            this.Close();
           
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (objId != -1)
          //      DrawObjects.delobj(DrawObjects.searchObjByCoord(tempElement.relativeLocation));
            MapInterface.opened = false;
            MapInterface.chosedObjId = -1;     
            this.Close();
        }
    }
}
