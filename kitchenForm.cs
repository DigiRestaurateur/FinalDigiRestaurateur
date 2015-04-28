using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Digiadministrator
{
    public partial class kitchenForm : Form
    {
        SqlConnection con = new SqlConnection("Data Source=RAHUL-PC;Initial Catalog=Digidatabase;Persist Security Info=True;User ID=sa;Password=123");
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();

        public kitchenForm()
        {
            InitializeComponent();
            display();
                
        }
        public void display()
        {
            con.Open();
            cmd = new SqlCommand("select order_id,table_id,order_item,order_quantity,order_desc,order_status from ordertable order by order_id", con);
         
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);

            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            dataGridView1.DataSource = bs;
            da.Update(dt);
            con.Close();
        }

        private void kitchenForm_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
