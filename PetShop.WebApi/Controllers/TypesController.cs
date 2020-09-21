using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.ApplicationService;
using PetShop.Core.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetShop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesController : ControllerBase
    {
        private IPetTypeService _petTypeService;

        public TypesController(IPetTypeService petTypeService)
        {
            _petTypeService = petTypeService;
        }
        // GET: api/<TypesController>
        [HttpGet]
        public ActionResult<IEnumerable<Pettype>> Get()
        {
            return _petTypeService.GetAllTypes();
        }

        // GET api/<TypesController>/5
        [HttpGet("{id}")]
        public ActionResult<Pettype> Get(int id)
        {
            try
            {
                return StatusCode(200,_petTypeService.FindTypeById(id));
            }
            catch (Exception e)
            {
                return StatusCode(500,e.Message);
            }
        }

        // POST api/<TypesController>
        [HttpPost]
        public ActionResult<Pettype> Post([FromBody] Pettype type)
        {

            try
            {
                return StatusCode(201,_petTypeService.CreateType(type));
            }
            catch (Exception e)
            {
                return StatusCode(500,e.Message);
            }
        }

        // PUT api/<TypesController>/5
        [HttpPut("{id}")]
        public ActionResult<Pettype> Put(int id, [FromBody] Pettype type)
        {
            try
            {
                return StatusCode(202,_petTypeService.UpdateType(type));
            }
            catch (Exception e)
            {
                return StatusCode(500,e.Message);
            }
        }

        // DELETE api/<TypesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                _petTypeService.DeleteType(id);
            }
            catch (Exception e)
            {
                StatusCode(500,e.Message);
            }
        }
    }
}
