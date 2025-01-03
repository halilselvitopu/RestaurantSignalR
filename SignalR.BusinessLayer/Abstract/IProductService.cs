﻿using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        List<Product> TGetProductsWithCategories();
        int TGetProductCount();
        int TGetProductCountByCategoryNameDrink();
        int TGetProductCountByCategoryNameHamburger();
        decimal TGetAverageProductPrice();
        IEnumerable<string> TGetMostExpensiveProductNames();
        IEnumerable<string> TGetCheapestProductNames();
        decimal TGetAverageHamburgerPrice();
        List<Product> TGetMostPopularProducts();
        decimal TGetSteakBurgerPrice();
        decimal TGetTotalPriceByDrinks();
        decimal TGetTotalPriceBySalads();
        

    }
}
