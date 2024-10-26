namespace Yazlab_1
{
    partial class Malzeme_Ekleme
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
            textBox1 = new TextBox();
            numericUpDown1 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            comboBox1 = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.IndianRed;
            button1.Font = new Font("Century", 9F);
            button1.Location = new Point(389, 251);
            button1.Name = "button1";
            button1.Size = new Size(94, 37);
            button1.TabIndex = 0;
            button1.Text = "Tamam";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.RosyBrown;
            textBox1.Font = new Font("Century", 9F);
            textBox1.Location = new Point(332, 64);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(151, 26);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // numericUpDown1
            // 
            numericUpDown1.BackColor = Color.RosyBrown;
            numericUpDown1.Font = new Font("Century", 9F);
            numericUpDown1.Location = new Point(332, 201);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(151, 26);
            numericUpDown1.TabIndex = 2;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // numericUpDown2
            // 
            numericUpDown2.BackColor = Color.RosyBrown;
            numericUpDown2.Font = new Font("Century", 9F);
            numericUpDown2.Location = new Point(332, 153);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(151, 26);
            numericUpDown2.TabIndex = 3;
            numericUpDown2.ValueChanged += numericUpDown2_ValueChanged;
            // 
            // comboBox1
            // 
            comboBox1.BackColor = Color.RosyBrown;
            comboBox1.Font = new Font("Century", 9F);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(332, 108);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 26);
            comboBox1.TabIndex = 4;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century", 9F);
            label1.Location = new Point(197, 67);
            label1.Name = "label1";
            label1.Size = new Size(127, 18);
            label1.TabIndex = 5;
            label1.Text = "Malzemenin Adı:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century", 9F);
            label2.Location = new Point(201, 111);
            label2.Name = "label2";
            label2.Size = new Size(125, 18);
            label2.TabIndex = 6;
            label2.Text = "Malzeme Birimi:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century", 9F);
            label3.Location = new Point(225, 155);
            label3.Name = "label3";
            label3.Size = new Size(99, 18);
            label3.TabIndex = 7;
            label3.Text = "Birim Fiyatı:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century", 9F);
            label4.Location = new Point(200, 203);
            label4.Name = "label4";
            label4.Size = new Size(124, 18);
            label4.TabIndex = 8;
            label4.Text = "Eklenen Miktar:";
            // 
            // button2
            // 
            button2.BackColor = Color.IndianRed;
            button2.Font = new Font("Century", 9F);
            button2.Location = new Point(201, 251);
            button2.Name = "button2";
            button2.Size = new Size(94, 37);
            button2.TabIndex = 9;
            button2.Text = "Geri";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // Malzeme_Ekleme
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Linen;
            BackgroundImage = Properties.Resources.Tatlı_Düşler_Mutfağı__1_;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(695, 359);
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
            Name = "Malzeme_Ekleme";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Malzeme Ekleme";
            Load += Malzeme_Ekleme_Load_1;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBox1;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;
        private ComboBox comboBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button button2;
    }
}