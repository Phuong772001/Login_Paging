using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Login_Paging.Services;

namespace Login_Paging.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IHangHoaResposity _hangHoaResposity;

        public ProductController(IHangHoaResposity hangHoaResposity )
        {
            _hangHoaResposity = hangHoaResposity;
        }

        [HttpGet]
        public IActionResult GetAllProduct(string search,int page = 1)
        {
            try
            {
                var result = _hangHoaResposity.GetAll(search,page);
                return Ok(result);
            }
            catch
            {
                return BadRequest("We can't get the product");
            }
        }
    }
}
