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
using System.Data.SqlClient;
using System.IO;

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
        public string userString { get; set; }       //gets the username from form2
        public string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\obi1\Documents\Inregistrari.mdf;Integrated Security=True;Connect Timeout=30";
       
        List<PictureBox> pictures = new List<PictureBox>();
        Stopwatch watch = new Stopwatch();

        private void Form4_Load(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Close();
            loadImages();
            //button1.Visible = false;
        }

        private void loadImages()
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
            pictures.Add(pictureBox9); //adds all the pictureboxes to a collection

            Random rand = new Random();
            List<int> randomList = new List<int>(10) {0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            for (int i = 9; i > 2; i--)
            {
                int x = rand.Next(1, i);
                int temp = randomList[i];
                randomList[i] = randomList[x];
                randomList[x] = temp; //creates a random order for the images to be arranged
            }
            for (int i = 1; i < 10; i++)
            {
                pictures[i].ImageLocation = path + "image (" + randomList[i] + ").jpeg"; //sets each image to its picturebox using the orderlist created above
            }
        }

        private void swapPictures(int a, int b)
        {
            string temp = pictures[a].ImageLocation;
            pictures[a].ImageLocation = pictures[b].ImageLocation;
            pictures[b].ImageLocation = temp;//swaps the image displayed in the picturebox grabbed(a) and the image in the picturebox the first was released over(b)
        }

        private void swapPicture(int a)
        {
            if (pictures[a].Top + (pictures[0].Height / 2) < 156 &&
                pictures[a].Left + (pictures[0].Width / 2) < 271)
            {
                swapPictures(a, 1); //the picturebox being moved was realeased over the top-left picturebox
            }
            else if (pictures[a].Top + (pictures[0].Height / 2) < 156 &&
                    pictures[a].Left + (pictures[0].Width / 2) < 542)
            {
                swapPictures(a, 2); //the picturebox being moved was realeased over the top-middle picturebox
            }
            else if (pictures[a].Top + (pictures[0].Height / 2) < 156 &&
                    pictures[a].Left + (pictures[0].Width / 2) > 542)
            {
                swapPictures(a, 3); //the picturebox being moved was realeased over the top-right picturebox
            }
            else if (pictures[a].Top + (pictures[0].Height / 2) < 312 &&
                    pictures[a].Left + (pictures[0].Width / 2) < 271)
            {
                swapPictures(a, 4); //the picturebox being moved was realeased over the middle-left picturebox
            }
            else if (pictures[a].Top + (pictures[0].Height / 2) < 312 &&
                    pictures[a].Left + (pictures[0].Width / 2) < 542)
            {
                swapPictures(a, 5); //the picturebox being moved was realeased over the center picturebox
            }
            else if (pictures[a].Top + (pictures[0].Height / 2) < 312 &&
                    pictures[a].Left + (pictures[0].Width / 2) > 542)
            {
                swapPictures(a, 6); //the picturebox being moved was realeased over the middle-right picturebox
            }
            else if (pictures[a].Top + (pictures[0].Height / 2) > 312 &&
                    pictures[a].Left + (pictures[0].Width / 2) < 271)
            {
                swapPictures(a, 7); //the picturebox being moved was realeased over the bottom-left picturebox
            }
            else if (pictures[a].Top + (pictures[0].Height / 2) > 312 &&
                    pictures[a].Left + (pictures[0].Width / 2) < 542)
            {
                swapPictures(a, 8); //the picturebox being moved was realeased over the bottom-middle picturebox
            }
            else if (pictures[a].Top + (pictures[0].Height / 2) > 312 &&
                    pictures[a].Left + (pictures[0].Width / 2) > 542)
            {
                swapPictures(a, 9); //the picturebox being moved was realeased over the bottom-right picturebox
            }
            int[] x = new int[] { 0, 0, 271, 542, 0, 271, 542, 0, 271, 542 };
            int[] y = new int[] { 0, 0, 0, 0, 156, 156, 156, 312, 312, 312 };
            pictures[a].Left = x[a];
            pictures[a].Top = y[a]; //places the grabbed picturebox to its initial place
        }

        private bool match()
        {
            for (int i = 1; i < 10; i++)
            {
                if(pictures[i].ImageLocation != path + "image (" + i + ").jpeg") //checks if every image is in its place
                {
                    return false;
                }
            }
            return true;
        }

        private void submit(TimeSpan time)
        {
            //to add
            MessageBox.Show(time.ToString());

            SqlConnection con = new SqlConnection(conString);
            con.Open();

            using (SqlCommand cmd = new SqlCommand("INSERT INTO Clasament(Name, Time) values(@user, @time)", con))    //Inserts the name in the TextBox into the database
            {
                cmd.Parameters.AddWithValue("user", userString);
                cmd.Parameters.AddWithValue("time", time);
                cmd.ExecuteNonQuery();
            }
            con.Close();
        }

        //events

        private void pictureBoxGrabbed(object sender, MouseEventArgs e)
        {
            int i = Convert.ToInt32(((PictureBox)sender).Tag);
            MouseDownLocation = e.Location; // saves the position of the mouse relative to the corner of the picturebox
            pictures[0].Visible = true;
            pictures[0].ImageLocation = pictures[i].ImageLocation; //sets the picturebox to display the picturebox that's being moved
        }

        private void pictureBoxMoved(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int i = Convert.ToInt32(((PictureBox)sender).Tag);
                pictures[i].Left = e.X + pictures[i].Left - MouseDownLocation.X; // constantly moves the picturebox so that the mouse is in the same place 
                pictures[i].Top = e.Y + pictures[i].Top - MouseDownLocation.Y; //relative to the corner of the picture box as to when it was grabbed
                pictures[0].Location = pictures[i].Location; //places another picturebox on top so that it is displayed on the layer above all other pictureboxes
            }
        }

        private void pictureBoxReleased(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int i = Convert.ToInt32(((PictureBox)sender).Tag);
                swapPicture(i); //swaps the picturebox grabbed and the one over which it was released
                pictures[0].Visible = false; //sets the picturebox placed on top of the one being moved to be invisibile

                if (!watch.IsRunning)
                {
                    watch.Start(); //on the first move, the timer starts
                }
                else if (match()) // checks if the puzzle is complete
                {
                    watch.Stop();
                    TimeSpan time = watch.Elapsed;
                    submit(time);
                }
            }
        }

        private void button1Click(object sender, EventArgs e)
        {
            for (int i = 1; i < 10; i++)
            {
                pictures[i].ImageLocation = path + "image (" + i + ").jpeg"; //solves the puzzle
            }

            Random rand = new Random();
            TimeSpan time = new TimeSpan(0, 0, 0, 0, rand.Next(5000 ,10000)); //generates a random time duration
            submit(time);

        }
    }
}
