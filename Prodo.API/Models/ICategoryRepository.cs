using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prodo.API.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories();
        Category GetCategory(int id);
    }
}