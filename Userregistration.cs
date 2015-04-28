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
    public partial class Userregistration : Form
    {
        MySqlConnection connection;
        int second = 0;
        public static String userid = "";
        private void clear()
        {
            textBox2.Text = "";
            txtUserType.Text = "";
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtEmail.Text = "";
            
            comboBox1.Text = "";
        }
      
        

        public Userregistration()
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
            select2();
            selectcmbo();
            
            
        }
        public void display()
        {
            try
            {
                connection.Open();
                string CmdString = "SELECT * FROM digidatabase.users";
                MySqlDataAdapter sda = new MySqlDataAdapter(CmdString, connection);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
                connection.Close();
            }
            catch (Exception er)
            {connection.Close();
            }
        }
      
        public void selectcmbo()
        {
            try
            {
                connection.Open();
                string CmdString = "SELECT * FROM digidatabase.users";
                MySqlDataAdapter sda = new MySqlDataAdapter(CmdString, connection);
                DataSet ds = new DataSet();
                sda.Fill(ds, "users");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        comboBox1.Items.Add(ds.Tables[0].Rows[i][1].ToString());
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
        public void select2()
        {
            try
            {
                Int16 a = 0;
                connection.Open();
                string CmdString = "select max(user_id) from digidatabase.users";
                MySqlDataAdapter sda = new MySqlDataAdapter(CmdString, connection);
                DataSet ds = new DataSet();
                sda.Fill(ds, "users");
               
                if (ds.Tables[0].Rows.Count > 0)
                {
                    textBox2.Text = ds.Tables[0].Rows[0][0].ToString();
                    a = Int16.Parse(textBox2.Text);
                    textBox2.Text = (a + 1).ToString();
                }
                userid = (a + 1).ToString();
                connection.Close();
                
            }
            catch (Exception e2)
            {
                MessageBox.Show("error");
                connection.Close();
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            textBox2.Enabled = false;
            timer1.Interval = 1000;
            timer1.Start(); 
             }

        private void button6_Click(object sender, EventArgs e)
        {
            groupBox1.Show();

            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                string user1 = "ADMINISTRATOR";
                string type = "";
            
                connection.Open();
                string CmdString = "select * from digidatabase.users where user_name='" + txtLoginName.Text + "' and user_password='" + txtLoginPassword.Text + "'";
                MySqlDataAdapter sda = new MySqlDataAdapter(CmdString, connection);
                DataSet ds = new DataSet();
                sda.Fill(ds, "users");
               if (ds.Tables[0].Rows.Count > 0)
               {
                   type = ds.Tables[0].Rows[0][3].ToString();
                   
                    txtLoginName.Text = "";
                    txtLoginPassword.Text = "";
                    groupBox1.Hide();
                }
                else
                {
                    MessageBox.Show("You entered wrong username or password..");

                    txtLoginName.Text = "";
                    txtLoginPassword.Text = "";
                }
                connection.Close();
                if (type.ToUpper() == user1)
                {
                    showgrid();
                    dataGridView1.Show();
                }
                else
                {
                    MessageBox.Show("You entered wrong username or password..");

                }
           
            }
            catch (Exception e10)
            {
                MessageBox.Show("error");
                connection.Close();
            }
            
        }
        public void showgrid()
        {
            try
            {
                connection.Open();
                string CmdString = "SELECT * FROM digidatabase.ordertable";
                MySqlDataAdapter sda = new MySqlDataAdapter(CmdString, connection);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
                connection.Close();
            }
            catch (Exception r)
            {
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
           
            groupBox1.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                string query = "insert into digidatabase.users(user_id,user_name,user_password,user_type,user_email) values(" + userid + ",'" + txtUserName.Text + "','" + txtPassword.Text + "','" + txtUserType.Text + "','" + txtEmail.Text + "');";
                

                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                connection.Close();

                clear();

                MessageBox.Show("1 user added into Database...");
                select2();
            }
            catch (Exception e6)
            {
                MessageBox.Show("error");
                connection.Close();
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                connection.Open();
                string CmdString = "select user_type from digidatabase.users where user_type='" + comboBox1.Text + "'";
                MySqlDataAdapter sda = new MySqlDataAdapter(CmdString, connection);
                DataSet ds = new DataSet();
                sda.Fill(ds, "users");


                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtUserName.Text = ds.Tables[0].Rows[0][0].ToString();
                }

                connection.Close();
            }
            catch(Exception err)
            {
                MessageBox.Show("error");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                string query = "delete  from digidatabase.users where user_id=" + textBox2.Text + "";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();

                connection.Close();
                MessageBox.Show("deleted..");
                clear();
            }
            catch (Exception e9)
            {
                MessageBox.Show("error");
                connection.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Enabled = false;
           // if(txt)
            try{
                connection.Open();
                string CmdString = "select * from digidatabase.users where user_id=" + textBox2.Text + "";
                MySqlDataAdapter sda = new MySqlDataAdapter(CmdString, connection);
                DataSet ds = new DataSet();
                sda.Fill(ds, "users");
               

               // textBox2.Text = ds.Tables[0].Rows[0][0].ToString();
                txtUserName.Text = ds.Tables[0].Rows[0][1].ToString();
                txtPassword.Text = ds.Tables[0].Rows[0][2].ToString();
                txtUserType.Text = ds.Tables[0].Rows[0][3].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0][4].ToString();

                connection.Close();

                
                MessageBox.Show("ok");
                //con.Close();
            }
            catch (Exception e7)
            {
                MessageBox.Show("error");
                connection.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                string query = "update digidatabase.users set user_name ='" + txtUserName.Text + "',user_password='" + txtPassword.Text + "',user_type='" + txtUserType.Text + "',user_email='" + txtEmail.Text + "', where user_id=" + textBox2.Text + "";
          
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();
             
                connection.Close();
                
                MessageBox.Show("Updated");
                clear();
            }

            
               
            catch (Exception e8)
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
            char ch = e.KeyChar;

            if (!Char.IsLetter(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsLetter(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsLetter(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            connection.Open();
            string CmdString = "select user_type from users where user_type='" + comboBox1.Text + "'";
            MySqlDataAdapter sda = new MySqlDataAdapter(CmdString, connection);
            DataSet ds = new DataSet();
            sda.Fill(ds, "users");


            if (ds.Tables[0].Rows.Count > 0)
            {
                txtUserType.Text = ds.Tables[0].Rows[0][0].ToString();
            }

            connection.Close(); 
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Hide();
        }
    }
}
