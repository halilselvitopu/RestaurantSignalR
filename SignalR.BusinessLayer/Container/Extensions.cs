using Microsoft.Extensions.DependencyInjection;
using SignalR.BusinessLayer.Abstract;
using SignalR.BusinessLayer.Concrete;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Container
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddScoped<IAboutDal, EfAboutDal>();
            services.AddScoped<IAboutService, AboutManager>();

            services.AddScoped<IBookingDal, EfBookingDal>();
            services.AddScoped<IBookingService, BookingManager>();

            services.AddScoped<ICategoryDal, EfCategoryDal>();
            services.AddScoped<ICategoryService, CategoryManager>();

            services.AddScoped<IDiscountProductDal, EfDiscountProductDal>();
            services.AddScoped<IDiscountProductService, DiscountProductManager>();

            services.AddScoped<IFeatureProductDal, EfFeatureProductDal>();
            services.AddScoped<IFeatureProductService, FeatureProductManager>();

            services.AddScoped<IContactDal, EfContactDal>();
            services.AddScoped<IContactService, ContactManager>();

            services.AddScoped<IProductDal, EfProductDal>();
            services.AddScoped<IProductService, ProductManager>();

            services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();
            services.AddScoped<ISocialMediaService, SocialMediaManager>();

            services.AddScoped<ITestimonialDal, EfTestimonialDal>();
            services.AddScoped<ITestimonialService, TestimonialManager>();

            services.AddScoped<IOrderDal, EfOrderDal>();
            services.AddScoped<IOrderService, OrderManager>();

            services.AddScoped<ITestimonialDal, EfTestimonialDal>();
            services.AddScoped<ITestimonialService, TestimonialManager>();

            services.AddScoped<ICashRegisterDal, EfCashRegisterDal>();
            services.AddScoped<ICashRegisterService, CashRegisterManager>();

            services.AddScoped<ITableDal, EfTableDal>();
            services.AddScoped<ITableService, TableManager>();

            services.AddScoped<ISliderDal, EfSliderDal>();
            services.AddScoped<ISliderService, SliderManager>();

            services.AddScoped<IBasketDal, EfBasketDal>();
            services.AddScoped<IBasketService, BasketManager>();

            services.AddScoped<INotificationDal, EfNotificationDal>();
            services.AddScoped<INotificationService, NotificationManager>();

            services.AddScoped<IMessageDal, EfMessageDal>();
            services.AddScoped<IMessageService, MessageManager>();
        }
    }
}
