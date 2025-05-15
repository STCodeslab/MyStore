using Microsoft.EntityFrameworkCore;
using MyStore.Data;
using MyStore.Models;

namespace MyStore.Repository
{
    public class CategoryRepository : Icategory
    {
        private readonly StoreDbContext _context;
        public CategoryRepository(StoreDbContext storeDbContext)
        {
            _context = storeDbContext;
        }
        public async Task<Category> CreateAsync(Category category)
        {
            try
            {
              await  _context.AddAsync(category);
               await _context.SaveChangesAsync();
                return category;
            }
            catch(Exception ex)
            {
                throw new Exception("Error" + ex);

            }
        }

        public async Task<Category> DeleteAsync(Category category)
        {

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public  async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.CategoryId == id);
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }





    }
}
