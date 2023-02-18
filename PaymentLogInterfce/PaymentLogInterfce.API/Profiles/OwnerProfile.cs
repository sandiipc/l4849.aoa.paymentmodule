using AutoMapper;

namespace PaymentLogInterfce.API.Profiles
{
    public class OwnerProfile: Profile
    {

        public OwnerProfile()
        {
            CreateMap<Models.Domain.Owner, Models.DTO.Owner>()
                .ReverseMap();
        }


    }
}
