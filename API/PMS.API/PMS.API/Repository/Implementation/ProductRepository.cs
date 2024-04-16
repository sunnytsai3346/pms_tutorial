using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using PMS.API.Data;
using PMS.API.Models.Domains;
using PMS.API.Repository.Interface;

namespace PMS.API.Repository.Implementation
{
    public class ProductRepository: IProductRepository
    {
        PMSDbContext dbContext;
        public ProductRepository(PMSDbContext dbContext)
        {
            this.dbContext = dbContext;
            
        }
        public async Task<Product>CreateAsync(Product product)
        {
            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();
            return product;
        }
       public async Task<List<Product>>GetAllAsync()
        {
            var productlist = await dbContext.Products.ToListAsync();
            return productlist;
        }
       public async Task<Product> GetByIdAsync(Guid id)
        {
            var product = await dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            return product;
        }

        public async Task<Product>UpdateAsync(Product product)
        {
            await dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product>RemoveAsync(Product product)
        {
            dbContext.Products.Remove(product);
            await dbContext.SaveChangesAsync();
            return product;
        }

        
    }
}
