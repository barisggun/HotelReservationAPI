using HotelProject.BusinessLayer.Abstract;
using HotelProject.BusinessLayer.Concrete;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//my codes start
builder.Services.AddDbContext<Context>();
builder.Services.AddScoped<IStaffDal,EfStaffDal>(); //Hafýzada 1 kez nesne örneði oluþtur ve bunu kullan.
builder.Services.AddScoped<IStaffService,StaffManager>();


builder.Services.AddScoped<IServiceDal, EfServiceDal>(); 
builder.Services.AddScoped<IServiceService, ServiceManager>();

builder.Services.AddScoped<ISubscribeDal, EfSubscribeDal>();
builder.Services.AddScoped<ISubscribeService, SubscribeManager>();

builder.Services.AddScoped<ITestimonialDal, EfTestimonialDal>();
builder.Services.AddScoped<ITestimonialService, TestimonialManager>();

builder.Services.AddScoped<IRoomDal, EfRoomDal>();
builder.Services.AddScoped<IRoomService, RoomManager>();

builder.Services.AddScoped<IAboutDal, EfAboutDal>();
builder.Services.AddScoped<IAboutService, AboutManager>();

builder.Services.AddScoped<IBookingDal, EfBookingDal>();
builder.Services.AddScoped<IBookingService, BookingManager>();
//end

builder.Services.AddCors(opt=>
{
    opt.AddPolicy("OtelApiCors", opts =>
    {
        opts.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
}); //Api'ýn baþka kaynaklar tarafýndan consume edilmesini saðlar.

builder.Services.AddAutoMapper(typeof(Program)); //Automapper


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("OtelApiCors"); //Buraya da consume edilebilmesi için policy'i ekliyoruz.

app.UseAuthorization();

app.MapControllers();

app.Run();
