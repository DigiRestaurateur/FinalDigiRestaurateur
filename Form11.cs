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
       
        public customer()
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
            try
            {
                connection.Open();
                string CmdString = "SELECT * FROM digidatabase.customertable";
                MySqlDataAdapter sda = new MySqlDataAdapter(CmdString, connection);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
                connection.Close();
            }
            catch (Exception)
            {

            }
        }
        private void customer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'digidatabaseDataSet5.customertable' table. You can move, or remove it, as needed.
           

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns[2], ListSortDirection.Ascending);


        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
