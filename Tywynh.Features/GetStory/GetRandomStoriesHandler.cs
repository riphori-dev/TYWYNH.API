using Tywynh.Domain.Interfaces;
using Tywynh.Domain.Models;
using Tywynh.Features.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tywynh.Features.GetStory
{
    public class GetRandomStoriesHandler : IRequestHandler<GetRandomStoriesCommand, List<Story>>
    {
        private readonly IStoryRepository _repository;
        public GetRandomStoriesHandler(IStoryRepository repository) => _repository = repository;

        public async Task<List<Story>> Handle(GetRandomStoriesCommand request)
        {
            var allStories = await _repository.GetAllStories();
            var todayStories = allStories
                .Where(s => s.CreatedAt.Date == request.Date.Date)
                .OrderBy(_ => Guid.NewGuid())
                .Take(5)
                .ToList();

            return todayStories;
        }
    }
}