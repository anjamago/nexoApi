using Nexos.Entities.DTO;
using Nexos.Entities.Interface.BusinessRules;
using Nexos.Entities.Interface.Repository;
using Nexos.Entities.Models;
using Nexos.Entities.Responses;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Nexos.BusinessRules
{
    public class AuthorBusiness : IAutorBusiness
    {
        private readonly IBaseRepository<Autore> Repository;

        public AuthorBusiness(IBaseRepository<Autore> repository)
        {
            Repository = repository;
        }


        public async Task<ResponseBase<List<Autore>>> GetAll()
        {
            var all = await Repository.GetAllAsync();
            return new ResponseBase<List<Autore>>(message: "Solicitud Ok", data: all.ToList(), count: all.Count());
        }

        public async Task<ResponseBase<Autore>> GetFind(int id)
        {
            var autor = await Repository.GetAsync(predicate: p => p.Id == id);
            if (autor == null)
            {
                return new ResponseBase<Autore>(message: "Nose encontro el registro solicitado");
            }

            return new ResponseBase<Autore>(message: "Solicitud Ok", data: autor, count: 1);
        }

        public  async Task<ResponseBase<Autore>> Create(AutoreDTO data)
        {
            var exist_autor = await Repository.GetAsync(predicate:p=> p.Correo == data.Correo);

            if (exist_autor != null)
            {
                return new ResponseBase<Autore>(message: "Ya existe una Editorial con el nombre o el correo registrado");
            }

            Autore autor = ConstructModel(data);

            await Repository.AddAsync(autor);

            return new ResponseBase<Autore>(message: "Solicitud Ok", data: autor, count: 1);
        }

        public async Task<ResponseBase<Autore>> Update(AutoreDTO data)
        {
            var autor = await Repository.GetAsync(predicate: p => p.Id == data.Id);
            if (autor == null)
            {
                return new ResponseBase<Autore>(message: "Nose pudo actualizar el registro solicitado");
            }

            autor = ConstructModel(data);
            await Repository.UpdateAsync(autor);

            return new ResponseBase<Autore>(message: "Solicitud Ok", data: autor, count: 1);
        }

        public async Task<ResponseBase<Autore>> delete(int id)
        {
            var autor = await Repository.GetAsync(predicate: p => p.Id == id);
            if (autor == null)
            {
                return new ResponseBase<Autore>(message: "Nose encontro el registro solicitado");
            }

            await Repository.DeleteAsync(predicate: p => p.Id == id);

            return new ResponseBase<Autore>(message: "Solicitud Ok", data: autor, count: 1);
        }
 

        private Autore ConstructModel(AutoreDTO data)
        {
            return new Autore() {
                Id = data.Id,
                NombreCompleto = data.NombreCompleto,
                FechaNacimiento = data.FechaNacimiento,
                Ciudad = data.Ciudad,
                Correo = data.Correo
            };
        }
    }
}
