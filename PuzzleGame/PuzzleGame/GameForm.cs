using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzleGame
{
    public partial class GameForm : Form
    {
        List<PictureBox> pictures = new List<PictureBox>();
        string path = @"D:\Projects\Csharp\PuzzleGame\Images\image1\image1-";
        private Point MouseDownLocation;

        public GameForm()
        {
            InitializeComponent();
            getImages();
        }

        void getImages()
        {
            pictures.Add(pictureBox1);
            pictures.Add(pictureBox2);
            pictures.Add(pictureBox3);
            pictures.Add(pictureBox4);
            pictures.Add(pictureBox5);
            pictures.Add(pictureBox6);
            pictures.Add(pictureBox7);
            pictures.Add(pictureBox8);
            pictures.Add(pictureBox9);

            for (int i = 0; i < 9; i++)
            {
                pictures[i].SizeMode = PictureBoxSizeMode.StretchImage;
                pictures[i].Image = Image.FromFile(path + i + ".jpeg");
            }
        }

        void shuffleImages()
        {
            Random rand = new Random();
            var vizited = new List<int>(8);
            int j = rand.Next(0, 8);

            for (int i = 0; i < 9; i++)
            {
                while (FindNumber(j, vizited))
                {
                    j = rand.Next(0, 9);
                }
                vizited.Add(j);
                pictures[i].Image = Image.FromFile(path + j + ".jpeg");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            shuffleImages();
        }

        bool FindNumber(int x, List<int> array)
        {
            foreach (int k in array)
                if (k == x)
                    return true;
            return false;
        }
    }
}
