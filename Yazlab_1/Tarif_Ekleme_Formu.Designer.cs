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
            textBox1 = new TextBox();
            numericUpDown1 = new NumericUpDown();
            richTextBox1 = new RichTextBox();
            comboBox1 = new ComboBox();
            numericUpDown2 = new NumericUpDown();
            tarifekle = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            MalzemeEkleme = new Button();
            tarifeklemegeri = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.RosyBrown;
            textBox1.Font = new Font("Segoe UI", 10F);
            textBox1.Location = new Point(226, 45);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(245, 30);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // numericUpDown1
            // 
            numericUpDown1.BackColor = Color.RosyBrown;
            numericUpDown1.Font = new Font("Segoe UI", 10F);
            numericUpDown1.Location = new Point(226, 89);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(245, 30);
            numericUpDown1.TabIndex = 1;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.RosyBrown;
            richTextBox1.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic, GraphicsUnit.Point, 162);
            richTextBox1.Location = new Point(226, 224);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(245, 137);
            richTextBox1.TabIndex = 2;
            richTextBox1.Text = "";
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            // 
            // comboBox1
            // 
            comboBox1.BackColor = Color.RosyBrown;
            comboBox1.Font = new Font("Segoe UI", 10F);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(226, 131);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(245, 31);
            comboBox1.TabIndex = 4;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // numericUpDown2
            // 
            numericUpDown2.BackColor = Color.RosyBrown;
            numericUpDown2.Font = new Font("Segoe UI", 10F);
            numericUpDown2.Location = new Point(226, 176);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(245, 30);
            numericUpDown2.TabIndex = 5;
            numericUpDown2.ValueChanged += numericUpDown2_ValueChanged;
            // 
            // tarifekle
            // 
            tarifekle.BackColor = Color.IndianRed;
            tarifekle.Font = new Font("Segoe UI", 12F);
            tarifekle.Location = new Point(768, 428);
            tarifekle.Name = "tarifekle";
            tarifekle.Size = new Size(108, 44);
            tarifekle.TabIndex = 7;
            tarifekle.Text = "Tarifi Ekle";
            tarifekle.UseVisualStyleBackColor = false;
            tarifekle.Click += button1_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.RosyBrown;
            flowLayoutPanel1.Location = new Point(510, 101);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(366, 260);
            flowLayoutPanel1.TabIndex = 8;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // MalzemeEkleme
            // 
            MalzemeEkleme.BackColor = Color.IndianRed;
            MalzemeEkleme.Font = new Font("Segoe UI", 12F);
            MalzemeEkleme.Location = new Point(724, 28);
            MalzemeEkleme.Name = "MalzemeEkleme";
            MalzemeEkleme.Size = new Size(152, 55);
            MalzemeEkleme.TabIndex = 9;
            MalzemeEkleme.Text = "Malzeme Ekle";
            MalzemeEkleme.UseVisualStyleBackColor = false;
            MalzemeEkleme.Click += button2_Click;
            // 
            // tarifeklemegeri
            // 
            tarifeklemegeri.BackColor = Color.IndianRed;
            tarifeklemegeri.Font = new Font("Segoe UI", 12F);
            tarifeklemegeri.Location = new Point(608, 428);
            tarifeklemegeri.Name = "tarifeklemegeri";
            tarifeklemegeri.Size = new Size(108, 44);
            tarifeklemegeri.TabIndex = 10;
            tarifeklemegeri.Text = "Geri";
            tarifeklemegeri.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(103, 41);
            label1.Name = "label1";
            label1.Size = new Size(103, 28);
            label1.TabIndex = 11;
            label1.Text = "Tarifin Adı:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(35, 84);
            label2.Name = "label2";
            label2.Size = new Size(171, 28);
            label2.TabIndex = 12;
            label2.Text = "Hazırlanma Süresi:";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(115, 127);
            label3.Name = "label3";
            label3.Size = new Size(91, 28);
            label3.TabIndex = 13;
            label3.Text = "Kategori:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(120, 171);
            label4.Name = "label4";
            label4.Size = new Size(86, 28);
            label4.TabIndex = 14;
            label4.Text = "Maliyeti:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(101, 220);
            label5.Name = "label5";
            label5.Size = new Size(105, 28);
            label5.TabIndex = 15;
            label5.Text = "Hazırlanışı:";
            // 
            // Tarif_Ekleme_Formu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Linen;
            ClientSize = new Size(921, 600);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tarifeklemegeri);
            Controls.Add(MalzemeEkleme);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(tarifekle);
            Controls.Add(numericUpDown2);
            Controls.Add(comboBox1);
            Controls.Add(richTextBox1);
            Controls.Add(numericUpDown1);
            Controls.Add(textBox1);
            Name = "Tarif_Ekleme_Formu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tarif Ekleme";
            Load += Tarif_Ekleme_Formu_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private NumericUpDown numericUpDown1;
        private RichTextBox richTextBox1;
        private ComboBox comboBox1;
        private NumericUpDown numericUpDown2;
        private Button tarifekle;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button MalzemeEkleme;
        private Button tarifeklemegeri;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}