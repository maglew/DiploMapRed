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
    public partial class Form1 : Form
    {
      

      
        public Form1()
        {
            InitializeComponent();
            //SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            //UpdateStyles();
            this.Controls.Add(new UserControl1());

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
