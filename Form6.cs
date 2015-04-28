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
    public partial class Form6 : Form
    {
        MySqlConnection connection;
       
        private void clear()
        {
            textBox2.Text = "";
            textBox5.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
            
            comboBox1.Text = "";
        }
      
        

        public Form6()
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
            select2();
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

                connection.Close();
                
            }
            catch (Exception e2)
            {
                MessageBox.Show("error");
                connection.Close();
            }
        }
        public void display()
        {
            connection.Open();
            string CmdString = "select * from digidatabase.users";
            MySqlDataAdapter sda = new MySqlDataAdapter(CmdString, connection);
            DataSet dt = new DataSet();
            sda.Fill(dt);
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            dataGridView1.DataSource = bs;
            sda.Update(dt);
            connection.Close();
        }
       
        private void Form6_Load(object sender, EventArgs e)
        {
            textBox1.Text = DateTime.Now.ToString();
         
            try
            {
                connection.Open();
                string CmdString = "select user_type from digidatabase.users";
                MySqlDataAdapter sda = new MySqlDataAdapter(CmdString, connection);
                DataSet ds = new DataSet();
                sda.Fill(ds, "category");
                
               if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count - 1; i++)
                    {
                        comboBox1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                    }
                }

                connection.Close();
            }
            catch (Exception e20)
            {
                MessageBox.Show("Error1321321");
                connection.Close();
            }





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
                connection.Open();
                string CmdString = "select * from digidatabase.users where user_name='" + textBox7.Text + "' and user_password='" + textBox8.Text + "'";
                MySqlDataAdapter sda = new MySqlDataAdapter(CmdString, connection);
                DataSet ds = new DataSet();
                sda.Fill(ds, "users");
               if (ds.Tables[0].Rows.Count > 0)
                {

                    dataGridView1.Show();
                    textBox7.Text = "";
                    textBox8.Text = "";
                    groupBox1.Hide();
                }
                else
                {
                    MessageBox.Show("You entered wrong username or password..");

                    textBox7.Text = "";
                    textBox8.Text = "";
                }
                connection.Close();
            }
            catch (Exception e10)
            {
                MessageBox.Show("error");
                connection.Close();
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
                string query = "insert into digidatabase.users(user_id,user_name,user_password,user_type,user_email) values(" + textBox2.Text + ",'" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "');";
                

                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                connection.Close();

                clear();

                MessageBox.Show("1 user added into Database...");
            }
            catch (Exception e6)
            {
                MessageBox.Show("error");
                connection.Close();
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection.Open();
            string CmdString = "select user_type from digidatabase.users where user_type='" + comboBox1.Text + "'";
            MySqlDataAdapter sda = new MySqlDataAdapter(CmdString, connection);
            DataSet ds = new DataSet();
            sda.Fill(ds,"users");
           

            

            if (ds.Tables[0].Rows.Count > 0)
            {
                textBox5.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            
            connection.Close();
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
            }
            catch (Exception e9)
            {
                MessageBox.Show("error");
                connection.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try{
                connection.Open();
                string CmdString = "select * from digidatabase.users where user_id=" + textBox2.Text + "";
                MySqlDataAdapter sda = new MySqlDataAdapter(CmdString, connection);
                DataSet ds = new DataSet();
                sda.Fill(ds, "users");
               

                textBox2.Text = ds.Tables[0].Rows[0][0].ToString();
                textBox3.Text = ds.Tables[0].Rows[0][1].ToString();
                textBox4.Text = ds.Tables[0].Rows[0][2].ToString();
                textBox5.Text = ds.Tables[0].Rows[0][3].ToString();
                textBox6.Text = ds.Tables[0].Rows[0][4].ToString();

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
                string query = "update digidatabase.users set user_name ='" + textBox3.Text + "',user_password='" + textBox4.Text + "',user_type='" + textBox5.Text + "',user_email='" + textBox6.Text + "', where user_id=" + textBox2.Text + "";

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
    }
}
