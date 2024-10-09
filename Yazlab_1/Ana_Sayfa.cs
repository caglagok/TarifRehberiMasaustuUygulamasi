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
            DataGridViewButtonColumn silButon = new DataGridViewButtonColumn();
            silButon.Name = "Sil";
            silButon.HeaderText = "Sil";
            silButon.Text = "Sil";
            silButon.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(silButon);

            DataGridViewButtonColumn guncelleButon = new DataGridViewButtonColumn();
            guncelleButon.Name = "Guncelle";
            guncelleButon.HeaderText = "Güncelle";
            guncelleButon.Text = "Güncelle";
            guncelleButon.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(guncelleButon);
        }

        private void LoadTarifler()
        {
            List<Tarifler> tariflerList = TarifMethodlarý.GetTarifler();

            // Tarifleri DataGridView'e baðla
            dataGridView1.DataSource = tariflerList;
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
            if (e.ColumnIndex == dataGridView1.Columns["Sil"].Index && e.RowIndex >= 0)
            {
                // Seçilen satýrdaki TarifID'yi al
                int tarifID = (int)dataGridView1.Rows[e.RowIndex].Cells["TarifID"].Value;

                var result = MessageBox.Show("Bu tarifi silmek istediðinize emin misiniz?", "Silme Onayý", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    TarifMethodlarý.TarifSil(tarifID); // Tarif silme iþlemini yap
                    MessageBox.Show("Tarif baþarýyla silindi.");
                    LoadTarifler(); // Listeyi güncelle
                }
            }
          
            }
        }
    }

