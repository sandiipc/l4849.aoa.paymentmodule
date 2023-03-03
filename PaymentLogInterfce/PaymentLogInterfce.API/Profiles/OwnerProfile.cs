using AutoMapper;

namespace PaymentLogInterfce.API.Profiles
{
    public class OwnerProfile: Profile
    {

        public OwnerProfile()
        {
            //CreateMap<Models.Domain.Owner, Models.DTO.GetOwnerDTO>()
            //    .ReverseMap();


            CreateMap<Models.Domain.Owner, Models.DTO.GetOwnerDTO>()
                .ForMember(dest => dest.OwnerCode, options => options.MapFrom(src => src.OwnerCode))
                .ForMember(dest => dest.FirstName, options => options.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, options => options.MapFrom(src => src.LastName))
                .ForMember(dest => dest.MobileNo, options => options.MapFrom(src => src.MobileNo))
                .ForMember(dest => dest.Email, options => options.MapFrom(src => src.Email))
                .ForMember(dest => dest.TowerNo, options => options.MapFrom(src => src.TowerNo))
                .ForMember(dest => dest.FlatNo, options => options.MapFrom(src => src.FlatNo));


            CreateMap<Models.DTO.AddOwnerDTO, Models.Domain.Owner>()
                .ForMember(dest => dest.FirstName, options => options.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, options => options.MapFrom(src => src.LastName))
                .ForMember(dest => dest.MobileNo, options => options.MapFrom(src => src.MobileNo))
                .ForMember(dest => dest.Email, options => options.MapFrom(src => src.Email))
                .ForMember(dest => dest.TowerNo, options => options.MapFrom(src => src.TowerNo))
                .ForMember(dest => dest.FlatNo, options => options.MapFrom(src => src.FlatNo));


            CreateMap<Models.DTO.UpdateOwnerDTO, Models.Domain.Owner>()
                .ForMember(dest => dest.FirstName, options => options.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, options => options.MapFrom(src => src.LastName))
                .ForMember(dest => dest.MobileNo, options => options.MapFrom(src => src.MobileNo))
                .ForMember(dest => dest.Email, options => options.MapFrom(src => src.Email));




        }


    }
}
