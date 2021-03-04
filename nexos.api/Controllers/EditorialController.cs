
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nexos.Entities.Interface.BusinessRules;

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
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EditorialController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EditorialController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EditorialController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
