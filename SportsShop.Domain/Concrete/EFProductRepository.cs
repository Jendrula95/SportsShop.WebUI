using SportsShop.Domain.Abstract;
using SportsShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsShop.Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private EFDbContext _dbContext = new EFDbContext();
        public IQueryable<Product> Products { get { return _dbContext.Products; } }

        public void SaveProduct(Product product)
        {
            if(product.ProductId == 0)
            {
                _dbContext.Products.Add(product);
            }
            else
            {
                Product dbEntry = _dbContext.Products.Find(product.ProductId);
                if(dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;
                }
            }
            _dbContext.SaveChanges();
        }

        public Product DeleteProduct(int productId)
        {
            Product dbEntry = _dbContext.Products.Find(productId);
            if(dbEntry != null)
            {
                _dbContext.Products.Remove(dbEntry);
                _dbContext.SaveChanges();
            }

            return dbEntry;

        }

    }
}
