using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tywynh.Domain.Interfaces;
using Tywynh.Features.Common;

namespace Tywynh.Features.UpliftingThought
{
    public class UpliftingThoughtHandler : IRequestHandler<UplifingThoughtCommand, string>
    {
        private readonly IUpliftingThoughtService _thoughtService;
        public UpliftingThoughtHandler(IUpliftingThoughtService thoughtService)
        {
            _thoughtService = thoughtService;
        }
        public async Task<string> Handle(UplifingThoughtCommand request)
        {
            return await _thoughtService.GetUpliftingThoughtAsync(request.Query);
        }
    }
}
