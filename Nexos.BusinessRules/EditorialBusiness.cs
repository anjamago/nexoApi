using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nexos.Entities.Interface.Repository;
using Nexos.Entities.Models;
using Nexos.Entities.Responses;
using Nexos.Entities.DTO;
using Nexos.Entities.Interface.BusinessRules;

namespace Nexos.BusinessRules
{
    public class EditorialBusiness: IEditorialBusiness
    {
        private readonly IBaseRepository<Editoriale> Repository;

        public EditorialBusiness(IBaseRepository<Editoriale> repository)
        {
            Repository = repository;
        }

        public async Task<ResponseBase<List<Editoriale>>> GetAll()
        {
            var all = await Repository.GetAllAsync();
            return new ResponseBase<List<Editoriale>>(message: "Solicitud Ok", data: all.ToList(), count: all.Count());
        }

        public async Task<ResponseBase<Editoriale>> GetFind(int id)
        {
            var editorial = await Repository.GetAsync(predicate:p=>p.Id == id);
            if(editorial == null)
            {
                return new ResponseBase<Editoriale>(message: "Nose encontro el registro solicitado" );
            }

            return new ResponseBase<Editoriale>(message: "Solicitud Ok", data: editorial, count: 1);
        }

        public async Task<ResponseBase<Editoriale>> Create(EditorialeDTO data)
        {
            var exist_editorial = await Repository.GetAsync(predicate: p => p.Nombre == data.Nombre || p.Correo == data.Correo);

            if (exist_editorial != null)
            {
                return new ResponseBase<Editoriale>(message: "Ya existe una Editorial con el nombre o el correo registrado");
            }

            Editoriale editorial = ConstructModel(data);

            await Repository.AddAsync(editorial);

            return new ResponseBase<Editoriale>(message: "Solicitud Ok", data: editorial, count: 1);
        }

        public async Task<ResponseBase<Editoriale>> Update(EditorialeDTO data)
        {
            var editorial = await Repository.GetAsync(predicate: p => p.Id == data.Id);
            if (editorial == null)
            {
                return new ResponseBase<Editoriale>(message: "Nose pudo actualizar el registro solicitado");
            }

            editorial = ConstructModel(data);
            await Repository.UpdateAsync(editorial);

            return new ResponseBase<Editoriale>(message: "Solicitud Ok", data: editorial, count: 1);
        }

        public async Task<ResponseBase<Editoriale>> delete(int id)
        {
            var editorial = await Repository.GetAsync(predicate: p => p.Id == id);
            if (editorial == null)
            {
                return new ResponseBase<Editoriale>(message: "Nose encontro el registro solicitado");
            }

            await Repository.DeleteAsync(predicate: p => p.Id == id);

            return new ResponseBase<Editoriale>(message: "Solicitud Ok", data: editorial, count: 1);
        }


        private Editoriale ConstructModel(EditorialeDTO data)
        {
            return  new Editoriale()
            {
                Id = data.Id,
                Nombre = data.Nombre,
                DirecionCorrespondencia = data.DirecionCorrespondencia,
                Telefono = data.Telefono,
                Correo = data.Correo,
                LibrosRegistrado = data.LibrosRegistrado
            };


        }

    }
}
