using Api.Models;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ProductController :ControllerBase
    {
        private readonly HelpDeskContext _context;
        private readonly IUnitOfWork unitOfWork;
        public ProductController(IUnitOfWork unitOfWork,HelpDeskContext helpDeskContext)
        {
            _context = helpDeskContext;
            this.unitOfWork = unitOfWork;
        }

        
        [HttpGet]
         public IEnumerable<Product> GetAllProducts() { return  unitOfWork.Product.GetAll(); }
       // public async Task<ActionResult<List<Product>>> GetAllProducts()
       // {
            //var product = await _context.Products
               /* .Include(p => p.ProductSerials)
                .Include(p => p.ProductCaracteristics)
                .Include(p => p.IdArrivals)
                .ToListAsync();
            return Ok(product);
            
        }*/

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int productId)
        {
            
            var item = unitOfWork.Product.GetById(productId);
            if (item == null)
                return NotFound();
            return Ok(item);
        }


        [HttpPost]
         public void AddProduct(Product product)
         {
            unitOfWork.Product.Add(product);
            unitOfWork.save();
         }


        [HttpPut]
        public void UpdateProduct(Product product)
        {
            var existingProduct = unitOfWork.Product.GetById(product.IdProduct);
            existingProduct.Categorie = product.Categorie;
            existingProduct.Model = product.Model;
            existingProduct.Marque=product.Marque;
            //update other properties as needed
            unitOfWork.Product.Update(existingProduct);
            unitOfWork.save();
            
        }
        [HttpDelete]
        public void Delete(int productid)
        {
            var product=unitOfWork.Product.GetById(productid);
            unitOfWork.Product.Remove(product);
            unitOfWork.save();
            
        }
    }
}
