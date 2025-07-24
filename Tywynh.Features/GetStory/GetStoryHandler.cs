using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tywynh.Domain.Interfaces;
using Tywynh.Domain.Models;
using Tywynh.Features.Common;

namespace Tywynh.Features.GetStory
{
    public class GetStoryHandler : IRequestHandler<GetStoryCommand, List<Story>>
    {
        private readonly IStoryRepository _repository;
        public GetStoryHandler(IStoryRepository repository) => _repository = repository;

        public async Task<List<Story>> Handle(GetStoryCommand request)
        {
            return await _repository.GetAllStories();
        }
    }
}
