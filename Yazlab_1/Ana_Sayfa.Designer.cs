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
            tarif_ekle = new Button();
            SuspendLayout();
            // 
            // tarif_ekle
            // 
            tarif_ekle.Location = new Point(965, 78);
            tarif_ekle.Name = "tarif_ekle";
            tarif_ekle.Size = new Size(217, 113);
            tarif_ekle.TabIndex = 0;
            tarif_ekle.Text = "+Tarif Ekle";
            tarif_ekle.UseVisualStyleBackColor = true;
            tarif_ekle.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1258, 724);
            Controls.Add(tarif_ekle);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button tarif_ekle;
    }
}
