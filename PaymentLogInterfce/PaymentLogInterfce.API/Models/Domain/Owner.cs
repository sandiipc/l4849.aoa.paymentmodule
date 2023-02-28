﻿using System.ComponentModel;

namespace PaymentLogInterfce.API.Models.Domain
{
    public class Owner
    {
        public Guid Id { get; set; }
        public string OwnerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string TowerNo { get; set; }
        public string FlatNo { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        [DefaultValue("N")]
        public string IsDeleted { get; set; }

        public IEnumerable<PaymentLog> PaymentLogs { get; set; }


    }
}
