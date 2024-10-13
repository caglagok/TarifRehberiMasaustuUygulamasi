using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using Yazlab_1.Yazlab_1.Yazlab_1;

namespace Yazlab_1
{
    public partial class Ana_Sayfa : Form
    {
        private MalzemeMethodlar� malzemeMethodlar�; // MalzemeMethodlar� �rne�i

        public Ana_Sayfa()
        {
            InitializeComponent();
            malzemeMethodlar� = new MalzemeMethodlar�(); // Yeni �rne�i olu�tur
            dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView1_CellFormatting);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            LoadTarifler();
            LoadMalzemeler();

        }

        public void LoadTarifler()
        {
            List<Tarifler> tariflerList = TarifMethodlar�.GetTarifler();

            // Tarifleri DataGridView'e ba�la
            dataGridView1.DataSource = tariflerList;

            // MaliyetHesaplama s�n�f�ndan bir nesne olu�tur
            MaliyetHesaplama maliyetHesaplama = new MaliyetHesaplama();

            for (int i = 0; i < tariflerList.Count; i++)
            {
                int tarifID = tariflerList[i].TarifID;

                // MaliyetHesaplama s�n�f�ndan TarifMaliyetiHesapla metodunu �a��r
                decimal maliyet = maliyetHesaplama.TarifMaliyetiHesapla(tarifID);

                // Maliyeti ilgili s�tuna ekle
                dataGridView1.Rows[i].Cells["Maliyet"].Value = maliyet;

                // E�le�me y�zdesini ilgili s�tuna ekle
                dataGridView1.Rows[i].Cells["EslestirmeYuzdesi"].Value = tariflerList[i].EslestirmeYuzdesi;
            }

            // DataGridView'da sadece gerekli s�tunlar� g�ster
            dataGridView1.Columns["TarifAdi"].HeaderText = "Tarif Ad�"; // S�tun ba�l���n� de�i�tir
            dataGridView1.Columns["HazirlamaSuresi"].HeaderText = "Haz�rlama S�resi (dk)"; // S�tun ba�l���n� de�i�tir
            dataGridView1.Columns["EslestirmeYuzdesi"].HeaderText = "E�le�me Y�zdesi"; // E�le�me y�zdesi s�tun ba�l���n� ayarla

            // Di�er s�tunlar� gizle
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Name != "TarifAdi" && column.Name != "HazirlamaSuresi" && column.Name != "Maliyet" && column.Name != "EslestirmeYuzdesi")
                {
                    column.Visible = false; // Sadece istenen s�tunlar� g�ster
                }
            }
        }

        private void LoadMalzemeler()
        {
            List<Malzemeler> malzemeListesi = malzemeMethodlar�.GetMalzemeler();

            foreach (var malzeme in malzemeListesi)
            {
                checkedListBox1.Items.Add(malzeme.MalzemeAdi, false); // Malzemeleri ekle
            }
        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Maliyet s�tununa g�re sat�r rengini de�i�tirme
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Maliyet")
            {
                // H�cre de�erinin null olmad���ndan emin olun
                if (e.Value != null && decimal.TryParse(e.Value.ToString(), out decimal maliyet))
                {
                    // E�er maliyet 0 ise ye�il, 0'dan b�y�kse k�rm�z�
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

            // E�er t�klanan h�cre, DataGridView'deki bir sat�rda ise
            if (e.RowIndex >= 0)
            {
                // Se�ilen tarifin ID'sini al
                int tarifID = (int)dataGridView1.Rows[e.RowIndex].Cells["TarifID"].Value;

                // Tarif detay formunu a�
                Tarif_Detay_Formu tarifDetayForm = new Tarif_Detay_Formu(tarifID);
                tarifDetayForm.ShowDialog();
            }

        }

        private List<TreeNode> selectedNodes = new List<TreeNode>(); // Se�ili d���mleri tutacak liste

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Se�ili d���mleri kontrol et ve listeyi g�ncelle
            if (selectedNodes.Contains(e.Node))
            {
                selectedNodes.Remove(e.Node);
                e.Node.BackColor = Color.White; // Se�im iptal edildi�inde rengi beyaz yap
            }
            else
            {
                selectedNodes.Add(e.Node);
                e.Node.BackColor = Color.LightGray; // Se�ildi�inde rengi a��k gri yap
            }


        }

        // Se�ilen filtrelere g�re tarifleri filtrele
        private void button2_Click(object sender, EventArgs e)
        {
            // Kullan�c�dan al�nan arama terimini temizle
            string searchTerm = textBox1.Text.Trim();

            // ComboBox'tan s�ralama kriterini al
            string selectedSortOrder = comboBox1.SelectedItem?.ToString(); // null kontrol� ekledik

            // Filtreleri ve arama terimini uygula
            List<Tarifler> aramaSonuclari = ApplyFilters(searchTerm, selectedSortOrder);

            // Veri kayna��n� g�ncelle
            dataGridView1.DataSource = aramaSonuclari;
        }

        // Se�ilen filtrelere ve arama terimine g�re tarifleri filtrele
        private List<Tarifler> ApplyFilters(string searchTerm, string selectedSortOrder)
        {
            // Se�ili d���mlerden kategorileri al
            List<string> selectedCategories = selectedNodes
                .Where(node => node.Parent != null && node.Parent.Text == "Kategori")
                .Select(node => node.Text)
                .ToList();

            // Se�ili maliyet aral�klar�n� al
            List<string> selectedCostRanges = selectedNodes
                .Where(node => node.Parent != null && node.Parent.Text == "Maliyet Aral���")
                .Select(node => node.Text)
                .ToList();

            // Se�ili malzeme say�s� aral�klar�n� al
            List<string> selectedIngredientRanges = selectedNodes
                .Where(node => node.Parent != null && node.Parent.Text == "Malzeme Say�s�na G�re")
                .Select(node => node.Text)
                .ToList();

            // Filtreyi uygulamak i�in arama fonksiyonunu �a��r
            List<Tarifler> filtrelenmisTarifler = TarifMethodlar�.SearchTarifler(
                searchTerm, // Arama terimi
                selectedCategories, // Kategoriler listesi
                selectedCostRanges.Count > 0 ? string.Join(",", selectedCostRanges) : null, // Maliyet aral���
                selectedIngredientRanges.Count > 0 ? string.Join(",", selectedIngredientRanges) : null, // Malzeme say�s� aral���
                selectedSortOrder // S�ralama kriteri
               
            );

            // Se�ilen malzemeler varsa filtreleme yap
            if (checkedListBox1.CheckedItems.Count > 0)
            {
                // E�er checkedListBox1 bo�sa, bo� bir liste olu�tur
                List<string> selectedIngredients = checkedListBox1.CheckedItems.Cast<string>().ToList();

                // Sadece se�ilen malzemeleri i�eren tarifleri filtrele
                filtrelenmisTarifler = filtrelenmisTarifler
                    .Where(tarif =>
                        tarif.Malzemeler.All(m => selectedIngredients.Contains(m.MalzemeAdi) || !selectedIngredients.Contains(m.MalzemeAdi))
                        && tarif.Malzemeler.Any(m => selectedIngredients.Contains(m.MalzemeAdi))
                    ).ToList();

                // E�le�me y�zdesini hesapla ve tarifleri s�rala
                foreach (var tarif in filtrelenmisTarifler)
                {
                    int totalSelectedIngredients = selectedIngredients.Count; // Kullan�c�n�n se�ti�i malzeme say�s�
                    int matchingIngredients = selectedIngredients.Count(m => tarif.Malzemeler.Any(t => t.MalzemeAdi == m)); // Se�ilen malzemelerden tarifte olanlar�n say�s�
                    decimal matchingPercentage = totalSelectedIngredients > 0 ? (decimal)matchingIngredients / totalSelectedIngredients * 100 : 0; // E�le�me y�zdesi
                    tarif.EslestirmeYuzdesi = matchingPercentage;
                }


                // Y�zdeye g�re s�rala
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

