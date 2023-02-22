﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroApi.Models;

namespace SuperHeroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllHeroes()
        {
            var superHeroes = new List<SuperHero> {
                new SuperHero 
                {   
                    Id = 1, 
                    Name ="Spider Man",
                    FirstName="Peter",
                    LastName="Parker",
                    Place="New York City"
                }
            };

            return Ok(superHeroes);
        }
    }
}