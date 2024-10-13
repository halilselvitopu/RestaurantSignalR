using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.EntityLayer.Entities
{
	public class CashRegister
	{
        public int Id { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
