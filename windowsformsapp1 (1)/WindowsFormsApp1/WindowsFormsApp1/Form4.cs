using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private Point MouseDownLocation;
        public string path { get; set; }
        List<PictureBox> pictures = new List<PictureBox>();
        Stopwatch watch = new Stopwatch();

        private void Form4_Load(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Close();
            loadImages();
        }

        void loadImages()
        {
            pictures.Add(pictureBox10);
            pictures.Add(pictureBox1);
            pictures.Add(pictureBox2);
            pictures.Add(pictureBox3);
            pictures.Add(pictureBox4);
            pictures.Add(pictureBox5);
            pictures.Add(pictureBox6);
            pictures.Add(pictureBox7);
            pictures.Add(pictureBox8);
            pictures.Add(pictureBox9);

            Random rand = new Random();
            var randomList = new List<int>(9) { 1, 2, 3, 4, 5, 6, 7, 8, 9};

            for(int i = 7; i > 1; i--)
            {
                int x = rand.Next(0, i);
                int temp = randomList[i];
                randomList[i] = randomList[x];
                randomList[x] = temp;
            }
            for (int i = 1; i < 10; i++)
            {
                pictures[i].ImageLocation = path + "image  (" + randomList[i - 1] + ").jpeg";
                pictures[i].Tag = i;
            }
        }

        private void swapPictures(int a, int b)
        {
            var temp = pictures[a].ImageLocation;
            pictures[a].ImageLocation = pictures[b].ImageLocation;
            pictures[b].ImageLocation = temp;
        }

        private void swapPicture(int a)
        {
            if (pictures[a].Top + pictureBox1.Height / 2 < (this.Height - 20) / 3 && pictures[a].Left + pictureBox1.Width / 2 < this.Width / 3)
            {
                swapPictures(a, 1);
            }
            else if (pictures[a].Top + pictureBox1.Height / 2 < (this.Height - 20) / 3 && pictures[a].Left + pictureBox1.Width / 2 < this.Width / 3 * 2)
            {
                swapPictures(a, 2);
            }
            else if (pictures[a].Top + pictureBox1.Height / 2 < (this.Height - 20) / 3 && pictures[a].Left + pictureBox1.Width / 2 > this.Width / 3 * 2)
            {
                swapPictures(a, 3);
            }
            else if (pictures[a].Top + pictureBox1.Height / 2 < (this.Height - 20) / 3 * 2 && pictures[a].Left + pictureBox1.Width / 2 < this.Width / 3)
            {
                swapPictures(a, 4);
            }
            else if (pictures[a].Top + pictureBox1.Height / 2 < (this.Height - 20) / 3 * 2 && pictures[a].Left + pictureBox1.Width / 2 < this.Width / 3 * 2)
            {
                swapPictures(a, 5);
            }
            else if (pictures[a].Top + pictureBox1.Height / 2 < (this.Height - 20) / 3 * 2 && pictures[a].Left + pictureBox1.Width / 2 > this.Width / 3 * 2)
            {
                swapPictures(a, 6);
            }
            else if (pictures[a].Top + pictureBox1.Height / 2 > (this.Height - 20) / 3 * 2 && pictures[a].Left + pictureBox1.Width / 2 < this.Width / 3)
            {
                swapPictures(a, 7);
            }
            else if (pictures[a].Top + pictureBox1.Height / 2 > (this.Height - 20) / 3 * 2 && pictures[a].Left + pictureBox1.Width / 2 < this.Width / 3 * 2)
            {
                swapPictures(a, 8);
            }
            else if (pictures[a].Top + pictureBox1.Height / 2 > (this.Height - 20) / 3 * 2 && pictures[a].Left + pictureBox1.Width / 2 > this.Width / 3 * 2)
            {
                swapPictures(a, 9);
            }
            int[] x = new int[] {0, 0, 271, 542, 0, 271, 542, 0, 271, 542};
            int[] y = new int[] {0, 0, 0, 0, 156, 156, 156, 312, 312, 312};
            pictures[a].Left = x[a];
            pictures[a].Top = y[a];
        }

        private void isSolved()
        {
            if (pictureBox1.ImageLocation == path + "image  (1).jpeg" &&
                pictureBox2.ImageLocation == path + "image  (2).jpeg" &&
                pictureBox3.ImageLocation == path + "image  (3).jpeg" &&
                pictureBox4.ImageLocation == path + "image  (4).jpeg" &&
                pictureBox5.ImageLocation == path + "image  (5).jpeg" &&
                pictureBox6.ImageLocation == path + "image  (6).jpeg" &&
                pictureBox7.ImageLocation == path + "image  (7).jpeg" &&
                pictureBox8.ImageLocation == path + "image  (8).jpeg" &&
                pictureBox9.ImageLocation == path + "image  (9).jpeg")
            {
                watch.Stop();
                var time = watch.Elapsed;
                MessageBox.Show(time.ToString());
            }
        }


        //==========================================================================
        
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            var i = (PictureBox)sender;
            MouseDownLocation = e.Location;
            pictureBox10.Visible = true;
            pictureBox10.ImageLocation = pictures[Convert.ToInt32(i.Tag)].ImageLocation;
            pictureBox10.Top = pictures[Convert.ToInt32(i.Tag)].Top;
            pictureBox10.Left = pictures[Convert.ToInt32(i.Tag)].Left;
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                var i = (PictureBox)sender;
                pictures[Convert.ToInt32(i.Tag)].Left = e.X + pictures[Convert.ToInt32(i.Tag)].Left - MouseDownLocation.X;
                pictures[Convert.ToInt32(i.Tag)].Top = e.Y + pictures[Convert.ToInt32(i.Tag)].Top - MouseDownLocation.Y;
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                var i = (PictureBox)sender;
                swapPicture(Convert.ToInt32(i.Tag));
                pictureBox10.Visible = false;
            }
            if (!watch.IsRunning)
                watch.Start();
            else
                isSolved();
        }
    }
}
