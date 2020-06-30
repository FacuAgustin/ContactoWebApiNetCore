using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactoWebApiNetCore.Context;
using ContactoWebApiNetCore.Modelo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Pages.Internal.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.EntityFrameworkCore;

namespace ContactoWebApiNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactosController : ControllerBase
    {
        private readonly ContactoContext _context;
        public ContactosController(ContactoContext objContexto)
        {
            _context = objContexto;
        }

        //Peticion GET: api/contacto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contacto>>> GetContactos()
        {
            return await _context.ContactoItem.ToListAsync();
        }
        //Peticion GET: api/contactos/4
        [HttpGet("{id}")]
        public async Task<ActionResult<Contacto>> GetContacto(int id)
        {
            var TraerPorId = await _context.ContactoItem.FindAsync(id);
            return TraerPorId;

        }

        //Peticion POST: api/contacto/3
        [HttpPost]
        public  async Task<ActionResult<Contacto>> PostContacto(Contacto item)
        {
            _context.ContactoItem.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetContacto), new { id = item.Id }, item);
        }
        //Peticion PUT: api/contacto/id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactos(int id,Contacto item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        //Prticion DELETE:api/contactos/3
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContacto(int id)
        {
            var traerPorId = await _context.ContactoItem.FindAsync(id);

            if (traerPorId == null)
            {
                return BadRequest();
            }
            _context.ContactoItem.Remove(traerPorId);
            
            await _context.SaveChangesAsync();
            return NoContent();


        }


 

    }
}
