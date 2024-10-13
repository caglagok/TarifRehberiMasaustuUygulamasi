using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using Yazlab_1.Yazlab_1.Yazlab_1;

namespace Yazlab_1
{
    public partial class Ana_Sayfa : Form
    {
        private MalzemeMethodlarý malzemeMethodlarý; // MalzemeMethodlarý örneði

        public Ana_Sayfa()
        {
            InitializeComponent();
            malzemeMethodlarý = new MalzemeMethodlarý(); // Yeni örneði oluþtur
            dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView1_CellFormatting);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            LoadTarifler();
            LoadMalzemeler();

        }

        public void LoadTarifler()
        {
            List<Tarifler> tariflerList = TarifMethodlarý.GetTarifler();

            // Tarifleri DataGridView'e baðla
            dataGridView1.DataSource = tariflerList;

            // MaliyetHesaplama sýnýfýndan bir nesne oluþtur
            MaliyetHesaplama maliyetHesaplama = new MaliyetHesaplama();

            for (int i = 0; i < tariflerList.Count; i++)
            {
                int tarifID = tariflerList[i].TarifID;

                // MaliyetHesaplama sýnýfýndan TarifMaliyetiHesapla metodunu çaðýr
                decimal maliyet = maliyetHesaplama.TarifMaliyetiHesapla(tarifID);

                // Maliyeti ilgili sütuna ekle
                dataGridView1.Rows[i].Cells["Maliyet"].Value = maliyet;

                // Eþleþme yüzdesini ilgili sütuna ekle
                dataGridView1.Rows[i].Cells["EslestirmeYuzdesi"].Value = tariflerList[i].EslestirmeYuzdesi;
            }

            // DataGridView'da sadece gerekli sütunlarý göster
            dataGridView1.Columns["TarifAdi"].HeaderText = "Tarif Adý"; // Sütun baþlýðýný deðiþtir
            dataGridView1.Columns["HazirlamaSuresi"].HeaderText = "Hazýrlama Süresi (dk)"; // Sütun baþlýðýný deðiþtir
            dataGridView1.Columns["EslestirmeYuzdesi"].HeaderText = "Eþleþme Yüzdesi"; // Eþleþme yüzdesi sütun baþlýðýný ayarla

            // Diðer sütunlarý gizle
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Name != "TarifAdi" && column.Name != "HazirlamaSuresi" && column.Name != "Maliyet" && column.Name != "EslestirmeYuzdesi")
                {
                    column.Visible = false; // Sadece istenen sütunlarý göster
                }
            }
        }

        private void LoadMalzemeler()
        {
            List<Malzemeler> malzemeListesi = malzemeMethodlarý.GetMalzemeler();

            foreach (var malzeme in malzemeListesi)
            {
                checkedListBox1.Items.Add(malzeme.MalzemeAdi, false); // Malzemeleri ekle
            }
        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Maliyet sütununa göre satýr rengini deðiþtirme
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Maliyet")
            {
                // Hücre deðerinin null olmadýðýndan emin olun
                if (e.Value != null && decimal.TryParse(e.Value.ToString(), out decimal maliyet))
                {
                    // Eðer maliyet 0 ise yeþil, 0'dan büyükse kýrmýzý
                    if (maliyet == 0)
                    {
                        dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Green;
                    }
                    else if (maliyet > 0)
                    {
                        dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                    }
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

            // Eðer týklanan hücre, DataGridView'deki bir satýrda ise
            if (e.RowIndex >= 0)
            {
                // Seçilen tarifin ID'sini al
                int tarifID = (int)dataGridView1.Rows[e.RowIndex].Cells["TarifID"].Value;

                // Tarif detay formunu aç
                Tarif_Detay_Formu tarifDetayForm = new Tarif_Detay_Formu(tarifID);
                tarifDetayForm.ShowDialog();
            }

        }

        private List<TreeNode> selectedNodes = new List<TreeNode>(); // Seçili düðümleri tutacak liste

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Seçili düðümleri kontrol et ve listeyi güncelle
            if (selectedNodes.Contains(e.Node))
            {
                selectedNodes.Remove(e.Node);
                e.Node.BackColor = Color.White; // Seçim iptal edildiðinde rengi beyaz yap
            }
            else
            {
                selectedNodes.Add(e.Node);
                e.Node.BackColor = Color.LightGray; // Seçildiðinde rengi açýk gri yap
            }


        }

        // Seçilen filtrelere göre tarifleri filtrele
        private void button2_Click(object sender, EventArgs e)
        {
            // Kullanýcýdan alýnan arama terimini temizle
            string searchTerm = textBox1.Text.Trim();

            // ComboBox'tan sýralama kriterini al
            string selectedSortOrder = comboBox1.SelectedItem?.ToString(); // null kontrolü ekledik

            // Filtreleri ve arama terimini uygula
            List<Tarifler> aramaSonuclari = ApplyFilters(searchTerm, selectedSortOrder);

            // Veri kaynaðýný güncelle
            dataGridView1.DataSource = aramaSonuclari;
        }

        // Seçilen filtrelere ve arama terimine göre tarifleri filtrele
        private List<Tarifler> ApplyFilters(string searchTerm, string selectedSortOrder)
        {
            // Seçili düðümlerden kategorileri al
            List<string> selectedCategories = selectedNodes
                .Where(node => node.Parent != null && node.Parent.Text == "Kategori")
                .Select(node => node.Text)
                .ToList();

            // Seçili maliyet aralýklarýný al
            List<string> selectedCostRanges = selectedNodes
                .Where(node => node.Parent != null && node.Parent.Text == "Maliyet Aralýðý")
                .Select(node => node.Text)
                .ToList();

            // Seçili malzeme sayýsý aralýklarýný al
            List<string> selectedIngredientRanges = selectedNodes
                .Where(node => node.Parent != null && node.Parent.Text == "Malzeme Sayýsýna Göre")
                .Select(node => node.Text)
                .ToList();

            // Filtreyi uygulamak için arama fonksiyonunu çaðýr
            List<Tarifler> filtrelenmisTarifler = TarifMethodlarý.SearchTarifler(
                searchTerm, // Arama terimi
                selectedCategories, // Kategoriler listesi
                selectedCostRanges.Count > 0 ? string.Join(",", selectedCostRanges) : null, // Maliyet aralýðý
                selectedIngredientRanges.Count > 0 ? string.Join(",", selectedIngredientRanges) : null, // Malzeme sayýsý aralýðý
                selectedSortOrder // Sýralama kriteri
               
            );

            // Seçilen malzemeler varsa filtreleme yap
            if (checkedListBox1.CheckedItems.Count > 0)
            {
                // Eðer checkedListBox1 boþsa, boþ bir liste oluþtur
                List<string> selectedIngredients = checkedListBox1.CheckedItems.Cast<string>().ToList();

                // Sadece seçilen malzemeleri içeren tarifleri filtrele
                filtrelenmisTarifler = filtrelenmisTarifler
                    .Where(tarif =>
                        tarif.Malzemeler.All(m => selectedIngredients.Contains(m.MalzemeAdi) || !selectedIngredients.Contains(m.MalzemeAdi))
                        && tarif.Malzemeler.Any(m => selectedIngredients.Contains(m.MalzemeAdi))
                    ).ToList();

                // Eþleþme yüzdesini hesapla ve tarifleri sýrala
                foreach (var tarif in filtrelenmisTarifler)
                {
                    int totalSelectedIngredients = selectedIngredients.Count; // Kullanýcýnýn seçtiði malzeme sayýsý
                    int matchingIngredients = selectedIngredients.Count(m => tarif.Malzemeler.Any(t => t.MalzemeAdi == m)); // Seçilen malzemelerden tarifte olanlarýn sayýsý
                    decimal matchingPercentage = totalSelectedIngredients > 0 ? (decimal)matchingIngredients / totalSelectedIngredients * 100 : 0; // Eþleþme yüzdesi
                    tarif.EslestirmeYuzdesi = matchingPercentage;
                }


                // Yüzdeye göre sýrala
                filtrelenmisTarifler = filtrelenmisTarifler.OrderByDescending(t => t.EslestirmeYuzdesi).ToList();
            }

            return filtrelenmisTarifler;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }



        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

