using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;



//Data Source=RAHUL-PC;Initial Catalog=Digidatabase;Persist Security Info=True;User ID=sa;Password=123
namespace Digiadministrator
{
    public partial class Login : Form
    {
        MySqlConnection connection;
        //MySqlBackup mb;
        String username;
        int second = 0;
        
        public Login()
        {
            InitializeComponent();
            try
            {
//                String server = "192.168.173.1";
                String server = "192.168.0.65";
            //    String server = "192.168.0.65";
                String Port = "3306";
                String database = "digidatabase";
               // String uid = "ADMINISTRATOR";
                String uid = "ADMINISTRATOR";
                String password = "";
                string connectionString;
                connectionString = "SERVER=" + server + ";" + "PORT=" + Port + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
             //   connectionString = "server=192.168.0.65;database=digidatabase;uid=root;password="+password;
                connection = new MySqlConnection(connectionString);
                
            }
            catch (Exception r)
            {
                MessageBox.Show(""+r);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Start();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string user1 = "ADMINISTRATOR";
            string user2 = "CHEF";
            string user3 = "CASHIER";
            string type = "";
             connection.Open();          
            string CmdString = "select * from digidatabase.users where user_name='" + txtLName.Text + "' and user_password='" + txtLPassword.Text + "'";
            MySqlDataAdapter sda = new MySqlDataAdapter(CmdString, connection);
            DataSet ds = new DataSet();
            sda.Fill(ds, "users");
            if (ds.Tables[0].Rows.Count > 0)
            {
               type= ds.Tables[0].Rows[0][3].ToString();
              MessageBox.Show("" + type);
              
            }
            else
            {
                MessageBox.Show("Invalid User...");
            }

            connection.Close();
            if (type.ToUpper() == user1)
            {
               
                Dashboard g = new Dashboard();
                
                g.Show();

            }
            else if(type.ToUpper() == user2)
            {

                currentorder co = new currentorder();
                co.Show(); 
            }
            else if (type.ToUpper() == user3)
            {
                cashier c = new cashier();
                c.Show();               
            }
            else
            {
            }
            txtLName.Text = "";
            txtLPassword.Text = "";
            type = "";
            //connection.Open();
            //string CmdString = "select * from login where names='" + textBox1.Text + "' and passwords='" + textBox2.Text + "'";
            //MySqlDataAdapter sda = new MySqlDataAdapter(CmdString, connection);
            //DataSet ds = new DataSet();
            //sda.Fill(ds, "login");
            //if (ds.Tables[0].Rows.Count > 0)
            //{ 
            
            // username=textBox1.Text;
            //MessageBox.Show("Welcome '" + textBox1.Text + "'");
            //if (s == "cashier")
            //{
            //    cashier c = new cashier();
            //    c.Show();
            //    textBox1.Text = "";
            //    textBox2.Text = "";
            //    this.Hide();
            //}
            //else if (s == "Admin")
            //{
            //    Dashboard g = new Dashboard();
            //    g.Show();


            //    textBox1.Text = "";
            //    textBox2.Text = "";
            //    this.Hide();
            //}
            //}
            //else
            //{
            //    MessageBox.Show("You entered wrong username or password..");

            //    textBox1.Text = "";
            //    textBox2.Text = "";
            //}
            //con.Close();
           
               }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void Exit_Click_1(object sender, EventArgs e)
        {
            //Backup();
          //  MessageBox.Show("Good");
            this.Close();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("" + DateTime.Now.ToString());
            
           

        }

       

        private void timer1_Tick(object sender, EventArgs e)
        {
            second = second + 1;
            if (second >= 2)
            {
               // timer1.Stop();
              //  MessageBox.Show("Exiting from Timer....");



            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            

        }
        /*
        private void Backup()
        {
            string constring = "server=localhost;user=root;pwd=root;database=digidatabase;";
            string file = "C:\\backup.sql";
            using (MySqlConnection conn = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    mb = new MySqlBackup(cmd);
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        mb.ExportToFile(file);
                        conn.Close();
                    }
                }
            }
        }*/
        
        

    }
}
