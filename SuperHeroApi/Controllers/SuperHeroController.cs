using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroApi.Models;
using SuperHeroApi.Services.SuperHeroService;

namespace SuperHeroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService superHeroService;

        public SuperHeroController(ISuperHeroService superHeroService)
        {
            this.superHeroService = superHeroService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            return superHeroService.GetAllHeroes();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetSingleHeroes(int id)
        {
            var hero = superHeroService.GetSingleHeroes(id);
            if (hero is null)
            {
                return NotFound("Sorry, But this hero doesn't exist.");
            }
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<SuperHero>> AddHero([FromBody] SuperHero hero)
        {
            superHeroService.AddHero(hero);
            return Ok(hero);
        }

        [HttpPut]
        public async Task<ActionResult<SuperHero>> UpdateHero(SuperHero request)
        {
            var hero = superHeroService.UpdateHero(request);
            if (hero is null)
            {
                return NotFound("Sorry, But this hero doesn't exist.");
            }
            return Ok(hero);
        }

        [HttpDelete("id")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var hero = superHeroService.DeleteHero(id);
            if (hero is null)
            {
                return NotFound("Sorry, But this hero doesn't exist.");
            }
            return Ok(hero);
        }
    }
}
