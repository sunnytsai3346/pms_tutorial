using PMS.API.Models.Domains;

namespace PMS.API.Repository.Interface
{
    public interface IProductRepository
    {
        public Task<Product> CreateAsync(Product product);
        public Task<List<Product>> GetAllAsync();

        public Task<Product> GetByIdAsync(Guid id);
        public Task<Product> UpdateAsync(Product product);
        public Task<Product> RemoveAsync(Product product);

    }
}
