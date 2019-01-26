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


namespace WindowsFormsApp1
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            populateDataTable();
        }

        void populateDataTable()           // Gets all the rocords from the DataBase
        {
            DataTable clasament;
            const string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\obi1\Documents\Inregistrari.mdf;Integrated Security=True;Connect Timeout=30";
            using(SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("SELECT Name, Time FROM Clasament", conString);
                clasament = new DataTable();
                sqlData.Fill(clasament);
            }
            dataGridView.DataSource = clasament;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
