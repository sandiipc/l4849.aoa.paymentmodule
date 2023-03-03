

namespace PaymentLogInterfce.API.Models.Domain
{
    public class Role
    {

        public Guid Id { get; set; }
        public string Name { get; set; }

        public List<Owner_Role> OwnerRoles { get; set; }


    }
}
