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


        [HttpGet]
        [Route("{ownerCode}")]
        [ActionName("GetOwnerById")]
        public async Task<IActionResult> GetOwnerById(string ownerCode)
        {
            var owner = await this.ownerRepository.GetByIdAsync(ownerCode);

            if(owner == null)
            {
                return NotFound();
            }

            var ownerDTO = mapper.Map<Models.DTO.Owner>(owner);

            return Ok(ownerDTO);

        }


        [HttpPost]
        public async Task<IActionResult> AddOwnerAsync([FromBody] Models.DTO.Owner ownerDTO)
        {
            //Models.Domain.Owner owner = mapper.Map<Models.Domain.Owner>(ownerDTO);

            var owner = new Models.Domain.Owner()
            {
                Id  = Guid.NewGuid(),
                OwnerCode = ownerDTO.OwnerCode,
                FirstName = ownerDTO.FirstName,
                LastName = ownerDTO.LastName,
                MobileNo= ownerDTO.MobileNo,
                Email= ownerDTO.Email,
                TowerNo= ownerDTO.TowerNo,
                FlatNo= ownerDTO.FlatNo,
                UserName= ownerDTO.UserName,
                Password    = ownerDTO.Password

            };

            owner = await this.ownerRepository.AddOwnerAsync(owner);

            //ownerDTO = mapper.Map<Models.DTO.Owner>(owner);

            var response = new Models.DTO.Owner()
            {
                Id= owner.Id,
                OwnerCode = owner.OwnerCode,
                FirstName = owner.FirstName,
                LastName = owner.LastName,
                MobileNo = owner.MobileNo,
                Email = owner.Email,
                TowerNo = owner.TowerNo,
                FlatNo = owner.FlatNo,
                UserName = owner.UserName,
                Password = owner.Password

            };

            return CreatedAtAction(nameof(GetOwnerById), new { OwnerCode = ownerDTO.OwnerCode }, response);

        }

        [HttpDelete]
        [Route("{ownerCode}")]
        public async Task<IActionResult> DeleteOwnerAsync(string ownerCode)
        {

           var owner = await this.ownerRepository.DeleteOwnerAsync(ownerCode);

            if(owner == null)
            {
                return NotFound();
            }

            var ownerDTO = new Models.DTO.Owner()
            {
                Id = owner.Id,
                OwnerCode = owner.OwnerCode,
                FirstName = owner.FirstName,
                LastName = owner.LastName,
                MobileNo = owner.MobileNo,
                Email = owner.Email,
                TowerNo = owner.TowerNo,
                FlatNo = owner.FlatNo,
                UserName = owner.UserName,
                Password = owner.Password

            };

            return Ok(ownerDTO);

        }



        [HttpPut]
        [Route("{ownerCode}")]
        public async Task<IActionResult> UpdateOwnerAsync(string ownerCode, [FromBody] Models.DTO.Owner owner)
        {
            var domainOwner = mapper.Map<Models.Domain.Owner>(owner);

            var updatedOwner = await this.ownerRepository.UpdateOwnerAsync(ownerCode, domainOwner);

            if (owner == null)
            {
                return NotFound();
            }

            var ownerDTO = new Models.DTO.Owner()
            {
                Id = updatedOwner.Id,
                OwnerCode = updatedOwner.OwnerCode,
                FirstName = updatedOwner.FirstName,
                LastName = updatedOwner.LastName,
                MobileNo = updatedOwner.MobileNo,
                Email = updatedOwner.Email,
                TowerNo = updatedOwner.TowerNo,
                FlatNo = updatedOwner.FlatNo,
                UserName = updatedOwner.UserName,
                Password = updatedOwner.Password

            };

            return Ok(ownerDTO);




        }



    }
}
