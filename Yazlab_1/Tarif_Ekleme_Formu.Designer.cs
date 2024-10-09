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
            button1 = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(29, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(29, 45);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(150, 27);
            numericUpDown1.TabIndex = 1;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(29, 166);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(245, 120);
            richTextBox1.TabIndex = 2;
            richTextBox1.Text = "";
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(29, 78);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 4;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(29, 121);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(150, 27);
            numericUpDown2.TabIndex = 5;
            numericUpDown2.ValueChanged += numericUpDown2_ValueChanged;
            // 
            // button1
            // 
            button1.Location = new Point(539, 354);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 7;
            button1.Text = "tarifekle";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(391, 78);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(366, 258);
            flowLayoutPanel1.TabIndex = 8;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // button2
            // 
            button2.Location = new Point(625, 45);
            button2.Name = "button2";
            button2.Size = new Size(132, 29);
            button2.TabIndex = 9;
            button2.Text = "malzemeekle";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Tarif_Ekleme_Formu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(button1);
            Controls.Add(numericUpDown2);
            Controls.Add(comboBox1);
            Controls.Add(richTextBox1);
            Controls.Add(numericUpDown1);
            Controls.Add(textBox1);
            Name = "Tarif_Ekleme_Formu";
            Text = "Tarif_Ekleme_Formu";
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
        private Button button1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button button2;
    }
}