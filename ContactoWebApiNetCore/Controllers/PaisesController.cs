using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using ContactoWebApiNetCore.Context;
using ContactoWebApiNetCore.Modelo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Pages.Internal.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ContactoWebApiNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisesController : ControllerBase
    {
        private readonly ContactoContext _context;
        public PaisesController( ContactoContext objContexto)
        {
            _context = objContexto;
        }

        //Peticion GET:api/paises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paises>>> GetPaises()
        {
            return await _context.PaisesItem.ToListAsync();
        }

        //Peticion GET:api/paises/3
        [HttpGet("{id}")]
        public async Task<ActionResult<Paises>> GetPais(int id)
        {
            var TraerPorId = await _context.PaisesItem.FindAsync(id);
            return TraerPorId;
        }

        //Peticion POST:api/paises
        [HttpPost]
        public async Task<ActionResult<Paises>> PostPaises(Paises item)
        {
            _context.PaisesItem.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPais), new { id = item.Id }, item);
        }
        //Peticion Put: api/paises/3
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaises(int id,Paises item)
        {
            if (id !=item.Id)
            {
                return BadRequest();
            }
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        //Peticion DELETE:api/paises/3
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaises(int id)
        {
            var paisABorrar = await _context.PaisesItem.FindAsync(id);
            if (paisABorrar == null)
            {
                return NotFound();
            }
            _context.PaisesItem.Remove(paisABorrar);
            await _context.SaveChangesAsync();
            return NoContent();
        }




    }
}
