using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yazlab_1
{
    public partial class Baslangıc : Form
    {
        public Baslangıc()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            Ana_Sayfa anasayfaForm = new Ana_Sayfa();
            anasayfaForm.ShowDialog();

            this.Close();
        }

        private void Baslangıc_Load(object sender, EventArgs e)
        {

        }
    }
}
