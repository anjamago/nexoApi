using System;
using System.Collections.Generic;


namespace Nexos.Entities.Models
{
    public partial class Autore
    {
        public Autore()
        {
            Libros = new HashSet<Libro>();
        }

        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Ciudad { get; set; }
        public string Correo { get; set; }

        public virtual ICollection<Libro> Libros { get; set; }
    }
}
