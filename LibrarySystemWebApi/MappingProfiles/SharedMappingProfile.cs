using AutoMapper;
using LibrarySystem.CQRS.Commands;
using LibrarySystem.CQRS.Responses.Author;
using LibrarySystemWebApi.Models;

namespace LibrarySystemWebApi.MappingProfiles
{
    public class SharedMappingProfile : Profile
    {
        public SharedMappingProfile()
        {
            CreateMap<Author, GetAuthorResponse>();
            CreateMap<UpdateAuthorCommand, Author>();
            CreateMap<AddAuthorCommand, Author>();
        }
    }
}
