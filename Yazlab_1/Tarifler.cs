using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yazlab_1
{
    internal class Tarifler
    {
        public int TarifID { get; set; }   
        public string TarifAdi { get; set; }  
        public string Kategori { get; set; } 
        public int HazirlamaSuresi { get; set; }  
        public string Talimatlar { get; set; }   
        public List<Malzemeler> Malzemeler { get; set; }   
    }
}
