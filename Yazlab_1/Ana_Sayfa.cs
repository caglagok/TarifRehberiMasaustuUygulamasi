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
            List<Tarifler> tariflerList = TarifMethodlar�.GetTarifler();

            // Tarifleri DataGridView'e ba�la
            dataGridView1.DataSource = tariflerList;



            // MaliyetHesaplama s�n�f�ndan bir nesne olu�tur
            MaliyetHesaplama maliyetHesaplama = new MaliyetHesaplama();

            // Tariflerin maliyetini hesapla ve yeni s�tuna ekle
            for (int i = 0; i < tariflerList.Count; i++)
            {
                int tarifID = tariflerList[i].TarifID;

                // Tarif ID'yi kontrol et
                Console.WriteLine($"Tarif ID: {tarifID}");

                // MaliyetHesaplama s�n�f�ndan TarifMaliyetiHesapla metodunu �a��r
                decimal maliyet = maliyetHesaplama.TarifMaliyetiHesapla(tarifID);

                // Maliyeti ilgili s�tuna ekle
                dataGridView1.Rows[i].Cells["Maliyet"].Value = maliyet;
            }

            // DataGridView'da sadece gerekli s�tunlar� g�ster
            dataGridView1.Columns["TarifAdi"].HeaderText = "Tarif Ad�"; // S�tun ba�l���n� de�i�tir
            dataGridView1.Columns["HazirlamaSuresi"].HeaderText = "Haz�rlama S�resi (dk)"; // S�tun ba�l���n� de�i�tir

            // Di�er s�tunlar� gizle
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Name != "TarifAdi" && column.Name != "HazirlamaSuresi" && column.Name != "Maliyet")
                {
                    column.Visible = false; // Sadece istenen s�tunlar� g�ster
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Tarif_Ekleme_Formu tarifEklemeFormu = new Tarif_Ekleme_Formu(this); // 'this' ile mevcut Ana_Sayfa formunu ge�iyoruz
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

        private List<TreeNode> selectedNodes = new List<TreeNode>(); // Se�ili d���mleri tutacak liste

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Se�ili d���mleri kontrol et ve listeyi g�ncelle
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

        // Se�ilen filtrelere g�re tarifleri filtrele
        private void ApplyFilters()
        {
            // Se�ilen kategoriler
            var selectedCategories = selectedNodes
                .Where(node => node.Parent != null && node.Parent.Text == "Kategori")
                .Select(node => node.Text).ToList();

            // Se�ilen maliyet aral���
            var selectedCostRange = selectedNodes
                .FirstOrDefault(node => node.Parent != null && node.Parent.Text == "Maliyet Aral���")?.Text;

            // Se�ilen malzeme say�s� aral���
            var selectedIngredientRange = selectedNodes
                .FirstOrDefault(node => node.Parent != null && node.Parent.Text == "Malzeme Say�s�na G�re")?.Text;

            // Filtreyi uygulamak i�in arama fonksiyonunu �a��r
            List<Tarifler> filtrelenmisTarifler = TarifMethodlar�.SearchTarifler("", selectedCategories.FirstOrDefault(), selectedCostRange, selectedIngredientRange);
            dataGridView1.DataSource = filtrelenmisTarifler;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string searchTerm = textBox1.Text.Trim();
            List<Tarifler> aramaSonuclari = TarifMethodlar�.SearchTarifler(searchTerm, "", "", "");
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

