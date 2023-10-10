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
        Label[] labelArr = new Label[Form1.JudgeCnt];
        Label headerColumn = new Label();
        int[] spacing = { 40, 40 };
        int[] offset = { 20, 20 };
        public dances()
        {
            InitializeComponent();

            headerColumn = new Label();
            headerColumn.Parent = panel1;

            for (int y = 0; y < textBoxArr.GetLength(1); y++)
            {
                for (int x = 0; x < textBoxArr.GetLength(0); x++)
                {
                    if (x == 0 && y == 0)
                    {
                        headerColumn.Visible = true;
                        headerColumn.Location = new Point(offset[0], offset[1]);
                        continue;
                    }
                    if(x == 0)
                    {
                        labelArr[y] = new Label();
                        labelArr[y].Parent = panel1;
                        labelArr[y].Text = "Porodce č.:";
                        labelArr[y].Visible = true;
                        labelArr[y].Location = new Point(x * spacing[0] + offset[0], offset[1]);
                    }
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
