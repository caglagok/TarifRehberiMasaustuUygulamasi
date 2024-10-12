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
            button2 = new Button();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            listView2 = new ListView();
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
            button1.Font = new Font("Segoe UI", 12F);
            button1.Location = new Point(595, 589);
            button1.Name = "button1";
            button1.Size = new Size(94, 45);
            button1.TabIndex = 0;
            button1.Text = "Geri";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.IndianRed;
            button2.Font = new Font("Segoe UI", 12F);
            button2.Location = new Point(803, 589);
            button2.Name = "button2";
            button2.Size = new Size(94, 45);
            button2.TabIndex = 1;
            button2.Text = "Yap";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.RosyBrown;
            pictureBox1.Location = new Point(595, 141);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(302, 370);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bernard MT Condensed", 25F, FontStyle.Italic);
            label1.Location = new Point(67, 19);
            label1.Name = "label1";
            label1.Size = new Size(210, 49);
            label1.TabIndex = 10;
            label1.Text = "TARİFİN ADI";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(67, 81);
            label2.Name = "label2";
            label2.Size = new Size(117, 28);
            label2.TabIndex = 4;
            label2.Text = "Malzemeler:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(67, 396);
            label3.Name = "label3";
            label3.Size = new Size(105, 28);
            label3.TabIndex = 6;
            label3.Text = "Hazırlanışı:";
            // 
            // listView2
            // 
            listView2.BackColor = Color.RosyBrown;
            listView2.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 162);
            listView2.Location = new Point(67, 427);
            listView2.Name = "listView2";
            listView2.Size = new Size(428, 207);
            listView2.TabIndex = 7;
            listView2.UseCompatibleStateImageBehavior = false;
            listView2.SelectedIndexChanged += listView2_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Linen;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(67, 356);
            label4.Name = "label4";
            label4.Size = new Size(128, 28);
            label4.TabIndex = 8;
            label4.Text = "Total Maliyet:";
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.RosyBrown;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Malzeme, Miktar, BirimFiyatı });
            dataGridView1.GridColor = Color.DarkGray;
            dataGridView1.Location = new Point(67, 112);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(428, 226);
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
            button3.Font = new Font("Segoe UI", 12F);
            button3.Location = new Point(781, 45);
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
            button4.Font = new Font("Segoe UI", 10F);
            button4.Location = new Point(595, 47);
            button4.Name = "button4";
            button4.Size = new Size(116, 64);
            button4.TabIndex = 13;
            button4.Text = "Tarifi Güncelle";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(67, 427);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(381, 222);
            richTextBox1.TabIndex = 14;
            richTextBox1.Text = "";
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(216, 360);
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
            ClientSize = new Size(945, 731);
            Controls.Add(textBox1);
            Controls.Add(richTextBox1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(dataGridView1);
            Controls.Add(label4);
            Controls.Add(listView2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Tarif_Detay_Formu";
            Text = "Tarif_Detay_Formu";
            Load += Tarif_Detay_Formu_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private ListView listView2;
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