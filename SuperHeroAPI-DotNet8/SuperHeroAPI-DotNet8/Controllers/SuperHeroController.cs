/*SuperHeroController is like the bridge between the frontend and the database.
It listens for HTTP requests (like GET, POST, PUT, DELETE) and performs the right actions.

The [Route("api/[controller]")] means:
👉 The URL will look like /api/SuperHero.*/

/*
 ***✅ What the controller SHOULD do:

Receive the request (and model/data from the client).

Call the right service or repository method.

Handle validation or status codes.

Return an ActionResult with the correct response.

 ***❌ What the controller SHOULD NOT do:

Write SQL or LINQ queries directly.

Contain business logic (like “calculate hero strength” or “apply discounts”).

Access the database directly.*/


using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI_DotNet8.DTOs;
using SuperHeroAPI_DotNet8.Entities;
using SuperHeroAPI_DotNet8.Repositories;
using SuperHeroAPI_DotNet8.Services;

namespace SuperHeroAPI_DotNet8.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _service;

        public SuperHeroController(ISuperHeroService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            var heroes = await _service.GetAllHeroesAsync();
            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetHero(int id)
        {
            var hero = await _service.GetHeroAsync(id);
            if (hero is null) return NotFound("Hero not found.");
            return Ok(hero);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<SuperHero>> GetHeroByName(string name)
        {
            var hero = await _service.GetHeroByNameAsync(name);
            if (hero is null) return NotFound($"No hero with name {name}");
            return Ok(hero);
        }

        [HttpGet("{place}")]
        public async Task<ActionResult<List<SuperHero>>> GetHeroByPlace(string place)
        {
            var heroes = await _service.GetHeroesByPlaceAsync(place);
            if (heroes is null) return NotFound($"No place with name {place}");
            return Ok(heroes);
        }

        [HttpGet("{partialName}")]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroPartialName(string partialName)
        {
            var heroes = await _service.GetHeroesByPartialNameAsync(partialName);
            return Ok(heroes);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHeroDTO hero)
        {
            var heroes = await _service.AddHeroAsync(hero);
            return Ok(heroes);
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero updatedHero)
        {
            var heroes = await _service.UpdateHeroAsync(updatedHero);
            if (!heroes.Any()) return NotFound("Hero not found.");
            return Ok(heroes);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var heroes = await _service.DeleteHeroAsync(id);
            return Ok(heroes);
        }
    }
}


/*💡 Why We Use Async Everywhere

All methods (GET, POST, PUT, DELETE) use async and await because:

Database calls take time.

Async lets the server handle other requests while waiting.

It improves performance and scalability.*/
