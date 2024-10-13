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
	public class EfOrderDal : GenericRepository<Order>, IOrderDal
	{
		public EfOrderDal(SignalRContext signalRContext) : base(signalRContext)
		{
		}

		public int GetActiveOrderCount()
		{
			using var context = new SignalRContext();
			return context.Orders.Count(x => x.Description == "Müşteri Masada");
		}

		public decimal GetLastOrderPrice()
		{
			using var context = new SignalRContext();
			return context.Orders.OrderByDescending(x => x.Id).Select(o => o.TotalPrice).FirstOrDefault();
		}

		public decimal GetTodayTotalProfit()
		{
			using var context = new SignalRContext();
			var today = DateTime.Now.Date;
			return context.Orders.Where(p => p.Date == today).Sum(x => x.TotalPrice);
		}

		public int GetTotalOrderCount()
		{
			using var context = new SignalRContext();
			return context.Orders.Count();
		}
	}
}
