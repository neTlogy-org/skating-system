using System;
using System.Collections.Generic;
using System.Collections.Immutable;
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
        TextBox[,] textBoxArr = new TextBox[Form1.CoupleCnt, Form1.JudgeCnt];
        int[] spacing = { 40, 40 };
        int[] offset = { 20, 20 };
        public dances()
        {
            InitializeComponent();

            for (int x = 0; x < textBoxArr.GetLength(0); x++)
            {
                for (int y = 0; y < textBoxArr.GetLength(0); y++)
                {
                    textBoxArr[x, y] = new TextBox();
                    textBoxArr[x, y].Parent = panel1;
                    textBoxArr[x, y].Size = new Size(30, 30);
                    textBoxArr[x, y].Visible = true;
                    textBoxArr[x, y].Location = new Point(x * spacing[0] + offset[0], y * spacing[1] + offset[1]);
                }
            }




        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
