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
    public partial class cashier : Form
    {
        MySqlConnection connection;
        int second = 0;
        public cashier()
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            currentorder co = new currentorder();
            co.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            customer c = new customer();
            c.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Billing b = new Billing();
            b.Show();
        }

        private void cashier_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Start(); 
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            second = second + 1;
            if (second >= 2)
            {
           

                textBox1.Text = DateTime.Now.ToString();
            }
        
        }

        private void button10_Click(object sender, EventArgs e)
        {
            usermanual um = new usermanual();
            um.Show();
        }
    }
}
