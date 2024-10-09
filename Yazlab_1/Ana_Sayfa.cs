namespace Yazlab_1
{
    public partial class Ana_Sayfa : Form
    {
        public Ana_Sayfa()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Tarif_Ekleme_Formu tarifEkleForm = new Tarif_Ekleme_Formu();
            tarifEkleForm.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        { 
            Malzeme_Ekleme malzemeEkleForm = new Malzeme_Ekleme();
            malzemeEkleForm.ShowDialog();
        }
    }
}
