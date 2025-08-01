using System.Collections.Generic;
using System.Threading.Tasks;
using Tywynh.Domain.Models;

namespace Tywynh.Domain.Interfaces
{   
    public interface ILogRepository
    {
        Task AddAsync(RequestLog log);
        Task<List<RequestLog>> GetAllAsync();
    }
}