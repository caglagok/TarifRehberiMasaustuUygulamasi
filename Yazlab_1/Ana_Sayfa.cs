using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using Yazlab_1.Yazlab_1.Yazlab_1;

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

        public void LoadTarifler()
        {
            List<Tarifler> tariflerList = TarifMethodlarý.GetTarifler();

            // Tarifleri DataGridView'e baðla
            dataGridView1.DataSource = tariflerList;



            // MaliyetHesaplama sýnýfýndan bir nesne oluþtur
            MaliyetHesaplama maliyetHesaplama = new MaliyetHesaplama();

            // Tariflerin maliyetini hesapla ve yeni sütuna ekle
            for (int i = 0; i < tariflerList.Count; i++)
            {
                int tarifID = tariflerList[i].TarifID;

                // Tarif ID'yi kontrol et
                Console.WriteLine($"Tarif ID: {tarifID}");

                // MaliyetHesaplama sýnýfýndan TarifMaliyetiHesapla metodunu çaðýr
                decimal maliyet = maliyetHesaplama.TarifMaliyetiHesapla(tarifID);

                // Maliyeti ilgili sütuna ekle
                dataGridView1.Rows[i].Cells["Maliyet"].Value = maliyet;
            }

            // DataGridView'da sadece gerekli sütunlarý göster
            dataGridView1.Columns["TarifAdi"].HeaderText = "Tarif Adý"; // Sütun baþlýðýný deðiþtir
            dataGridView1.Columns["HazirlamaSuresi"].HeaderText = "Hazýrlama Süresi (dk)"; // Sütun baþlýðýný deðiþtir

            // Diðer sütunlarý gizle
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Name != "TarifAdi" && column.Name != "HazirlamaSuresi" && column.Name != "Maliyet")
                {
                    column.Visible = false; // Sadece istenen sütunlarý göster
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Tarif_Ekleme_Formu tarifEklemeFormu = new Tarif_Ekleme_Formu(this); // 'this' ile mevcut Ana_Sayfa formunu geçiyoruz
            tarifEklemeFormu.Show();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            Malzeme_Ekleme malzemeEkleForm = new Malzeme_Ekleme();
            malzemeEkleForm.ShowDialog();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {



        }

        private List<TreeNode> selectedNodes = new List<TreeNode>(); // Seçili düðümleri tutacak liste

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Seçili düðümleri kontrol et ve listeyi güncelle
            if (selectedNodes.Contains(e.Node))
            {
                selectedNodes.Remove(e.Node);
                e.Node.BackColor = Color.White;
            }
            else
            {
                selectedNodes.Add(e.Node);
                e.Node.BackColor = Color.LightGray;
            }

            ApplyFilters(); // Filtreleri uygula
        }

        // Seçilen filtrelere göre tarifleri filtrele
        private void ApplyFilters()
        {
            // Seçilen kategoriler
            var selectedCategories = selectedNodes
                .Where(node => node.Parent != null && node.Parent.Text == "Kategori")
                .Select(node => node.Text).ToList();

            // Seçilen maliyet aralýðý
            var selectedCostRange = selectedNodes
                .FirstOrDefault(node => node.Parent != null && node.Parent.Text == "Maliyet Aralýðý")?.Text;

            // Seçilen malzeme sayýsý aralýðý
            var selectedIngredientRange = selectedNodes
                .FirstOrDefault(node => node.Parent != null && node.Parent.Text == "Malzeme Sayýsýna Göre")?.Text;

            // Filtreyi uygulamak için arama fonksiyonunu çaðýr
            List<Tarifler> filtrelenmisTarifler = TarifMethodlarý.SearchTarifler("", selectedCategories.FirstOrDefault(), selectedCostRange, selectedIngredientRange);
            dataGridView1.DataSource = filtrelenmisTarifler;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string searchTerm = textBox1.Text.Trim();
            List<Tarifler> aramaSonuclari = TarifMethodlarý.SearchTarifler(searchTerm, "", "", "");
            dataGridView1.DataSource = aramaSonuclari;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }
    }
}

