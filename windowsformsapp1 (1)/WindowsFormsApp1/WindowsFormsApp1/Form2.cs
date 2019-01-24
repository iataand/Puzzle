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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Close();

            Form3 f3 = new Form3();
            this.Hide();
            f3.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            this.Hide();
            f3.ShowDialog();
            this.Close();
        }
    }
}
