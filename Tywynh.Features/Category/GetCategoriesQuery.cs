using Tywynh.Domain.Models;
using Tywynh.Features.Common;
using System.Collections.Generic;

namespace Tywynh.Features.Category
{
    public class GetCategoriesQuery : IRequest<List<Domain.Models.Category>> { }
}