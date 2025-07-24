using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tywynh.Domain.Models;
using Tywynh.Features.Common;

namespace Tywynh.Features.GetStory
{
    // Command to get all stories
    public class GetStoryCommand : IRequest<List<Story>?>
    {
        // No parameters needed to get all stories
    }
}
