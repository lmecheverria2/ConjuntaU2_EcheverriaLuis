using ConjuntaU2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConjuntaU2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VentasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Ventas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venta>>> GetVentas()
        {
            return await _context.Ventas.Include(v => v.ProductoId).ToListAsync();
        }

        // GET: api/Ventas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Venta>> GetVenta(int id)
        {
            var venta = await _context.Ventas.Include(v => v.ProductoId).FirstOrDefaultAsync(v => v.Id == id);
            if (venta == null)
            {
                return NotFound();
            }
            return venta;
        }

        // POST: api/Ventas
        [HttpPost]
        [HttpPost]
        [Route("api/Ventas")]
        public async Task<IActionResult> RegistrarVenta([FromBody] VentaRequest ventaRequest)
        {
            var producto = await _context.Productos.FindAsync(ventaRequest.ProductoId);
            if (producto == null)
            {
                return NotFound($"No se encontró un producto con el ID {ventaRequest.ProductoId}.");
            }

            if (producto.CantidadStock < ventaRequest.Cantidad)
            {
                return BadRequest("Stock insuficiente para realizar la venta.");
            }

            // Actualizar el stock del producto
            producto.CantidadStock -= ventaRequest.Cantidad;

            // Registrar la venta
            var venta = new Venta
            {
                ProductoId = ventaRequest.ProductoId,
                Cantidad = ventaRequest.Cantidad,
                Fecha = DateTime.UtcNow
            };
            _context.Ventas.Add(venta);

            // Guardar cambios
            await _context.SaveChangesAsync();

            return Ok(new
            {
                mensaje = "Venta registrada correctamente.",
                venta = new
                {
                    venta.Id,
                    venta.ProductoId,
                    venta.Cantidad,
                    venta.Fecha
                },
                producto = new
                {
                    producto.Id,
                    producto.Nombre,
                    producto.CantidadStock
                }
            });
        }


        // PUT: api/Ventas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVenta(int id, Venta venta)
        {
            if (id != venta.Id)
            {
                return BadRequest();
            }
            _context.Entry(venta).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Ventas.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                throw;
            }
            return NoContent();
        }

        // DELETE: api/Ventas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenta(int id)
        {
            var venta = await _context.Ventas.FindAsync(id);
            if (venta == null)
            {
                return NotFound();
            }
            _context.Ventas.Remove(venta);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
