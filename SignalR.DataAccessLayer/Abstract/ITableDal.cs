﻿using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstract
{
	public interface ITableDal : IGenericDal<Table>
	{
		int GetTotalTableCount();
		void ChangeTableStatusToTrue(int id);
		void ChangeTableStatusToFalse(int id);
	}
}
