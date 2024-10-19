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
	public class NotificationManager : INotificationService
	{
		private readonly INotificationDal _notificationDal;

		public NotificationManager(INotificationDal notificationDal)
		{
			_notificationDal = notificationDal;
		}

		public int TNotificationCountByStatusFalse()
		{
			return _notificationDal.NotificationCountByStatusFalse();
		}

		public void TAdd(Notification entity)
		{
			_notificationDal.Add(entity);
		}

		public void TDelete(Notification entity)
		{
			_notificationDal.Delete(entity);
		}

		public List<Notification> TGetAll()
		{
			return _notificationDal.GetAll();
		}

		public Notification TGetById(int id)
		{
			return _notificationDal.GetById(id);
		}

		public void TUpdate(Notification entity)
		{
			_notificationDal.Update(entity);
		}

		public List<Notification> TGetAllNotificationsByStatusFalse()
		{
			return _notificationDal.GetAllNotificationsByStatusFalse();
		}

		public void TChangeNotificationStatusToFalse(int id)
		{
			_notificationDal.ChangeNotificationStatusToFalse(id);
		}

		public void TChangeNotificationStatusToTrue(int id)
		{
			_notificationDal.ChangeNotificationStatusToTrue(id);
		}
	}
}
