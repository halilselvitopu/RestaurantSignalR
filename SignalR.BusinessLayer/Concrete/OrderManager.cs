using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
	public class OrderManager : IOrderService
	{
		private readonly IOrderDal _orderDal;

		public OrderManager(IOrderDal orderDal)
		{
			_orderDal = orderDal;
		}

		public int TGetActiveOrderCount()
		{
			return _orderDal.GetActiveOrderCount();
		}

		public void TAdd(Order entity)
		{
			_orderDal.Add(entity);
		}

		public void TDelete(Order entity)
		{
			_orderDal.Delete(entity);
		}

		public List<Order> TGetAll()
		{
			return _orderDal.GetAll();
		}

		public Order TGetById(int id)
		{
			return _orderDal.GetById(id);
		}

		public int TGetTotalOrderCount()
		{
			return _orderDal.GetTotalOrderCount();
		}

		public void TUpdate(Order entity)
		{
			_orderDal.Update(entity);
		}

		public decimal TGetLastOrderPrice()
		{
			return _orderDal.GetLastOrderPrice();
		}

		public decimal TGetTodayTotalProfit()
		{
			return _orderDal.GetTodayTotalProfit();
		}
	}
}
