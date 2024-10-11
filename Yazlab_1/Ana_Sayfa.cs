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
            List<Tarifler> tariflerList = TarifMethodlarý.GetTarifler();

            // Eðer liste boþsa, kullanýcýyý bilgilendir
            if (tariflerList.Count == 0)
            {
                MessageBox.Show("Veritabanýnda hiç tarif yok!");
                return;
            }

            // DataGridView'ýn veri kaynaðýný ayarla
            dataGridView1.DataSource = tariflerList;

            // DataGridView'da sadece gerekli sütunlarý göster
            dataGridView1.Columns["TarifAdi"].HeaderText = "Tarif Adý"; // Sütun baþlýðýný deðiþtir
            dataGridView1.Columns["HazirlamaSuresi"].HeaderText = "Hazýrlama Süresi (dk)"; // Sütun baþlýðýný deðiþtir

            // Diðer sütunlarý gizle
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Name != "TarifAdi" && column.Name != "HazirlamaSuresi")
                {
                    column.Visible = false; // Sadece istenen sütunlarý göster
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
            // Seçilen düðümü almak için 'e.Node' kullanýlýr
            TreeNode selectedNode = e.Node;

            // Seçilen düðümün text'ini bir mesaj kutusunda gösteriyoruz
            MessageBox.Show("Seçilen düðüm: " + selectedNode.Text);

            // Örnek: Farklý düðümlere göre farklý iþlemler yapabilirsiniz
            if (selectedNode.Text == "Tatlý")
            {
                // Tatlý kategorisine týklanýrsa yapýlacak iþlemler
                MessageBox.Show("Tatlý kategorisine týkladýnýz!");
            }
            else if (selectedNode.Text == "Ana yemek")
            {
                // Ana yemek kategorisine týklanýrsa yapýlacak iþlemler
                MessageBox.Show("Ana yemek kategorisine týkladýnýz!");
            }
            // Diðer düðümler için de benzer kontroller yapabilirsiniz
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // TextBox'taki arama terimini al
            string searchTerm = textBox1.Text.Trim();

            // Arama fonksiyonunu çaðýr ve sonucu DataGridView'e baðla
            List<Tarifler> aramaSonuclari = TarifMethodlarý.SearchTarifler(searchTerm);
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

