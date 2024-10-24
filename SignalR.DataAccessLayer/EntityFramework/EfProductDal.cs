using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
	public class EfProductDal : GenericRepository<Product>, IProductDal
	{
		public EfProductDal(SignalRContext signalRContext) : base(signalRContext)
		{
		}

		public decimal GetAverageHamburgerPrice()
		{
			using var context = new SignalRContext();
			return context.Products.Where(p => p.Category.Name == "Hamburger").Average(x => x.Price);
		}

		public decimal GetAverageProductPrice()
		{
			using var context = new SignalRContext();
			return context.Products.Average(x => x.Price);
		}

		public IEnumerable<string> GetCheapestProductNames()
		{
			using var context = new SignalRContext();
			var minPrice = context.Products.Min(x => x.Price);
			return context.Products.Where(x => x.Price == minPrice).Select(p => p.Name).ToList();
		}

		public IEnumerable<string> GetMostExpensiveProductNames()
		{
			using var context = new SignalRContext();
			var maxPrice = context.Products.Max(p => p.Price);
			return context.Products.Where(x => x.Price == maxPrice).Select(p => p.Name).ToList();
		}

        public List<Product> GetMostPopularProducts()
        {
            using var context = new SignalRContext();
            return context.Products.OrderBy(x => x.Id).Take(9).ToList();
        }

        public int GetProductCount()
		{
			using var context = new SignalRContext();
			return context.Products.Count();
		}

		public int GetProductCountByCategoryNameDrink()
		{
			using var context = new SignalRContext();
			return context.Products.Count(p => p.Category.Name == "İçecek");
		}

		public int GetProductCountByCategoryNameHamburger()
		{
			using var context = new SignalRContext();
			return context.Products.Count(x => x.Category.Name == "Hamburger");
		}

		public List<Product> GetProductsWihtCategories()
		{
			using var context = new SignalRContext();
			var values = context.Products.Include(p => p.Category).ToList();
			return values;
		}

        public decimal GetSteakBurgerPrice()
        {
           using var context = new SignalRContext();
		   return context.Products.Where(x => x.Name == "Steak Burger").Select(x => x.Price).FirstOrDefault();
        }

        public decimal GetTotalPriceByDrinks()
        {
			using var context = new SignalRContext();
			int id = context.Categories.Where(x => x.Name == "İçecek").Select(x => x.Id).FirstOrDefault();
			return context.Products.Where(x => x.Id == id).Sum(x => x.Price);

        }

        public decimal GetTotalPriceBySalads()
        {
            using var context = new SignalRContext();
            int id = context.Categories.Where(x => x.Name == "Salata").Select(x => x.Id).FirstOrDefault();
            return context.Products.Where(x => x.Id == id).Sum(x => x.Price);
        }
    }
}
