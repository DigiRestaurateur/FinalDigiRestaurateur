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
    public partial class Viewmenu : Form
    {
        MySqlConnection connection;
        String catid;
        int second = 0;
        DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
        public Viewmenu()
        {
            InitializeComponent();

            String server = "192.168.0.65";
            String database = "digidatabase";
            String uid = "ADMINISTRATOR";;
            String password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);

          
            DateTime  dt=new DateTime();
             
            textBox1.Text = DateTime.Now.Hour.ToString () ;

            loadComboItem();
        }
        public void loadComboItem()
        {
            try
            {
                connection.Open();
                string CmdString = "SELECT * FROM digidatabase.category";
                MySqlDataAdapter sda = new MySqlDataAdapter(CmdString, connection);
                DataSet ds = new DataSet();
                sda.Fill(ds, "category");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        cmbCat.Items.Add(ds.Tables[0].Rows[i][1].ToString());
                    }
                }


                connection.Close();

            }
            catch (Exception e18)
            {
                MessageBox.Show("Error1321321");
                connection.Close();
            }
 
        }
        public void displayItems(String catid)
        {
            connection.Open();
            string CmdString = "SELECT * FROM digidatabase.itemtable where cat_id='" + catid + "'";
            MySqlDataAdapter sda = new MySqlDataAdapter(CmdString, connection);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            connection.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close(); 

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'digidatabaseDataSet.itemtable' table. You can move, or remove it, as needed.
            timer1.Interval = 1000;
            timer1.Start();
            
        }

    
        private void chkItems_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            connection.Open();
            string CmdString = "select cat_id from category where cat_name='" + cmbCat.Text + "'";
            MySqlDataAdapter sda = new MySqlDataAdapter(CmdString, connection);
            DataSet ds = new DataSet();
            sda.Fill(ds, "category");


            if (ds.Tables[0].Rows.Count > 0)
            {
                catid= ds.Tables[0].Rows[0][0].ToString();
            }

            connection.Close();

            displayItems(catid);
        }

        private void button3_Click(object sender, EventArgs e)
        {

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

        private void timer1_Tick(object sender, EventArgs e)
        {
            second = second + 1;
            if (second >= 2)
            {
              

                textBox1.Text = DateTime.Now.ToString();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        
    }
}
