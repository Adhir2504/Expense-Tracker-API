/*
 ***✅ What the repository SHOULD do:

Write and execute LINQ/EF queries.

Insert, update, delete, or fetch data.

Map entities or use DTOs (if not handled in a service layer).

Keep database access consistent in one place.

 ***❌ What the repository SHOULD NOT do:

Know about HTTP requests/responses.

Handle user input or validation.

Return ActionResult (that’s the controller’s job).

Contain heavy business logic — that’s for the service layer.
*/

using Microsoft.EntityFrameworkCore;
using SuperHeroAPI_DotNet8.Data;
using SuperHeroAPI_DotNet8.DTOs;
using SuperHeroAPI_DotNet8.Entities;

namespace SuperHeroAPI_DotNet8.Repositories
{
    //Dependency Injection
    public class SuperHeroRepository : ISuperHeroRepository
    {
        private readonly DataContext _context;

        public SuperHeroRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<SuperHero>> GetAllHeroesAsync()
        {
            return await _context.SuperHeroes.ToListAsync();
        }

        public async Task<SuperHero?> GetHeroAsync(int id)
        {
            return await _context.SuperHeroes.FindAsync(id);
        }

        public async Task<List<SuperHero>> GetHeroByNameAsync(string name)
        {
            return await _context.SuperHeroes
                .Where(h => h.Name == name)
                .ToListAsync();

        }

        public async Task<List<SuperHero>> GetHeroByPlaceAsync(string place)
        {
            return await _context.SuperHeroes
                .Where(h => h.Place == place)
                .ToListAsync();
        }

        public async Task<List<SuperHero>> GetAllHeroPartialNameAsync(string name)
        { 
            return await _context.SuperHeroes
                .Where(h => h.Name.Contains(name))
                .ToListAsync();
        }

        public async Task<List<SuperHero>> AddHeroAsync(SuperHero hero)
        {
            var newHero = new SuperHero
            {
                Name = hero.Name,
                FirstName = hero.FirstName,
                LastName = hero.LastName,
                Place = hero.Place
            };

            _context.SuperHeroes.Add(newHero);
            await _context.SaveChangesAsync();

            return await _context.SuperHeroes.ToListAsync();
        }

        public async Task<List<SuperHero>> UpdateHeroAsync(SuperHero updatedHero)
        {
            var dbHero = await _context.SuperHeroes.FindAsync(updatedHero.Id);
            if (dbHero is null) return new List<SuperHero>();

            dbHero.Name = updatedHero.Name;
            dbHero.FirstName = updatedHero.FirstName;
            dbHero.LastName = updatedHero.LastName;
            dbHero.Place = updatedHero.Place;

            await _context.SaveChangesAsync();
            return await _context.SuperHeroes.ToListAsync();
        }

        public async Task<List<SuperHero>> DeleteHeroAsync(int id)
        {
            var dbHero = await _context.SuperHeroes.FindAsync(id);
            if (dbHero is null) return new List<SuperHero>();

            _context.SuperHeroes.Remove(dbHero);
            await _context.SaveChangesAsync();

            return await _context.SuperHeroes.ToListAsync();
        }
    }
}
