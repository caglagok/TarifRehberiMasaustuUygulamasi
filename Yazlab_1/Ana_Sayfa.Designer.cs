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
            TreeNode treeNode1 = new TreeNode("Tatlı");
            TreeNode treeNode2 = new TreeNode("Ana yemek");
            TreeNode treeNode3 = new TreeNode("Çorba");
            TreeNode treeNode4 = new TreeNode("Salata");
            TreeNode treeNode5 = new TreeNode("Ara yemek");
            TreeNode treeNode6 = new TreeNode("Kategori", new TreeNode[] { treeNode1, treeNode2, treeNode3, treeNode4, treeNode5 });
            TreeNode treeNode7 = new TreeNode("0-5");
            TreeNode treeNode8 = new TreeNode("5-10");
            TreeNode treeNode9 = new TreeNode("Malzeme Sayısına Göre", new TreeNode[] { treeNode7, treeNode8 });
            TreeNode treeNode10 = new TreeNode("0-100 TL");
            TreeNode treeNode11 = new TreeNode("100-500 TL");
            TreeNode treeNode12 = new TreeNode("500TL ve Üzeri");
            TreeNode treeNode13 = new TreeNode("Maliyet Aralığı", new TreeNode[] { treeNode10, treeNode11, treeNode12 });
            tarif_ekle = new Button();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            treeView1 = new TreeView();
            textBox1 = new TextBox();
            Ara = new Button();
            button2 = new Button();
            label1 = new Label();
            comboBox1 = new ComboBox();
            label2 = new Label();
            checkedListBox1 = new CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // tarif_ekle
            // 
            tarif_ekle.BackColor = Color.IndianRed;
            tarif_ekle.Font = new Font("Century", 12F);
            tarif_ekle.Location = new Point(766, 32);
            tarif_ekle.Name = "tarif_ekle";
            tarif_ekle.Size = new Size(193, 73);
            tarif_ekle.TabIndex = 0;
            tarif_ekle.Text = "Yeni Tarif Ekle";
            tarif_ekle.UseVisualStyleBackColor = false;
            tarif_ekle.Click += button1_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.IndianRed;
            button1.Font = new Font("Century", 12F);
            button1.Location = new Point(1044, 33);
            button1.Name = "button1";
            button1.Size = new Size(193, 71);
            button1.TabIndex = 1;
            button1.Text = "Malzeme Deposu";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.RosyBrown;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 121);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(735, 629);
            dataGridView1.TabIndex = 2;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // treeView1
            // 
            treeView1.BackColor = Color.RosyBrown;
            treeView1.CheckBoxes = true;
            treeView1.Font = new Font("Century", 9F);
            treeView1.Location = new Point(766, 163);
            treeView1.Name = "treeView1";
            treeNode1.Name = "Tatli";
            treeNode1.Text = "Tatlı";
            treeNode2.Name = "AnaYemek";
            treeNode2.Text = "Ana yemek";
            treeNode3.Name = "Corba";
            treeNode3.Text = "Çorba";
            treeNode4.Name = "Salata";
            treeNode4.Text = "Salata";
            treeNode5.Name = "AraYemek";
            treeNode5.Text = "Ara yemek";
            treeNode6.Name = "Kategori";
            treeNode6.Text = "Kategori";
            treeNode7.Name = "m05";
            treeNode7.Text = "0-5";
            treeNode8.Name = "m510";
            treeNode8.Text = "5-10";
            treeNode9.Name = "MalzemeSayisi";
            treeNode9.Text = "Malzeme Sayısına Göre";
            treeNode10.Name = "maliyet0100";
            treeNode10.Text = "0-100 TL";
            treeNode11.Name = "maliyet100500";
            treeNode11.Text = "100-500 TL";
            treeNode12.Name = "maliyet200300";
            treeNode12.Text = "500TL ve Üzeri";
            treeNode13.Name = "MaliyetAralıgı";
            treeNode13.Text = "Maliyet Aralığı";
            treeView1.Nodes.AddRange(new TreeNode[] { treeNode6, treeNode9, treeNode13 });
            treeView1.Size = new Size(257, 322);
            treeView1.TabIndex = 3;
            treeView1.AfterSelect += treeView1_AfterSelect;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.RosyBrown;
            textBox1.Location = new Point(68, 56);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(322, 27);
            textBox1.TabIndex = 4;
            // 
            // Ara
            // 
            Ara.BackColor = Color.IndianRed;
            Ara.Font = new Font("Century", 9F);
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
            button2.BackColor = Color.IndianRed;
            button2.Font = new Font("Century", 12F);
            button2.Location = new Point(1133, 695);
            button2.Name = "button2";
            button2.Size = new Size(113, 55);
            button2.TabIndex = 6;
            button2.Text = "Geri";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.IndianRed;
            label1.Font = new Font("Century", 15F);
            label1.Location = new Point(766, 122);
            label1.Name = "label1";
            label1.Size = new Size(136, 29);
            label1.TabIndex = 12;
            label1.Text = "Filtreleme";
            label1.Click += label1_Click;
            // 
            // comboBox1
            // 
            comboBox1.BackColor = Color.RosyBrown;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Süreye göre Artan", "Süreye göre Azalan", "Maliyete göre Artan", "Maliyete göre Azalan" });
            comboBox1.Location = new Point(766, 550);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(257, 28);
            comboBox1.TabIndex = 9;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.IndianRed;
            label2.Font = new Font("Century", 15F);
            label2.Location = new Point(766, 508);
            label2.Name = "label2";
            label2.Size = new Size(120, 29);
            label2.TabIndex = 13;
            label2.Text = "Sıralama";
            // 
            // checkedListBox1
            // 
            checkedListBox1.BackColor = Color.RosyBrown;
            checkedListBox1.Font = new Font("Century", 9F);
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(1044, 163);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(193, 319);
            checkedListBox1.TabIndex = 15;
            checkedListBox1.SelectedIndexChanged += checkedListBox1_SelectedIndexChanged;
            // 
            // Ana_Sayfa
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Linen;
            ClientSize = new Size(1258, 793);
            Controls.Add(checkedListBox1);
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
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Anasayfa";
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
        private Label label2;
        private CheckedListBox checkedListBox1;
    }
}