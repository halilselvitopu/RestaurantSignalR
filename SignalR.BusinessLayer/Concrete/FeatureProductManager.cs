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
    public class FeatureProductManager : IFeatureProductService
    {
        private readonly IFeatureProductDal _featureProductDal;

        public FeatureProductManager(IFeatureProductDal featureProductDal)
        {
            _featureProductDal = featureProductDal;
        }

        public void TAdd(FeatureProduct entity)
        {
            _featureProductDal.Add(entity);
        }

        public void TDelete(FeatureProduct entity)
        {
            _featureProductDal.Delete(entity);
        }

        public List<FeatureProduct> TGetAll()
        {
            return _featureProductDal.GetAll();
        }

        public FeatureProduct TGetById(int id)
        {
           return _featureProductDal.GetById(id);
        }

        public void TUpdate(FeatureProduct entity)
        {
            _featureProductDal.Update(entity);
        }
    }
}
