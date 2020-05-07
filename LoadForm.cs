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
    public partial class LoadForm : Form
    {
        String tempath = "C:\\Users\\maglew\\Desktop";

        public LoadForm()
        {
            InitializeComponent();
            // String path= "C:\\Users\\maglew";
            
            webBrowser1.Url = new Uri(tempath);
            pathclean();
            textBox1.Text = tempath;
        }

        private void LoadForm_Load(object sender, EventArgs e)
        {

        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            //using (FolderBrowserDialog fbd = new FolderBrowserDialog() { Description = "Select your path." })
            //{
            //    if (fbd.ShowDialog() == DialogResult.OK)
            //    {
            //        webBrowser1.Url = new Uri(fbd.SelectedPath);
            //        textBox1.Text = fbd.SelectedPath;
            //    }
            //}
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

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
           
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            tempath = webBrowser1.Url.ToString();
            pathclean();
            textBox1.Text = tempath;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MapManager.map.loadSer(tempath + @"\");
            this.Close();

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
                String str =
                tempath = tempath.Replace("/", @"\");
            }
        }
    }
}
