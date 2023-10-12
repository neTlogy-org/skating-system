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
    public partial class paramsForm : Form
    {
        static TextBox[] dancesNames = new TextBox[Form1.DanceCnt];
        static TextBox[] coupleNums = new TextBox[Form1.CoupleCnt];

        public static TextBox[] DancesNames { get => dancesNames; }
        public TextBox[] CoupleNums { get => coupleNums; }

        int[] spacing = { 41, 30 };
        int[] offset = { 20, 10 };
        int size = 30;
        public paramsForm()
        {
            InitializeComponent();
            for (int i = 0; i < Form1.DanceCnt; i++)
            {
                dancesNames[i] = new TextBox();
                dancesNames[i].Parent = panel1;
                dancesNames[i].Location = new Point(offset[0], i * spacing[1] + offset[1]);
                dancesNames[i].Width = panel1.Width - 2 * offset[0];
                dancesNames[i].Visible = true;
            }
            for (int i = 0; i < Form1.CoupleCnt; i++)
            {
                coupleNums[i] = new TextBox();
                coupleNums[i].Parent = panel2;
                coupleNums[i].Location = new Point((i % 12) * spacing[0] + offset[0], (int)Math.Floor((double)i / 12) * spacing[1] + offset[1]);
                coupleNums[i].Width = size;

            }
        }

        private void next_btn_Click(object sender, EventArgs e)
        {
           new dances().ShowDialog();
        }
    }
}
