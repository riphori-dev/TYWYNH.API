using Tywynh.Domain.Interfaces;
using Tywynh.Domain.Models;
using Tywynh.Features.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tywynh.Features.Category
{
    public class GetCategoriesHandler : IRequestHandler<GetCategoriesQuery, List<Domain.Models.Category>>
    {
        private readonly ICategoryRepository _repository;
        public GetCategoriesHandler(ICategoryRepository repository) => _repository = repository;

        public async Task<List<Domain.Models.Category>> Handle(GetCategoriesQuery request)
        {
            return await _repository.GetAllAsync();
        }
    }
}