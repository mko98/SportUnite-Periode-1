using System;
using Halcyon.HAL;
using Halcyon.Web.HAL;
using Microsoft.AspNetCore.Mvc;
using SportUnite.BLL;
using SportUnite.Domain.Models;

namespace SportUnite.API.Controllers
{
    [Produces("application/json")]
    [Route("api/sports")]
    public class SportsController : Controller
    {
        private IManager<Sport> _sportManager;

        public SportsController(IManager<Sport> sportManager)
        {
            _sportManager = sportManager;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var sportsFromRepo = _sportManager.Get();

            return Ok(sportsFromRepo);
        }

        [HttpGet("{SportId}", Name = "GetSport"), Route("{SportId:int}")]
        public IActionResult Get(int sportId)
        {
            var sportFromRepo = _sportManager.Get(sportId);

            if (sportFromRepo == null)
            {
                return NotFound();
            }

            return Ok(sportFromRepo);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Sport sport)
        {
            if (sport == null)
            {
                return BadRequest();
            }
            if (!_sportManager.Save(sport))
            {
                throw new Exception("Creating an author failed on save.");
            }
            return Ok(sport);
        }

        [HttpDelete("{SportId}")]
        public IActionResult Delete(int sportId)
        {
            var sportFromRepo = _sportManager.Get(sportId);
            if (sportFromRepo == null)
            {
                return NotFound();
            }
            if (!_sportManager.Delete(sportFromRepo))
            {
                throw new Exception($"Deleting author {sportId} failed on save.");
            }
            return NoContent();
        }

        [HttpPut("{SportId}")]
        public IActionResult Put(int sportId, [FromBody] Sport sport)
        {
            var sportFromRepo = _sportManager.Get(sportId);
            if (sportFromRepo == null || sport == null)
            {
                return NotFound();
            }
            if (sport.Name != null)
            {
                sportFromRepo.Name = sport.Name;
            }
            if (sport.Description != null)
            {
                sportFromRepo.Description = sport.Description;
            }
            if (sport.Availability != null)
            {
                sportFromRepo.Availability = sport.Availability;
            }
            if (!_sportManager.Save(sportFromRepo))
            {
                throw new Exception($"Deleting author {sportId} failed on save.");
            }
            return Ok(sportFromRepo);
        }
    }
}
