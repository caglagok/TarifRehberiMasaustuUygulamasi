using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yazlab_1
{
   
        public class Kullanilan_Malzeme
        {
            public int MalzemeID { get; set; }
            public float Miktar { get; set; }

            public Kullanilan_Malzeme(int malzemeID, float miktar)
            {
                MalzemeID = malzemeID;
                Miktar = miktar;
            }
        }
    }

