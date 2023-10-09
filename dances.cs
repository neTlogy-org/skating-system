using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace skating_system
{
    public partial class dances : Form
    {
        public dances()
        {
            InitializeComponent();
            label2.Text = Form1.CoupleCnt.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
