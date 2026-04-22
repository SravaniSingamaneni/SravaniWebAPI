using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SravaniWebAPI.Models;
using SravaniWebAPI.Services;
using SravaniWebAPI.Validations;
using System.ComponentModel;

namespace SravaniWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MongoOrderController : ControllerBase
    {
        private readonly IMongoOrderServicecs _mongoOrderServicecs;
        public MongoOrderController(IMongoOrderServicecs mongoOrderServicecs)
        {
            _mongoOrderServicecs = mongoOrderServicecs;
        }

        // GET:: Show the Customer orders based on OrderCode from mongoDB
        [HttpGet(Name ="GetCustomerOrderInfo")]
        public async Task<IActionResult> GetCustomerOrderData([FromQuery] RequestCustomerOrders reqCustOrders)
        {
            var getCustOrderResult = await _mongoOrderServicecs.GetCustomerOrdersAsync(reqCustOrders);
            return Ok(getCustOrderResult);
        }

        // POST:: Save Orders information in ReturnOrders collection
        [HttpPost(Name ="SaveOrderInfo")]
        public async Task<IActionResult> SaveOrderData([FromBody]Orders objOrder)
        {  
            var result= await _mongoOrderServicecs.SaveOrdersAsync(objOrder);
            return Ok(result);
        }

        // PUT:: Update Orders information in ReturnOrders collection
        [HttpPut(Name ="UpdateOrderInfo/{id}")]
        public async Task<IActionResult> UpdateOrderData(string id,[FromBody] Orders objUpdateOrder)
        {
            var updateResult= await _mongoOrderServicecs.UpdateOrdersAsync(id, objUpdateOrder);
            return Ok(updateResult);
        }

        // DELETE:: Delete Orders information based on OrderCode
        [HttpDelete(Name ="DeleteOrderInfo/{OrderCode}")]
        public async Task<IActionResult> DeleteByOrderCode(string OrderCode)
        {
            var deleteCount = await _mongoOrderServicecs.DeleteByOrderCodeAsync(OrderCode); 
            
            return Ok($"{OrderCode} record(s) deleted successfully!");
        }
    }
}
