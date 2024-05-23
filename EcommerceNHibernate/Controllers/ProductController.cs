using EcommerceNHibernate.Aplication.Service;
using EcommerceNHibernate.Domain.Entidades;
using EcommerceNHibernate.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceNHibernate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
     

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("id/{IdProduct}", Name = "GetProductById")]
        public Product GetProduct([FromRoute] int IdProduct) {
            var response = _productService.GetProductById(IdProduct);
            return response;
        }
        [HttpPost (Name = "Insert")]
        public IActionResult InsertProduct([FromBody]Product product)
        {
            _productService.AddProduct(product);
            return Ok();
        }
        [HttpPut(Name = "Update")]
        public IActionResult UpdateProduct([FromBody] Product product)
        {
            _productService.UpdateProduct(product);
            return Ok();
        }
        [HttpDelete("{IdProduct}", Name = "Delete")]
        public IActionResult DeleteProduct([FromRoute] int IdProduct)
        {
            _productService.DeleteProduct(IdProduct);
            return Ok();
        }
        [HttpGet(Name = "GetProductsByPrice")]
        public IEnumerable<Product> GetProductsByPrice([FromRoute] decimal minPrice, decimal maxPrice)
        {
            var response = _productService.GetProductsByPriceRange(minPrice, maxPrice);
            return response;
           
        }
        [HttpGet("name/{NameProduct}", Name = "GetProductByName")]
        public Product GetProductByName([FromRoute] string NameProduct)
        {
            var response = _productService.GetProductByName(NameProduct);
            return response;
        }








    }
}
