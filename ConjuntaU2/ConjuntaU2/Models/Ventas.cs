namespace ConjuntaU2.Models
{
    public class Venta
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }
    }

    public class VentaRequest
    {
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
    }

}
