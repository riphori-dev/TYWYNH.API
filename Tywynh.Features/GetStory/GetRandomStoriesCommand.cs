using Tywynh.Features.Common;
using System;

namespace Tywynh.Features.GetStory
{
    public class GetRandomStoriesCommand : IRequest<List<Tywynh.Domain.Models.Story>>
    {
        public DateTime Date { get; set; } = DateTime.UtcNow.Date;
    }
}