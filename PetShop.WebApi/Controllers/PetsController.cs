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
        public IEnumerable<Pet> Get()
        {
            return _petservice.GetAllPets();
        }

        // GET api/<PetsController>/5
        [HttpGet("{id}")]
        public Pet Get(int id)
        {
            return _petservice.FindPetById(id);
        }

        // POST api/<PetsController>
        [HttpPost]
        public void Post([FromBody] Pet pet)
        {
            _petservice.CreatePet(pet);
        }

        // PUT api/<PetsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PetsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
