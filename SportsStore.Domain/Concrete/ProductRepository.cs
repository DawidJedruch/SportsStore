using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Concrete
{
    public class ProductRepository : IProductRepository
    {
        private ProductDbContext _dbContext = new ProductDbContext();

        public IEnumerable<Product> Products
        {
            get { return _dbContext.Products; }
        }

        public void SaveProduct(Product product)
        {
            if (product.ProductID == 0)
            {
                _dbContext.Products.Add(product);
            }
            else
            {
                Product dbEntry = _dbContext.Products.Find(product.ProductID);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;
                }
            }
            _dbContext.SaveChanges();
        }
    }
}
