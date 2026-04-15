using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SravaniWebAPI.Models;
using SravaniWebAPI.Services;
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

        // POST:: Save Orders information in ReturnOrders collection
        [HttpPost(Name ="SaveOrderInfo")]
        public async Task<IActionResult> SaveOrderData([FromBody]Orders objOrder)
        {
            var result= await _mongoOrderServicecs.SaveOrdersAsync(objOrder);

            return Ok(result);
        }

        // PUT:: Update Orders information in ReturnOrders collection

        // DELETE:: Delete Orders information from ReturnOrders collection
    }
}
