using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tywynh.Domain.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        private Category() { } // For EF Core or serialization

        public Category(string name, string description)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Category name cannot be empty.", nameof(name));
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Category description cannot be empty.", nameof(description));

            Name = name;
            Description = description;
        }
    }
}
