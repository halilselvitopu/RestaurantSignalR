﻿using SignalR.DataAccessLayer.Abstract;
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
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EfBookingDal(SignalRContext signalRContext) : base(signalRContext)
        {
        }

        public void ChangeBookingStatusToApproved(int id)
        {
            using var context = new SignalRContext();
            var value = context.Bookings.Find(id);
            value.Description = "Rezervasyon Onaylandı";
            context.SaveChanges();
        }

        public void ChangeBookingStatusToCancelled(int id)
        {
            using var context = new SignalRContext();
            var value = context.Bookings.Find(id);
            value.Description = "Rezervasyon İptal Edildi";
            context.SaveChanges();
        }
    }
}
