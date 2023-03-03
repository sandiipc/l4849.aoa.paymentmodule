using System.ComponentModel;

namespace PaymentLogInterfce.API.Models.DTO
{
    public class GetOwnerDTO
    {

        public string OwnerCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string TowerNo { get; set; }
        public string FlatNo { get; set; }

    }
}
