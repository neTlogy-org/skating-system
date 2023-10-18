using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace skating_system
{
    public partial class results : Form
    {
        Results resultsStruct = new Results();
        public results()
        {
            resultsStruct = dances.ResultsStruct;
            label1.Text = resultsStruct.ToString();
            InitializeComponent();
        }
    }
}
