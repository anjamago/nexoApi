using Microsoft.EntityFrameworkCore;
using Nexos.Entities.DTO;
using Nexos.Entities.Interface.BusinessRules;
using Nexos.Entities.Interface.Repository;
using Nexos.Entities.Models;
using Nexos.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexos.BusinessRules
{
    class LibrosBusiness : ILibrosBusiness
    {
        private readonly IBaseRepository<Libro> LibroRepo;
        private readonly IBaseRepository<Autore> AutorRepo;
        private readonly IBaseRepository<Editoriale> EditorialRepo;

        public LibrosBusiness(
            IBaseRepository<Libro> libroRepo,
            IBaseRepository<Editoriale> _editorialRepo,
            IBaseRepository<Autore> _autoreRepo
            ) {
            LibroRepo = libroRepo;
            EditorialRepo = _editorialRepo;
            AutorRepo = _autoreRepo;
        }

        public async Task<ResponseBase<Libro>> Create(LibroDTO data)
        {
            var exist = await LibroRepo.GetAsync(predicate: p => p.Titulo == data.Titulo && p.IdAutor == data.IdAutor);
            var _libros = await LibroRepo.GetAllAsync(predicate: p => p.IdEditorial == data.IdEditorial);
            var editorial = await EditorialRepo.GetAsync(predicate: p => p.Id == data.IdEditorial);
            var autor = await AutorRepo.GetAsync(predicate: p => p.Id == data.IdAutor);


            if (exist != null)
            {
                return new ResponseBase<Libro>(message: "Ya existe un Libros Registrado con Este Nombre y Este Autor",code:System.Net.HttpStatusCode.OK);
            }

            if (editorial == null)
            {
                return new ResponseBase<Libro>(message: "La Editorial no está registrada",  code:System.Net.HttpStatusCode.OK);
            }

            if (autor == null)
            {
                return new ResponseBase<Libro>(message: "El Autor no está registrado", code:System.Net.HttpStatusCode.OK);
            }

            if ( _libros.Count() >= editorial.LibrosRegistrado)
            {
                return new ResponseBase<Libro>(message: "No es posible registrar el libro, se alcanzó el máximo permitido.", code:System.Net.HttpStatusCode.OK);
            }

            Libro libro = ConstructModel(data);

            await LibroRepo.AddAsync(libro);

            return new ResponseBase<Libro>(message: "Solicitud Ok", data: libro, count: 1);
        }

      

        public async Task<ResponseBase<Libro>> delete(int id)
        {
            var editorial = await LibroRepo.GetAsync(predicate: p => p.Id == id);
            if (editorial == null)
            {
                return new ResponseBase<Libro>(message: "Nose encontro el registro solicitado");
            }

            await LibroRepo.DeleteAsync(predicate: p => p.Id == id);

            return new ResponseBase<Libro>(message: "Solicitud Ok", data: editorial, count: 1);
        }

        public async  Task<ResponseBase<List<LibroDTO>>> GetAll()
        {
            var all = await LibroRepo.GetAllAsync(include:i=>i.Include(inc=>inc.IdAutorNavigation).Include(inc=>inc.IdEditorialNavigation));
            List<LibroDTO> libros = new List<LibroDTO>();

            all.ToList().ForEach(f => libros.Add(new LibroDTO { 
                Titulo = f.Titulo,
                Generon = f.Generon,
                Anno = f.Anno,
                NumeroPagina = f.NumeroPagina??0,
                Autor = f.IdAutorNavigation.NombreCompleto,
                Editorial = f.IdEditorialNavigation.Nombre

            }));

            return new ResponseBase<List<LibroDTO>>(message: "Solicitud Ok", data: libros, count: all.Count());
        }

        public async Task<ResponseBase<Libro>> GetFind(int id)
        {
            var editorial = await LibroRepo.GetAsync(predicate: p => p.Id == id);
            if (editorial == null)
            {
                return new ResponseBase<Libro>(message: "Nose encontro el registro solicitado");
            }

            return new ResponseBase<Libro>(message: "Solicitud Ok", data: editorial, count: 1);
        }

        public async Task<ResponseBase<Libro>> Update(LibroDTO data)
        {
            var editorial = await LibroRepo.GetAsync(predicate: p => p.Id == data.Id);
            if (editorial == null)
            {
                return new ResponseBase<Libro>(message: "Nose pudo actualizar el registro solicitado");
            }

            editorial = ConstructModel(data);
            await LibroRepo.UpdateAsync(editorial);

            return new ResponseBase<Libro>(message: "Solicitud Ok", data: editorial, count: 1);
        }


        private Libro ConstructModel(LibroDTO data)=> new Libro()
            {
                Titulo = data.Titulo,
                Anno = data.Anno,
                Generon = data.Generon,
                IdAutor = data.IdAutor,
                IdEditorial = data.IdEditorial,
                NumeroPagina = data.NumeroPagina
            };
        
    }
}
