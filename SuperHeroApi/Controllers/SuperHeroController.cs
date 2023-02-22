﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroApi.Models;

namespace SuperHeroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> superHeroes = new List<SuperHero>(){
                new SuperHero
                {
                    Id = 1,
                    Name ="Spider Man",
                    FirstName="Peter",
                    LastName="Parker",
                    Place="New York City"
                },
                new SuperHero
                {
                    Id = 2,
                    Name ="Iron Man",
                    FirstName="Tony",
                    LastName="Stark",
                    Place="Malibu"
                }
            };

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            return Ok(superHeroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetSingleHeroes(int id)
        {
            var hero = superHeroes.Find(x => x.Id == id);
            if(hero is null)
            {
                return NotFound("Sorry, But this hero doesn't exist.");
            }
            return Ok(hero);
        }
    }
}
