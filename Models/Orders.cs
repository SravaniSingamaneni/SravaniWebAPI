namespace SravaniWebAPI.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Description { get; set; }
        public string OrderCode {  get; set; }
        public string PhoneNumber {  get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string EmailId { get; set; }
        public string OrderCreatedBy {  get; set; }
        public string OrderModifiedBy { get; set; }
        public DateTime OrderCreatedDate {  get; set; }
        public DateTime OrderModifiedDate { get; set; }
    }
}
