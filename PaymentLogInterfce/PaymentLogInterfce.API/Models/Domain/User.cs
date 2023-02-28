﻿namespace PaymentLogInterfce.API.Models.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string OwnerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<string> Roles { get; set; }
        public string IsDeleted { get; set; }

    }
}
