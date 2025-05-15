using MyStore.Models;

namespace MyStore.Repository
{
    public interface IProducts
    {
        Task<Product> CreateAsync(Product product);
        Task<Product> UpdateAsync(Product product);

        Task<Product> DeleteAsync(Product product);

        Task<IEnumerable<Product>> GetAllAsync();

        Task<Product> GetByIdAsync(int id);
    }
}
