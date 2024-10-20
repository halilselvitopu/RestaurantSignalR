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
    public class EfDiscountProductDal : GenericRepository<DiscountProduct>, IDiscountProductDal
    {
        public EfDiscountProductDal(SignalRContext signalRContext) : base(signalRContext)
        {
        }

		public void ChangeStatusToFalse(int id)
		{
			using var context = new SignalRContext();
			var value = context.DiscountProducts.Find(id);
			value.Status = false;
			context.SaveChanges();
		}

		public void ChangeStatusToTrue(int id)
		{
			using var context = new SignalRContext();
			var value = context.DiscountProducts.Find(id);
			value.Status = true;
			context.SaveChanges();
		}
	}
}
