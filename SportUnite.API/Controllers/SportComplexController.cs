using System;
using Halcyon.HAL;
using Halcyon.Web.HAL;
using Microsoft.AspNetCore.Mvc;
using SportUnite.BLL;
using SportUnite.Domain.Models;

namespace SportUnite.API.Controllers
{
    [Produces("application/json")]
    [Route("api/sportcomplexes")]

    public class SportComplexController : Controller
    {
        private IManager<SportComplex> _sportComplexManager;

        public SportComplexController(IManager<SportComplex> sportComplexManager)
        {
            this._sportComplexManager = sportComplexManager;
        }

        [HttpGet()]
        public IActionResult Get()
        {
            var sportcomplexFromRepo = _sportComplexManager.Get();

            return Ok(sportcomplexFromRepo);
        }

        [HttpGet("{SportComplexId}", Name = "GetSportComplex"), Route("{SportComplexId:int}")]
        public IActionResult Get(int sportComplexId)
        {
            var sportComplexFromRepo = _sportComplexManager.Get(sportComplexId);

            if (sportComplexFromRepo == null)
            {
                return NotFound();
            }

            return Ok(sportComplexFromRepo);
        }

        [HttpPost]
        public IActionResult Post([FromBody] SportComplex sportComplex)
        {
            if (sportComplex == null)
            {
                return BadRequest();
            }
            if (!_sportComplexManager.Save(sportComplex))
            {
                throw new Exception("Creating an sporthall failed on save.");
            }
            return Ok(sportComplex);
        }

        [HttpDelete("{SportComplexId}")]
        public IActionResult Delete(int sportcomplexId)
        {
            var sportcomplexFromRepo = _sportComplexManager.Get(sportcomplexId);
            if (sportcomplexFromRepo == null)
            {
                return NotFound();
            }
            if (!_sportComplexManager.Delete(sportcomplexFromRepo))
            {
                throw new Exception($"Deleting sportcomplex {sportcomplexId} failed on save.");
            }
            return NoContent();
        }

        [HttpPut("{SportComplexId}")]
        public IActionResult Put(int sportcomplexId, [FromBody] SportComplex sportcomplex)
        {
            var sportcomplexFromRepo = _sportComplexManager.Get(sportcomplexId);
            if (sportcomplexFromRepo == null || sportcomplex == null)
            {
                return NotFound();
            }
            if (sportcomplex.Name != null)
            {
                sportcomplexFromRepo.Name = sportcomplex.Name;
            }
            if (sportcomplex.Address != null)
            {
                sportcomplexFromRepo.Address = sportcomplex.Address;
            }
            if (sportcomplex.City != null)
            {
                sportcomplexFromRepo.City = sportcomplex.City;
            }
            if (sportcomplex.PostalCode != null)
            {
                sportcomplexFromRepo.PostalCode = sportcomplex.PostalCode;
            }
            if (sportcomplex.HouseNumber != null)
            {
                sportcomplexFromRepo.HouseNumber = sportcomplex.HouseNumber;
            }
            if (sportcomplex.Availability != null)
            {
                sportcomplexFromRepo.Availability = sportcomplex.Availability;
            }
            if (!_sportComplexManager.Save(sportcomplexFromRepo))
            {
                throw new Exception($"Deleting sportcomplex {sportcomplexId} failed on save.");
            }
            return Ok(sportcomplexFromRepo);
        }
    }
}