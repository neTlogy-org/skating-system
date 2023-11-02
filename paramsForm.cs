using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace skating_system
{
    public partial class paramsForm : Form
    {
        public static bool dancesOpened = false;
        static TextBox[] dancesNames = new TextBox[Form1.DanceCnt];
        static TextBox[] coupleNums = new TextBox[Form1.CoupleCnt];

        public static TextBox[] DancesNames { get => dancesNames; }
        public static TextBox[] CoupleNums { get => coupleNums; }

        int[] spacing = { 41, 30 };
        int[] offset = { 20, 10 };
        int size = 30;
        float scale; 
        public paramsForm()
        {
            InitializeComponent();
            scale = (float)DeviceDpi / 96;
            for (int i = 0; i < Form1.DanceCnt; i++)
            {
                dancesNames[i] = new TextBox();
                dancesNames[i].Parent = panel1;
                dancesNames[i].Location = new Point(offset[0], (int)(scale * i * spacing[1] + offset[1]));
                dancesNames[i].Width = panel1.Width - 2 * offset[0];
                dancesNames[i].Visible = true;
                dancesNames[i].KeyDown += dances_tb_keyDown;
            }
            for (int i = 0; i < Form1.CoupleCnt; i++)
            {
                coupleNums[i] = new TextBox();
                coupleNums[i].Parent = panel2;
                coupleNums[i].Location = new Point((int)(scale * (i % 12) * spacing[0]) + offset[0], (int)Math.Floor((double)i / 12) * spacing[1] + offset[1]);
                coupleNums[i].Width = (int)(scale * size);
                coupleNums[i].KeyDown += coupleNums_tb_KeyDown;
            }
            if (Form1.DanceCnt < 4)
            {
                stt4_btn.Enabled = false;
                stt5_btn.Enabled = false;
                lat4_btn.Enabled = false;
                lat5_btn.Enabled = false;
            }
            else if (Form1.DanceCnt < 5)
            {
                stt5_btn.Enabled = false;
                lat5_btn.Enabled = false;
            }
        }
        private void dances_tb_keyDown(object sender, KeyEventArgs e)
        {
            int index = Array.IndexOf(dancesNames, sender);
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                if (index == dancesNames.Length - 1)
                {
                    coupleNums[0].Focus();
                }
                else
                {
                    dancesNames[index + 1].Focus();
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                if (index == dancesNames.Length - 1)
                {
                    coupleNums[0].Focus();
                }
                else
                {
                    dancesNames[index + 1].Focus();
                }
            }
            if (e.KeyCode == Keys.Up)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                if (index > 0)
                {
                    dancesNames[index - 1].Focus();
                }
            }
        }
        private void coupleNums_tb_KeyDown(object sender, KeyEventArgs e)
        {
            int index = Array.IndexOf(coupleNums, sender);
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                if (index == coupleNums.Length - 1)
                {
                    next_btn.Focus();
                }
                else
                {
                    coupleNums[index + 1].Focus();
                }
            }
            if (e.KeyCode == Keys.Right)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                if (index == coupleNums.Length - 1)
                {
                    coupleNums[0].Focus();
                }
                else
                {
                    coupleNums[index + 1].Focus();
                }
            }
            if (e.KeyCode == Keys.Left)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                if (index > 0)
                {
                    coupleNums[index - 1].Focus();
                }
                else
                {
                    dancesNames[0].Focus();
                }
            }
        }
        private void next_btn_Click(object sender, EventArgs e)
        {
            foreach (TextBox danceName in dancesNames)
            {
                if (danceName.Text.Trim() == "")
                {
                    MessageBox.Show("Špatný název tance", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (Array.FindAll(dancesNames, e => e.Text == danceName.Text).Length > 1)
                {
                    MessageBox.Show($"Dva tance mají stejný název (\"{danceName.Text}\")", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            }
            foreach (TextBox coupleNum in coupleNums)
            {
                try
                {
                    Convert.ToInt32(coupleNum.Text);
                }
                catch
                {
                    MessageBox.Show("Špatné číslo páru", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (Array.FindAll(coupleNums, e => e.Text == coupleNum.Text).Length > 1)
                {
                    MessageBox.Show($"Dva páry mají stejné číslo (\"{coupleNum.Text}\")", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (coupleNum.Text.Length > 3)
                {
                    MessageBox.Show("Číslo páru může být maximálně 3 ciferné", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            new dances().ShowDialog();

        }


        private void paramsForm_FormClosing(object sender, FormClosingEventArgs e)
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

        string[] stt4 = { "Waltz", "Tango", "Valčík", "Quickstep"};
        string[] lat4 = { "Chacha", "Samba", "Rumba", "Jive"};
        string[] stt5 = { "Waltz", "Tango", "Valčík", "Slowfox", "Quickstep"};
        string[] lat5 = { "Chacha", "Samba", "Rumba", "Paso Doble", "Jive"};

        private void stt4_btn_Click(object sender, EventArgs e)
        {
            foreach (TextBox dance in dancesNames)
            {
                dance.Text = "";
            }
            for (int i = 0; i < 4; i++)
            {
                dancesNames[i].Text = stt4[i];
            }
        }

        private void stt5_btn_Click(object sender, EventArgs e)
        {
            foreach (TextBox dance in dancesNames)
            {
                dance.Text = "";
            }
            for (int i = 0; i < 5; i++)
            {
                dancesNames[i].Text = stt5[i];
            }
        }

        private void lat4_btn_Click(object sender, EventArgs e)
        {
            foreach (TextBox dance in dancesNames)
            {
                dance.Text = "";
            }
            for (int i = 0; i < 4; i++)
            {
                dancesNames[i].Text = lat4[i];
            }
        }

        private void lat5_btn_Click(object sender, EventArgs e)
        {
            foreach (TextBox dance in dancesNames)
            {
                dance.Text = "";
            }
            for (int i = 0; i < 5; i++)
            {
                dancesNames[i].Text = lat5[i];
            }
        }
    }
}
