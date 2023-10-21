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
        Label[] lines_y = new Label[dances.DancesArr.Length];
        Label[,] judge_names = new Label[Form1.JudgeCnt, Form1.DanceCnt];

        Label[] dancesNames = new Label[dances.DancesArr.Length];

        int[] spacing = { 40, 40, 40 };
        int[] offset = { 20, 20 };
        int headerSpace = 60;
        int headerOffset = 4;
        int size = 30;
        int maxTitleSize = 0;
        int judge_name_width = 25;
        public results()
        {

            InitializeComponent();

            for (int i = 0; i < dances.DancesArr.Length; i++)
            {
                DancesArr[i] = dances.DancesArr[i];
            }

            resultsStruct = placement.Evaluate();




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
            headerColumn.Width = 90;

            judge_lbl.Parent = panel1;
            judge_lbl.Text = "Porotce: ";
            judge_lbl.TextAlign = ContentAlignment.MiddleRight;
            judge_lbl.Visible = true;
            judge_lbl.Location = new Point(offset[0], offset[1] + spacing[1]);
            judge_lbl.Width = 90;

            for (int x = 0; x < DancesArr.Length; x++)
            {

                lines_y[x] = new Label
                {
                    AutoSize = false,
                    Text = "",
                    Parent = panel1,
                    Location = new Point(maxTitleSize + spacing[0] > Form1.JudgeCnt * judge_name_width ? headerColumn.Width + offset[0] + x * (spacing[0] + maxTitleSize) : headerColumn.Width + offset[0] + x * (Form1.JudgeCnt * judge_name_width), offset[1]),
                    Height = (Form1.CoupleCnt + 1) * spacing[1] + size,
                    Width = 2,
                    Visible = true,
                    BorderStyle = BorderStyle.Fixed3D


                };

                dancesNames[x] = new Label
                {
                    Text = DancesArr[x].Dance_title.ToString(),
                    Width = maxTitleSize + spacing[0] > Form1.JudgeCnt * judge_name_width ? maxTitleSize + 5 : Form1.JudgeCnt * judge_name_width,
                    Parent = panel1,
                    Visible = true,
                    Location = new Point(maxTitleSize + spacing[0] > Form1.JudgeCnt * judge_name_width ? x * (spacing[0] + maxTitleSize) + offset[0] + headerColumn.Width + 18 : x * (Form1.JudgeCnt * judge_name_width) + offset[0] + headerColumn.Width, offset[1] + headerOffset),
                    TextAlign = ContentAlignment.MiddleCenter,

                };
                for (int z = 0; z < Form1.JudgeCnt; z++)
                {
                    judge_names[x, z] = new Label
                    {
                        Text = Convert.ToChar('A' + z).ToString(),
                        Width = judge_name_width,
                        Parent = panel1,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Visible = true,
                        Location = new Point(maxTitleSize + spacing[0] > Form1.JudgeCnt * judge_name_width ? x * (spacing[0] + maxTitleSize) + offset[0] + headerColumn.Width + z * judge_name_width : x * (Form1.JudgeCnt * judge_name_width) + offset[0] + headerColumn.Width + z * judge_name_width, offset[1] + spacing[1])
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
                Width = maxTitleSize + spacing[0] > Form1.JudgeCnt * judge_name_width ? DancesArr.Length * (spacing[0] + maxTitleSize) + headerColumn.Width : DancesArr.Length * (Form1.JudgeCnt * judge_name_width) + headerColumn.Width,
                Visible = true,
                BorderStyle = BorderStyle.Fixed3D


            };
            /*Label line_y = new Label
            {
                AutoSize = false,
                Text = "",
                Parent = panel1,
                Location = new Point(headerColumn.Width + offset[0], offset[1]),
                Height = Form1.JudgeCnt * spacing[1] + size,
                Width = 2,
                Visible = true,
                BorderStyle = BorderStyle.Fixed3D


            };*/
        }
    }
}
