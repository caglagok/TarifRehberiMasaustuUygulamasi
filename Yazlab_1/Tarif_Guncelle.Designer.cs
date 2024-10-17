namespace Yazlab_1
{
    partial class Tarif_Guncelle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label5 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            tarifeklemegeri = new Button();
            MalzemeEkleme = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            tarifekle = new Button();
            comboBox1 = new ComboBox();
            richTextBox1 = new RichTextBox();
            numericUpDown1 = new NumericUpDown();
            textBox1 = new TextBox();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century", 12F);
            label5.Location = new Point(169, 231);
            label5.Name = "label5";
            label5.Size = new Size(119, 23);
            label5.TabIndex = 27;
            label5.Text = "Hazırlanışı:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century", 12F);
            label3.Location = new Point(191, 188);
            label3.Name = "label3";
            label3.Size = new Size(97, 23);
            label3.TabIndex = 26;
            label3.Text = "Kategori:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century", 12F);
            label2.Location = new Point(96, 144);
            label2.Name = "label2";
            label2.Size = new Size(192, 23);
            label2.TabIndex = 25;
            label2.Text = "Hazırlanma Süresi:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century", 12F);
            label1.Location = new Point(171, 102);
            label1.Name = "label1";
            label1.Size = new Size(117, 23);
            label1.TabIndex = 24;
            label1.Text = "Tarifin Adı:";
            // 
            // tarifeklemegeri
            // 
            tarifeklemegeri.BackColor = Color.IndianRed;
            tarifeklemegeri.Font = new Font("Century", 12F);
            tarifeklemegeri.Location = new Point(164, 429);
            tarifeklemegeri.Name = "tarifeklemegeri";
            tarifeklemegeri.Size = new Size(124, 58);
            tarifeklemegeri.TabIndex = 23;
            tarifeklemegeri.Text = "Geri";
            tarifeklemegeri.UseVisualStyleBackColor = false;
            tarifeklemegeri.Click += tarifeklemegeri_Click;
            // 
            // MalzemeEkleme
            // 
            MalzemeEkleme.BackColor = Color.IndianRed;
            MalzemeEkleme.Font = new Font("Century", 12F);
            MalzemeEkleme.Location = new Point(816, 68);
            MalzemeEkleme.Name = "MalzemeEkleme";
            MalzemeEkleme.Size = new Size(152, 55);
            MalzemeEkleme.TabIndex = 22;
            MalzemeEkleme.Text = "Malzeme Ekle";
            MalzemeEkleme.UseVisualStyleBackColor = false;
            MalzemeEkleme.Click += MalzemeEkleme_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.RosyBrown;
            flowLayoutPanel1.Font = new Font("Century", 12F);
            flowLayoutPanel1.Location = new Point(604, 135);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(364, 272);
            flowLayoutPanel1.TabIndex = 21;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // tarifekle
            // 
            tarifekle.BackColor = Color.IndianRed;
            tarifekle.Font = new Font("Century", 12F);
            tarifekle.Location = new Point(844, 429);
            tarifekle.Name = "tarifekle";
            tarifekle.Size = new Size(124, 58);
            tarifekle.TabIndex = 20;
            tarifekle.Text = "Tarifi Ekle";
            tarifekle.UseVisualStyleBackColor = false;
            tarifekle.Click += tarifekle_Click;
            // 
            // comboBox1
            // 
            comboBox1.BackColor = Color.RosyBrown;
            comboBox1.Font = new Font("Segoe UI", 10F);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Tatlı", "Ana Yemek", "Ara Yemek", "Çorba", "Salata" });
            comboBox1.Location = new Point(302, 186);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(245, 31);
            comboBox1.TabIndex = 19;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.RosyBrown;
            richTextBox1.Font = new Font("Century", 12F, FontStyle.Italic, GraphicsUnit.Point, 162);
            richTextBox1.Location = new Point(302, 231);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(245, 176);
            richTextBox1.TabIndex = 18;
            richTextBox1.Text = "";
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            // 
            // numericUpDown1
            // 
            numericUpDown1.BackColor = Color.RosyBrown;
            numericUpDown1.Font = new Font("Segoe UI", 10F);
            numericUpDown1.Location = new Point(302, 144);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(245, 30);
            numericUpDown1.TabIndex = 17;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.RosyBrown;
            textBox1.Font = new Font("Century", 12F);
            textBox1.Location = new Point(302, 99);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(245, 32);
            textBox1.TabIndex = 16;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(990, 291);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 28;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(990, 326);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(143, 120);
            pictureBox1.TabIndex = 29;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // Tarif_Guncelle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Linen;
            ClientSize = new Size(1162, 573);
            Controls.Add(pictureBox1);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tarifeklemegeri);
            Controls.Add(MalzemeEkleme);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(tarifekle);
            Controls.Add(comboBox1);
            Controls.Add(richTextBox1);
            Controls.Add(numericUpDown1);
            Controls.Add(textBox1);
            Name = "Tarif_Guncelle";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tarif Guncelle Ekranı";
            Load += Tarif_Guncelle_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label5;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button tarifeklemegeri;
        private Button MalzemeEkleme;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button tarifekle;
        private ComboBox comboBox1;
        private RichTextBox richTextBox1;
        private NumericUpDown numericUpDown1;
        private TextBox textBox1;
        private Button button1;
        private PictureBox pictureBox1;
    }
}