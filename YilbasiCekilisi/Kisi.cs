using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YilbasiCekilisi
{
    class Kisi
    {
        public Kisi()
        {
            Id = Guid.NewGuid(); // benzersiz bir string oluşturuyor. random ancak unique oluyor. Bu sayede aynı isim soyisim girsen de 2 farklı kişi olacak.

        }
        public Guid Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
    }
}
