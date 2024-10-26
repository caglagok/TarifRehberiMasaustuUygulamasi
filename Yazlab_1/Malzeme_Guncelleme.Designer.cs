namespace Yazlab_1
{
    partial class Malzeme_Guncelleme
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
            button2 = new Button();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            comboBox1 = new ComboBox();
            numericUpDown2 = new NumericUpDown();
            numericUpDown1 = new NumericUpDown();
            textBox1 = new TextBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // button2
            // 
            button2.BackColor = Color.IndianRed;
            button2.Font = new Font("Century", 9F);
            button2.Location = new Point(261, 306);
            button2.Name = "button2";
            button2.Size = new Size(94, 37);
            button2.TabIndex = 19;
            button2.Text = "Geri";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century", 9F);
            label4.Location = new Point(260, 247);
            label4.Name = "label4";
            label4.Size = new Size(124, 18);
            label4.TabIndex = 18;
            label4.Text = "Eklenen Miktar:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century", 9F);
            label3.Location = new Point(285, 199);
            label3.Name = "label3";
            label3.Size = new Size(99, 18);
            label3.TabIndex = 17;
            label3.Text = "Birim Fiyatı:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century", 9F);
            label2.Location = new Point(261, 155);
            label2.Name = "label2";
            label2.Size = new Size(125, 18);
            label2.TabIndex = 16;
            label2.Text = "Malzeme Birimi:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century", 9F);
            label1.Location = new Point(257, 111);
            label1.Name = "label1";
            label1.Size = new Size(127, 18);
            label1.TabIndex = 15;
            label1.Text = "Malzemenin Adı:";
            // 
            // comboBox1
            // 
            comboBox1.BackColor = Color.RosyBrown;
            comboBox1.Font = new Font("Century", 9F);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(392, 152);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 26);
            comboBox1.TabIndex = 14;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // numericUpDown2
            // 
            numericUpDown2.BackColor = Color.RosyBrown;
            numericUpDown2.Font = new Font("Century", 9F);
            numericUpDown2.Location = new Point(392, 197);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(151, 26);
            numericUpDown2.TabIndex = 13;
            numericUpDown2.ValueChanged += numericUpDown2_ValueChanged;
            // 
            // numericUpDown1
            // 
            numericUpDown1.BackColor = Color.RosyBrown;
            numericUpDown1.Font = new Font("Century", 9F);
            numericUpDown1.Location = new Point(392, 245);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(151, 26);
            numericUpDown1.TabIndex = 12;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.RosyBrown;
            textBox1.Font = new Font("Century", 9F);
            textBox1.Location = new Point(392, 108);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(151, 26);
            textBox1.TabIndex = 11;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // button1
            // 
            button1.BackColor = Color.IndianRed;
            button1.Font = new Font("Century", 9F);
            button1.Location = new Point(449, 306);
            button1.Name = "button1";
            button1.Size = new Size(94, 37);
            button1.TabIndex = 10;
            button1.Text = "Tamam";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // Malzeme_Guncelleme
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Linen;
            BackgroundImage = Properties.Resources.Tatlı_Düşler_Mutfağı__1_;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(numericUpDown2);
            Controls.Add(numericUpDown1);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Name = "Malzeme_Guncelleme";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Malzeme_Guncelleme";
            Load += Malzeme_Guncelleme_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button2;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox comboBox1;
        private NumericUpDown numericUpDown2;
        private NumericUpDown numericUpDown1;
        private TextBox textBox1;
        private Button button1;
    }
}