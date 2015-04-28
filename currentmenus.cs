using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Digiadministrator
{
    public partial class currentmenus : Form
    {
        
        MySqlConnection connection;
        int second = 0;
        public currentmenus()
        {
            InitializeComponent();
            String server = "192.168.0.65";
            String database = "digidatabase";
            String uid = "ADMINISTRATOR";;
            String password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);
            displayCurrentMenu();
            textBox1.Text = DateTime.Now.ToString();
        }
        public void displayCurrentMenu()
        {
           connection.Open();
            string CmdString = "SELECT * FROM digidatabase.itemtable where item_status ='Available'";
            MySqlDataAdapter sda = new MySqlDataAdapter(CmdString, connection);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            connection.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1[6, e.RowIndex].Value.ToString() == "Available")
            {
                dataGridView1[6, e.RowIndex].Value = "Not Available";
                dataGridView1[0, e.RowIndex].Value = true;

                string status = "Not Available";
                string row = dataGridView1[1, e.RowIndex].Value.ToString();
                connection.Open();
                string query = "UPDATE digidatabase.itemtable SET item_status='" + status + "' WHERE item_id=" + row;

                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();
                connection.Close();


            }
            else
            {
                dataGridView1[0, e.RowIndex].Value = false;
                dataGridView1[6, e.RowIndex].Value = "Available";

                string status = "Available";
                string row = dataGridView1[1, e.RowIndex].Value.ToString();
                connection.Open();
                string query = "UPDATE digidatabase.itemtable SET item_status='" + status + "' WHERE item_id=" + row;

                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            displayCurrentMenu();
        }

        private void currentmenus_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Start();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            second = second + 1;
            if (second >= 2)
            {
                displayCurrentMenu();

                textBox1.Text = DateTime.Now.ToString();
            }
        }
    }
}
