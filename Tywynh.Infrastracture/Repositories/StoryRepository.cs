using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tywynh.Domain.Interfaces;
using Tywynh.Domain.Models;
using Tywynh.Infrastracture.Persistence.Data;

namespace Tywynh.Infrastracture.Repositories
{
    public class StoryRepository : IStoryRepository
    {
        private readonly AppDbContext _context;

        public StoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Story>> GetAllStories()
        {
            try
            {
                return await _context.Stories
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                throw new Exception("An error occurred while retrieving stories.", ex);
            }
        }

        public async Task<Story?> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Stories
                    .FirstOrDefaultAsync(s => s.Id == id);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                throw new Exception($"An error occurred while retrieving the story with ID {id}.", ex);
            }
        }

        public async Task SaveAsync(Story story)
        {
             _context.Stories.Add(story);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Story story)
        {
            _context.Stories.Update(story);
            await _context.SaveChangesAsync();
        }
    }
}
