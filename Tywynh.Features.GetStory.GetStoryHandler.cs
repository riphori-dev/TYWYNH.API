using Tywynh.Domain.Interfaces;
using Tywynh.Domain.Models;
using Tywynh.Features.Common;

namespace Tywynh.Features.GetStory
{
    public class GetStoryHandler : IRequestHandler<GetStoryQuery, Story?>
    {   
        private readonly IStoryRepository _repository;
        public GetStoryHandler(IStoryRepository repository) => _repository = repository;

        public async Task<Story?> Handle(GetStoryQuery request)
        {
            return await _repository.GetByIdAsync(request.Id);
        }
    }
}