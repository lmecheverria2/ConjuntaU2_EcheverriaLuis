﻿namespace ConjuntaU2.Models
{
    public class Productos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int CantidadStock { get; set; }
        public int CategoriaId { get; set; }
        public Categorias Categoria { get; set; }

    }
}
