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
    public partial class Form10 : Form
    {
        MySqlConnection connection;
       
        public Form10()
        {
            InitializeComponent();

            String server = "localhost";
            String database = "digidatabase";
            String uid = "root";
            String password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);
            
            display();
            textBox1.Text = DateTime.Now.ToString();
        }
        public void display()
        {
            connection.Open();
            string CmdString = "SELECT * FROM digidatabase.tablemaster";
            MySqlDataAdapter sda = new MySqlDataAdapter(CmdString, connection);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            connection.Close();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
           
        }

        public void clear()
        {
            textBox4.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                
                MessageBox.Show("hi");
                connection.Open();
                MessageBox.Show("hi2");
                // string query = "INSERT INTO student (id,name,con) VALUES("+ textBox1.Text+"+'"+ textBox2.Text +"'+"+ textBox3.Text +")";
                // string query = "UPDATE student SET id=100,name='" + textBox2.Text + "' WHERE id=" + textBox1.Text;
                string query = "insert into digidatabase.tablemaster values(" + textBox2.Text + "," + textBox3.Text + "," + textBox4.Text + ");";
                                                                           
              //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();
                connection.Close();

                clear();
                MessageBox.Show("added");
            }
            catch (Exception e15)
            {
                MessageBox.Show("error");
                connection.Close();
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                
                connection.Open();
                string query = "DELETE FROM digidatabase.tablemaster  WHERE table_id=" + textBox2.Text;

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();

                connection.Close();

                clear();
                MessageBox.Show("This Record is Deleted....");
            }
            catch (Exception e16)
            {
                MessageBox.Show("error");

                connection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }
    }
}
