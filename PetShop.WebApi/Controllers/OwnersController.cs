﻿using System;
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
    public class OwnersController : ControllerBase
    {
        private IOwnerService _ownerService;

        public OwnersController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }
        // GET: api/<OwnersController>
        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get()
        {
            return _ownerService.GetAllOwners();
        }

        // GET api/<OwnersController>/5
        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
            try
            {
                return StatusCode(200,_ownerService.FindOwnerById(id));
            }
            catch (Exception e)
            {
                return StatusCode(500,e.Message);
            }
            
        }

        // POST api/<OwnersController>
        [HttpPost]
        public ActionResult<Owner> Post([FromBody] Owner owner)
        {
            try
            {
                return StatusCode(201,_ownerService.CreateOwner(owner));
            }
            catch (Exception e)
            {
                return StatusCode(500,e.Message);
            }
           
        }

        // PUT api/<OwnersController>/5
        [HttpPut("{id}")]
        public ActionResult<Owner> Put(int id, [FromBody] Owner owner)
        {
            try
            {
                return StatusCode(202,_ownerService.UpdateOwner(owner));
            }
            catch (Exception e)
            {
                return StatusCode(500,e.Message);
            }
              
            
        }

        // DELETE api/<OwnersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                _ownerService.DeleteOwner(id);
            }
            catch (Exception e)
            {
                BadRequest(e.Message);
            }
            
        }
    }
}
