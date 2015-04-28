using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using CrystalDecisions.CrystalReports.Engine;

namespace Digiadministrator
{
    public partial class Billprint : Form
    {
        MySqlConnection connection;
        public static int bilidprnt = 0;
            public static int ordrid=0;
        public Billprint(int billid,int order)
        {
            InitializeComponent();
            String server = "192.168.0.65";
            String database = "digidatabase";
            String uid = "ADMINISTRATOR";;
            String password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);
            bilidprnt = billid;
            ordrid=order;
        }

        private void Billprint_Load(object sender, EventArgs e)
        {
            CrystalAddData();
        }

        public void CrystalAddData()
        {
           // connection.Open();
            //   string CmdString = "SELECT * FROM digidatabase.ordertable,digidatabase.customertable where" + bilidprnt + "=customertable.cust_id AND ordertable.order_status='Billing' ";
         //   string CmdString = "SELECT * FROM digidatabase.ordertable,digidatabase.customertable where customertable.cust_id=" + bilidprnt + " AND ordertable.order_itid=" + ordrid + " And ordertable.order_status='Billing'";
            string CmdString = "SELECT * FROM digidatabase.ordertable,digidatabase.customertable where ordertable.order_id=" + bilidprnt + " AND customertable.cust_id=" + bilidprnt + " And ordertable.order_status='Billing'";
            //AND ordertable.order_status='Billing'";
            MySqlDataAdapter sda = new MySqlDataAdapter(CmdString, connection);                    //WHERE order_itid=" + row;
            DataSet ds = new DataSet();
            sda.Fill(ds);

            ReportDocument rd = new ReportDocument();
            rd.Load(@"E:\PROJECT\Digiadministrator\Digiadministrator\CrystalReport1.rpt");
            //rd.Load(@"..Digiadministrator\CrystalReport1.rpt");
            rd.SetDataSource(ds.Tables[0]);
            crystalReportViewer1.ReportSource = rd;



            connection.Close();
          
            ordrid = 0;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
        public void dd()
        {
            try
            {
               // connection.Open();
                
                string CmdString = "SELECT order_id,cust_name,cust_contact,order_item,order_price,order_quantity,order_ototal FROM digidatabase.ordertable,digidatabase.customertable where customertable.cust_id=ordertable.order_id AND ordertable.order_status='Billing'";
            MySqlDataAdapter sda = new MySqlDataAdapter(CmdString, connection);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            //sda.Fill(ds, "itemtable");

            String order_id = ds.Tables[0].Rows[0][0].ToString();
                String cname = ds.Tables[0].Rows[0][1].ToString();
                String ccontact = ds.Tables[0].Rows[0][2].ToString();
                String order_item = ds.Tables[0].Rows[0][3].ToString();
                String oprice = ds.Tables[0].Rows[0][4].ToString();
                String oqty = ds.Tables[0].Rows[0][5].ToString();
                String ototal = ds.Tables[0].Rows[0][6].ToString();
           
            string query = "insert into digidatabase.calculation values(" + order_id + ",'" + cname + "'," + ccontact + ",'" + order_item + "'," + oprice + "," + oqty + "," + ototal + ")";
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                connection.Close();
                MessageBox.Show("Record added to Database...");

            }
            catch (Exception e11)
            {
                MessageBox.Show("error in calculation"+e11);
                connection.Close();
            }

        }
        private void Billprint_FormClosed(object sender, FormClosedEventArgs e)
        {
            dd();
            try
            {
                connection.Open();
                string query = "delete  from digidatabase.ordertable where order_id=" + bilidprnt;
                MessageBox.Show("This Order Deleted...." + bilidprnt);
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("This Order Deleted....");

            }
            catch (Exception e4)
            {
                MessageBox.Show("error delete");
                connection.Close();
            }
            bilidprnt = 0;
        }
        

    }
}
