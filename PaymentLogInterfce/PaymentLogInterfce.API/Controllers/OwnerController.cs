using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> GetAllActiveOwnersAsync() 
        {

            var owners = await this.ownerRepository.GetAllActiveOwnersAsync();
           

            var ownersDTO = mapper.Map<List<Models.DTO.GetOwnerDTO>>(owners);


            return Ok(ownersDTO);
        
        
        }


        [HttpGet]
        [Route("{ownerId}")]
        [ActionName("GetActiveOwnerByIdAsync")]
        public async Task<IActionResult> GetActiveOwnerByIdAsync(string ownerId)
        {
            var owner = await this.ownerRepository.GetActiveOwnerByIdAsync(ownerId);

            if(owner == null)
            {
                return NotFound($"OwnerId {ownerId} not found.");
            }

            var ownerDTO = mapper.Map<Models.DTO.GetOwnerDTO>(owner);

            return Ok(ownerDTO);

        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddOwnerAsync([FromBody] Models.DTO.AddOwnerDTO ownerDTO)
        {

            var ownerId = ownerDTO.TowerNo.ToUpper() + ownerDTO.FlatNo.ToUpper();

            var existingOwner = await GetActiveOwnerByIdAsync(ownerId);

            if(existingOwner is NotFoundObjectResult)
            {
                var owner = mapper.Map<Models.Domain.Owner>(ownerDTO);
                owner.Id = Guid.NewGuid();
                owner.OwnerId = ownerId;
                owner.IsDeleted = "N";

                owner = await this.ownerRepository.AddOwnerAsync(owner);
                var response = mapper.Map<Models.DTO.GetOwnerDTO>(owner);

                return CreatedAtAction(nameof(GetActiveOwnerByIdAsync), new { OwnerId = ownerId }, response);

            }


            return BadRequest($"Duplicate owner id {ownerId}.");


        }

        [HttpDelete]
        [Route("{ownerId}")]
        [Authorize]
        public async Task<IActionResult> DeleteOwnerAsync(string ownerId)
        {

           var owner = await this.ownerRepository.DeleteOwnerAsync(ownerId);

            if(owner == null)
            {
                return NotFound($"OwnerId {ownerId} not found.");
            }

            var deletedOwnerDTO = mapper.Map<Models.DTO.GetOwnerDTO>(owner);

            //var ownerDTO = new Models.DTO.GetOwnerDTO()
            //{
            //    Id = owner.Id,
            //    OwnerId = owner.OwnerId,
            //    FirstName = owner.FirstName,
            //    LastName = owner.LastName,
            //    MobileNo = owner.MobileNo,
            //    Email = owner.Email,
            //    TowerNo = owner.TowerNo,
            //    FlatNo = owner.FlatNo

            //};

            return Ok(deletedOwnerDTO);

        }



        [HttpPut]
        [Route("{ownerId}")]
        [Authorize]
        public async Task<IActionResult> UpdateOwnerAsync(string ownerId, [FromBody] Models.DTO.UpdateOwnerDTO ownerDTO)
        {
            var domainOwner = mapper.Map<Models.Domain.Owner>(ownerDTO);

            var updatedOwner = await this.ownerRepository.UpdateOwnerAsync(ownerId.ToUpper(), domainOwner);

            if (updatedOwner == null)
            {
                return NotFound($"OwnerId {ownerId.ToUpper()} not found.");
            }

            var updatedOwnerDTO = mapper.Map<Models.DTO.GetOwnerDTO>(updatedOwner);

            return Ok(updatedOwnerDTO);


        }



    }
}
