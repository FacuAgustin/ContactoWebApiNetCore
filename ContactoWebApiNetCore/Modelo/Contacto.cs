using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactoWebApiNetCore.Modelo
{
    public class Contacto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public bool Verification { get; set; }
    }
}
