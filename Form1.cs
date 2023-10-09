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
            CoupleCnt = Convert.ToInt32(coupleCnt_TB.Text);
            new dances().ShowDialog();


        }
    }
}