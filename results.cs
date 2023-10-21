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

        Label[] dancesNames = new Label[dances.DancesArr.Length];

        int[] spacing = { 40, 40, 40 };
        int[] offset = { 20, 20 };
        int headerSpace = 60;
        int headerOffset = 4;
        int size = 30;
        int maxTitleSize = 0;
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
            headerColumn.Text = "Název tance:";
            headerColumn.TextAlign = ContentAlignment.MiddleRight;
            headerColumn.Visible = true;
            headerColumn.Location = new Point(offset[0], offset[1] + headerOffset);
            headerColumn.Width = 90;

            judge_lbl.Parent = panel1;
            judge_lbl.Text = "Porotce:";
            judge_lbl.TextAlign = ContentAlignment.MiddleRight;
            judge_lbl.Visible = true;
            judge_lbl.Location = new Point(offset[0], offset[1] + headerOffset + spacing[1]);
            judge_lbl.Width = 90;

            for (int x = 0; x < DancesArr.Length; x++)
            {

                lines_y[x] = new Label
                {
                    AutoSize = false,
                    Text = "",
                    Parent = panel1,
                    Location = new Point(headerColumn.Width + offset[0] + x * (spacing[0] + maxTitleSize), offset[1]),
                    Height = (Form1.CoupleCnt+1) * spacing[1] + size,
                    Width = 2,
                    Visible = true,
                    BorderStyle = BorderStyle.Fixed3D


                };

                dancesNames[x] = new Label
                {
                    Text = DancesArr[x].Dance_title.ToString(),
                    Width = maxTitleSize + 5,
                    Parent = panel1,
                    Visible = true,
                    Location = new Point(x * (spacing[0] + maxTitleSize) + offset[0] + headerColumn.Width + 18, offset[1] + headerOffset),
                    TextAlign = ContentAlignment.MiddleCenter

                };
            }

            Label line_x = new Label
            {
                AutoSize = false,
                Text = "",
                Parent = panel1,
                Location = new Point(offset[0], offset[1] + size),
                Height = 2,
                Width = DancesArr.Length * (spacing[0] + maxTitleSize) + headerColumn.Width,
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
