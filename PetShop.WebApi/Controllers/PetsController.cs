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
    public class PetsController : ControllerBase
    {
        private IPetShopService _petservice;

        public PetsController(IPetShopService petShopService)
        {
            _petservice = petShopService;
        }
        // GET: api/<PetsController>
        [HttpGet]
        public ActionResult<FilteredList<Pet>> Get([FromQuery] Filter filter)
        {
            try
            {
                return Ok(_petservice.GetAllFilterPets(filter));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // GET api/<PetsController>/5
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {

            try
            {
                return  StatusCode(200,_petservice.FindPetByIdWithOwner(id));
            }
            catch (Exception e)
            {
                return StatusCode(500,e.Message);
            }
           
        }

        // POST api/<PetsController>
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
            try
            {
                return StatusCode(201,_petservice.CreatePet(pet));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
            
        }

        // PUT api/<PetsController>/5
        [HttpPut("{id}")]
        public ActionResult<Pet> Put([FromBody] Pet pet)
        {
            try
            {
                return StatusCode(202,_petservice.UpdatePet(pet));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
            
        }

        // DELETE api/<PetsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            { 
                StatusCode(202,_petservice.DeletePet(id));
            }
            catch (Exception e)
            {
                 StatusCode(404, e.Message);
            }
        }
    }
}
