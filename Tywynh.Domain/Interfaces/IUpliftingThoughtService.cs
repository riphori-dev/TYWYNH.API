using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tywynh.Domain.Interfaces
{
    public interface IUpliftingThoughtService
    {
        Task<string> GetUpliftingThoughtAsync(string Query);

    }
}
