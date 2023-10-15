﻿using System;
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
        string dance_title;
        int[] couples_nums;
        int judgeCnt;
        int[][] marks;

        public string Dance_title { get => dance_title; set => dance_title = value; }
        public int[] Couples_nums { get => couples_nums; set => couples_nums = value; }
        public int JudgeCnt { get => judgeCnt; set => judgeCnt = value; }
        public int[][] Marks { get => marks; set => marks = value; }

        public Dance(string dance_title, int[] couples_nums, int judgeCnt, int[][] marks)
        {
            this.dance_title = dance_title;
            this.couples_nums = couples_nums;
            this.judgeCnt = judgeCnt;
            this.marks = marks;
        }

    }
    public partial class dances : Form
    {
        Label[] coupleNums = new Label[Form1.CoupleCnt];
        TextBox[,] textBoxArr = new TextBox[Form1.CoupleCnt, Form1.JudgeCnt];
        Label[] labelArr = new Label[Form1.JudgeCnt];
        Label headerColumn = new Label();
        Dance[] dancesArr = new Dance[Form1.DanceCnt];
        int dance = 1;

        string[] dancesNames = new string[Form1.DanceCnt];

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

            dancesNames = paramsForm.DancesNames.Select(e => e.Text).ToArray();

            paramsForm.dancesOpened = true;
            Form1.paramsFormIns.Close();

        }

        private void tb_KeyDown(object sender, KeyEventArgs e)
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

        private void next_btn_Click(object sender, EventArgs e)
        {
            int[] coupleIDs = new int[Form1.CoupleCnt];
            int[][] marks = new int[Form1.CoupleCnt][];
            int[][] reversedMarks = new int[Form1.JudgeCnt][];

            for (int i = 0; i < Form1.CoupleCnt; i++)
            {
                coupleIDs[i] = Convert.ToInt32(coupleNums[i].Text);
            }

            for (int i = 0; i < Form1.CoupleCnt; i++)
            {
                marks[i] = new int[Form1.JudgeCnt];
            }

            for (int i = 0; i < Form1.JudgeCnt; i++)
            {
                reversedMarks[i] = new int[Form1.CoupleCnt];
            }

            for (int x = 0; x < Form1.CoupleCnt; x++)
            {
                for (int y = 0; y < Form1.JudgeCnt; y++)
                {
                    if (!int.TryParse(textBoxArr[x, y].Text, out marks[x][y]))
                    {
                        MessageBox.Show($"Špatně zadaná známka páru {coupleIDs[x]} od porotce {Convert.ToChar('A' + y)}", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (marks[x][y] == 0)
                    {
                        MessageBox.Show($"Špatně zadaná známka páru {coupleIDs[x]} od porotce {Convert.ToChar('A' + y)}; známka nemže být 0", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;

                    }
                    if (marks[x][y] > Form1.CoupleCnt)
                    {
                        MessageBox.Show($"Špatně zadaná známka páru {coupleIDs[x]} od porotce {Convert.ToChar('A' + y)}; známka nemůže být větší než počet párů", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                }
            }
            for(int x = 0; x < Form1.JudgeCnt; x++)
            {
                for (int y = 0; y < Form1.CoupleCnt; y++)
                {
                    reversedMarks[y][x] = marks[x][y];
                }
            }
            for (int x = 0; x < Form1.JudgeCnt; x++)
            {
                for (int y = 0; y < Form1.CoupleCnt; y++)
                {
                    if (Array.FindAll(reversedMarks[x], e => e == reversedMarks[x][y]).Length > 1)
                    {
                        MessageBox.Show($"Špatně zadané známky od porotce {Convert.ToChar('A' + x)}, nemůže použít jednu známku víckrát", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                }
            }



                foreach (TextBox textBox in textBoxArr)
            {
                textBox.Text = "";
            }

            


            dancesArr[dance - 1] = new Dance(dance_TB.Text, coupleIDs, Form1.JudgeCnt, marks);
            dance_TB.Text = dancesNames[dance];

            dance++;

            if (dance > 1)
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



        }


        private void initialize()
        {
            back_btn.Enabled = false;

            dance_TB.Text = paramsForm.DancesNames[0].Text;

            headerColumn = new Label
            {
                Parent = panel1,
                Text = "Číslo páru:",
                TextAlign = ContentAlignment.MiddleCenter
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
                            Location = new Point(offset[0], y * spacing[1] + offset[1] + headerOffset),
                            TextAlign = ContentAlignment.TopCenter

                        };
                        continue;
                    }
                    if (y == 0)
                    {
                        coupleNums[x - 1] = new Label
                        {
                            Text = paramsForm.CoupleNums[x - 1].Text.ToString(),
                            Parent = panel1,
                            Size = new Size(size, size),
                            Visible = true,
                            Location = new Point(x * spacing[0] + offset[0] + headerSpace, offset[1]),
                            TextAlign = ContentAlignment.MiddleCenter
                        };
                        continue;

                    }
                    textBoxArr[x - 1, y - 1] = new TextBox
                    {
                        Parent = panel1,
                        Size = new Size(size, size),
                        Visible = true,
                        Location = new Point(x * spacing[0] + offset[0] + headerSpace, y * spacing[1] + offset[1]),
                    };
                    textBoxArr[x - 1, y - 1].KeyDown += tb_KeyDown;
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

        private void dances_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.form1.Close();
        }
    }
}
