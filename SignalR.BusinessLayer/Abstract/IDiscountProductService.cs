using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IDiscountProductService : IGenericService<DiscountProduct>
    {
		void TChangeStatusToTrue(int id);
		void TChangeStatusToFalse(int id);
        public List<DiscountProduct> TGetDiscountProductByStatus();

    }
}
