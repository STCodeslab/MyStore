using MyStore.Models;

namespace MyStore.Repository
{
    public interface Icategory
    {
        Task<Category> CreateAsync(Category category);
        Task<Category> UpdateAsync(Category category);
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(int id);
        Task<Category> DeleteAsync(Category category);


    }
}
