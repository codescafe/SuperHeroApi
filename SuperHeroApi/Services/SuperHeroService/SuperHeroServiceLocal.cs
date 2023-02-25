using Microsoft.AspNetCore.Mvc;
using SuperHeroApi.Data;

namespace SuperHeroApi.Services.SuperHeroService
{
    public class SuperHeroServiceLocal : ISuperHeroService
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


        public async Task<SuperHero> AddHero(SuperHero hero)
        {
            superHeroes.Add(hero);
            return await Task.Run(() => hero);
        }

        public  async Task<SuperHero?> DeleteHero(int id)
        {
            var hero = superHeroes.Find(x => x.Id == id);
            if (hero is null)
            {
                return null;
            }
            superHeroes.Remove(hero);

            return await Task.Run(() => hero);
        }

        public async Task<List<SuperHero>> GetAllHeroes()
        {
            return await Task.Run(() => superHeroes);
        }

        public async Task<SuperHero?> GetSingleHeroes(int id)
        {
            var hero = superHeroes.Find(x => x.Id == id);

            return await Task.Run(() => hero);
        }

        public async Task<SuperHero?> UpdateHero(SuperHero request)
        {
            var hero = superHeroes.Find(x => x.Id == request.Id);
            if (hero is null)
            {
                return null;
            }

            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Name = request.Name;
            hero.Place = request.Place;

            return await Task.Run(() => hero);
        }
    }
}
