using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Yazlab_1
{
    public partial class Malzeme_Deposu : Form
    {
        private MalzemeMethodları malzemeMethodları;

        public Malzeme_Deposu()
        {
            InitializeComponent();
            malzemeMethodları = new MalzemeMethodları();
            InitializeDataGridView(); // DataGridView sütunlarını tanımla
            LoadMalzemeler(); // Malzemeleri yükle
        }

        private void InitializeDataGridView()
        {
            // DataGridView sütunlarını temizleyelim ve yeni baştan tanımlayalım.
            dataGridView1.Columns.Clear();

            // DataGridView genel ayarları
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Alanı eşit dağıt
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Century", 10, FontStyle.Bold); // Başlıklar için yazı tipi
            dataGridView1.DefaultCellStyle.Font = new Font("Century", 9); // Hücreler için yazı tipi
            dataGridView1.RowHeadersVisible = false; // Satır numaralarını gizle
            // DataGridView sütunlarını tanımlama
            dataGridView1.Columns.Clear(); // Öncelikle mevcut sütunları temizleyelim

            //dataGridView1.Columns.Add("MalzemeAdi", "Malzeme Adı");
            //dataGridView1.Columns.Add("MalzemeBirim", "Malzeme Birimi");

            // Malzeme Adı sütunu
            var malzemeAdiColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Malzeme Adı",
                Name = "MalzemeAdi",
                Width = 150
            };
            dataGridView1.Columns.Add(malzemeAdiColumn);

            // Malzeme Birimi sütunu
            var malzemeBirimColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Malzeme Birimi",
                Name = "MalzemeBirim",
                Width = 150
            };
            dataGridView1.Columns.Add(malzemeBirimColumn);

            // Güncelle butonu sütunu
            DataGridViewButtonColumn updateButtonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "Güncelle",
                Name = "UpdateButton",
                Text = "Güncelle",
                UseColumnTextForButtonValue = true, 
                Width = 100
                /*,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.LightGreen,  // Arka plan rengi
                    ForeColor = Color.Black,       // Yazı rengi
                    SelectionBackColor = Color.Green, // Seçildiğinde arka plan
                    SelectionForeColor = Color.White   // Seçildiğinde yazı rengi
                }
                */
            };
            updateButtonColumn.DefaultCellStyle.BackColor = Color.LightGreen; // Tüm hücrelerin arka planını yeşil yap
            updateButtonColumn.DefaultCellStyle.ForeColor = Color.Black;      // Yazı rengini siyah yap
            updateButtonColumn.DefaultCellStyle.SelectionBackColor = Color.Green; // Seçildiğinde yeşil kalsın
            updateButtonColumn.DefaultCellStyle.SelectionForeColor = Color.White; // Seçildiğinde yazı rengi beyaz olsun
            dataGridView1.Columns.Add(updateButtonColumn);

            // Sil butonu sütunu
            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "Sil",
                Name = "DeleteButton",
                Text = "Sil",
                UseColumnTextForButtonValue = true,
                Width = 100
                /*,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.Red,          // Arka plan rengi
                    ForeColor = Color.White,        // Yazı rengi
                    SelectionBackColor = Color.DarkRed, // Seçildiğinde arka plan
                    SelectionForeColor = Color.White    // Seçildiğinde yazı rengi
                }
                */
            };
            deleteButtonColumn.DefaultCellStyle.BackColor = Color.Red;       // Tüm hücrelerin arka planını kırmızı yap
            deleteButtonColumn.DefaultCellStyle.ForeColor = Color.White;     // Yazı rengini beyaz yap
            deleteButtonColumn.DefaultCellStyle.SelectionBackColor = Color.DarkRed; // Seçildiğinde koyu kırmızı
            deleteButtonColumn.DefaultCellStyle.SelectionForeColor = Color.White;   // Seçildiğinde yazı rengi beyaz
            dataGridView1.Columns.Add(deleteButtonColumn);
        }

        private void LoadMalzemeler()
        {
            // Malzemeleri al
            List<Malzemeler> malzemeListesi = malzemeMethodları.GetMalzemeler();
            // DataGridView'e bağla
            dataGridView1.Rows.Clear(); // Önceki verileri temizle
            foreach (var malzeme in malzemeListesi)
            {
                dataGridView1.Rows.Add(malzeme.MalzemeAdi, malzeme.MalzemeBirim);
                // Butonlar zaten sütun tanımlarında eklendi
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Ana_Sayfa anasayfaForm = new Ana_Sayfa();
            anasayfaForm.ShowDialog();
            
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Geçerli bir satırda olmadığımızı kontrol et

            if (e.ColumnIndex == dataGridView1.Columns["UpdateButton"].Index) // Güncelle butonuna tıklanırsa
            {
                int malzemeId = malzemeMethodları.GetMalzemeID(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()); // Malzeme ID'sini al
                Malzeme_Guncelleme guncellemeForm = new Malzeme_Guncelleme(malzemeId); // Yeni formu oluştur
                guncellemeForm.ShowDialog(); // Formu göster
            }
            else if (e.ColumnIndex == dataGridView1.Columns["DeleteButton"].Index) // Sil butonuna tıklanırsa
            {
                string malzemeAdi = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                DialogResult result = MessageBox.Show($"{malzemeAdi} silinecek. Onaylıyor musunuz?", "Sil", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    malzemeMethodları.MalzemeSil(malzemeAdi);
                    LoadMalzemeler(); // Malzeme listesi güncelleniyor
                }
            }
        }

    }
}
