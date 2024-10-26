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
	public class TableManager : ITableService
	{
		private readonly ITableDal _tableDal;

		public TableManager(ITableDal tableDal)
		{
			_tableDal = tableDal;
		}

		public void TAdd(Table entity)
		{
			_tableDal.Add(entity);
		}

        public void TChangeTableStatusToFalse(int id)
        {
            _tableDal.ChangeTableStatusToFalse(id);
        }

        public void TChangeTableStatusToTrue(int id)
        {
            _tableDal.ChangeTableStatusToTrue(id);
        }

        public void TDelete(Table entity)
		{
			_tableDal.Delete(entity);
		}

		public List<Table> TGetAll()
		{
			return _tableDal.GetAll();
		}

		public Table TGetById(int id)
		{
			return _tableDal.GetById(id);
		}

		public int TGetTotalTableCount()
		{
			return _tableDal.GetTotalTableCount();
		}

		public void TUpdate(Table entity)
		{
			_tableDal.Update(entity);
		}
	}
}
