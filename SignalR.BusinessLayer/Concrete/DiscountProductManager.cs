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
    public class DiscountProductManager : IDiscountProductService
    {
        private readonly IDiscountProductDal _discountProductDal;

        public DiscountProductManager(IDiscountProductDal discountProductDal)
        {
            _discountProductDal = discountProductDal;
        }

        public void TAdd(DiscountProduct entity)
        {
            _discountProductDal.Add(entity);
        }

        public void TDelete(DiscountProduct entity)
        {
            _discountProductDal.Delete(entity);
        }

        public List<DiscountProduct> TGetAll()
        {
            return _discountProductDal.GetAll();
        }

        public DiscountProduct TGetById(int id)
        {
           return _discountProductDal.GetById(id);
        }

        public void TUpdate(DiscountProduct entity)
        {
            _discountProductDal.Update(entity);
        }
    }
}
