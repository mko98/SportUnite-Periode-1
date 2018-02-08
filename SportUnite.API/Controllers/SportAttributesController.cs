using System;
using Halcyon.HAL;
using Halcyon.Web.HAL;
using Microsoft.AspNetCore.Mvc;
using SportUnite.BLL;
using SportUnite.Domain.Models;

namespace SportUnite.API.Controllers
{
    [Produces("application/json")]
    [Route("api/sportAttributes")]
    public class SportAttributesController : Controller
    {
        private IManager<SportAttribute> _sportAttributeManager;

        public SportAttributesController(IManager<SportAttribute> sportAttributeManager)
        {
            _sportAttributeManager = sportAttributeManager;
        }

        [HttpGet] 
        public IActionResult Get()
        {
            var sportAttributesFromRepo = _sportAttributeManager.Get();

            return Ok(sportAttributesFromRepo);
        }

        [HttpGet("{SportAttributeId}", Name = "GetSportAttribute"), Route("{SportAttributeId:int}")]
        public IActionResult Get(int sportAttributeId)
        {
            
            var sportAttributeFromRepo = _sportAttributeManager.Get(sportAttributeId);

            if (sportAttributeFromRepo == null)
            {
                return NotFound();
            }

            return Ok(sportAttributeFromRepo);
        }

        [HttpPost]
        public IActionResult Post([FromBody] SportAttribute sportAttribute)
        {
            if (sportAttribute == null)
            {
                return BadRequest();
            }
            if (!_sportAttributeManager.Save(sportAttribute))
            {
                throw new Exception("Creating an author failed on save.");
            }
            return Ok(sportAttribute);
        }
        
        
        [HttpDelete("{SportAttributeId}")]
        public IActionResult Delete(int sportAttributeId)
        {
            var sportAttributeFromRepo = _sportAttributeManager.Get(sportAttributeId);
            if (sportAttributeFromRepo == null)
            {
                return NotFound();
            }
            if (!_sportAttributeManager.Delete(sportAttributeFromRepo))
            {
                throw new Exception($"Deleting author {sportAttributeId} failed on save.");
            }

            return NoContent();
        }

        [HttpPut("{SportAttributeId}")]
        public IActionResult Put(int sportAttributeId, [FromBody] SportAttribute sportAttribute)
        {
            var sportAttributeFromRepo = _sportAttributeManager.Get(sportAttributeId);

            if (sportAttributeFromRepo == null || sportAttribute == null)
            {
                return NotFound();
            }
            if (sportAttribute.Name != null)
            {
                sportAttributeFromRepo.Name = sportAttribute.Name;
            }
            if (sportAttribute.Description != null)
            {
                sportAttributeFromRepo.Description = sportAttribute.Description;
            }
            if (sportAttribute.NotUsable != null)
            {
                sportAttributeFromRepo.NotUsable = sportAttribute.NotUsable;
            }
            if (sportAttribute.Availability != null)
            {
                sportAttributeFromRepo.Availability = sportAttribute.Availability;
            }
            if (!_sportAttributeManager.Save(sportAttributeFromRepo))
            {
                throw new Exception($"Deleting author {sportAttributeId} failed on save.");
            }
            return Ok(sportAttributeFromRepo);
        }
    }
}
