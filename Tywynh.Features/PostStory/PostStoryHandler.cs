using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tywynh.Domain.Interfaces;
using Tywynh.Domain.Models;
using Tywynh.Features.Common;
using System.Threading.Tasks;

namespace Tywynh.Features.PostStory
{
    public class PostStoryHandler : IRequestHandler<PostStoryCommand, int>
    {
        private readonly IStoryRepository _storyRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PostStoryHandler(IStoryRepository storyRepository, ICategoryRepository categoryRepository)
        {
            _storyRepository = storyRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<int> Handle(PostStoryCommand request)
        {
            var category = await _categoryRepository.GetByNameAsync(request.Category);
            if (category == null)
            {
                category = await _categoryRepository.AddAsync(new Domain.Models.Category(request.Category));
            }

            var story = new Story(request.Text, category.Name);
            await _storyRepository.SaveAsync(story);

            return story.Id;
        }
    }
}
