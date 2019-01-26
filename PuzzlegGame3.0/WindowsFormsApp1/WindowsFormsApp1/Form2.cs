using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public static string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\obi1\Documents\Inregistrari.mdf;Integrated Security=True;Connect Timeout=30";
        string userString;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            userString = userName.Text;

            Form3 f3 = new Form3();
            f3.userString = userString;

            Hide();
            f3.ShowDialog();
            Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
