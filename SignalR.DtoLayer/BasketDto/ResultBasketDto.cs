using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.BasketDto
{
    public class ResultBasketDto
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int ProductCount { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductId { get; set; }
        public int TableId { get; set; }
    }
}
