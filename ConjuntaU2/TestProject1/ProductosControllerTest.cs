using Xunit;
using ConjuntaU2.Models;

namespace TestProject
{
    public class ProductosControllerTest
    {
        [Fact]
        public void CrearProducto_ValidaDatosProducto()
        {
            var producto = new Productos
            {
                Id = 1,
                Nombre = "Laptop",
                Descripcion = "Laptop de última generación",
                Precio = 1200.99m,
                CantidadStock = 10,
                CategoriaId = 1
            };

            Assert.NotNull(producto);
            Assert.True(producto.Id > 0, "El ID del producto debe ser mayor a 0.");
            Assert.False(string.IsNullOrWhiteSpace(producto.Nombre), "El nombre no debe estar vacío.");
            Assert.True(producto.Precio > 0, "El precio debe ser mayor a 0.");
            Assert.True(producto.CantidadStock >= 0, "La cantidad en stock no puede ser negativa.");
        }
    }
}