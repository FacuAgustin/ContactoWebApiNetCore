using ContactoWebApiNetCore.Modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactoWebApiNetCore.Context
{
    public class ContactoContext:DbContext
    {
        public ContactoContext(DbContextOptions<ContactoContext> options):base(options)
        {

        }
        public DbSet<Contacto> ContactoItem{ get; set; }
        public DbSet<Paises> PaisesItem { get; set; }
    }
}
