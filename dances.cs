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
        results resultsIns;
        Label[] coupleNums = new Label[Form1.CoupleCnt];
        TextBox[,] textBoxArr = new TextBox[Form1.CoupleCnt, Form1.JudgeCnt];
        Label[] labelArr = new Label[Form1.JudgeCnt];
        Label headerColumn = new Label();
        static Dance[] dancesArr = new Dance[Form1.DanceCnt];

        int dance = 1;

        string[] dancesNames = new string[Form1.DanceCnt];


        int[] spacing = { 40, 40 };
        int[] offset = { 20, 20 };
        int headerSpace = 60;
        int headerOffset = 4;
        int size = 30;

        internal static Dance[] DancesArr { get => dancesArr; }

        public dances()
        {
            InitializeComponent();

            initialize();

            dancesNames = paramsForm.DancesNames.Select(e => e.Text).ToArray();

            paramsForm.dancesOpened = true;


        }

        private void tb_KeyDown(object sender, KeyEventArgs e)
        {

            if (sender == null) return;

            int currentRow = -1;
            int currentColumn = -1;

            for (int x = 0; x < Form1.CoupleCnt; x++)
            {
                for (int y = 0; y < Form1.JudgeCnt; y++)
                {
                    if (textBoxArr[x, y] == sender)
                    {
                        currentRow = x;
                        currentColumn = y;
                        break;
                    }
                }
            }

            if (currentRow == -1 || currentColumn == -1) return;

            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (currentRow > 0)
                    {
                        textBoxArr[currentRow - 1, currentColumn].Focus();
                    }
                    break;
                case Keys.Right:
                    if (currentRow < Form1.CoupleCnt - 1)
                    {
                        textBoxArr[currentRow + 1, currentColumn].Focus();
                    }
                    break;
                case Keys.Up:
                    if (currentColumn > 0)
                    {
                        textBoxArr[currentRow, currentColumn - 1].Focus();
                    }
                    break;
                case Keys.Down:
                    if (currentColumn < Form1.JudgeCnt - 1)
                    {
                        textBoxArr[currentRow, currentColumn + 1].Focus();
                    }
                    break;
                case Keys.Enter:
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    if (currentColumn < Form1.JudgeCnt - 1)
                    {
                        textBoxArr[currentRow, currentColumn + 1].Focus();
                    }
                    else if (currentRow < Form1.CoupleCnt - 1)
                    {
                        textBoxArr[currentRow + 1, 0].Focus();
                    }
                    else
                    {
                        next_btn.Focus();
                    }
                    break;

            }
        }

        private void next_btn_Click(object sender, EventArgs e)
        {
            if (!toDances()) return;
            if (next_btn.Text == "Dokončit")
            {
                resultsIns = new results();
                resultsIns.ShowDialog();
                return;
            }

            dance++;

            textBoxArr[0, 0].Focus();

            if (dancesArr[dance - 1].Dance_title != null)
            {
                for (int x = 0; x < Form1.CoupleCnt; x++)
                {
                    for (int y = 0; y < Form1.JudgeCnt; y++)
                    {
                        textBoxArr[x, y].Text = dancesArr[dance - 1].Marks[x][y].ToString();
                    }
                }
            }
            else
            {
                foreach (TextBox textBox in textBoxArr)
                {
                    textBox.Text = "";
                }
            }



            if (dancesArr[dance - 1].Dance_title != null)
            {
                dance_TB.Text = dancesArr[dance - 1].Dance_title;
            }
            else
            {
                dance_TB.Text = dancesNames[dance - 1];
            }


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
                next_btn.Text = "Dokončit";
            }
            else
            {
                next_btn.Text = "Další";
            }



        }
        private void back_btn_Click(object sender, EventArgs e)
        {
            if (!toDances()) return;

            dance--;
            if (dancesArr[dance - 1].Dance_title != null)
            {
                dance_TB.Text = dancesArr[dance - 1].Dance_title;
            }
            else
            {
                dance_TB.Text = dancesNames[dance - 1];
            }


            for (int x = 0; x < Form1.CoupleCnt; x++)
            {
                for (int y = 0; y < Form1.JudgeCnt; y++)
                {
                    textBoxArr[x, y].Text = dancesArr[dance - 1].Marks[x][y].ToString();
                }
            }

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
                next_btn.Text = "Dokončit";
            }
            else
            {
                next_btn.Text = "Další";
            }
        }

        private bool toDances()
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
                        return false;
                    }
                    if (marks[x][y] == 0)
                    {
                        MessageBox.Show($"Špatně zadaná známka páru {coupleIDs[x]} od porotce {Convert.ToChar('A' + y)}; známka nemže být 0", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;

                    }
                    if (marks[x][y] > Form1.CoupleCnt)
                    {
                        MessageBox.Show($"Špatně zadaná známka páru {coupleIDs[x]} od porotce {Convert.ToChar('A' + y)}; známka nemůže být větší než počet párů", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }
            for (int x = 0; x < Form1.JudgeCnt; x++)
            {
                for (int y = 0; y < Form1.CoupleCnt; y++)
                {
                    reversedMarks[x][y] = marks[y][x];
                }
            }
            for (int x = 0; x < Form1.JudgeCnt; x++)
            {
                for (int y = 0; y < Form1.CoupleCnt; y++)
                {
                    if (Array.FindAll(reversedMarks[x], e => e == reversedMarks[x][y]).Length > 1)
                    {
                        MessageBox.Show($"Špatně zadané známky od porotce {Convert.ToChar('A' + x)}, nemůže použít jednu známku víckrát", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                }
            }

            dancesArr[dance - 1] = new Dance(dance_TB.Text, coupleIDs, Form1.JudgeCnt, marks);
            return true;
        }

        private void initialize()
        {
            back_btn.Enabled = false;

            if (dance == Form1.DanceCnt)
            {
                next_btn.Text = "Dokončit";
            }
            else
            {
                next_btn.Text = "Další";
            }

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


        private void dances_Shown(object sender, EventArgs e)
        {
            textBoxArr[0, 0].Focus();
        }

        private void dance_TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxArr[0, 0].Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void dances_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.UserClosing) return;
            DialogResult res = MessageBox.Show("Opravdu chcete odejít?", "Odejít", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
