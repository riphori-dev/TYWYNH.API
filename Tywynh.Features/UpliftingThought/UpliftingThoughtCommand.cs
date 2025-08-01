using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tywynh.Features.Common;

namespace Tywynh.Features.UpliftingThought
{
    public class UplifingThoughtCommand : IRequest<string>
    {
        public string Query { get; set; }
        public UplifingThoughtCommand(string query)
        {
            Query = query;
        }
    }
}
