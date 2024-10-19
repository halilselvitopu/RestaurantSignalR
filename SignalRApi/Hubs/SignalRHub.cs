using Microsoft.AspNetCore.SignalR;
using SignalR.BusinessLayer.Abstract;

namespace SignalRApi.Hubs
{
	public class SignalRHub : Hub
	{
		private readonly ICategoryService _categoryService;
		private readonly IProductService _productService;
		private readonly IOrderService _orderService;
		private readonly ITableService _tableService;
		private readonly ICashRegisterService _cashRegisterService;
		private readonly IBookingService _bookingService;
		private readonly INotificationService _notificationService;

		public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, ITableService tableService, ICashRegisterService cashRegisterService, IBookingService bookingService, INotificationService notificationService)
		{
			_categoryService = categoryService;
			_productService = productService;
			_orderService = orderService;
			_tableService = tableService;
			_cashRegisterService = cashRegisterService;
			_bookingService = bookingService;
			_notificationService = notificationService;
		}

		public async Task SendStatistics()
		{
			var categoryCount = _categoryService.TGetCategoryCount();
			await Clients.All.SendAsync("ReceiveCategoryCount", categoryCount);

			var productCount = _productService.TGetProductCount();
			await Clients.All.SendAsync("ReceiveProductCount", productCount);

			var activeCategoryCount = _categoryService.TGetActiveCategoryCount();
			await Clients.All.SendAsync("ReceiveActiveCategoryCount", activeCategoryCount);

			var passiveCategoryCount = _categoryService.TGetActiveCategoryCount();
			await Clients.All.SendAsync("ReceivePassiveCategoryCount", passiveCategoryCount);

			var hamburgerCount = _productService.TGetProductCountByCategoryNameHamburger();
			await Clients.All.SendAsync("ReceiveHamburgerCount", hamburgerCount);

			var drinkCount = _productService.TGetProductCountByCategoryNameHamburger();
			await Clients.All.SendAsync("ReceiveDrinkCount", drinkCount);

			var avergaePrice = _productService.TGetAverageProductPrice();
			await Clients.All.SendAsync("ReceiveAveragePrice", avergaePrice.ToString("0.00") + "₺");

			var expensiveProduct = _productService.TGetMostExpensiveProductNames();
			await Clients.All.SendAsync("ReceiveExpensiveProduct", expensiveProduct);

			var cheapestProduct = _productService.TGetCheapestProductNames();
			await Clients.All.SendAsync("ReceiveCheapestProduct", cheapestProduct);

			var averageHamburgerPrice = _productService.TGetAverageHamburgerPrice();
			await Clients.All.SendAsync("ReceiveAverageHamburgerPrice", averageHamburgerPrice.ToString("0.00") + "₺");

			var orderCount = _orderService.TGetTotalOrderCount();
			await Clients.All.SendAsync("ReceiveTotalOrderCount", orderCount);

			var activeOrderCount = _orderService.TGetActiveOrderCount();
			await Clients.All.SendAsync("ReceiveActiveOrderCount", activeOrderCount);

			var lastOrderPrice = _orderService.TGetLastOrderPrice();
			await Clients.All.SendAsync("ReceiveLastOrderPrice", lastOrderPrice.ToString("0.00") + "₺");

			var cashRegisterPrice = _cashRegisterService.TGetTotalPriceCashRegister();
			await Clients.All.SendAsync("ReceiveTotalCashRegisterPrice", cashRegisterPrice.ToString("0.00") + "₺");

			var todayProfit = _orderService.TGetTodayTotalProfit();
			await Clients.All.SendAsync("ReceiveTodayProfit", todayProfit.ToString("0.00") + "₺");

			var tableCount = _tableService.TGetTotalTableCount();
			await Clients.All.SendAsync("ReceiveTableCount", tableCount);
		}

		public async Task SendProgress()
		{
			var cashRegisterPrice = _cashRegisterService.TGetTotalPriceCashRegister();
			await Clients.All.SendAsync("ReceiveTotalCashRegisterPrice", cashRegisterPrice.ToString("0,00") + "₺");

            var activeOrderCount = _orderService.TGetActiveOrderCount();
			await Clients.All.SendAsync("ReceiveActiveOrderCount", activeOrderCount);

            var tableCount = _tableService.TGetTotalTableCount();
            await Clients.All.SendAsync("ReceiveTableCount", tableCount);

        }

		public async Task GetBookingList()
		{
			var bookingList = _bookingService.TGetAll();
			await Clients.All.SendAsync("ReceiveBookingList", bookingList);
		}

		public async Task SendNotification()
		{
			var notificationCountByFalse = _notificationService.TNotificationCountByStatusFalse();
			await Clients.All.SendAsync("ReceiveNotificationByStatusFalse", notificationCountByFalse);

			var notificationListByFalse = _notificationService.TGetAllNotificationsByStatusFalse();
			await Clients.All.SendAsync("ReceiveNotificationListByFalse", notificationListByFalse);
		}

		public async Task GetTableStatus()
		{
			var tableStatus = _tableService.TGetAll();
			await Clients.All.SendAsync("ReceiveTableStatus", tableStatus);
		}

	}
}
