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
    public partial class Gallary : Form
    {
        MySqlConnection connection;

        private void clear()
        {
            textBox2.Text = "";
           
            textBox3.Text = "";
            textBox4.Text = "";
            
        }
        public Gallary()
        {
            InitializeComponent();
            String server = "localhost";
            String database = "digidatabase";
            String uid = "root";
            String password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            textBox1.Text = DateTime.Now.ToString();

            try
            {
                connection.Open();
                string CmdString = "select cat_name from database.category";
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
            catch (Exception e19)
            {
                MessageBox.Show("Error1321321");
                connection.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Select Your Image";


            openFileDialog1.Filter = "All Files|*.*";
            openFileDialog1.ShowDialog();
            textBox4.Text = openFileDialog1.FileName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string imagepath = textBox4.Text;
                string picname = imagepath.Substring(imagepath.LastIndexOf('\\'));
                Bitmap b = new Bitmap("" + textBox4.Text);

                b.Save(@"E:\Project\Digiadministrator\Digiadministrator\images\" + picname + ".bmp");
                clear();

                MessageBox.Show("1 Category added into Database...");
            }
            catch (Exception e5)
            {
                MessageBox.Show("error");
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsLetter(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
