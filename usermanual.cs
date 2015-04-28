using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Digiadministrator
{
    public partial class usermanual : Form
    {
        public usermanual()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void usermanual_Load(object sender, EventArgs e)
        {
            String g =@".\DIGI UserManual.pdf";
          

            if (g != null)
            {
                axAcroPDF1.LoadFile(g);
            }
           
        }
    }
}
