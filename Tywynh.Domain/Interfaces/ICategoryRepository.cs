using Tywynh.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tywynh.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category?> GetByNameAsync(string name);
        Task<Category?> GetByIdAsync(int id);
        Task<List<Category>> GetAllAsync();
        Task<Category> AddAsync(Category category);
    }
}