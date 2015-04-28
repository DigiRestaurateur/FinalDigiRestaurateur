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
    public partial class Form8 : Form
    {
        MySqlConnection connection;

        private void clear()
        {
            textBox2.Text = "";

            textBox5.Text = "";    
            textBox3.Text = "";
            
           
        }


        public Form8()
        {
            InitializeComponent();
            String server = "localhost";
            String database = "digidatabase";
            String uid = "root";
            String password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);
            select1();
        }
        public void select1()
        {
            try
            {
                Int16 a = 0;
                connection.Open();
                string CmdString = "select max(cat_id) from  digidatabase.category";
                MySqlDataAdapter sda = new MySqlDataAdapter(CmdString, connection);
                DataSet ds = new DataSet();
                sda.Fill(ds, "category");

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
        private void button3_Click(object sender, EventArgs e)
        {
            
            
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            textBox1.Text = DateTime.Now.ToString();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {

           
        }

        private void delete_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
               connection.Open();
               string query = "insert into digidatabase.category values(" + textBox2.Text + ",'" + textBox3.Text + "');";
               MySqlCommand cmd = new MySqlCommand(query, connection);

               //Execute command
               cmd.ExecuteNonQuery();

               connection.Close();
                

                string imagepath = textBox5.Text;
                string picname = imagepath.Substring(imagepath.LastIndexOf('\\'));
                Bitmap b = new Bitmap("" + textBox5.Text);

                b.Save(@"E:\Project\Digiadministrator\Digiadministrator\images\" + picname + ".bmp");
                clear();
                MessageBox.Show("1 category added into Database...");
            }
            catch (Exception e11)
            {
                MessageBox.Show("error");
                connection.Close();
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                string CmdString = "select * from category where cat_id=" + textBox6.Text+"";
                MySqlDataAdapter sda = new MySqlDataAdapter(CmdString, connection);
                DataSet ds = new DataSet();
                sda.Fill(ds, "category");
                

                textBox6.Text = ds.Tables[0].Rows[0][0].ToString();
                textBox3.Text = ds.Tables[0].Rows[0][1].ToString();
                
                //con.Close();

                //con.Open();
                
                connection.Close();
            }
            catch (Exception e12)
            {
                MessageBox.Show("error");
                connection.Close();
            }
        }

        private void delete_Click_1(object sender, EventArgs e)
        {
            try
            {

                connection.Open();
                string query = "delete  from category WHERE cat_id=" + textBox6.Text + "";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();

                connection.Close();
                MessageBox.Show("This Category Deleted....");
            }
            catch (Exception e14)
            {
                MessageBox.Show("error");
                connection.Close();
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                string query = "update category set cat_name='" + textBox3.Text + "' where cat_id=" + textBox6.Text + "";

                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();
                connection.Close();
                clear();
                MessageBox.Show("This Category Updated....");
            }
            catch (Exception e13)
            {
                MessageBox.Show("error");
                connection.Close();
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            openFileDialog1.Title = "Select Your Image";


            openFileDialog1.Filter = "All Files|*.*";
            openFileDialog1.ShowDialog();
            textBox5.Text = openFileDialog1.FileName;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {

            char ch = e.KeyChar;

            if (!Char.IsLetter(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {

            char ch = e.KeyChar;

            if (!Char.IsLetter(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
        }
    }
}
