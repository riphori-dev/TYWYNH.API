using Tywynh.Domain.Interfaces;
using Tywynh.Features.Common;
using System.Threading.Tasks;

namespace Tywynh.Features.StoryHeart
{
    public class AddHeartHandler : IRequestHandler<AddHeartCommand, bool>
    {
        private readonly IStoryRepository _repository;
        public AddHeartHandler(IStoryRepository repository) => _repository = repository;

        public async Task<bool> Handle(AddHeartCommand request)
        {
            var story = await _repository.GetByIdAsync(request.StoryId);
            if (story == null)
                return false;

            story.AddHeart();
            await _repository.UpdateAsync(story);
            return true;
        }
    }
}