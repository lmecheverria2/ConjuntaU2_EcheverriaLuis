using Xunit;
using ConjuntaU2.Models;

namespace TestProject
{
    public class VentasControllerTest
    {
        [Fact]
        public void RegistrarVenta_ValidaDatosVenta()
        {
            var venta = new Ventas
            {
                Id = 1,
                ProductoId = 1,
                Cantidad = 2,
                FechaVenta = DateTime.Now,
                Total = 2400.00m
            };

            Assert.NotNull(venta);
            Assert.True(venta.Id > 0, "El ID de la venta debe ser mayor a 0.");
            Assert.True(venta.ProductoId > 0, "El ID del producto debe ser mayor a 0.");
            Assert.True(venta.Cantidad > 0, "La cantidad debe ser mayor a 0.");
            Assert.True(venta.Total > 0, "El total debe ser mayor a 0.");
        }
    }
}