using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Digiadministrator
{
    public partial class Dashboard : Form
    {
        int second = 0;
        public Dashboard()
        {
            
            InitializeComponent();
            textBox1.Text = DateTime.Now.ToString();
            String session = "";          

       /*     DateTime dt = new DateTime();
            session = DateTime.Now.Hour.ToString();
                 int session1 = int.Parse(session);
                 
                 for (int j = 1; j < 13; j++)
                 {
                     MessageBox.Show("" + session1);
                     if (session1 > 6 && session1 < 11)
                     {
                         label5.Text = "Morning";
                     }
                     else if (session1 > 12 && session1 < 4)
                     {
                         label5.Text = "Afternoon";

                     }
                     else if (session1 > 4 && session1 < 8)
                     {
                         label5.Text = "Evening";
                     }
                     else if (session1 > 8 && session1 < 12)
                     {
                         label5.Text = "Night";
                     }
                 }*/
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            this.Close();

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Viewmenu f3 = new Viewmenu();
            f3.Show();
          Dashboard d = new Dashboard();
            d.Close();
            
        }

        private void label1_Click(object sender, EventArgs e)
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            Setting f7 = new Setting();
            f7.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
          
        }

        private void button11_Click(object sender, EventArgs e)
        {
            customer c = new customer();
            c.Show();
 
        }

        private void button10_Click(object sender, EventArgs e)
        {
            usermanual um = new usermanual();
            um.Show();
            
        }

       

        private void button8_Click(object sender, EventArgs e)
        {
            currentorder co = new currentorder();
            co.Show();
        }

       

        private void button6_Click(object sender, EventArgs e)
        {
            currentmenus cm = new currentmenus();
            cm.Show();

           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Billing b = new Billing();
            b.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            addcategory f8 = new addcategory();
            f8.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            addmenu a = new addmenu();
            a.Show();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Start(); 
           
          
           
        }

        
        private void button12_Click_1(object sender, EventArgs e)
        {
            todaysspecial ts = new todaysspecial();
            ts.Show();
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
