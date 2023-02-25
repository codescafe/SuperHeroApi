using Microsoft.AspNetCore.Mvc;
using SuperHeroApi.Data;

namespace SuperHeroApi.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly DataContext context;

        public SuperHeroService(DataContext context)
        {
            this.context = context;
        }

        public async Task<SuperHero> AddHero([FromBody] SuperHero hero)
        {
            context.SuperHeroes.Add(hero);
            await context.SaveChangesAsync();
            return hero;
        }

        public async Task<SuperHero?> DeleteHero(int id)
        {
            var hero = await context.SuperHeroes.FindAsync(id);
            if (hero == null)
            {
                return null;
            }
            context.SuperHeroes.Remove(hero);
            await context.SaveChangesAsync();
            return hero;
        }

        public async Task<List<SuperHero>> GetAllHeroes()
        {
            var heroes = await context.SuperHeroes.ToListAsync();
            return heroes;
        }

        public async Task<SuperHero?> GetSingleHeroes(int id)
        {
            var hero = await context.SuperHeroes.FindAsync(id);
            return hero;
        }

        public async Task<SuperHero?> UpdateHero(SuperHero request)
        {
            var hero = await context.SuperHeroes.FindAsync(request.Id);
            if (hero is null)
            {
                return null;
            }

            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Name = request.Name;
            hero.Place = request.Place;

            await context.SaveChangesAsync();
            return hero;
        }
    }
}
