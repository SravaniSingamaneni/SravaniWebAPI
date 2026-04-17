using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SravaniWebAPI.Models
{
    public class Orders
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("customerName")]
        public string CustomerName { get; set; }
        [BsonElement("description")]
        public string Description { get; set; }
        [BsonElement("orderCode")]
        public string OrderCode {  get; set; }
        [BsonElement("phoneNumber")]
        public string PhoneNumber {  get; set; }
        [BsonElement("address1")]
        public string Address1 { get; set; }
        [BsonElement("address2")]
        public string Address2 { get; set; }
        [BsonElement("city")]
        public string City { get; set; }
        [BsonElement("stateCode")]
        public string StateCode { get; set; }
        [BsonElement("postalCode")]
        public int PostalCode { get; set; }
        [BsonElement("country")]
        public string Country { get; set; }
        [BsonElement("emailId")]
        public string EmailId { get; set; }
        [BsonElement("orderCreatedBy")]
        public string OrderCreatedBy {  get; set; }
        [BsonElement("orderModifiedBy")]
        public string OrderModifiedBy { get; set; }
        [BsonElement("orderCreatedDate")]
        public DateTime OrderCreatedDate {  get; set; }
        [BsonElement("orderModifiedDate")]
        public DateTime OrderModifiedDate { get; set; }
    }

    public class RequestCustomerOrders
    {
        public string OrderCode { get; set; }
    }
}
