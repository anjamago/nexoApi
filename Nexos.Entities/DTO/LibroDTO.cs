using System;
using System.Collections.Generic;


namespace Nexos.Entities.DTO
{
    public partial class LibroDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int? Anno { get; set; }
        public string Generon { get; set; }
        public int NumeroPagina { get; set; }
        public int IdEditorial { get; set; }
        public int IdAutor { get; set; }

    }
}
