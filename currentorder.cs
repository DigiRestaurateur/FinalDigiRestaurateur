using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using MySql.Data.MySqlClient;
using System.Threading;
namespace Digiadministrator
{
    public partial class currentorder : Form
    {

        MySqlConnection connection;
        int second = 0;
        public currentorder()
        {
            InitializeComponent();
            String server = "192.168.0.65";
            String database = "digidatabase";
            String uid = "ADMINISTRATOR";;
            String password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);
            textBox1.Text = DateTime.Now.ToString();
            displayCurrentOrder();
        }
        public void displayCurrentOrder()
        {
            connection.Open();
            string CmdString = "SELECT * FROM digidatabase.ordertable where order_status='Pending'";
            MySqlDataAdapter sda = new MySqlDataAdapter(CmdString, connection);
            DataSet ds = new DataSet();
            sda.Fill(ds);
           
           // dataGridView1.DataSource = ds.Tables[0].Rows.Add(sda.+DateTime.Now.ToString());
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            connection.Close();
          
            /*connection.Open();
         
            

            string CmdString = "SELECT * FROM digidatabase.ordertable where order_id=0 group by table_id";
            MySqlDataAdapter sda = new MySqlDataAdapter(CmdString, connection);
            DataSet ds = new DataSet();
            sda.Fill(ds,"ordertable");
            
             if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
           MessageBox.Show(""+ds.Tables[0].Rows[i][0].ToString()+""+ds.Tables[0].Rows[i][1].ToString());
           String abc = ds.Tables[0].Rows[i][0].ToString();
           String pqr = ds.Tables[0].Rows[i][1].ToString();

           string CmdString4 = "SELECT MAX(order_id) FROM digidatabase.ordertable group by table_id";



           MySqlCommand cm = new MySqlCommand();
           //Assign the query using CommandText
           cm.CommandText = CmdString4;
           //Assign the connection using Connection
           cm.Connection = connection;
           //Execute query
           //  cmd.ExecuteNonQuery();

           int maxId = Convert.ToInt32(cm.ExecuteScalar());
           MessageBox.Show("max" + maxId); 
                        
                        int pqrr = maxId + 10;
         int abcc=Int32.Parse(abc);
           string query = "update digidatabase.ordertable set order_id=" + pqrr + " where table_id=" + pqr + " and order_id=0";
  MessageBox.Show("hhello"+abcc+"/"+pqr+"*"+pqrr);//create mysql command
           MySqlCommand cmd1 = new MySqlCommand();
           //Assign the query using CommandText
           cmd1.CommandText = query;
           //Assign the connection using Connection
           cmd1.Connection = connection;
           //Execute query
           cmd1.ExecuteNonQuery();
                    }
                } 
       

            
          
            connection.Close();
                connection.Open();
                string CmdString1 = "SELECT * FROM digidatabase.ordertable where order_status='Pending'";
                MySqlDataAdapter sda1 = new MySqlDataAdapter(CmdString1, connection);
                DataSet ds1 = new DataSet();
                sda1.Fill(ds1);
                dataGridView1.DataSource = ds1.Tables[0].DefaultView;
                connection.Close();
        */
        }
        private void currentorder_Load(object sender, EventArgs e)
        {
           
           
           timer1.Interval = 1000;
          timer1.Start();
         }
        
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1[9, e.RowIndex].Value.ToString() == "Pending")
            {
                dataGridView1[9, e.RowIndex].Value = "Billing";
                dataGridView1[0, e.RowIndex].Value = true;
               
                string status = "Billing";
                string row = dataGridView1[3, e.RowIndex].Value.ToString();
                string row3 = dataGridView1[1, e.RowIndex].Value.ToString();
                connection.Open();
                string query = "UPDATE digidatabase.ordertable SET order_status='" + status + "' WHERE order_itid=" + row + " AND order_id=" + row3;

                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();
                connection.Close();
                displayCurrentOrder();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {displayCurrentOrder();
            /*connection.Open();
            string CmdString = "SELECT MAX(order_id) FROM digidatabase.ordertable group by table_id";
           


             MySqlCommand cmd = new MySqlCommand();
             //Assign the query using CommandText
             cmd.CommandText = CmdString;
             //Assign the connection using Connection
             cmd.Connection = connection;
             //Execute query
           //  cmd.ExecuteNonQuery();

             int maxId = Convert.ToInt32(cmd.ExecuteScalar());
             MessageBox.Show(""+maxId);
            connection.Close();
       */ }

        private void timer1_Tick(object sender, EventArgs e)
        {
            second = second + 1;
            if (second >= 4)
            {
                displayCurrentOrder();

                textBox1.Text = DateTime.Now.ToString();

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
//

// down vote
	

//ExecuteScalar() only returns the value from the first column of the first row of your query.
//ExecuteReader() returns an object that can iterate over the entire result set.
//ExecuteNonQuery() does not return data at all: only the number of rows affected by an insert, update, or delete. 