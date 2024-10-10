namespace Yazlab_1
{
    partial class Ana_Sayfa
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TreeNode treeNode14 = new TreeNode("Tatlı");
            TreeNode treeNode15 = new TreeNode("Ana yemek");
            TreeNode treeNode16 = new TreeNode("Çorba");
            TreeNode treeNode17 = new TreeNode("Salata");
            TreeNode treeNode18 = new TreeNode("Ara yemek");
            TreeNode treeNode19 = new TreeNode("Kategori", new TreeNode[] { treeNode14, treeNode15, treeNode16, treeNode17, treeNode18 });
            TreeNode treeNode20 = new TreeNode("0-5");
            TreeNode treeNode21 = new TreeNode("5-10");
            TreeNode treeNode22 = new TreeNode("Malzeme Sayısına Göre", new TreeNode[] { treeNode20, treeNode21 });
            TreeNode treeNode23 = new TreeNode("0-100 TL");
            TreeNode treeNode24 = new TreeNode("100-200 TL");
            TreeNode treeNode25 = new TreeNode("200-300 TL");
            TreeNode treeNode26 = new TreeNode("Maliyet Aralığı", new TreeNode[] { treeNode23, treeNode24, treeNode25 });
            tarif_ekle = new Button();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            treeView1 = new TreeView();
            textBox1 = new TextBox();
            Ara = new Button();
            button2 = new Button();
            label1 = new Label();
            comboBox1 = new ComboBox();
            Tarifler = new DataGridViewTextBoxColumn();
            Süre = new DataGridViewTextBoxColumn();
            TotalMaliyet = new DataGridViewTextBoxColumn();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // tarif_ekle
            // 
            tarif_ekle.BackColor = Color.LightSeaGreen;
            tarif_ekle.Location = new Point(1042, 12);
            tarif_ekle.Name = "tarif_ekle";
            tarif_ekle.Size = new Size(102, 71);
            tarif_ekle.TabIndex = 0;
            tarif_ekle.Text = "+Tarif Ekle";
            tarif_ekle.UseVisualStyleBackColor = false;
            tarif_ekle.Click += button1_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.LightSeaGreen;
            button1.Location = new Point(1144, 12);
            button1.Name = "button1";
            button1.Size = new Size(102, 71);
            button1.TabIndex = 1;
            button1.Text = "+Malzeme Ekle";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.DarkSeaGreen;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Tarifler, Süre, TotalMaliyet });
            dataGridView1.Location = new Point(12, 121);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(735, 629);
            dataGridView1.TabIndex = 2;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // treeView1
            // 
            treeView1.BackColor = Color.DarkSeaGreen;
            treeView1.Location = new Point(1042, 161);
            treeView1.Name = "treeView1";
            treeNode14.Name = "Tatli";
            treeNode14.Text = "Tatlı";
            treeNode15.Name = "AnaYemek";
            treeNode15.Text = "Ana yemek";
            treeNode16.Name = "Corba";
            treeNode16.Text = "Çorba";
            treeNode17.Name = "Salata";
            treeNode17.Text = "Salata";
            treeNode18.Name = "AraYemek";
            treeNode18.Text = "Ara yemek";
            treeNode19.Name = "Kategori";
            treeNode19.Text = "Kategori";
            treeNode20.Name = "m05";
            treeNode20.Text = "0-5";
            treeNode21.Name = "m510";
            treeNode21.Text = "5-10";
            treeNode22.Name = "MalzemeSayisi";
            treeNode22.Text = "Malzeme Sayısına Göre";
            treeNode23.Name = "maliyet0100";
            treeNode23.Text = "0-100 TL";
            treeNode24.Name = "maliyet100200";
            treeNode24.Text = "100-200 TL";
            treeNode25.Name = "maliyet200300";
            treeNode25.Text = "200-300 TL";
            treeNode26.Name = "MaliyetAralıgı";
            treeNode26.Text = "Maliyet Aralığı";
            treeView1.Nodes.AddRange(new TreeNode[] { treeNode19, treeNode22, treeNode26 });
            treeView1.Size = new Size(204, 322);
            treeView1.TabIndex = 3;
            treeView1.AfterSelect += treeView1_AfterSelect;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(68, 56);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(322, 27);
            textBox1.TabIndex = 4;
            // 
            // Ara
            // 
            Ara.BackColor = Color.LightSeaGreen;
            Ara.Location = new Point(414, 56);
            Ara.Name = "Ara";
            Ara.Size = new Size(127, 29);
            Ara.TabIndex = 5;
            Ara.Text = "Ara";
            Ara.UseVisualStyleBackColor = false;
            Ara.Click += button2_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.LightSeaGreen;
            button2.Location = new Point(1042, 515);
            button2.Name = "button2";
            button2.Size = new Size(94, 43);
            button2.TabIndex = 6;
            button2.Text = "Geri";
            button2.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.LightSeaGreen;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(1042, 121);
            label1.Name = "label1";
            label1.Size = new Size(98, 28);
            label1.TabIndex = 12;
            label1.Text = "Filtreleme";
            label1.Click += label1_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Süreye göre Artan-Azalan", "Süreye göre Azalan-Artan", "Maliyete göre Artan-Azalan", "Maliyete göre Azalan-Artan" });
            comboBox1.Location = new Point(762, 161);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(257, 28);
            comboBox1.TabIndex = 9;
            // 
            // Tarifler
            // 
            Tarifler.HeaderText = "Tarifler";
            Tarifler.MinimumWidth = 8;
            Tarifler.Name = "Tarifler";
            Tarifler.Width = 300;
            // 
            // Süre
            // 
            Süre.HeaderText = "Süre";
            Süre.MinimumWidth = 8;
            Süre.Name = "Süre";
            Süre.Width = 190;
            // 
            // TotalMaliyet
            // 
            TotalMaliyet.HeaderText = "Total Maliyet";
            TotalMaliyet.MinimumWidth = 8;
            TotalMaliyet.Name = "TotalMaliyet";
            TotalMaliyet.Width = 190;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.LightSeaGreen;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(762, 121);
            label2.Name = "label2";
            label2.Size = new Size(87, 28);
            label2.TabIndex = 13;
            label2.Text = "Sıralama";
            // 
            // Ana_Sayfa
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightCyan;
            ClientSize = new Size(1258, 793);
            Controls.Add(label2);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(Ara);
            Controls.Add(textBox1);
            Controls.Add(treeView1);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Controls.Add(tarif_ekle);
            Name = "Ana_Sayfa";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button tarif_ekle;
        private Button button1;
        private DataGridView dataGridView1;
        private TreeView treeView1;
        private TextBox textBox1;
        private Button Ara;
        private Button button2;
        private Label label1;
        private ComboBox comboBox1;
        private DataGridViewTextBoxColumn Tarifler;
        private DataGridViewTextBoxColumn Süre;
        private DataGridViewTextBoxColumn TotalMaliyet;
        private Label label2;
    }
}
