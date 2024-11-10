using AutoMapper;
using TVShowsAPI.DTOs;
using TVShowsAPI.Models;

namespace TVShowsAPI.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TvShow, TvShowDto>().ReverseMap();
            CreateMap<CreateTvShowDto, TvShow>();
            CreateMap<UpdateTvShowDto, TvShow>();
        }
    }
}
