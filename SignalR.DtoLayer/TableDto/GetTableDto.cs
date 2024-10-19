using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.TableDto
{
    public class GetTableDto
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public bool Status { get; set; }
    }
}
