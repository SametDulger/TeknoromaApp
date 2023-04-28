using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductManager _productManager;

        public ProductController(ProductManager productManager)
        {
            _productManager = productManager;
        }


        [HttpGet]
        public IActionResult GetAllProduct()
        {
            try
            {
                var products = _productManager.GetAllProductForApi();

                return Ok(products);


            }
            catch (Exception)
            {
                return StatusCode(500, "Servis Hatası");
            }
        }

    }
}
