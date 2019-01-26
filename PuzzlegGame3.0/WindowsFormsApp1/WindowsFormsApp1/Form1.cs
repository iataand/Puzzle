using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //sterge asta daca vr sa nu sara la form2
            Form2 f2 = new Form2();
            Hide();
            f2.ShowDialog();
            Close();
            //
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "jucator" && textBox2.Text == "jucator")
            {
                Form2 f2 = new Form2();
                Hide();
                f2.ShowDialog();
                Show();
            }
            else if (textBox1.Text == "administrator" && textBox2.Text == "administrator")
            {
                MessageBox.Show("");
            }
            else
                MessageBox.Show("Utilizator sau parola incorecte");
        }
    }
}
