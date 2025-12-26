using AutoMapper;
using SuperHeroAPI_DotNet8.DTOs;
using SuperHeroAPI_DotNet8.Entities;

namespace SuperHeroAPI_DotNet8.Mapping
{
    public class AutoMapper: Profile
    {
        public AutoMapper() 
        {
            CreateMap<SuperHero, SuperHeroDTO>().ReverseMap();
        }
        
    }
}
