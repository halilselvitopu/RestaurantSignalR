using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IProductDal : IGenericDal<Product>
    {
        List<Product> GetProductsWihtCategories();
        int GetProductCount();
        int GetProductCountByCategoryNameHamburger();
        int GetProductCountByCategoryNameDrink();
        decimal GetAverageProductPrice();
        decimal GetAverageHamburgerPrice();
		IEnumerable<string> GetMostExpensiveProductNames();
		IEnumerable<string> GetCheapestProductNames();
        List<Product> GetMostPopularProducts();
        decimal GetSteakBurgerPrice();
        decimal GetTotalPriceByDrinks();
        decimal GetTotalPriceBySalads();

	}
}
