using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Yazlab_1
{
    public partial class Malzeme_Deposu : Form
    {
        private MalzemeMethodları malzemeMethodları;
        private DataTable dataTable;
        public Malzeme_Deposu()
        {
            InitializeComponent();
            malzemeMethodları = new MalzemeMethodları();
            dataTable = new DataTable();
            InitializeDataGridView(); 
            LoadMalzemeler();

            dataGridView1.CellPainting += dataGridView1_CellPainting;
        }
        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return; 

            Rectangle cellBounds = e.CellBounds;

            if (e.ColumnIndex == dataGridView1.Columns["UpdateButton"].Index) 
            {
                e.Paint(cellBounds, DataGridViewPaintParts.All); 

                e.Graphics.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.DarkGreen), cellBounds);

                TextRenderer.DrawText(
                    e.Graphics,
                    "Güncelle",
                    dataGridView1.Font,
                    cellBounds,
                    System.Drawing.Color.White,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                );

                using (Pen pen = new Pen(System.Drawing.Color.White, 2))
                {
                    e.Graphics.DrawRectangle(pen, cellBounds.X, cellBounds.Y, cellBounds.Width - 1, cellBounds.Height - 1);
                }

                e.Handled = true; 
            }
            else if (e.ColumnIndex == dataGridView1.Columns["DeleteButton"].Index) 
            {
                e.Paint(cellBounds, DataGridViewPaintParts.All);

                e.Graphics.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.IndianRed), cellBounds);

                TextRenderer.DrawText(
                    e.Graphics,
                    "Sil",
                    dataGridView1.Font,
                    cellBounds,
                    System.Drawing.Color.White,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                );

                using (Pen pen = new Pen(System.Drawing.Color.White, 2))
                {
                    e.Graphics.DrawRectangle(pen, cellBounds.X, cellBounds.Y, cellBounds.Width - 1, cellBounds.Height - 1);
                }

                e.Handled = true; 
            }
        }


        private void InitializeDataGridView()
        {
            dataTable.Columns.Add("MalzemeAdi", typeof(string));
            dataTable.Columns.Add("MalzemeBirim", typeof(string));
            dataTable.Columns.Add("ToplamMiktar", typeof(decimal));
            dataTable.Columns.Add("BirimFiyat", typeof(decimal));

            dataGridView1.DataSource = dataTable; 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowHeadersVisible = false;

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.DefaultCellStyle.BackColor = System.Drawing.Color.RosyBrown;
                column.DefaultCellStyle.ForeColor = System.Drawing.Color.Black; 
            }

            DataGridViewButtonColumn updateButtonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "Güncelle",
                Name = "UpdateButton",
                Text = "Güncelle",
                UseColumnTextForButtonValue = true
            };
            dataGridView1.Columns.Add(updateButtonColumn);

            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "Sil",
                Name = "DeleteButton",
                Text = "Sil",
                UseColumnTextForButtonValue = true
            };
            dataGridView1.Columns.Add(deleteButtonColumn);
        }

        public void LoadMalzemeler()
        {
            dataTable.Clear(); 

            List<Malzemeler> malzemeListesi = malzemeMethodları.GetMalzemeler();

            foreach (var malzeme in malzemeListesi)
            {
                dataTable.Rows.Add(malzeme.MalzemeAdi, malzeme.MalzemeBirim, malzeme.ToplamMiktar, malzeme.BirimFiyat);
            }

            dataGridView1.DataSource = dataTable; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var anasayfa = Application.OpenForms.OfType<Ana_Sayfa>().FirstOrDefault();
            if (anasayfa != null)
            {
                anasayfa.LoadMalzemeler(); 
            }
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; 

            if (e.ColumnIndex == dataGridView1.Columns["UpdateButton"].Index)
            {
                string malzemeAdi = dataGridView1.Rows[e.RowIndex].Cells["MalzemeAdi"].Value.ToString();

                int malzemeId = malzemeMethodları.GetMalzemeID(malzemeAdi); 
                Malzeme_Guncelleme guncellemeForm = new Malzeme_Guncelleme(malzemeId); 
                guncellemeForm.Show(); 

            }
            else if (e.ColumnIndex == dataGridView1.Columns["DeleteButton"].Index)
            {
                string malzemeAdi = dataGridView1.Rows[e.RowIndex].Cells["MalzemeAdi"].Value.ToString();
                DialogResult result = MessageBox.Show($"{malzemeAdi} silinecek. Onaylıyor musunuz?", "Sil", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    malzemeMethodları.MalzemeSil(malzemeAdi);
                    LoadMalzemeler(); 
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBox1.Text.ToLower(); 

            DataView view = dataTable.DefaultView;
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                view.RowFilter = string.Format("MalzemeAdi LIKE '%{0}%'", searchText);
            }
            else
            {
                view.RowFilter = ""; 
            }

            dataGridView1.DataSource = view; 
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
