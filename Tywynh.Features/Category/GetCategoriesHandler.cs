using Tywynh.Domain.Interfaces;
using Tywynh.Features.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tywynh.Features.Category
{
    public class GetCategoriesHandler : IRequestHandler<GetCategoriesQuery, List<CategoryDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IStoryRepository _storyRepository;

        public GetCategoriesHandler(ICategoryRepository categoryRepository, IStoryRepository storyRepository)
        {
            _categoryRepository = categoryRepository;
            _storyRepository = storyRepository;
        }

        public async Task<List<CategoryDto>> Handle(GetCategoriesQuery request)
        {
            var categories = await _categoryRepository.GetAllAsync();
            var stories = await _storyRepository.GetAllStories();

            var result = categories
                .Select(cat => new CategoryDto
                {
                    Id = cat.Id,
                    Name = cat.Name,
                    Count = stories.Count(s => s.Category == cat.Name)
                })
                .ToList();

            return result;
        }
    }
}