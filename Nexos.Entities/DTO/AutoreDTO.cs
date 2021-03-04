using System;
using System.Collections.Generic;


namespace Nexos.Entities.DTO
{
    public partial class AutoreDTO
    {
       
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Ciudad { get; set; }
        public string Correo { get; set; }

    }
}
