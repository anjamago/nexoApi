using System;
using System.Collections.Generic;



namespace Nexos.Entities.Models
{
    public partial class Editoriale
    {
        public Editoriale()
        {
            Libros = new HashSet<Libro>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string DirecionCorrespondencia { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public long? LibrosRegistrado { get; set; }

        public virtual ICollection<Libro> Libros { get; set; }
    }
}
