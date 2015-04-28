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
    public partial class todaysspecial : Form
    {
        MySqlConnection connection;
        int second = 0;
        public todaysspecial()
        {
       
            InitializeComponent();
            String server = "192.168.0.65";
            String database = "digidatabase";
            String uid = "ADMINISTRATOR";;
            String password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                string query1 = "delete from special";

                MySqlCommand cmd = new MySqlCommand(query1, connection);
                cmd.ExecuteNonQuery();
                String offr = richTextBox1.Text;
                offr=offr.Replace(" ","_");
            
                string query = "insert into special values('" + offr + "')";
                //  string query = "insert into itemtable values(7,10,'m',50,'a','a');";
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd1 = new MySqlCommand(query, connection);
                //Execute command
                cmd1.ExecuteNonQuery();
                richTextBox1.Text = "";
                MessageBox.Show("This Offer Added....");
                connection.Close();    
            }
            catch (Exception e3)
            {
                MessageBox.Show("error");
                connection.Close();
            }
        
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            second = second + 1;
            if (second >= 2)
            {
                

                textBox1.Text = DateTime.Now.ToString();
            }
        }

        private void todaysspecial_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Start();
        }
    }
}
