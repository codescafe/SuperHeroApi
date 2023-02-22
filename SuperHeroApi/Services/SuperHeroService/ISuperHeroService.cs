using Microsoft.AspNetCore.Mvc;

namespace SuperHeroApi.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
        List<SuperHero> GetAllHeroes();
        SuperHero? GetSingleHeroes(int id);
        SuperHero AddHero([FromBody] SuperHero hero);
        SuperHero? UpdateHero(SuperHero request);
        SuperHero? DeleteHero(int id);
    }
}
