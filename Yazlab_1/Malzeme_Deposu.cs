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
            // DataGridView sütunlarını tanımlama
            dataGridView1.Columns.Clear(); // Öncelikle mevcut sütunları temizleyelim

            dataGridView1.Columns.Add("MalzemeAdi", "Malzeme Adı");
            dataGridView1.Columns.Add("MalzemeBirim", "Malzeme Birimi");

            // Güncelle butonu sütunu
            DataGridViewButtonColumn updateButtonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "Güncelle",
                Name = "UpdateButton",
                Text = "Güncelle",
                UseColumnTextForButtonValue = true // Buton metnini ayarla
            };
            dataGridView1.Columns.Add(updateButtonColumn);

            // Sil butonu sütunu
            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "Sil",
                Name = "DeleteButton",
                Text = "Sil",
                UseColumnTextForButtonValue = true // Buton metnini ayarla
            };
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
