using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel;

namespace Yazlab_1
{
    public partial class Ana_Sayfa : Form
    {
        private MalzemeMethodlarý malzemeMethodlarý; 

        public Ana_Sayfa()
        {
            InitializeComponent();
            malzemeMethodlarý = new MalzemeMethodlarý();
            dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView1_CellFormatting);
            dataGridView1.CellPainting += new DataGridViewCellPaintingEventHandler(dataGridView1_CellPainting); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            treeView1.AfterCheck += treeView1_AfterCheck; 
            LoadTarifler();
            LoadMalzemeler();
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return; 

            if (e.ColumnIndex == dataGridView1.Columns["Detaylar"].Index) 
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All); 

                e.Graphics.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.IndianRed), e.CellBounds);

                TextRenderer.DrawText(
                    e.Graphics,
                    "Detaylar",
                    dataGridView1.Font,
                    e.CellBounds,
                    System.Drawing.Color.Black,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                );

                using (Pen pen = new Pen(System.Drawing.Color.White, 1))
                {
                    e.Graphics.DrawRectangle(pen, e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width - 1, e.CellBounds.Height - 1);
                }

                e.Handled = true;
            }
        }

        public void LoadTarifler()
        {
            dataGridView1.Columns.Clear();
            List<Tarifler> tariflerList = TarifMethodlarý.GetTarifler();
            
            dataGridView1.DataSource = tariflerList;

            MaliyetHesaplama maliyetHesaplama = new MaliyetHesaplama();

            for (int i = 0; i < tariflerList.Count; i++)
            {
                int tarifID = tariflerList[i].TarifID;
                decimal maliyet = maliyetHesaplama.TarifMaliyetiHesapla(tarifID);

                dataGridView1.Rows[i].Cells["Maliyet"].Value = maliyet;

                dataGridView1.Rows[i].Cells["EslestirmeYuzdesi"].Value = tariflerList[i].EslestirmeYuzdesi;
            }
            DataGridViewButtonColumn detaybuton = new DataGridViewButtonColumn
            {
                HeaderText = "Detaylar",
                Name = "Detaylar",
                Text = "Detaylar",
                UseColumnTextForButtonValue = true
            };
            dataGridView1.Columns.Add(detaybuton);

            dataGridView1.Columns["TarifAdi"].HeaderText = "Tarif Adý";
            dataGridView1.Columns["HazirlamaSuresi"].HeaderText = "Hazýrlama Süresi (dk)";
            dataGridView1.Columns["EslestirmeYuzdesi"].HeaderText = "Eþleþme Yüzdesi";

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Name != "TarifAdi" && column.Name != "HazirlamaSuresi" && column.Name != "Maliyet" && column.Name != "EslestirmeYuzdesi" && column.Name != "Detaylar")
                {
                    column.Visible = false;
                }
            }
        }

        public void LoadMalzemeler()
        {
            checkedListBox1.Items.Clear();
            List<Malzemeler> malzemeListesi = malzemeMethodlarý.GetMalzemeler();

            foreach (var malzeme in malzemeListesi)
            {
                checkedListBox1.Items.Add(malzeme.MalzemeAdi, false);
            }
        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Maliyet")
            {
                if (e.Value != null && decimal.TryParse(e.Value.ToString(), out decimal maliyet))
                {
                    if (maliyet == 0)
                    {
                        dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.DarkGreen;
                        dataGridView1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                    }
                    else if (maliyet > 0)
                    {
                        dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.DarkRed;
                        dataGridView1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White; 
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tarif_Ekleme_Formu tarifEklemeFormu = new Tarif_Ekleme_Formu(this);
            tarifEklemeFormu.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Malzeme_Deposu malzemeDeposuForm = new Malzeme_Deposu();
            malzemeDeposuForm.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int tarifID = (int)dataGridView1.Rows[e.RowIndex].Cells["TarifID"].Value;

                Tarif_Detay_Formu tarifDetayForm = new Tarif_Detay_Formu(tarifID, this);
                tarifDetayForm.ShowDialog();
            }
        }

        private List<TreeNode> selectedNodes = new List<TreeNode>();
        private Dictionary<TreeNode, Color> nodeOriginalColors = new Dictionary<TreeNode, Color>();

        // AfterCheck olayý tetiklendiðinde checkbox durumu deðiþtiyse kontrol et düðüm listesine ekleme ,çýkarma
        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {

            if (e.Action != TreeViewAction.Unknown)
            {
                if (e.Node.Checked)
                {
                    if (!selectedNodes.Contains(e.Node))
                    {
                        selectedNodes.Add(e.Node);
                    }
                }
                else
                {
                    selectedNodes.Remove(e.Node);
                }
            }
        }

        // arama ve malzeme seçimini hepsini bir butona baðladým
        private void button2_Click(object sender, EventArgs e)
        {

            string searchTerm = textBox1.Text.Trim();

            string selectedSortOrder = comboBox1.SelectedItem?.ToString(); // null kontrolü ekledik

            List<Tarifler> aramaSonuclari = ApplyFilters(searchTerm, selectedSortOrder);

            dataGridView1.DataSource = aramaSonuclari;
        }

        private List<Tarifler> ApplyFilters(string searchTerm, string selectedSortOrder)
        {
            List<string> selectedCategories = selectedNodes
                .Where(node => node.Parent != null && node.Parent.Text == "Kategori")
                .Select(node => node.Text)
                .ToList();


            List<string> selectedCostRanges = selectedNodes
                .Where(node => node.Parent != null && node.Parent.Text == "Maliyet Aralýðý")
                .Select(node => node.Text)
                .ToList();


            List<string> selectedIngredientRanges = selectedNodes
                .Where(node => node.Parent != null && node.Parent.Text == "Malzeme Sayýsýna Göre")
                .Select(node => node.Text)
                .ToList();

            List<Tarifler> filtrelenmisTarifler = TarifMethodlarý.SearchTarifler(
                searchTerm,
                selectedCategories,
                selectedCostRanges.Count > 0 ? string.Join(",", selectedCostRanges) : null,
                selectedIngredientRanges.Count > 0 ? string.Join(",", selectedIngredientRanges) : null,
                selectedSortOrder
            );

            if (checkedListBox1.CheckedItems.Count > 0)
            {
                List<string> selectedIngredients = checkedListBox1.CheckedItems.Cast<string>().ToList();

                // Sadece seçilen malzemeleri içeren tarifleri filtreleme
                filtrelenmisTarifler = filtrelenmisTarifler
                    .Where(tarif =>
                        tarif.Malzemeler.All(m => selectedIngredients.Contains(m.MalzemeAdi) || !selectedIngredients.Contains(m.MalzemeAdi))
                        && tarif.Malzemeler.Any(m => selectedIngredients.Contains(m.MalzemeAdi))
                    ).ToList();

                // Eþleþme yüzdesini hesapla ve tarifleri sýralama
                foreach (var tarif in filtrelenmisTarifler)
                {
                    int totalSelectedIngredients = selectedIngredients.Count;
                    int totalTarifIngredients = tarif.Malzemeler.Count; 
                    int matchingIngredients = selectedIngredients.Count(m => tarif.Malzemeler.Any(t => t.MalzemeAdi == m));

                    // Hem tarifteki malzemelerin sayýsýný hem de seçilen malzemeleri dikkate alarak eþleþme yüzdesi hesaplama!!!
                    decimal matchingPercentage = totalTarifIngredients > 0
                        ? (decimal)matchingIngredients / totalTarifIngredients * 100
                        : 0;

                    tarif.EslestirmeYuzdesi = matchingPercentage;
                }

                filtrelenmisTarifler = filtrelenmisTarifler
                    .OrderByDescending(t => t.EslestirmeYuzdesi)
                    .ToList();
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
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = textBox1.Text.Trim();
            string selectedSortOrder = comboBox1.SelectedItem?.ToString();

            List<Tarifler> aramaSonuclari = ApplyFilters(searchTerm, selectedSortOrder);

            dataGridView1.DataSource = aramaSonuclari;
        }

    }
}