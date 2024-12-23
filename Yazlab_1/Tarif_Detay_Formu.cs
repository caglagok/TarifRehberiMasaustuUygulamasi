﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Yazlab_1
{
    public partial class Tarif_Detay_Formu : Form
    {
        private int _tarifID;
        private TarifMethodları _tarifDetayManager; 
        private Ana_Sayfa anaSayfaForm;
        public Tarif_Detay_Formu(int tarifID, Ana_Sayfa anaSayfaForm)
        {
            InitializeComponent();
            _tarifID = tarifID;
            _tarifDetayManager = new TarifMethodları();
            this.anaSayfaForm = anaSayfaForm;
        }
        public void LoadData()
        {
            dataGridView1.Rows.Clear();

            string tarifAdi = _tarifDetayManager.TarifDetaylariniGetir(_tarifID, dataGridView1, richTextBox1, textBox1, pictureBox1);
            label1.Text = tarifAdi;
        }

        private void Tarif_Detay_Formu_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TarifMethodları.TarifSil(_tarifID);
            anaSayfaForm.LoadTarifler();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            anaSayfaForm.LoadMalzemeler();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Tarif_Guncelle tarifGuncelleFormu = new Tarif_Guncelle(_tarifID,anaSayfaForm); 
            tarifGuncelleFormu.Show();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
