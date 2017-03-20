using System;
using System.Collections.Generic;

namespace Prodo.API.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts(int categoryId);
        Product GetProduct(int id);
        Product SaveProduct(Product product);
        bool UpdateProduct(int id, Product product);
        void Delete(int id);
    }
}