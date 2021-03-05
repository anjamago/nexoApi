using Nexos.Entities.DTO;
using Nexos.Entities.Models;
using Nexos.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nexos.Entities.Interface.BusinessRules
{
    public interface ILibrosBusiness
    {
        Task<ResponseBase<List<LibroDTO>>> GetAll();
        Task<ResponseBase<Libro>> GetFind(int id);
        Task<ResponseBase<Libro>> Create(LibroDTO data);
        Task<ResponseBase<Libro>> Update(LibroDTO data);
        Task<ResponseBase<Libro>> delete(int id);
    }
}
