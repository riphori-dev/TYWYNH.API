using Tywynh.Features.Common;

namespace Tywynh.Features.Category
{
    public class CreateCategoryCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}