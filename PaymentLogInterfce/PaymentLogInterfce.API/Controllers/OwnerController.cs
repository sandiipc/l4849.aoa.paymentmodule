using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaymentLogInterfce.API.Models.Domain;
using PaymentLogInterfce.API.Repositories;

namespace PaymentLogInterfce.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OwnerController : Controller
    {
        private readonly IOwnerRepository ownerRepository;
        private readonly IMapper mapper;

        public OwnerController(IOwnerRepository ownerRepository, IMapper mapper)
        {
            this.ownerRepository = ownerRepository;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllOwners() 
        {

            var owners = await this.ownerRepository.GetAllAsync();

            //var ownersDTO = new List<Models.DTO.Owner>();
            //owners.ToList().ForEach(owner =>
            //{
            //    var ownerDTO = new Models.DTO.Owner()
            //    {
            //        Id= owner.Id,
            //        OwnerCode= owner.OwnerCode,
            //        FirstName= owner.FirstName,
            //        LastName= owner.LastName,
            //        MobileNo= owner.MobileNo,
            //        Email= owner.Email,
            //        TowerNo= owner.TowerNo,
            //        FlatNo= owner.FlatNo

            //    };

            //    ownersDTO.Add(ownerDTO);
            //});

            var ownersDTO = mapper.Map<List<Models.DTO.Owner>>(owners);


            return Ok(ownersDTO);
        
        
        }



    }
}
