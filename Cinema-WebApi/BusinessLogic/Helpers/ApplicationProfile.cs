using AutoMapper;
using BusinessLogic.DTOs;
using DataAccess.Entities;
using DataAccess.Entities.MovieInformation;

namespace BusinessLogic.Helpers
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Genre, GenreDTO>()
                .ForMember(dest => dest.GenreName, act => act.MapFrom(src => src.GenreName))
                .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
                .ReverseMap();
            CreateMap<RoleDTO, MovieActor>().ReverseMap();
            CreateMap<CinemaHall, CinemaHallDTO>().ReverseMap();
            CreateMap<ActorDTO, Actor>()
                .ForMember(dest => dest.Movies, act => act.MapFrom(src => src.Roles))
                .ReverseMap();
            CreateMap<GenreDTO, GenreMovie>()
            .ForMember(dest => dest.GenreId, act => act.MapFrom(src => src.Id));
            CreateMap<GenreMovie, MovieDTO>()
                .ForMember(dest => dest.Id, act => act.MapFrom(src => src.MovieId))
                .ReverseMap(); 
            CreateMap<GenreMovie, GenreDTO>()
            .ForMember(dest => dest.Id, act => act.MapFrom(src => src.GenreId))
            .ForMember(dest => dest.GenreName, act => act.MapFrom(src => src.Genre.GenreName));
            CreateMap<MovieDTO, Movie>()
                    .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Genres, act => act.MapFrom(src => src.Genres))
                    .ForMember(dest => dest.Actors, act => act.MapFrom(src => src.Roles))
                    .ReverseMap();
            CreateMap<UserDTO, User>().ReverseMap();
        }
    }
}