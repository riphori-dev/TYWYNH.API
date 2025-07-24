using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tywynh.Features.Common;

namespace Tywynh.Features.PostStory
{
    public class PostStoryCommand : IRequest<int>
    {
        public string Text { get; set; }

        public string Category { get; set; }
    }
}
