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
        Results resultsStruct;
        Placement placement;
        public results()
        {

            InitializeComponent();

            placement = new Placement(dances.DancesArr);
            label1.Text = placement.Evaluate().total[1].ToString();
        }
    }
}
