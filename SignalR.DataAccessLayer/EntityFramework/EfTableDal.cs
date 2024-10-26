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
	public class EfTableDal : GenericRepository<Table>, ITableDal
	{
		public EfTableDal(SignalRContext signalRContext) : base(signalRContext)
		{
		}

        public void ChangeTableStatusToFalse(int id)
        {
            using var context = new SignalRContext();
            var value = context.Tables.Where(x => x.Id == id).FirstOrDefault();
            value.Status = false;
			context.SaveChanges();
        }

        public void ChangeTableStatusToTrue(int id)
        {
            using var context = new SignalRContext();
			var value = context.Tables.Where(x => x.Id == id).FirstOrDefault();
			value.Status = true;
            context.SaveChanges();
        }

        public int GetTotalTableCount()
		{
			using var context = new SignalRContext();
			return context.Tables.Count();
		}
	}
}
