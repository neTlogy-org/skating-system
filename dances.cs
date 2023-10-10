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
        TextBox[] coupleNums = new TextBox[Form1.CoupleCnt];
        TextBox[,] textBoxArr = new TextBox[Form1.CoupleCnt, Form1.JudgeCnt];
        Label[] labelArr = new Label[Form1.JudgeCnt];
        Label headerColumn = new Label();
        int[] spacing = { 40, 40 };
        int[] offset = { 20, 20 };
        int headerSpace = 60;
        int headerOffset = 3;
        int size = 30;
        public dances()
        {
            InitializeComponent();

            headerColumn = new Label();
            headerColumn.Parent = panel1;
            headerColumn.Text = "Číslo páru:";

            for (int y = 0; y < textBoxArr.GetLength(1) + 1; y++)
            {
                for (int x = 0; x < textBoxArr.GetLength(0) + 1; x++)
                {
                    if (x == 0 && y == 0)
                    {
                        headerColumn.Visible = true;
                        headerColumn.Location = new Point(offset[0], offset[1] + headerOffset);
                        continue;
                    }   
                    if(x == 0)
                    {
                        labelArr[y - 1] = new Label();
                        labelArr[y - 1].Parent = panel1;
                        labelArr[y - 1].Text = $"Porodce č. {y}";
                        labelArr[y - 1].Visible = true;
                        labelArr[y - 1].Location = new Point(offset[0], y * spacing[1] + offset[1] + headerOffset);
                        continue;
                    }
                    if(y == 0)
                    {
                        coupleNums[x - 1] = new TextBox();
                        coupleNums[x - 1].Parent = panel1;
                        coupleNums[x - 1].Size = new Size(size, size);
                        coupleNums[x - 1].Visible = true;
                        coupleNums[x - 1].Location = new Point(x * spacing[0] + offset[0] + headerSpace, offset[1]);
                        continue;

                    }
                    textBoxArr[x - 1, y - 1] = new TextBox();
                    textBoxArr[x - 1, y - 1].Parent = panel1;
                    textBoxArr[x - 1, y - 1].Size = new Size(size, size);
                    textBoxArr[x - 1, y - 1].Visible = true;
                    textBoxArr[x - 1, y - 1].Location = new Point(x * spacing[0] + offset[0] + headerSpace, y * spacing[1] + offset[1]);
                }
            }




        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
