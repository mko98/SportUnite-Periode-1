﻿using System;
using Halcyon.HAL;
using Halcyon.Web.HAL;
using Microsoft.AspNetCore.Mvc;
using SportUnite.BLL;
using SportUnite.Domain.Models;

namespace SportUnite.API.Controllers
{
    [Produces("application/json")]
    [Route("api/sportEvents")]
    public class SportEventController : Controller
    {
        private IManager<SportEvent> _sportEventManager;

        public SportEventController(IManager<SportEvent> sportEventManager)
        {
            _sportEventManager = sportEventManager;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var sportEventsFromRepo = _sportEventManager.Get();
            return Ok(sportEventsFromRepo);
        }

        [HttpGet("{SportEventId}", Name = "GetSportEvent"), Route("{SportEventId:int}")]
        public IActionResult Get(int sportEventId)
        {
            
            var sportEventFromRepo = _sportEventManager.Get(sportEventId);

            if (sportEventFromRepo == null)
            {
                return NotFound();
            }

            return Ok(sportEventFromRepo);
        }

        [HttpPost]
        public IActionResult Post([FromBody] SportEvent sportEvent)
        {
            if (sportEvent == null)
            {
                return BadRequest();
            }
            if (!_sportEventManager.Save(sportEvent))
            {
                throw new Exception("Creating an author failed on save.");
            }
            return Ok(sportEvent);
        }

        [HttpDelete("{SportEventId}")]
        public IActionResult Delete(int sportEventId)
        {
            var sportEventFromRepo = _sportEventManager.Get(sportEventId);
            if (sportEventFromRepo == null)
            {
                return NotFound();
            }
            if (!_sportEventManager.Delete(sportEventFromRepo))
            {
                throw new Exception($"Deleting author {sportEventId} failed on save.");
            }

            return NoContent();
        }

        [HttpPut("{SportEventId}")]
        public IActionResult Put(int sportEventId, [FromBody] SportEvent sportEvent)
        {
            var sportEventFromRepo = _sportEventManager.Get(sportEventId);
            if (sportEventFromRepo == null || sportEvent == null)
            {
                return NotFound();
            }
            if (sportEvent.Name != null)
            {
                sportEventFromRepo.Name = sportEvent.Name;
            }
            if (sportEvent.Price != null)
            {
                sportEventFromRepo.Price = sportEvent.Price;
            }
            if (sportEvent.Availability != null)
            {
                sportEventFromRepo.Availability = sportEvent.Availability;
            }
            if (!_sportEventManager.Save(sportEventFromRepo))
            {
                throw new Exception($"Deleting author {sportEventId} failed on save.");
            }
            return Ok(sportEventFromRepo);
        }
    }
}
