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
            guncelleButon.HeaderText = "G�ncelle";
            guncelleButon.Text = "G�ncelle";
            guncelleButon.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(guncelleButon);
        }

        private void LoadTarifler()
        {
            List<Tarifler> tariflerList = TarifMethodlar�.GetTarifler();

            // Tarifleri DataGridView'e ba�la
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
                // Se�ilen sat�rdaki TarifID'yi al
                int tarifID = (int)dataGridView1.Rows[e.RowIndex].Cells["TarifID"].Value;

                var result = MessageBox.Show("Bu tarifi silmek istedi�inize emin misiniz?", "Silme Onay�", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    TarifMethodlar�.TarifSil(tarifID); // Tarif silme i�lemini yap
                    MessageBox.Show("Tarif ba�ar�yla silindi.");
                    LoadTarifler(); // Listeyi g�ncelle
                }
            }
          
            }
        }
    }

