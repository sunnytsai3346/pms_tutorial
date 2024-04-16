using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMS.API.Models.Domains;
using PMS.API.Models.Dtos;
using PMS.API.Repository.Interface;

namespace PMS.API.Controllers
{
    //url : https://localhost:portnumber/api/products
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductRepository productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Addproductdto request)
        {
            // map request to product
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                Category = request.Category,
                Unitprice = request.Unitprice,
            };

            // call productrepository to do create data
            await productRepository.CreateAsync(product);

            // map product to productdto
            var response = new Productdto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Category = product.Category,
                Unitprice = product.Unitprice,
            };
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // call respository getall
            var productlist = await productRepository.GetAllAsync();
            var productdtolist = new List<Productdto>();
            //map to dtolist
            foreach (var product in productlist)
            {
                var productdto = new Productdto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Category = product.Category,
                    Unitprice = product.Unitprice,

                };
                productdtolist.Add(productdto);
            }
            return Ok(productdtolist);
        }
        [HttpGet]
        [Route("/api/Products/{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)        
        {
            // repository get by id
            var product = await productRepository.GetByIdAsync(id);
            if (product == null)
                return NotFound();
            // if found , map to dto and return
            var productdto = new Productdto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Category = product.Category,
                Unitprice = product.Unitprice,

            };
            return Ok(productdto);
        }

        [HttpPut]
        [Route("/api/Products/{id:guid}")]
        public async Task<IActionResult>Update(Guid id, Productdto request)
        {
            // get by id from repository
            var product = await productRepository.GetByIdAsync(id);
            if (product == null)
                return NotFound();

            // if found , map to product
            product.Name = request.Name;
            product.Description = request.Description;
            product.Category = request.Category;
            product.Unitprice = request.Unitprice;


            // call repository update
            product = await productRepository.UpdateAsync(product);
            //map to dto , return
            var response = new Productdto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Category = product.Category,
                Unitprice = product.Unitprice,

            };
            return Ok(response);
        }

        [HttpDelete]
        [Route("/api/Products/{id:guid}")]
        public async Task<IActionResult>Delete(Guid id)
        {
            // first , repository get by id 
            var product = await productRepository.GetByIdAsync(id);
            if (product == null )
                return NotFound();

            // if found , repository remove
            product =await productRepository.RemoveAsync(product);
            //map to dto and return
            var response = new Productdto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Category = product.Category,
                Unitprice = product.Unitprice,
            };
            return Ok(response);
        }
       
    }

}
