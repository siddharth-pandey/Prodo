using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prodo.API.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        public static List<Category> Categories { get; private set; }

        public CategoryRepository()
        {
            if (Categories == null || Categories.Count == 0)
            {
                Seed();
            }
        }

        private void Seed()
        {
            Categories = new List<Category>
            {
                new Category() { Id = 1, Name = "Smartphones" },
                new Category() { Id = 2, Name = "Tablets" }
            };
        }

        public IEnumerable<Category> GetCategories()
        {
            return Categories;
        }

        public Category GetCategory(int id)
        {
            return Categories.FirstOrDefault(p => p.Id.Equals(id));
        }
    }
}