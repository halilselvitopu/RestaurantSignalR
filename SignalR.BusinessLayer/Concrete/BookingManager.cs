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
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal _bookingDal;

        public BookingManager(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
        }

        public void TAdd(Booking entity)
        {
            _bookingDal.Add(entity);
        }

        public void TChangeBookingStatusToApproved(int id)
        {
            _bookingDal.ChangeBookingStatusToApproved(id);
        }

        public void TChangeBookingStatusToCancelled(int id)
        {
            _bookingDal.ChangeBookingStatusToCancelled(id);
        }

        public void TDelete(Booking entity)
        {
            _bookingDal.Delete(entity);
        }

        public List<Booking> TGetAll()
        {
            return _bookingDal.GetAll();    
        }

        public Booking TGetById(int id)
        {
            return _bookingDal.GetById(id);
        }

        public int TGetTotalBookingCount()
        {
            return _bookingDal.GetTotalBookingCount();
        }

        public void TUpdate(Booking entity)
        {
            _bookingDal.Update(entity);
        }
    }
}
