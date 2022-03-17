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
                    dbEntry.ImageData = product.ImageData;
                    dbEntry.ImageMimeType = product.ImageMimeType;
                }
            }
            _dbContext.SaveChanges();
        }

        public Product DeleteProduct(int productID)
        {
            Product dbEntry = _dbContext.Products.Find(productID);
            if(dbEntry != null)
            {
                _dbContext.Products.Remove(dbEntry);
                _dbContext.SaveChanges();
            }
            return dbEntry;
        }
    }
}
