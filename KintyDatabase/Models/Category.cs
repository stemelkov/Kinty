using System.Collections.Generic;

namespace KintyDatabase.Models
{
    public class Category
    {
        // Primary key
        public int CategoryId { get; set; }

        // Name of the category
        public string Name { get; set; }

        // Indication whether this category is for income
        public bool IsIncome { get; set; }

        // Optional parent category - foreign key and navigation property
        public int? ParentCategoryId { get; set; }
        public virtual Category Parent { get; set; }
        public virtual ICollection<Category> Children { get; set; }
    }
}
