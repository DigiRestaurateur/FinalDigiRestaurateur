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
    public partial class customer : Form
    {
        MySqlConnection connection;
        public static string deltcust = "";
        int second = 0;
        public customer()
        {
            InitializeComponent();
            String server = "192.168.0.65";
            String database = "digidatabase";
            String uid = "ADMINISTRATOR";
            String password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);

            displayCustomers();
            textBox1.Text = DateTime.Now.ToString();
        }
        public void displayCustomers()
        {
            try
            {
                connection.Open();
             //   string CmdString = "SELECT cust_id,cust_name,cust_contact,user_count,user_feedback FROM digidatabase.customertable,digidatabase.userinfo where customertable.cust_id=userinfo.user_id";
                string CmdString = "SELECT * FROM digidatabase.customertable";
                MySqlDataAdapter sda = new MySqlDataAdapter(CmdString, connection);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0].DefaultView;

                string CmdString1 = "SELECT * FROM digidatabase.userinfo";
                MySqlDataAdapter sda1 = new MySqlDataAdapter(CmdString1, connection);
                DataSet ds1 = new DataSet();
                sda1.Fill(ds1);
                dataGridView2.DataSource = ds1.Tables[0].DefaultView;
             
                
                connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(""+e);
            }
        }
        private void customer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'digidatabaseDataSet5.customertable' table. You can move, or remove it, as needed.



            timer1.Interval = 1000;
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                string query = "delete  from customertable where cust_id=" + deltcust + "";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();

                string query2 = "delete  from userinfo where user_id=" + deltcust + "";

                MySqlCommand cmd2 = new MySqlCommand(query2, connection);
                cmd2.ExecuteNonQuery();
                connection.Close();
                displayCustomers();
                MessageBox.Show("This record Deleted....");

            }
            catch (Exception e4)
            {
                MessageBox.Show("error");
                connection.Close();
            }
        

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1[1, e.RowIndex].Value.ToString() != "M")
            {

                dataGridView1[0, e.RowIndex].Value = true;


                string row = dataGridView1[1, e.RowIndex].Value.ToString();
              
                deltcust = row.ToString();
                 displayCustomers();
                //  dataGridView1[1, e.RowIndex].Value = true;
            }
            else
            {
                MessageBox.Show("Error");
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            second = second + 1;
            if (second >= 2)
            {
                displayCustomers();

                textBox1.Text = DateTime.Now.ToString();

            }
        }

       }
}
