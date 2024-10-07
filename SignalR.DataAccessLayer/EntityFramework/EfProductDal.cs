using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(SignalRContext signalRContext) : base(signalRContext)
        {
        }

        public List<Product> GetProductsWihtCategories()
        {
            var context = new SignalRContext();
            var values = context.Products.Include(p => p.Category).ToList();
            return values;
        }
    }
}
