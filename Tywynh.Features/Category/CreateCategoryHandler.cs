using Tywynh.Domain.Interfaces;
using Tywynh.Domain.Models;
using Tywynh.Features.Common;
using System.Threading.Tasks;

namespace Tywynh.Features.Category
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, int>
    {
        private readonly ICategoryRepository _repository;
        public CreateCategoryHandler(ICategoryRepository repository) => _repository = repository;

        public async Task<int> Handle(CreateCategoryCommand request)
        {
            var existing = await _repository.GetByNameAsync(request.Name);
            if (existing != null)
                return existing.Id;

            var category = new Domain.Models.Category(request.Name);
            var added = await _repository.AddAsync(category);
            return added.Id;
        }
    }
}