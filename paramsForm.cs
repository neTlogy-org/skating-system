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
        public paramsForm()
        {
            InitializeComponent();
            for (int i = 0; i < Form1.DanceCnt; i++)
            {
                dancesNames[i] = new TextBox();
                dancesNames[i].Parent = panel1;
                dancesNames[i].Location = new Point(offset[0], i * spacing[1] + offset[1]);
                dancesNames[i].Width = panel1.Width - 2 * offset[0];
                dancesNames[i].Visible = true;
                dancesNames[i].KeyDown += dances_tb_keyDown;
            }
            for (int i = 0; i < Form1.CoupleCnt; i++)
            {
                coupleNums[i] = new TextBox();
                coupleNums[i].Parent = panel2;
                coupleNums[i].Location = new Point((i % 12) * spacing[0] + offset[0], (int)Math.Floor((double)i / 12) * spacing[1] + offset[1]);
                coupleNums[i].Width = size;
                coupleNums[i].KeyDown += coupleNums_tb_KeyDown;

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
                if (danceName.Text == "")
                {
                    MessageBox.Show("Špatný název tance", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            }
            new dances().ShowDialog();
            
        }

        private void paramsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(!dancesOpened)
                Program.form1.Close();
        }
    }
}
