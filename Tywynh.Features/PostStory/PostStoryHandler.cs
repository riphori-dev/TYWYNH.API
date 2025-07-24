using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tywynh.Domain.Interfaces;
using Tywynh.Domain.Models;
using Tywynh.Features.Common;

namespace Tywynh.Features.PostStory
{
    public class PostStoryHandler : IRequestHandler<PostStoryCommand, int>
    {
        private readonly IStoryRepository _repository;
        public PostStoryHandler(IStoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> Handle(PostStoryCommand request)
        {
            var story = new Story(request.Text, request.Category);

            await _repository.SaveAsync(story);

            return story.Id;
        }
    }
}
