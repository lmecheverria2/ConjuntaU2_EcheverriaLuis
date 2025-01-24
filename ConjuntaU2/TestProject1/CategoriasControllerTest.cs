using Xunit;
using ConjuntaU2.Models;

namespace TestProject
{
    public class CategoriasControllerTest
    {
        [Fact]
        public void CrearCategoria_ValidaDatosCategoria()
        {
            var categoria = new Categorias
            {
                Id = 1,
                Nombre = "Electrónica",
                Descripcion = "Dispositivos electrónicos"
            };

            Assert.NotNull(categoria);
            Assert.True(categoria.Id > 0, "El ID de la categoría debe ser mayor a 0.");
            Assert.False(string.IsNullOrWhiteSpace(categoria.Nombre), "El nombre no debe estar vacío.");
        }
    }
}