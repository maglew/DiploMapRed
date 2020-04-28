using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapRedPc
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();

            this.Controls.Add(new UserControl2());
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();

            this.Controls.Add(new UserControl3());
        }
    }
}
