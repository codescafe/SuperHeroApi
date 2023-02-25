using Microsoft.AspNetCore.Mvc;

namespace SuperHeroApi.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
        Task<List<SuperHero>> GetAllHeroes();
        Task<SuperHero?> GetSingleHeroes(int id);
        Task<SuperHero> AddHero([FromBody] SuperHero hero);
        Task<SuperHero?> UpdateHero(SuperHero request);
        Task<SuperHero?> DeleteHero(int id);
    }
}
