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
    public partial class Setting : Form
    {
        public Setting()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Userregistration f6 = new Userregistration();
            f6.Show();

        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Othersetting f10 = new Othersetting();
            f10.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            systemdatabase sd = new systemdatabase();
            sd.Show();
        }
    }
}
