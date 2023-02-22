using Microsoft.AspNetCore.Mvc;

namespace SuperHeroApi.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
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

        public SuperHero AddHero([FromBody] SuperHero hero)
        {
            superHeroes.Add(hero);
            return hero;
        }

        public SuperHero? DeleteHero(int id)
        {
            var hero = superHeroes.Find(x => x.Id == id);
            if (hero is null)
            {
                return null;
            }
            superHeroes.Remove(hero);

            return hero;
        }

        public List<SuperHero> GetAllHeroes()
        {
            return superHeroes;
        }

        public SuperHero? GetSingleHeroes(int id)
        {
            var hero = superHeroes.Find(x => x.Id == id);

            return hero;
        }

        public SuperHero? UpdateHero(SuperHero request)
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

            return hero;
        }
    }
}
