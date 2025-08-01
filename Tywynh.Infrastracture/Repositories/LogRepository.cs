using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tywynh.Domain.Interfaces;
using Tywynh.Domain.Models;
using Tywynh.Infrastracture.Persistence.Data;

namespace Tywynh.Infrastracture.Repositories
{
    public class LogRepository : ILogRepository
    {
        private readonly AppDbContext _context;
        public LogRepository(AppDbContext context) => _context = context;

        public async Task AddAsync(RequestLog log)
        {
            _context.RequestLogs.Add(log);
            await _context.SaveChangesAsync();
        }

        public async Task<List<RequestLog>> GetAllAsync()
        {
            return await _context.RequestLogs.OrderByDescending(l => l.Timestamp).ToListAsync();
        }
    }
}