
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nexos.Entities.Interface.BusinessRules;
using Nexos.Entities.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace nexos.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorialController : ControllerBase
    {
        private readonly IEditorialBusiness business;
        public EditorialController(IEditorialBusiness _business) {
            business = _business;
        }
        // GET: api/<EditorialController>
        [HttpGet]
        public async Task<ActionResult>  Get()
        {
            var result = await business.GetAll();
            return StatusCode(result.Code, result);
        }

        // GET api/<EditorialController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await business.GetFind(id);
            return StatusCode(result.Code, result);
        }

        // POST api/<AutorController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EditorialeDTO data)
        {
            var result = await business.Create(data);
            return StatusCode(result.Code, result);
        }

        // PUT api/<AutorController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] EditorialeDTO data)
        {
            var result = await business.Update(data);
            return StatusCode(result.Code, result);
        }

        // DELETE api/<AutorController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await business.delete(id);
            return StatusCode(result.Code, result);
        }
    }
}
