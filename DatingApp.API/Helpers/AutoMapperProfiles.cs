using System.Linq;
using AutoMapper;
using DatingApp.API.Dtos;
using DatingApp.Models;

namespace DatingApp.API.Helpers
{
    public class AutoMapperProfiles :Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User,UserForListDto>()
            .ForMember(dest =>dest.PhotoUrl,opt=>{
                opt.MapFrom(src =>src.photos.FirstOrDefault(P => P.IsMain ).Url );
            })
            .ForMember(dest =>dest.Age,opt =>{
              opt.ResolveUsing(d => d.DateOfBirth.CalculateAge());
            });
            CreateMap<User,UserForDetailedDto>().ForMember(dest =>dest.PhotoUrl,opt=>{
                opt.MapFrom(src =>src.photos.FirstOrDefault(P => P.IsMain ).Url );
            }).ForMember(dest =>dest.Age,opt =>{
              opt.ResolveUsing(d => d.DateOfBirth.CalculateAge());
            });
            CreateMap<Photo,PhotosForDetailedDto>();
        }
        
    }
}