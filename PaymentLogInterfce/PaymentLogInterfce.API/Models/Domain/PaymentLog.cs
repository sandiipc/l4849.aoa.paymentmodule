namespace PaymentLogInterfce.API.Models.Domain
{
    public class PaymentLog
    {

        public Guid Id { get; set; }
        public string ParentOwnerId { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string MobileNo { get; set; }
        //public string Email { get; set; }
        //public string TowerNo { get; set; }
        //public string FlatNo { get; set; }
        public string Description { get; set; }
        public string PaymentDate { get; set;}
        public string TxnID { get; set; }
        public double Amount { get; set; }

        public Owner Owner { get; set; }


    }
}
