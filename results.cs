using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace skating_system
{
    public partial class results : Form
    {
        Results resultsStruct;
        Dance[] DancesArr = new Dance[dances.DancesArr.Length];
        Placement placement = new Placement(dances.DancesArr);
        Label headerColumn = new Label();
        Label judge_lbl = new Label();
        Label[] lines_y = new Label[dances.DancesArr.Length + 1];
        Label[] lines_x = new Label[2];
        Label[,] judge_names = new Label[Form1.DanceCnt, Form1.JudgeCnt];
        Label[] couple_names = new Label[Form1.CoupleCnt];
        Label[,] couple_marks = new Label[Form1.JudgeCnt, Form1.CoupleCnt];
        Label[,] couple_dance_placement = new Label[Form1.DanceCnt, Form1.CoupleCnt];
        Label[] couple_totals = new Label[Form1.CoupleCnt];
        Dictionary<int, int> couple_names_dict = new Dictionary<int, int>();

        Label[] dancesNames = new Label[dances.DancesArr.Length];

        int[] spacing = { 40, 40, 40 };
        int[] offset = { 20, 20 };
        int headerSpace = 60;
        int headerOffset = 4;
        int size = 30;
        int maxTitleSize = 0;
        int judge_name_width = Form1.JudgeCnt > 1 ? 25 : 30;
        float scale;
        public results()
        {
            scale = (float)DeviceDpi / 96;
            InitializeComponent();

            for (int i = 0; i < dances.DancesArr.Length; i++)
            {
                DancesArr[i] = dances.DancesArr[i];
            }

            resultsStruct = placement.Evaluate();

            for (int i = 0; i < Form1.CoupleCnt; i++)
            {
                couple_names_dict[DancesArr[0].Couples_nums[i]] = i;
            }

            foreach (Dance dance in DancesArr)
            {
                int width = TextRenderer.MeasureText(dance.Dance_title, new Font("Segoe UI", 9)).Width;
                if (width > maxTitleSize)
                {
                    maxTitleSize = width;
                }
            }

            headerColumn.Parent = panel1;
            headerColumn.Text = "Název tance: ";
            headerColumn.TextAlign = ContentAlignment.MiddleRight;
            headerColumn.Visible = true;
            headerColumn.Location = new Point(offset[0], offset[1] + headerOffset);
            headerColumn.Width = (int)(scale * 90);

            judge_lbl.Parent = panel1;
            judge_lbl.Text = "Porotce: ";
            judge_lbl.TextAlign = ContentAlignment.MiddleRight;
            judge_lbl.Visible = true;
            judge_lbl.Location = new Point(offset[0], offset[1] + spacing[1]);
            judge_lbl.Width = (int)(scale * 90);

            lines_y[DancesArr.Length] = new Label
            {
                AutoSize = false,
                Text = "",
                Parent = panel1,
                Location = new Point(maxTitleSize + spacing[0] > Form1.JudgeCnt * judge_name_width ? headerColumn.Width + offset[0] + (int)(scale * DancesArr.Length * (spacing[0] + maxTitleSize)) : headerColumn.Width + offset[0] + (int)(scale * DancesArr.Length * (Form1.JudgeCnt * judge_name_width)), offset[1]),
                Height = Convert.ToInt32((Form1.CoupleCnt + 1) * 1.5 * spacing[1] + size),
                Width = 2,
                Visible = true,
                BorderStyle = BorderStyle.Fixed3D
            };

            Label sum = new Label
            {
                Text = "Součet",
                Parent = panel1,
                TextAlign = ContentAlignment.MiddleCenter,
                Visible = true,
                Location = new Point(maxTitleSize + spacing[0] > Form1.JudgeCnt * judge_name_width ? (int)(scale * DancesArr.Length * (spacing[0] + maxTitleSize)) + offset[0] + headerColumn.Width : (int)(scale * DancesArr.Length * (Form1.JudgeCnt * judge_name_width)) + offset[0] + headerColumn.Width, offset[1] + spacing[1] / 2),
                Width = (int)(scale * 50),
            };

            var order = resultsStruct.placement.OrderBy(x => x.Value).ToList();

            for (int x = 0; x < DancesArr.Length; x++)
            {
                lines_y[x] = new Label
                {
                    AutoSize = false,
                    Text = "",
                    Parent = panel1,
                    Location = new Point(maxTitleSize + spacing[0] > Form1.JudgeCnt * judge_name_width ? headerColumn.Width + offset[0] + (int)(scale * x * (spacing[0] + maxTitleSize)) : headerColumn.Width + offset[0] + (int)(scale * x * (Form1.JudgeCnt * judge_name_width)), offset[1]),
                    Height = Convert.ToInt32((Form1.CoupleCnt + 1) * 1.5 * spacing[1] + size),
                    Width = 2,
                    Visible = true,
                    BorderStyle = BorderStyle.Fixed3D
                };

                dancesNames[x] = new Label
                {
                    Text = DancesArr[x].Dance_title.ToString(),
                    Width = maxTitleSize + spacing[0] > Form1.JudgeCnt * judge_name_width ? (int)(scale * maxTitleSize) + 5 : (int)(scale * Form1.JudgeCnt * judge_name_width),
                    Parent = panel1,
                    Visible = true,
                    Location = new Point(maxTitleSize + spacing[0] > Form1.JudgeCnt * judge_name_width ? (int)(scale * x * (spacing[0] + maxTitleSize)) + offset[0] + headerColumn.Width + (int)(scale * 18) : (int)(scale * x * (Form1.JudgeCnt * judge_name_width)) + offset[0] + headerColumn.Width, offset[1] + headerOffset),
                    TextAlign = ContentAlignment.MiddleCenter,

                };
                for (int z = 0; z < Form1.JudgeCnt; z++)
                {
                    judge_names[x, z] = new Label
                    {
                        Text = Convert.ToChar('A' + z).ToString(),
                        Width = (int)(scale * judge_name_width),
                        Parent = panel1,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Visible = true,
                        Location = new Point(maxTitleSize + spacing[0] > Form1.JudgeCnt * judge_name_width ? (int)(scale * x * (spacing[0] + maxTitleSize)) + offset[0] + headerColumn.Width + (int)(scale * z * judge_name_width) : (int)(scale * x * (Form1.JudgeCnt * judge_name_width)) + offset[0] + headerColumn.Width + (int)(scale * z * judge_name_width), offset[1] + spacing[1])
                    };
                }
                for (int y = 0; y < Form1.CoupleCnt; y++)
                {
                    if (x == 0)
                    {
                        string place = order[y].Value.ToString("F1");
                        string spaces = "";
                        for(int i = 0; i < 8 - place.Length; i++)
                        {
                            spaces += " ";
                        }
                        place += spaces;
                        couple_names[y] = new Label
                        {
                            Text = $"{place}Pár č. {order[y].Key} ",
                            Width = (int)(scale * 100),
                            Parent = panel1,
                            TextAlign = ContentAlignment.MiddleRight,
                            Visible = true,
                            Location = new Point(offset[0] - (int)(scale * 10), Convert.ToInt32(offset[1] + (y + 1.25) * spacing[1] * 1.5)),
                        };
                    }
                    couple_totals[y] = new Label
                    {
                        Text = resultsStruct.total[order[y].Key].ToString(),
                        Width = (int)(scale * 50),
                        Parent = panel1,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Visible = true,
                        Location = new Point(maxTitleSize + spacing[0] > Form1.JudgeCnt * judge_name_width ? (int)(scale * DancesArr.Length * (spacing[0] + maxTitleSize)) + offset[0] + headerColumn.Width : (int)(scale * DancesArr.Length * (Form1.JudgeCnt * judge_name_width)) + offset[0] + headerColumn.Width, Convert.ToInt32((offset[1] + (y + 1.25) * spacing[1] * 1.5)))
                    };

                    for (int z = 0; z < Form1.JudgeCnt; z++)
                    {
                        couple_marks[z, y] = new Label
                        {
                            Text = DancesArr[x].Marks[couple_names_dict[order[y].Key]][z].ToString(),
                            Width = (int)(scale * judge_name_width),
                            Parent = panel1,
                            TextAlign = ContentAlignment.MiddleCenter,
                            Visible = true,
                            Location = new Point(maxTitleSize + spacing[0] > Form1.JudgeCnt * judge_name_width ? (int)(scale * x * (spacing[0] + maxTitleSize)) + offset[0] + headerColumn.Width + (int)(scale * z * judge_name_width) : (int)(scale * x * (Form1.JudgeCnt * judge_name_width)) + offset[0] + headerColumn.Width + (int)(scale * z * judge_name_width), Convert.ToInt32(offset[1] + (y + 1.25) * spacing[1] * 1.5))

                        };
                    }
                    couple_dance_placement[x, y] = new Label
                    {
                        Text = $"({resultsStruct.individual[DancesArr[x].Dance_title][order[y].Key]})",
                        Width = (int)(scale * Form1.JudgeCnt * judge_name_width),
                        Parent = panel1,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Visible = true,
                        Location = new Point(maxTitleSize + spacing[0] > Form1.JudgeCnt * judge_name_width ? (int)(scale * x * (spacing[0] + maxTitleSize)) + offset[0] + headerColumn.Width : (int)(scale * x * (Form1.JudgeCnt * judge_name_width)) + offset[0] + headerColumn.Width, Convert.ToInt32(offset[1] + size * 0.75 + (y + 1.25) * spacing[1] * 1.5)),
                    };
                }
            }

            lines_x[0] = new Label
            {
                AutoSize = false,
                Text = "",
                Parent = panel1,
                Location = new Point(offset[0], offset[1] + size),
                Height = 2,
                Width = (int)(scale * 2) + (maxTitleSize + spacing[0] > Form1.JudgeCnt * judge_name_width ? (int)(scale * DancesArr.Length * (spacing[0] + maxTitleSize)) + headerColumn.Width : (int)(scale * DancesArr.Length * (Form1.JudgeCnt * judge_name_width)) + headerColumn.Width),
                Visible = true,
                BorderStyle = BorderStyle.Fixed3D
            };

            lines_x[1] = new Label
            {
                AutoSize = false,
                Text = "",
                Parent = panel1,
                Location = new Point(offset[0], offset[1] + size + spacing[1]),
                Height = 2,
                Width = (int)(scale * 50) + (maxTitleSize + spacing[0] > Form1.JudgeCnt * judge_name_width ? (int)(scale * DancesArr.Length * (spacing[0] + maxTitleSize)) + headerColumn.Width : (int)(scale * DancesArr.Length * (Form1.JudgeCnt * judge_name_width)) + headerColumn.Width),
                Visible = true,
                BorderStyle = BorderStyle.Fixed3D
            };
        }

        private void export_btn_Click(object sender, EventArgs e)
        {
            string path;
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
                sfd.FileName = Form1.ContestName;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    path = sfd.FileName;
                }
                else
                {
                    return;
                }
            }
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine($"Název soutěže: {Form1.ContestName}");
                writer.WriteLine("Datum: " + DateTime.Today.ToString("dd. MMMM yyyy"));
                writer.WriteLine();

                writer.Write("Název tance\t");
                foreach (var dance in dances.DancesArr)
                {
                    if (dance.Dance_title.Length > 7)
                        writer.Write(dance.Dance_title + "\t");
                    else
                        writer.Write(dance.Dance_title + "\t\t");
                }
                writer.WriteLine("Součet");

                var sorted_couples = resultsStruct.total.OrderBy(pair => pair.Value);
                foreach (var pair in sorted_couples)
                {
                    if (pair.Key <= 1) 
                        writer.Write($"{pair.Key} ({resultsStruct.placement[pair.Key]:0.0})\t\t");
                    else
                        writer.Write($"{pair.Key} ({resultsStruct.placement[pair.Key]:0.0})\t");
                    foreach (var dance in dances.DancesArr)
                        writer.Write($"{resultsStruct.rating[pair.Key][dance.Dance_title]} ({resultsStruct.individual[dance.Dance_title][pair.Key]:0.0})\t");
                    writer.WriteLine($"{pair.Value:0.0}");
                }
            }

            MessageBox.Show($"Exportováno do {path}", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Opravdu chcete odejít?", "Odejít", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
        }
    }
}
