using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nexos.Entities.Interface.BusinessRules;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace nexos.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorBusiness business;
        public AutorController(IAutorBusiness _business) {
            business = _business;
        }
        // GET: api/<AutorController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await business.GetAll();
            return StatusCode(result.Code, result);
        }

        // GET api/<AutorController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AutorController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AutorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AutorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
