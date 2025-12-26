using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI_DotNet8.DTOs;
using SuperHeroAPI_DotNet8.Entities;

namespace SuperHeroAPI_DotNet8.Repositories
{
    public interface ISuperHeroRepository
    {
        Task<List<SuperHero>> GetAllHeroesAsync();
        Task<SuperHero?> GetHeroAsync(int id);
        Task<List<SuperHero>> GetHeroByNameAsync(string name);
        Task<List<SuperHero>> GetHeroByPlaceAsync(string place);
        Task<List<SuperHero?>> GetAllHeroPartialNameAsync(string name);
        Task<List<SuperHero>> AddHeroAsync(SuperHero hero);
        Task<List<SuperHero?>> UpdateHeroAsync(SuperHero updatedHero);
        Task<List<SuperHero>> DeleteHeroAsync(int id);
    }
}