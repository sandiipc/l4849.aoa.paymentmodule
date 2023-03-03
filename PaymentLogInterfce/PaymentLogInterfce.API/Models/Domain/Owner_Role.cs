


namespace PaymentLogInterfce.API.Models.Domain
{
    public class Owner_Role
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public Owner Owner { get; set; }
        public Guid RoleId { get; set; }
        public Role Role { get; set; }


    }
}
