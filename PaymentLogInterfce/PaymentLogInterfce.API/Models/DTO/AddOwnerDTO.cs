﻿using Azure.Identity;

namespace PaymentLogInterfce.API.Models.DTO
{
    public class AddOwnerDTO
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string TowerNo { get; set; }
        public string FlatNo { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }


    }
}
