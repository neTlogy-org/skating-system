namespace skating_system
{
    public partial class Form1 : Form
    {
        public static paramsForm paramsFormIns;
        static int coupleCnt;
        static int judgeCnt;
        static int danceCnt;
        public static int CoupleCnt { get => coupleCnt; set => coupleCnt = value; }
        public static int JudgeCnt { get => judgeCnt; set => judgeCnt = value; }
        public static int DanceCnt { get => danceCnt; set => danceCnt = value; }

        public Form1()
        {
            InitializeComponent();
        }

        private void next_btn_Click(object sender, EventArgs e)
        {
            if (!(int.TryParse(coupleCnt_TB.Text, out coupleCnt) && int.TryParse(judgeCnt_TB.Text, out judgeCnt) && int.TryParse(danceCnt_TB.Text, out danceCnt)))
            {
                MessageBox.Show("Špatný vstup", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (coupleCnt > 99 || judgeCnt > 26 || danceCnt > 50)
            {
                MessageBox.Show("Maximální počet párů, porotců nebo tancu překročen (99, 26, 50)", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (coupleCnt < 1 || judgeCnt < 1 || danceCnt < 1)
            {
                MessageBox.Show("Počet párů, porotců nebo tanců musí být větší než nula", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (JudgeCnt % 2 == 0)
            {
                MessageBox.Show("Počet porotců musí být lichý", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            paramsFormIns = new paramsForm();
            paramsFormIns.ShowDialog();

        }

        private void coupleCnt_TB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                judgeCnt_TB.Focus();
                e.Handled = true;
            }

        }
        private void judgeCnt_TB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                danceCnt_TB.Focus();
                e.Handled = true;
            }
        }

        private void danceCnt_TB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                next_btn.Focus();
                e.Handled = true;
            }

        }


        private void coupleCnt_TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                judgeCnt_TB.Focus();
                e.Handled = true;
            }
        }

        private void judgeCnt_TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                danceCnt_TB.Focus();
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                coupleCnt_TB.Focus();
                e.Handled = true;
            }

        }

        private void danceCnt_TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                next_btn.Focus();
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                judgeCnt_TB.Focus();
                e.Handled = true;
            }
        }

        private void next_btn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                danceCnt_TB.Focus();
                e.Handled = true;
            }
        }
    }
}