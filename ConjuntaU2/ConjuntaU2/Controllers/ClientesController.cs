using ConjuntaU2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConjuntaU2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ClientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clientes>>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Clientes>> GetCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return cliente;
        }

        // POST: api/Clientes
        [HttpPost]
        public async Task<ActionResult<Clientes>> PostCliente(Clientes cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCliente), new { id = cliente.Id }, cliente);
        }

        // PUT: api/Clientes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Clientes cliente)
        {
            if (id != cliente.Id)
            {
                return BadRequest();
            }
            _context.Entry(cliente).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Clientes.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                throw;
            }
            return NoContent();
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
