namespace skating_system
{
    public partial class Form1 : Form
    {
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



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void next_btn_Click(object sender, EventArgs e)
        {
            if (!(int.TryParse(coupleCnt_TB.Text, out coupleCnt) && int.TryParse(judgeCnt_TB.Text, out judgeCnt) && int.TryParse(danceCnt_TB.Text, out danceCnt)))
            {
                MessageBox.Show("Špatný vstup", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(coupleCnt > 70 ||  judgeCnt > 70 || danceCnt > 50) {
                MessageBox.Show("Maximální počet párů, porotců nebo tancu překročen (70, 70, 50)", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            new dances().ShowDialog();


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


    }
}