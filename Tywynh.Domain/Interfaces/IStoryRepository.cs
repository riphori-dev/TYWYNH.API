using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tywynh.Domain.Models;

namespace Tywynh.Domain.Interfaces
{
    public interface IStoryRepository
    {
        Task<Story?> GetByIdAsync(int id);
        Task SaveAsync(Story story);
        Task<List<Story>> GetAllStories();
    }
}
