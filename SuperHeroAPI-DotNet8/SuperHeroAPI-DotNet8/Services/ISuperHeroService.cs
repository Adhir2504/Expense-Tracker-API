using SuperHeroAPI_DotNet8.DTOs;
using SuperHeroAPI_DotNet8.Entities;
using System.Threading.Tasks;

namespace SuperHeroAPI_DotNet8.Services
{
    public interface ISuperHeroService
    {
        Task<List<SuperHeroDTO>> GetAllHeroesAsync();
        Task<SuperHeroDTO?> GetHeroAsync(int id);
        Task<List<SuperHeroDTO>> GetHeroByNameAsync(string name);
        Task<List<SuperHeroDTO>> GetHeroesByPlaceAsync(string place);
        Task<List<SuperHeroDTO1>> GetHeroesByPartialNameAsync(string partialName);
        Task<List<SuperHeroDTO>> AddHeroAsync(SuperHeroDTO heroDto);
        Task<List<SuperHeroDTO>?> UpdateHeroAsync(SuperHero updatedHero);
        Task<bool> DeleteHeroAsync(int id);
    }
}
