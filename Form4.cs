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
    public partial class addmenu : Form
    {
        MySqlConnection connection;
        

        private void clear()
        {
            textBox2.Text = "";
            textBox5.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            comboBox1.Text = "";
        }

        public addmenu()
        {
            

            InitializeComponent();
            String server = "localhost";
            String database = "digidatabase";
            String uid = "root";
            String password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);
            select3();
           
            try
            {
                connection.Open();
                string CmdString = "SELECT * FROM digidatabase.category";
                MySqlDataAdapter sda = new MySqlDataAdapter(CmdString, connection);
                DataSet ds = new DataSet();
                sda.Fill(ds, "category");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count - 1; i++)
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
        public void select3()
        {
            try
            {
                Int16 a = 0;
                connection.Open();
                string CmdString = " select max(item_id) from digidatabase.itemtable";
                MySqlDataAdapter sda = new MySqlDataAdapter(CmdString, connection);
                DataSet ds = new DataSet();
                sda.Fill(ds, "itemtable");

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
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close(); 
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           // textBox5.Text = comboBox1.Text;
       
            connection.Open();
            string CmdString = " select cat_id from digidatabase.category where cat_name='" + comboBox1.Text + "'";
            MySqlDataAdapter sda = new MySqlDataAdapter(CmdString, connection);
            DataSet ds = new DataSet();
            sda.Fill(ds, "category");

          
            textBox3.Text = ds.Tables[0].Rows[0][1].ToString();
            

            connection.Close();

        }

        private void add_Click(object sender, EventArgs e)
        {
            try
            {


               connection.Open();
                
                // string query = "INSERT INTO student (id,name,con) VALUES("+ textBox1.Text+"+'"+ textBox2.Text +"'+"+ textBox3.Text +")";
                // string query = "UPDATE student SET id=100,name='" + textBox2.Text + "' WHERE id=" + textBox1.Text;
                string query = "insert into itemtable values(" + textBox2.Text + "," + textBox3.Text + ",'" + textBox4.Text + "'," + textBox5.Text + ",'" + textBox6.Text + "','" + textBox7.Text + "')";
              //  string query = "insert into itemtable values(7,10,'m',50,'a','a');";
                  //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Execute command
                cmd.ExecuteNonQuery();
                MessageBox.Show("hi2");        

                /*
                string imagepath = textBox8.Text;
                string picname = imagepath.Substring(imagepath.LastIndexOf('\\'));
                Bitmap b = new Bitmap("" + textBox8.Text);

                b.Save(@"E:\Project\Digiadministrator\Digiadministrator\images\" + picname + ".bmp");
                */
                clear();
                
                MessageBox.Show("1 Menu added into Database...");
                connection.Close(); 

            }
            catch (Exception e1)
            {
                MessageBox.Show("error");
                connection.Close(); 
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

       

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void brows_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Select Your Image";


            openFileDialog1.Filter = "All Files|*.*";
            openFileDialog1.ShowDialog();
            textBox8.Text = openFileDialog1.FileName;



        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void categoryBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void addmenu_Load(object sender, EventArgs e)
        {
            textBox1.Text = DateTime.Now.ToString();
           
            
            
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            connection.Open();
            string CmdString = "select cat_id from category where cat_name='" + comboBox1.Text + "'";
            MySqlDataAdapter sda = new MySqlDataAdapter(CmdString, connection);
            DataSet ds = new DataSet();
            sda.Fill(ds, "category");


            if (ds.Tables[0].Rows.Count > 0)
            {
                textBox3.Text = ds.Tables[0].Rows[0][0].ToString();
            }

            connection.Close(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            


        }

        private void select_Click(object sender, EventArgs e)
        {
            
            try{

                connection.Open();
                string CmdString = "select * from itemtable where item_id=" + textBox9.Text + "";
                MySqlDataAdapter sda = new MySqlDataAdapter(CmdString, connection);
                DataSet ds = new DataSet();
                sda.Fill(ds, "itemtable");


                textBox9.Text = ds.Tables[0].Rows[0][0].ToString();
                textBox3.Text = ds.Tables[0].Rows[0][1].ToString();
                textBox4.Text = ds.Tables[0].Rows[0][2].ToString();
                textBox5.Text = ds.Tables[0].Rows[0][3].ToString();
                textBox6.Text = ds.Tables[0].Rows[0][4].ToString();
                textBox7.Text = ds.Tables[0].Rows[0][5].ToString();
            //    con.Close();

              //  con.Open();

               
                string CmdString1 = "select cat_name from category where cat_id=" + textBox3.Text + "";
                MySqlDataAdapter sda1 = new MySqlDataAdapter(CmdString, connection);
                DataSet ds1 = new DataSet();
                sda1.Fill(ds1, "category");

               

                if (ds1.Tables[0].Rows.Count > 0)
                {
                    comboBox1.Text = ds1.Tables[0].Rows[0][0].ToString();
                }

                connection.Close(); 
                MessageBox.Show("good");
            }
            catch (Exception e2)
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
                string query = "update digidatabase.itemtable set item_name='" + textBox4.Text + "',item_price=" + textBox5.Text + ",item_discription='" + textBox6.Text + "',item_status='" + textBox7.Text + "' where item_id=" + textBox9.Text + "";

                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;
                //Execute query
                cmd.ExecuteNonQuery();            
                connection.Close(); 
                clear();
                MessageBox.Show("This Menu updated....");
            }
            catch (Exception e3)
            {
                MessageBox.Show("error");
                connection.Close(); 
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                string query = "delete  from itemtable where item_id=" + textBox9.Text + "";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();               
                connection.Close(); 
                clear();
                MessageBox.Show("This Menu Deleted....");
            }
            catch (Exception e4)
            {
                MessageBox.Show("error");
                connection.Close(); 
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

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch !=46)
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

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsLetter(ch) && ch != 8)
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_2(object sender, EventArgs e)
        {       
        pictureBox3.ImageLocation = @"Image\Desert.jpg"; 
            // Set the PictureBox image property to this image.
            // ... Then, adjust its height and width properties.
           // pictureBox3.Image = image;
        pictureBox3.SizeMode = PictureBoxSizeMode.AutoSize;
this.pictureBox3.Image = global::Digiadministrator.Properties.Resources._2;
        }

       

    }
}
