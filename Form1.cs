namespace skating_system
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void next_btn_Click(object sender, EventArgs e)
        {
            new dances().ShowDialog();
        }
    }
}