using System;
using System.Collections.Generic;



namespace Nexos.Entities.DTO
{
    public partial class EditorialeDTO
    {
        
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string DirecionCorrespondencia { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public long? LibrosRegistrado { get; set; }

    }
}
