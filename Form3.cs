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
    public partial class Form3 : Form
    {
        MySqlConnection connection;
        

        public Form3()
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
            DateTime  dt=new DateTime();
             
            textBox1.Text = DateTime.Now.Hour.ToString () ;
             
        }
        public void display()
        {
            connection.Open();
            string CmdString = "SELECT * FROM digidatabase.itemtable";
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
           
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //CheckBox c = new CheckBox();
          //  if (dataGridView1)
            //{ MessageBox.Show("hi"); }
            //else { MessageBox.Show("dfgdfghi"); }
        }

        private void chkItems_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[1];
                if (chk.Value == chk.TrueValue)
                {
                    MessageBox.Show("hi");
                    chk.Value = chk.FalseValue;
                }
                else
                {
                    MessageBox.Show("hello");
                    chk.Value = chk.TrueValue;
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        
    }
}
