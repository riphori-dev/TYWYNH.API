using Tywynh.Features.Common;

namespace Tywynh.Features.GetStory
{   
    public class GetStoryQuery : IRequest<Story?>
    {
        public int Id { get; set; }
        public GetStoryQuery(int id) => Id = id;
    }
}