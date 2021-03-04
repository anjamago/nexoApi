using System;
using System.Collections.Generic;


namespace Nexos.Entities.Models
{
    public partial class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int? Anno { get; set; }
        public string Generon { get; set; }
        public int? NumeroPagina { get; set; }
        public int? IdEditorial { get; set; }
        public int? IdAutor { get; set; }

        public virtual Autore IdAutorNavigation { get; set; }
        public virtual Editoriale IdEditorialNavigation { get; set; }
    }
}
