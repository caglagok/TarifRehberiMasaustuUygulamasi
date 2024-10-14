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
    public partial class Malzeme_Deposu : Form
    {
        public Malzeme_Deposu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ana_Sayfa anasayfaForm = new Ana_Sayfa();
            anasayfaForm.ShowDialog();

            this.Close();
        }
    }
}
