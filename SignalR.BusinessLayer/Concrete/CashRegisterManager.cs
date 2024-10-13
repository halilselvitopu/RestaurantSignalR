﻿using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
	public class CashRegisterManager : ICashRegisterService
	{
		private readonly ICashRegisterDal _cashRegisterDal;

		public CashRegisterManager(ICashRegisterDal cashRegisterDal)
		{
			_cashRegisterDal = cashRegisterDal;
		}

		public void TAdd(CashRegister entity)
		{
			_cashRegisterDal.Add(entity);
		}

		public void TDelete(CashRegister entity)
		{
			_cashRegisterDal.Delete(entity);
		}

		public List<CashRegister> TGetAll()
		{
			return _cashRegisterDal.GetAll();
		}

		public CashRegister TGetById(int id)
		{
			return _cashRegisterDal.GetById(id);
		}

		public decimal TGetTotalPriceCashRegister()
		{
			return _cashRegisterDal.GetTotalPriceCashRegister();
		}

		public void TUpdate(CashRegister entity)
		{
			_cashRegisterDal.Update(entity);
		}
	}
}
