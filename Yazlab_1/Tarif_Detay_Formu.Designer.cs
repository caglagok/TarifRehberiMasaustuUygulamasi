namespace Yazlab_1
{
    partial class Tarif_Detay_Formu
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
            button1 = new Button();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            dataGridView1 = new DataGridView();
            Malzeme = new DataGridViewTextBoxColumn();
            Miktar = new DataGridViewTextBoxColumn();
            BirimFiyatı = new DataGridViewTextBoxColumn();
            button3 = new Button();
            button4 = new Button();
            richTextBox1 = new RichTextBox();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.IndianRed;
            button1.Font = new Font("Century", 12F);
            button1.Location = new Point(121, 660);
            button1.Name = "button1";
            button1.Size = new Size(94, 44);
            button1.TabIndex = 0;
            button1.Text = "Geri";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.RosyBrown;
            pictureBox1.Location = new Point(121, 149);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(511, 438);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.RosyBrown;
            label1.Font = new Font("Century", 25.2F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(121, 79);
            label1.Name = "label1";
            label1.Size = new Size(298, 50);
            label1.TabIndex = 10;
            label1.Text = "TARİFİN ADI";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century", 12F, FontStyle.Italic, GraphicsUnit.Point, 162);
            label2.Location = new Point(717, 79);
            label2.Name = "label2";
            label2.Size = new Size(119, 23);
            label2.TabIndex = 4;
            label2.Text = "Malzemeler";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century", 12F, FontStyle.Italic);
            label3.Location = new Point(717, 403);
            label3.Name = "label3";
            label3.Size = new Size(113, 23);
            label3.TabIndex = 6;
            label3.Text = "Hazırlanışı";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Linen;
            label4.Font = new Font("Century", 12F, FontStyle.Italic, GraphicsUnit.Point, 162);
            label4.Location = new Point(717, 371);
            label4.Name = "label4";
            label4.Size = new Size(135, 23);
            label4.TabIndex = 8;
            label4.Text = "Total Maliyet";
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.RosyBrown;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Malzeme, Miktar, BirimFiyatı });
            dataGridView1.GridColor = Color.IndianRed;
            dataGridView1.Location = new Point(717, 114);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(433, 251);
            dataGridView1.TabIndex = 9;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Malzeme
            // 
            Malzeme.HeaderText = "Malzeme";
            Malzeme.MinimumWidth = 6;
            Malzeme.Name = "Malzeme";
            Malzeme.Width = 125;
            // 
            // Miktar
            // 
            Miktar.HeaderText = "Miktar";
            Miktar.MinimumWidth = 6;
            Miktar.Name = "Miktar";
            Miktar.Width = 125;
            // 
            // BirimFiyatı
            // 
            BirimFiyatı.HeaderText = "Birim Fiyatı";
            BirimFiyatı.MinimumWidth = 6;
            BirimFiyatı.Name = "BirimFiyatı";
            BirimFiyatı.Width = 125;
            // 
            // button3
            // 
            button3.BackColor = Color.IndianRed;
            button3.Font = new Font("Century", 12F);
            button3.Location = new Point(1034, 16);
            button3.Name = "button3";
            button3.Size = new Size(116, 64);
            button3.TabIndex = 12;
            button3.Text = "Tarifi Sil";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.IndianRed;
            button4.Font = new Font("Century", 10F);
            button4.Location = new Point(894, 16);
            button4.Name = "button4";
            button4.Size = new Size(116, 64);
            button4.TabIndex = 13;
            button4.Text = "Tarifi Güncelle";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.RosyBrown;
            richTextBox1.Font = new Font("Century", 12F, FontStyle.Italic);
            richTextBox1.Location = new Point(717, 438);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(427, 204);
            richTextBox1.TabIndex = 14;
            richTextBox1.Text = "";
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.RosyBrown;
            textBox1.Location = new Point(872, 371);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 15;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // Tarif_Detay_Formu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Linen;
            BackgroundImage = Properties.Resources.Tatlı_Düşler_Mutfağı__1_;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1258, 793);
            Controls.Add(textBox1);
            Controls.Add(richTextBox1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(dataGridView1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(button1);
            Name = "Tarif_Detay_Formu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tarif Detayları";
            Load += Tarif_Detay_Formu_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Malzeme;
        private DataGridViewTextBoxColumn Miktar;
        private DataGridViewTextBoxColumn BirimFiyatı;
        private Button button3;
        private Button button4;
        private RichTextBox richTextBox1;
        private TextBox textBox1;
    }
}