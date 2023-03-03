



namespace PaymentLogInterfce.API.Models.Domain
{
    public class PaymentLog
    {

        public Guid Id { get; set; }        
        public string Description { get; set; }
        public string PaymentDate { get; set;}
        public string TxnID { get; set; }
        public double Amount { get; set; }

        public Guid OwnerId { get; set; }
        public Owner Owner { get; set; }


    }
}
