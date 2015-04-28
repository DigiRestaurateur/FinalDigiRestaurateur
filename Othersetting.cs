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
    public partial class Othersetting : Form
    {
        MySqlConnection connection;
        int second = 0;
        public Othersetting()
        {
            InitializeComponent();

            String server = "192.168.0.65";
            String database = "digidatabase";
            String uid = "ADMINISTRATOR";;
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
            timer1.Interval = 1000;
            timer1.Start(); 
        }

        public void clear()
        {
            txtWaiterId.Text = "";
            txtTableId.Text = "";
            txtTabletId.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                
                
                connection.Open();
                
                // string query = "INSERT INTO student (id,name,con) VALUES("+ textBox1.Text+"+'"+ textBox2.Text +"'+"+ textBox3.Text +")";
                // string query = "UPDATE student SET id=100,name='" + textBox2.Text + "' WHERE id=" + textBox1.Text;
                string query = "insert into digidatabase.tablemaster values(" + txtTableId.Text + ",'" + txtTabletId.Text + "'," + txtWaiterId.Text + ");";
                                                                           
              //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();
                connection.Close();

                clear();
                MessageBox.Show("added");
                display();
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
                string query = "DELETE FROM digidatabase.tablemaster  WHERE table_id=" + txtTableId.Text;

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();

                connection.Close();

                clear();
                MessageBox.Show("This Record is Deleted....");
                display();
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
            
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            try
            {

                //   connection.Open();
                string CmdString = "select * from digidatabase.tablemaster where table_id=" + txtTableId.Text + "";
                MySqlDataAdapter sda = new MySqlDataAdapter(CmdString, connection);
                DataSet ds = new DataSet();
                sda.Fill(ds, "tablemaster");


                txtTableId.Text = ds.Tables[0].Rows[0][0].ToString();
                txtTabletId.Text = ds.Tables[0].Rows[0][1].ToString();
                txtWaiterId.Text = ds.Tables[0].Rows[0][2].ToString();
               


                connection.Close();
            }
            catch (Exception t)
            {
                MessageBox.Show("Wrong Table Number");
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                string query = "update digidatabase.tablemaster set table_id=" + txtTableId.Text + ",tab_id='" + txtTabletId.Text + "',waiter_id=" + txtWaiterId.Text + " where table_id=" + txtTableId.Text + "";

                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;
                //Execute query
                cmd.ExecuteNonQuery();
                connection.Close();
                clear();
                MessageBox.Show("This record updated....");
                display();
               
            }
            catch (Exception e3)
            {
                MessageBox.Show("error");
                connection.Close();
            }
       
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            second = second + 1;
            if (second >= 2)
            {
                

                textBox1.Text = DateTime.Now.ToString();
            }
        }
    }
}
