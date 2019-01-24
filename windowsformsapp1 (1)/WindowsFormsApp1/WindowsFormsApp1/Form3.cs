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
        string path = @"C:\Users\obi1\Desktop\windowsformsapp1 (1)\WindowsFormsApp1\Img";
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Close();

            path = @"C:\Users\obi1\Desktop\windowsformsapp1 (1)\WindowsFormsApp1\Img\image1\";
            Form4 f4 = new Form4();
            f4.path = path;
            this.Hide();
            f4.ShowDialog();
            this.Close();


            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    path = fbd.SelectedPath;
                    pictureBox1.ImageLocation = path + "\\image1\\image.jpg";
                    pictureBox2.ImageLocation = path + "\\image2\\image.jpg";
                    pictureBox3.ImageLocation = path + "\\image3\\image.jpg";
                    pictureBox4.ImageLocation = path + "\\image5\\image.jpg";



                }
            }
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            path += @"\image1\";
            nextForm();
        }

        private void pictureBox2_DoubleClick(object sender, EventArgs e)
        {
            path += @"\image2\";
            nextForm();
        }

        private void pictureBox3_DoubleClick(object sender, EventArgs e)
        {
            path += @"\image3\";
            nextForm();
        }

        private void pictureBox4_DoubleClick(object sender, EventArgs e)
        {
            path += @"\image5\";
            nextForm();
        }

        private void nextForm()
        {
            Form4 f4 = new Form4();
            f4.path = path;
            this.Hide();
            f4.ShowDialog();
            this.Close();
        }
    }
}
