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
        int second = 0;
        public static String itemid="";
        private void clear()
        {
            itemId.Text = "";
            txtItemPrice.Text = "";
            txtCatId.Text = "";
            txtItemName.Text = "";
            txtItemDesc.Text = "";
            txtItemStatus.Text = "";
            catNameBox.Text = "";
        }

        public addmenu()
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
           
            try
            {
                connection.Open();
                string CmdString = "SELECT * FROM digidatabase.category";
                MySqlDataAdapter sda = new MySqlDataAdapter(CmdString, connection);
                DataSet ds = new DataSet();
                sda.Fill(ds, "category");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        catNameBox.Items.Add(ds.Tables[0].Rows[i][1].ToString());
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
        public void autoCatid()
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
                    itemId.Text = ds.Tables[0].Rows[0][0].ToString();
                    a = Int16.Parse(itemId.Text);
                    itemId.Text = (a + 1).ToString();
                }
                itemid = (a + 1).ToString();
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
            string CmdString = " select cat_id from digidatabase.category where cat_name='" + catNameBox.Text + "'";
            MySqlDataAdapter sda = new MySqlDataAdapter(CmdString, connection);
            DataSet ds = new DataSet();
            sda.Fill(ds, "category");

          
            txtCatId.Text = ds.Tables[0].Rows[0][1].ToString();
            

            connection.Close();

        }

        private void add_Click(object sender, EventArgs e)
        {
            try
            {


               connection.Open();
                
                // string query = "INSERT INTO student (id,name,con) VALUES("+ textBox1.Text+"+'"+ textBox2.Text +"'+"+ textBox3.Text +")";
                // string query = "UPDATE student SET id=100,name='" + textBox2.Text + "' WHERE id=" + textBox1.Text;
               string query = "insert into itemtable values(" + itemid + "," + txtCatId.Text + ",'" + txtItemName.Text + "'," + txtItemPrice.Text + ",'" + txtItemDesc.Text + "','" + txtItemStatus.Text + "')";
              //  string query = "insert into itemtable values(7,10,'m',50,'a','a');";
                  //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Execute command
                cmd.ExecuteNonQuery();
                   

                /*
                string imagepath = textBox8.Text;
                string picname = imagepath.Substring(imagepath.LastIndexOf('\\'));
                Bitmap b = new Bitmap("" + textBox8.Text);

                b.Save(@"E:\Project\Digiadministrator\Digiadministrator\images\" + picname + ".bmp");
                */
                clear();
                
                MessageBox.Show("1 Menu added into Database...");
                            connection.Close();


                            autoCatid();
              
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

            timer1.Interval = 1000;
            timer1.Start(); 
            
            
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            connection.Open();
            string CmdString = "select cat_id from category where cat_name='" + catNameBox.Text + "'";
            MySqlDataAdapter sda = new MySqlDataAdapter(CmdString, connection);
            DataSet ds = new DataSet();
            sda.Fill(ds, "category");


            if (ds.Tables[0].Rows.Count > 0)
            {
                txtCatId.Text = ds.Tables[0].Rows[0][0].ToString();
            }

            connection.Close(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            


        }

        private void select_Click(object sender, EventArgs e)
        {
            
            try{

             //   connection.Open();
                string CmdString = "select * from itemtable where item_id=" + itemId.Text + "";
                MySqlDataAdapter sda = new MySqlDataAdapter(CmdString, connection);
                DataSet ds = new DataSet();
                sda.Fill(ds, "itemtable");


                textBox2.Text = ds.Tables[0].Rows[0][0].ToString();
                txtCatId.Text = ds.Tables[0].Rows[0][1].ToString();
                txtItemName.Text = ds.Tables[0].Rows[0][2].ToString();
                txtItemPrice.Text = ds.Tables[0].Rows[0][3].ToString();
                txtItemDesc.Text = ds.Tables[0].Rows[0][4].ToString();
                txtItemStatus.Text = ds.Tables[0].Rows[0][5].ToString();

              
              
                string CmdString1 = "select cat_name from category where cat_id=" + txtCatId.Text + "";
                MySqlDataAdapter sda1 = new MySqlDataAdapter(CmdString1, connection);
                DataSet ds1 = new DataSet();
                sda1.Fill(ds1, "category");


                if (ds1.Tables[0].Rows.Count > 0)
                {
                    catNameBox.Text = ds1.Tables[0].Rows[0][0].ToString();
                    
               
                }

                connection.Close(); 
               
            }
            catch (Exception e2)
            {
                MessageBox.Show("Exception"+e2);
                connection.Close(); 
            }


            
        
        }

        private void update_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                string query = "update digidatabase.itemtable set item_name='" + txtItemName.Text + "',item_price=" + txtItemPrice.Text + ",item_discription='" + txtItemDesc.Text + "',item_status='" + txtItemStatus.Text + "' where item_id=" + itemId.Text + "";

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
                autoCatid();
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
                string query = "delete  from itemtable where item_id=" + itemId.Text + "";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();               
                connection.Close(); 
                clear();
                MessageBox.Show("This Menu Deleted....");
                autoCatid();
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

            if (!Char.IsLetter(ch) && ch != 8 && ch !=45)
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

       

        private void button3_Click(object sender, EventArgs e)
        {
            autoCatid();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clear();
            autoCatid();
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
               

                textBox2.Text = DateTime.Now.ToString();
            } 
        }

        private void txtItemStatus_TextChanged(object sender, EventArgs e)
        {

        }

       

    }
}
