using MapRedPc.code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapRedPc
{
    public partial class SaveForm : Form
    {
        String tempath = "C:\\Users\\maglew\\Desktop";
        String name = "map1";
        public SaveForm()
        {
            InitializeComponent();
            // String path= "C:\\Users\\maglew";

            webBrowser1.Url = new Uri(tempath);
            pathclean();
            textBox1.Text = tempath;
        }

        private void SaveForm_Load(object sender, EventArgs e)
        {

        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoBack)
                webBrowser1.GoBack();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoForward)
                webBrowser1.GoForward();

        }

       
        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            tempath = webBrowser1.Url.ToString();

            pathclean();
            textBox1.Text = tempath;
        }

        

        private void button4_Click_1(object sender, EventArgs e)
        {
            DrawMap.save(tempath+@"\"+"TcMap.txt");
        }

        public void pathclean()
        {
            if (tempath.Contains("file:///"))
            {
                tempath = tempath.Remove(0, 8);
            }

            if (tempath.Contains("/"))
            {
                //char a=@"\";
                String str=
                tempath = tempath.Replace("/",@"\");
            }
        }

    }
}
