using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        string path = AppDomain.CurrentDomain.BaseDirectory.Substring(0, AppDomain.CurrentDomain.BaseDirectory.Length - 11 - System.Reflection.Assembly.GetExecutingAssembly().GetName().Name.Length) + "Img";
        public string userString { get; set; }

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Close();

            loadImages();
        }

        private void loadImages()
        {
            pictureBox1.ImageLocation = path + @"\image1\image.jpg"; // load images to be chosen from
            pictureBox2.ImageLocation = path + @"\image2\image.jpg";
            pictureBox3.ImageLocation = path + @"\image3\image.jpg";
            pictureBox4.ImageLocation = path + @"\image4\image.jpg";
        }
        
        private void nextForm()
        {
            Form4 f4 = new Form4();
            f4.path = path; //pass the path to form4
            f4.userString = userString;
            path = path.Substring(0, path.Length - 8); //reset the path for reusage
            Hide();
            f4.ShowDialog();
            Show();
        }

        //events

        private void pictureBoxDoubleClick(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(((PictureBox)sender).Tag);
            path += @"\image" + i + @"\"; // select the folder containing the chosen image
            nextForm();
        }
    }
}
