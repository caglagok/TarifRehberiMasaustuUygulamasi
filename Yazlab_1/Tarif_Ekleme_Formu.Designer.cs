namespace Yazlab_1
{
    partial class Tarif_Ekleme_Formu
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
            components = new System.ComponentModel.Container();
            textBox1 = new TextBox();
            numericUpDown1 = new NumericUpDown();
            richTextBox1 = new RichTextBox();
            comboBox1 = new ComboBox();
            tarifMethodlarıBindingSource = new BindingSource(components);
            tarifekle = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            MalzemeEkleme = new Button();
            tarifeklemegeri = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label5 = new Label();
            pictureBox1 = new PictureBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tarifMethodlarıBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.RosyBrown;
            textBox1.Font = new Font("Century", 12F);
            textBox1.Location = new Point(324, 86);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(245, 32);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // numericUpDown1
            // 
            numericUpDown1.BackColor = Color.RosyBrown;
            numericUpDown1.Font = new Font("Segoe UI", 10F);
            numericUpDown1.Location = new Point(324, 131);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(245, 30);
            numericUpDown1.TabIndex = 1;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.RosyBrown;
            richTextBox1.Font = new Font("Century", 12F, FontStyle.Italic, GraphicsUnit.Point, 162);
            richTextBox1.Location = new Point(324, 233);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(300, 136);
            richTextBox1.TabIndex = 2;
            richTextBox1.Text = "";
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            // 
            // comboBox1
            // 
            comboBox1.BackColor = Color.RosyBrown;
            comboBox1.Font = new Font("Segoe UI", 10F);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Tatlı", "Ana Yemek", "Ara Yemek", "Çorba", "Salata" });
            comboBox1.Location = new Point(324, 173);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(245, 31);
            comboBox1.TabIndex = 4;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // tarifMethodlarıBindingSource
            // 
            tarifMethodlarıBindingSource.DataSource = typeof(TarifMethodları);
            // 
            // tarifekle
            // 
            tarifekle.BackColor = Color.IndianRed;
            tarifekle.Font = new Font("Century", 12F);
            tarifekle.Location = new Point(922, 671);
            tarifekle.Name = "tarifekle";
            tarifekle.Size = new Size(124, 58);
            tarifekle.TabIndex = 7;
            tarifekle.Text = "Tarifi Ekle";
            tarifekle.UseVisualStyleBackColor = false;
            tarifekle.Click += button1_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.RosyBrown;
            flowLayoutPanel1.Font = new Font("Century", 12F);
            flowLayoutPanel1.Location = new Point(699, 158);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(347, 451);
            flowLayoutPanel1.TabIndex = 8;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // MalzemeEkleme
            // 
            MalzemeEkleme.BackColor = Color.IndianRed;
            MalzemeEkleme.Font = new Font("Century", 12F);
            MalzemeEkleme.Location = new Point(805, 86);
            MalzemeEkleme.Name = "MalzemeEkleme";
            MalzemeEkleme.Size = new Size(241, 55);
            MalzemeEkleme.TabIndex = 9;
            MalzemeEkleme.Text = "Yeni Malzeme Ekle";
            MalzemeEkleme.UseVisualStyleBackColor = false;
            MalzemeEkleme.Click += button2_Click;
            // 
            // tarifeklemegeri
            // 
            tarifeklemegeri.BackColor = Color.IndianRed;
            tarifeklemegeri.Font = new Font("Century", 12F);
            tarifeklemegeri.Location = new Point(172, 671);
            tarifeklemegeri.Name = "tarifeklemegeri";
            tarifeklemegeri.Size = new Size(124, 58);
            tarifeklemegeri.TabIndex = 10;
            tarifeklemegeri.Text = "Geri";
            tarifeklemegeri.UseVisualStyleBackColor = false;
            tarifeklemegeri.Click += tarifeklemegeri_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.RosyBrown;
            label1.Font = new Font("Century", 12F);
            label1.Location = new Point(193, 89);
            label1.Name = "label1";
            label1.Size = new Size(117, 23);
            label1.TabIndex = 11;
            label1.Text = "Tarifin Adı:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.RosyBrown;
            label2.Font = new Font("Century", 12F);
            label2.Location = new Point(118, 132);
            label2.Name = "label2";
            label2.Size = new Size(192, 23);
            label2.TabIndex = 12;
            label2.Text = "Hazırlanma Süresi:";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.RosyBrown;
            label3.Font = new Font("Century", 12F);
            label3.Location = new Point(213, 175);
            label3.Name = "label3";
            label3.Size = new Size(97, 23);
            label3.TabIndex = 13;
            label3.Text = "Kategori:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.RosyBrown;
            label5.Font = new Font("Century", 12F);
            label5.Location = new Point(193, 233);
            label5.Name = "label5";
            label5.Size = new Size(119, 23);
            label5.TabIndex = 15;
            label5.Text = "Hazırlanışı:";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.RosyBrown;
            pictureBox1.Location = new Point(324, 396);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(300, 215);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 16;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.IndianRed;
            button1.Font = new Font("Century", 12F);
            button1.Location = new Point(172, 396);
            button1.Name = "button1";
            button1.Size = new Size(140, 68);
            button1.TabIndex = 17;
            button1.Text = "Tarifin Resmi";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // Tarif_Ekleme_Formu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Linen;
            BackgroundImage = Properties.Resources.Tatlı_Düşler_Mutfağı__1_;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1258, 793);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
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
            Name = "Tarif_Ekleme_Formu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Yeni Tarif Ekleme";
            Load += Tarif_Ekleme_Formu_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)tarifMethodlarıBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private NumericUpDown numericUpDown1;
        private RichTextBox richTextBox1;
        private ComboBox comboBox1;
        private Button tarifekle;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button MalzemeEkleme;
        private Button tarifeklemegeri;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label5;
        private BindingSource tarifMethodlarıBindingSource;
        private PictureBox pictureBox1;
        private Button button1;
    }
}