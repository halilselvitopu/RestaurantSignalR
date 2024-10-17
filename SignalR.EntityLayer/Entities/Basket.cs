using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.EntityLayer.Entities
{
    public class Basket
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int ProductCount { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int TableId { get; set; }
        public Table Table { get; set; }
    }
}
