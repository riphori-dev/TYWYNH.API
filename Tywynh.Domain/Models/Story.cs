using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tywynh.Domain.Models
{
    public class Story
    {
        public int Id { get; private set; }
        public string Text { get; private set; }
        public int Hearts { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string Category { get; private set; }

        private Story() { } // For EF Core or serialization

        public Story(string text, string category)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentException("Story text cannot be empty.", nameof(text));

            if (string.IsNullOrWhiteSpace(category))
                throw new ArgumentException("Category cannot be empty.", nameof(category));

            Text = text;
            Category = category;
            CreatedAt = DateTime.UtcNow;
            Hearts = 0;
        }

        public void AddHeart()
        {
            Hearts++;
        }
    }

}
