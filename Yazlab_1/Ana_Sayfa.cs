using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

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
            LoadTarifler();

        }

        private void LoadTarifler()
        {
            List<Tarifler> tariflerList = TarifMethodlar�.GetTarifler();

            // E�er liste bo�sa, kullan�c�y� bilgilendir
            if (tariflerList.Count == 0)
            {
                MessageBox.Show("Veritaban�nda hi� tarif yok!");
                return;
            }

            // DataGridView'�n veri kayna��n� ayarla
            dataGridView1.DataSource = tariflerList;

            // DataGridView'da sadece gerekli s�tunlar� g�ster
            dataGridView1.Columns["TarifAdi"].HeaderText = "Tarif Ad�"; // S�tun ba�l���n� de�i�tir
            dataGridView1.Columns["HazirlamaSuresi"].HeaderText = "Haz�rlama S�resi (dk)"; // S�tun ba�l���n� de�i�tir

            // Di�er s�tunlar� gizle
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Name != "TarifAdi" && column.Name != "HazirlamaSuresi")
                {
                    column.Visible = false; // Sadece istenen s�tunlar� g�ster
                }
            }
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
       


        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Se�ilen d���m� almak i�in 'e.Node' kullan�l�r
            TreeNode selectedNode = e.Node;

            // Se�ilen d���m�n text'ini bir mesaj kutusunda g�steriyoruz
            MessageBox.Show("Se�ilen d���m: " + selectedNode.Text);

            // �rnek: Farkl� d���mlere g�re farkl� i�lemler yapabilirsiniz
            if (selectedNode.Text == "Tatl�")
            {
                // Tatl� kategorisine t�klan�rsa yap�lacak i�lemler
                MessageBox.Show("Tatl� kategorisine t�klad�n�z!");
            }
            else if (selectedNode.Text == "Ana yemek")
            {
                // Ana yemek kategorisine t�klan�rsa yap�lacak i�lemler
                MessageBox.Show("Ana yemek kategorisine t�klad�n�z!");
            }
            // Di�er d���mler i�in de benzer kontroller yapabilirsiniz
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // TextBox'taki arama terimini al
            string searchTerm = textBox1.Text.Trim();

            // Arama fonksiyonunu �a��r ve sonucu DataGridView'e ba�la
            List<Tarifler> aramaSonuclari = TarifMethodlar�.SearchTarifler(searchTerm);
            dataGridView1.DataSource = aramaSonuclari;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

