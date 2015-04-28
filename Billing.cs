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
    public partial class Billing : Form
    {
        MySqlConnection connection;
        public static int bilid = 0;
        public static int orderid = 0;
        int second = 0;
        public Billing()
        {
            InitializeComponent();
            String server = "192.168.0.65";
            String database = "digidatabase";
            String uid = "ADMINISTRATOR";;
            String password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);
            displayCurrentOrder(); 
        }
        public void displayCurrentOrder()
        {
            connection.Open();
            string CmdString = "SELECT cust_name,order_id,table_id,order_itid,order_item,order_price,order_quantity,order_ototal,order_status FROM digidatabase.ordertable,digidatabase.customertable where customertable.cust_id=ordertable.order_id AND ordertable.order_status='Billing' GROUP BY ordertable.order_id";
            MySqlDataAdapter sda = new MySqlDataAdapter(CmdString, connection);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            connection.Close();
         
          
           }
       
        private void button3_Click(object sender, EventArgs e)
        {
          




            Billprint bp = new Billprint(bilid,orderid);
            bp.Show();
        }

        private void Billing_Load(object sender, EventArgs e)
        {
            
            timer1.Interval = 1000;
            timer1.Start();
        }
    
        

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1[9, e.RowIndex].Value.ToString() == "Billing")
            {
                connection.Open();
                dataGridView1[9, e.RowIndex].Value = "Billing";
                dataGridView1[0, e.RowIndex].Value = true;
                  string status = "Billing";
                string row = dataGridView1[2, e.RowIndex].Value.ToString();
                string row1 = dataGridView1[4, e.RowIndex].Value.ToString();
                 bilid = int.Parse(row);
                orderid = int.Parse(row1);
                
                string query = "UPDATE digidatabase.ordertable SET order_status='" + status + "' WHERE order_itid=" + row1 + " AND ordertable.order_id=" + row;

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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            second = second + 1;
            if (second >= 5)
            {
                displayCurrentOrder();

                textBox1.Text = DateTime.Now.ToString();
            }
        }
    }
}
