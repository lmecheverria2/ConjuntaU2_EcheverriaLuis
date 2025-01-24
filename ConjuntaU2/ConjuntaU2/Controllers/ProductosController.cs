using ConjuntaU2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConjuntaU2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Productos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Productos>>> GetProductos()
        {
            return await _context.Productos.Include(p => p.Categoria).ToListAsync();
        }

        // GET: api/Productos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Productos>> GetProducto(int id)
        {
            var producto = await _context.Productos.Include(p => p.Categoria).FirstOrDefaultAsync(p => p.Id == id);
            if (producto == null)
            {
                return NotFound();
            }
            return producto;
        }

        [HttpPost]
        public async Task<IActionResult> PostProducto(Productos producto)
        {
            // Validar que el producto no sea nulo
            if (producto == null)
            {
                return BadRequest("El producto no puede ser nulo.");
            }

            // Verificar si la categoría asociada existe
            var categoriaExiste = await _context.Categorias.FindAsync(producto.CategoriaId);
            if (categoriaExiste == null)
            {
                return BadRequest("La categoría especificada no existe.");
            }

            // Desvincular la propiedad Categoria para evitar conflictos
            producto.Categoria = null;

            // Agregar el producto al contexto
            _context.Productos.Add(producto);

            // Guardar los cambios en la base de datos
            await _context.SaveChangesAsync();

            // Retornar la respuesta con el producto creado
            //return CreatedAtAction("GetProducto", new { id = producto.Id }, producto);
            return Ok(producto);
        }

        [HttpPut("{id}/actualizar-stock")]
        public async Task<IActionResult> ActualizarStock(int id, [FromBody] int nuevaCantidadStock)
        {
            // Validar si el ID es válido
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound($"No se encontró un producto con el ID {id}.");
            }

            // Validar si la cantidad es válida
            if (nuevaCantidadStock < 0)
            {
                return BadRequest("La cantidad de stock no puede ser negativa.");
            }

            // Actualizar el stock
            producto.CantidadStock = nuevaCantidadStock;
            await _context.SaveChangesAsync();

            // Devolver respuesta exitosa
            return Ok(new
            {
                mensaje = "Stock actualizado correctamente.",
                producto = new
                {
                    producto.Id,
                    producto.Nombre,
                    producto.CantidadStock
                }
            });
        }


        // DELETE: api/Productos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
