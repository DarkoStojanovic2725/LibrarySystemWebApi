using AutoMapper;
using LibrarySystem.CQRS.Responses;
using LibrarySystemWebApi.Models;

namespace LibrarySystemWebApi.MappingProfiles
{
    public class SharedMappingProfile : Profile
    {
        public SharedMappingProfile()
        {
            CreateMap<Author, GetAuthorResponse>();
        }
    }
}
