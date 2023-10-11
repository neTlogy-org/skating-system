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
    struct Dance
    {
        public Dance(string dance, int[] couples_ids, int judgeCnt, int[,] marks) {
            
        }
    }
    public partial class dances : Form
    {

        

        TextBox[] coupleNums = new TextBox[Form1.CoupleCnt];
        TextBox[,] textBoxArr = new TextBox[Form1.CoupleCnt, Form1.JudgeCnt];
        Label[] labelArr = new Label[Form1.JudgeCnt];
        Label headerColumn = new Label();
        int dance = 1;

        Pen pen = new Pen(Color.Black, 3);

        int[] spacing = { 40, 40 };
        int[] offset = { 20, 20 };
        int headerSpace = 60;
        int headerOffset = 4;
        int size = 30;

        public dances()
        {
            InitializeComponent();

            initialize();


        }

        private void tb_btn_KeyDown(object sender, KeyEventArgs e)
        {
            /*int x;
            int y;
            for (x = 0; x < textBoxArr.GetLength(0); x++)
            {
                y = Array.IndexOf(textBoxArr[x], sender);
            }
            if (e.KeyCode == Keys.Up)
            {
                label1.Text = x.ToString();
                //textBoxArr[x, 1].Focus();
            }*/
        }

        private void initialize()
        {
            if(dance > 1)
            {
                back_btn.Enabled = true;
            }
            else
            {
                back_btn.Enabled = false;
            }
            if (dance == Form1.DanceCnt)
            {
                next_btn.Enabled = false;
            }
            else
            {
                next_btn.Enabled = true;
            }

            dance_TB.Text = dance.ToString();

            headerColumn = new Label
            {
                Parent = panel1,
                Text = "Číslo páru:"
            };


            for (int y = 0; y < textBoxArr.GetLength(1) + 1; y++)
            {
                for (int x = 0; x < textBoxArr.GetLength(0) + 1; x++)
                {
                    if (x == 0 && y == 0)
                    {
                        headerColumn.Visible = true;
                        headerColumn.Location = new Point(offset[0], offset[1] + headerOffset);
                        headerColumn.Width = 90;
                        continue;
                    }
                    if (x == 0)
                    {
                        labelArr[y - 1] = new Label
                        {
                            Parent = panel1,
                            Text = $"Porotce {Convert.ToChar('A' + y - 1)}",
                            Visible = true,
                            Width = 90,
                            Location = new Point(offset[0], y * spacing[1] + offset[1] + headerOffset)
                        };
                        continue;
                    }
                    if (y == 0)
                    {
                        coupleNums[x - 1] = new TextBox
                        {
                            Text = x.ToString(),
                            Parent = panel1,
                            Size = new Size(size, size),
                            Visible = true,
                            Location = new Point(x * spacing[0] + offset[0] + headerSpace, offset[1])
                        };
                        coupleNums[x - 1].KeyDown += tb_btn_KeyDown;
                        continue;

                    }
                    textBoxArr[x - 1, y - 1] = new TextBox
                    {
                        Parent = panel1,
                        Size = new Size(size, size),
                        Visible = true,
                        Location = new Point(x * spacing[0] + offset[0] + headerSpace, y * spacing[1] + offset[1])
                    };
                }
            }

            Label line_x = new Label
            {
                AutoSize = false,
                Text = "",
                Parent = panel1,
                Location = new Point(offset[0], offset[1] + size),
                Height = 2,
                Width = Form1.CoupleCnt * spacing[0] + headerColumn.Width,
                Visible = true,
                BorderStyle = BorderStyle.Fixed3D


            };
            Label line_y = new Label
            {
                AutoSize = false,
                Text = "",
                Parent = panel1,
                Location = new Point(headerColumn.Width + offset[0], offset[1]),
                Height = Form1.JudgeCnt * spacing[1] + size,
                Width = 2,
                Visible = true,
                BorderStyle = BorderStyle.Fixed3D


            };
        }

        private void next_btn_Click(object sender, EventArgs e)
        {
            dance++;

        }
    }
}
