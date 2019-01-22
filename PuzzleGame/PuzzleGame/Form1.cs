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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        public bool checkCredentials(string user, string parola)
        {
            if(user == "1" && parola == "1")
            {
                return true;
            }
            else
            {
                TextUsername.Text = string.Empty;
                TextParola.Text = string.Empty;
                return false;
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if(checkCredentials(TextUsername.Text, TextParola.Text))
            {
                GameForm form2 = new GameForm();
                form2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username sau parola incorecta.");
                TextUsername.Text = string.Empty;
                TextParola.Text = string.Empty;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
