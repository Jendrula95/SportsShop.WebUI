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

    }
}
