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
    public partial class addcategory : Form
    {
        MySqlConnection connection;
        int second = 0;
        public static String cat = "";
        private void clear()
        {
            txtCatid.Text = "";
            
               
            txtCatName.Text = "";
            
           
        }


        public addcategory()
        {
            InitializeComponent();
            String server = "192.168.0.65";
            String database = "digidatabase";
            String uid = "ADMINISTRATOR";;
            String password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);
            autoCatid();
        }
        public void autoCatid()
        {
            try
            {
                Int16 a = 0;
                connection.Open();
                string cmdString = "select max(cat_id) from  digidatabase.category";
                MySqlDataAdapter sda = new MySqlDataAdapter(cmdString, connection);
                DataSet ds = new DataSet();
                sda.Fill(ds, "category");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtCatid.Text = ds.Tables[0].Rows[0][0].ToString();
                    a = Int16.Parse(txtCatid.Text);
                    txtCatid.Text = (a + 10).ToString();
                    cat = (a + 10).ToString();
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
            timer1.Interval = 1000;
            timer1.Start(); 
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
               string query = "insert into digidatabase.category values(" + cat + ",'" + txtCatName.Text + "')";
               MySqlCommand cmd = new MySqlCommand(query, connection);

               //Execute command
               cmd.ExecuteNonQuery();

               connection.Close();
                

             /*   string imagepath = textBox5.Text;
                string picname = imagepath.Substring(imagepath.LastIndexOf('\\'));
                Bitmap b = new Bitmap("" + textBox5.Text);

                b.Save(@"E:\Project\Digiadministrator\Digiadministrator\images\" + picname + ".bmp");
               */ clear();
                MessageBox.Show("1 category added into Database...");
                autoCatid();
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
                string CmdString = "select * from category where cat_id=" + txtCatid.Text +"";
                MySqlDataAdapter sda = new MySqlDataAdapter(CmdString, connection);
                DataSet ds = new DataSet();
                sda.Fill(ds, "category");


                txtCatid.Text = ds.Tables[0].Rows[0][0].ToString();
                txtCatName.Text = ds.Tables[0].Rows[0][1].ToString();
                
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
                string query = "delete  from category WHERE cat_id=" + txtCatid.Text + "";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                clear();
                connection.Close();
                MessageBox.Show("This Category Deleted....");
                autoCatid();

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
                string query = "update category set cat_name='" + txtCatName.Text + "' where cat_id=" + txtCatid.Text + "";

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
                autoCatid();
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnA_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            clear();
            autoCatid();
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
    }
}
