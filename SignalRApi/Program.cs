using SignalR.BusinessLayer.Abstract;
using SignalR.BusinessLayer.Concrete;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.EntityFramework;
using SignalRApi.Hubs;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(opt =>
{
	opt.AddPolicy("CorsPolicy", builder =>
	{
		builder.AllowAnyHeader()
		.AllowAnyHeader()
		.SetIsOriginAllowed((host) => true)
		.AllowCredentials();

	});
});

builder.Services.AddSignalR();

// Add services to the container.
builder.Services.AddDbContext<SignalRContext>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddScoped<IAboutDal, EfAboutDal>();
builder.Services.AddScoped<IAboutService, AboutManager>();

builder.Services.AddScoped<IBookingDal, EfBookingDal>();
builder.Services.AddScoped<IBookingService, BookingManager>();

builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();

builder.Services.AddScoped<IDiscountProductDal, EfDiscountProductDal>();
builder.Services.AddScoped<IDiscountProductService, DiscountProductManager>();

builder.Services.AddScoped<IFeatureProductDal, EfFeatureProductDal>();
builder.Services.AddScoped<IFeatureProductService, FeatureProductManager>();

builder.Services.AddScoped<IContactDal, EfContactDal>();
builder.Services.AddScoped<IContactService, ContactManager>();

builder.Services.AddScoped<IProductDal, EfProductDal>();
builder.Services.AddScoped<IProductService, ProductManager>();

builder.Services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();
builder.Services.AddScoped<ISocialMediaService, SocialMediaManager>();

builder.Services.AddScoped<ITestimonialDal, EfTestimonialDal>();
builder.Services.AddScoped<ITestimonialService, TestimonialManager>();

builder.Services.AddScoped<IOrderDal, EfOrderDal>();
builder.Services.AddScoped<IOrderService, OrderManager>();

builder.Services.AddScoped<ITestimonialDal, EfTestimonialDal>();
builder.Services.AddScoped<ITestimonialService, TestimonialManager>();

builder.Services.AddScoped<ICashRegisterDal, EfCashRegisterDal>();
builder.Services.AddScoped<ICashRegisterService, CashRegisterManager>();

builder.Services.AddScoped<ITableDal, EfTableDal>();
builder.Services.AddScoped<ITableService, TableManager>();

builder.Services.AddScoped<ISliderDal, EfSliderDal>();
builder.Services.AddScoped<ISliderService, SliderManager>();

builder.Services.AddScoped<IBasketDal, EfBasketDal>();
builder.Services.AddScoped<IBasketService, BasketManager>();

builder.Services.AddScoped<INotificationDal, EfNotificationDal>();
builder.Services.AddScoped<INotificationService, NotificationManager>();

builder.Services.AddScoped<IMessageDal, EfMessageDal>();
builder.Services.AddScoped<IMessageService, MessageManager>();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});


builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHub<SignalRHub>("/signalrhub");

app.Run();
