using Tywynh.Features.Common;

namespace Tywynh.Features.StoryHeart
{
    public class AddHeartCommand : IRequest<bool>
    {
        public int StoryId { get; set; }
        public AddHeartCommand(int storyId) => StoryId = storyId;
    }
}