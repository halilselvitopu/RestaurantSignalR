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
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

		public int TGetProductCountByCategoryNameDrink()
		{
			return _productDal.GetProductCountByCategoryNameDrink();
		}

		public void TAdd(Product entity)
        {
            _productDal.Add(entity);
        }

        public void TDelete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public List<Product> TGetAll()
        {
           return _productDal.GetAll();
        }

        public Product TGetById(int id)
        {
            return _productDal.GetById(id);
        }

		public int TGetProductCount()
		{
			return _productDal.GetProductCount();
		}

		public List<Product> TGetProductsWithCategories()
        {
            return _productDal.GetProductsWihtCategories();
        }

        public void TUpdate(Product entity)
        {
            _productDal.Update(entity);
        }

		public int TGetProductCountByCategoryNameHamburger()
		{
			return _productDal.GetProductCountByCategoryNameHamburger();
		}

		public decimal TGetAverageProductPrice()
		{
			return _productDal.GetAverageProductPrice();
		}

		public IEnumerable<string> TGetMostExpensiveProductNames()
		{
			return _productDal.GetMostExpensiveProductNames();
		}

		public IEnumerable<string> TGetCheapestProductNames()
		{
			return _productDal.GetCheapestProductNames();
		}

		public decimal TGetAverageHamburgerPrice()
		{
			return _productDal.GetAverageHamburgerPrice();
		}

        public List<Product> TGetMostPopularProducts()
        {
            return _productDal.GetMostPopularProducts();
        }

        public decimal TGetSteakBurgerPrice()
        {
            return _productDal.GetSteakBurgerPrice();
        }

        public decimal TGetTotalPriceByDrinks()
        {
            return _productDal.GetTotalPriceByDrinks();
        }

        public decimal TGetTotalPriceBySalads()
        {
           return _productDal.GetTotalPriceBySalads();
        }

    }
}
