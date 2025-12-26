using SuperHeroAPI_DotNet8.DTOs;
using SuperHeroAPI_DotNet8.Entities;
using SuperHeroAPI_DotNet8.Repositories;

namespace SuperHeroAPI_DotNet8.Services
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly ISuperHeroRepository _repository;

        public SuperHeroService(ISuperHeroRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<SuperHeroDTO>> GetAllHeroesAsync()
        {
            var heroes = await _repository.GetAllHeroesAsync();
            return heroes.Select(MapToDTO).ToList();
        }

        public async Task<SuperHeroDTO?> GetHeroAsync(int id)
        {
            var hero = await _repository.GetHeroAsync(id);
            return hero == null ? null : MapToDTO(hero);
        }

        public async Task<List<SuperHeroDTO>> GetHeroByNameAsync(string name)
        {
            var hero = await _repository.GetHeroByNameAsync(name);
            return hero.Select(MapToDTO).ToList();
        }

        public async Task<List<SuperHeroDTO>> GetHeroesByPlaceAsync(string place)
        {
            var heroes = await _repository.GetHeroByPlaceAsync(place); // returns entities
            return heroes.Select(MapToDTO).ToList();
        }

        public async Task<List<SuperHeroDTO1>> GetHeroesByPartialNameAsync(string partialName)
        {
            var heroes = await _repository.GetAllHeroPartialNameAsync(partialName); // entities
            return heroes.Select(MapToDTO1).ToList();
        }

        public async Task<List<SuperHeroDTO>> AddHeroAsync(SuperHeroDTO heroDto)
        {
            var newHero = new SuperHero
            {
                Name = heroDto.Name,
                FirstName = heroDto.FirstName,
                LastName = heroDto.LastName,
                Place = heroDto.Place
            };

            await _repository.AddHeroAsync(newHero);
            var allHeroes = await _repository.GetAllHeroesAsync();
            return allHeroes.Select(MapToDTO).ToList();
        }

        public async Task<List<SuperHeroDTO>?> UpdateHeroAsync(SuperHero updatedHero)
        {
            var allHeroes = await _repository.GetAllHeroesAsync();
            return allHeroes.Select(MapToDTO).ToList();
        }

        public async Task<bool> DeleteHeroAsync(int id)
        {
            var dbHero = await _repository.GetHeroAsync(id);
            if (dbHero == null) return false;

            await _repository.DeleteHeroAsync(id);
            return true;
        }

        // Helper method to map Entity → DTO
        private SuperHeroDTO MapToDTO(SuperHero hero)
        {
            return new SuperHeroDTO
            {
                Name = hero.Name,
                FirstName = hero.FirstName,
                LastName = hero.LastName,
                Place = hero.Place
            };
        }

        private SuperHeroDTO1 MapToDTO1(SuperHero hero)
        {
            return new SuperHeroDTO1
            {
                Name = hero.Name,
                Place = hero.Place,
            };
        }

    }
}