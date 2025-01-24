using Xunit;
using ConjuntaU2.Models;

namespace TestProject
{
    public class ClientesControllerTest
    {
        [Fact]
        public void CrearCliente_ValidaDatosCliente()
        {
            var cliente = new Clientes
            {
                Id = 1,
                Nombre = "Juan",
                Apellido = "Pérez",
                Email = "juan.perez@gmail.com",
                Telefono = "1234567890"
            };

            Assert.NotNull(cliente);
            Assert.True(cliente.Id > 0, "El ID del cliente debe ser mayor a 0.");
            Assert.False(string.IsNullOrWhiteSpace(cliente.Nombre), "El nombre no debe estar vacío.");
            Assert.False(string.IsNullOrWhiteSpace(cliente.Email), "El email no debe estar vacío.");
        }
    }
}