using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prodo.API.Models
{
    public class ProductRepository : IProductRepository
    {
        public static List<Product> Products { get; private set; }
        private int _nextId = 5;

        public ProductRepository()
        {
            if (Products == null || Products.Count == 0)
            {
                Seed();
            }
        }

        private void Seed()
        {
            Products = new List<Product>();

            Products.Add(new Product()
            {
                Id = 1,
                CategoryId = 1,
                Name = "Samsung S6 edge",
                Description = "This is Samsung S6 edge smartphone.",
                Cost = 500,
                ImageUrl = "http://www.samsung.com/global/galaxy/galaxys6/galaxy-s6-edge/images/galaxy-s6-edge_gallery_front_black.png"
            });

            Products.Add(new Product()
            {
                Id = 2,
                CategoryId = 1,
                Name = "Samsung S6 edge plus",
                Description = "This is Samsung S6 edge plus smartphone.",
                Cost = 650,
                ImageUrl = "http://www.samsung.com/global/galaxy/galaxys6/galaxy-s6-edge/images/galaxy-s6-edge_gallery_front_black.png"
            });

            Products.Add(new Product()
            {
                Id = 3,
                CategoryId = 2,
                Name = "Apple iPad",
                Description = "This is a revolutionary product!",
                Cost = 500,
                ImageUrl = "https://www.bhphotovideo.com/images/images2500x2500/apple_ml0t2ll_a_256gb_ipad_pro_wi_fi_1241236.jpg"
            });

            Products.Add(new Product()
            {
                Id = 4,
                CategoryId = 2,
                Name = "Apple iPad Pro",
                Description = "This is just another revolutionary product!",
                Cost = 650,
                ImageUrl = "https://www.bhphotovideo.com/images/images2500x2500/apple_ml0t2ll_a_256gb_ipad_pro_wi_fi_1241236.jpg"
            });

            Products.Add(new Product()
            {
                Id = 5,
                CategoryId = 2,
                Name = "LG G-Pad",
                Description = "This is a tablet from LG",
                Cost = 600,
                ImageUrl = "http://www.lg.com/uk/images/tablets/v480/gallery/medium01-1.jpg"
            });
        }

        public IEnumerable<Product> GetProducts(int categoryId)
        {
            return Products.Where(p => p.CategoryId.Equals(categoryId)).ToList();
        }

        public IEnumerable<Product> GetProducts()
        {
            return Products.ToList();
        }

        public Product GetProduct(int id)
        {
            return Products.FirstOrDefault(p => p.Id.Equals(id));
        }

        public Product SaveProduct(Product product)
        {
            if (product.Id > 0)
            {
                var result = UpdateProduct(product.Id, product);

                if (result)
                {
                    return product;
                }
            }
            else
            {
                product.Id = _nextId;
                _nextId++;

                Products.Add(product);
            }

            return product;
        }

        public bool UpdateProduct(int id, Product product)
        {
            var index = Products.FindIndex(p => p.Id.Equals(id));

            if (index == -1 && !product.Id.Equals(id))
            {
                return false;
            }
            else
            {
                Products[index] = product;
            }

            return true;
        }

        public void Delete(int id)
        {
            Products.RemoveAll(p => p.Id.Equals(id));
        }
    }
}