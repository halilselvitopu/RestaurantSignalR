using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IBookingService :  IGenericService<Booking>
    {
        void TChangeBookingStatusToApproved(int id);
        void TChangeBookingStatusToCancelled(int id);
        int TGetTotalBookingCount();
    }
}
