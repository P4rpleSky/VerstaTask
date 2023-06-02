using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VerstaTask;
using VerstaTask.DbContexts;
using VerstaTask.Repository;
using VerstaTask.Services;
using VerstaTask.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<VerstaDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

SD.BaseUrl = builder.Configuration["BaseUrl"];

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddHttpClient<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderService, OrderService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Order}/{action=OrderIndex}/{id?}");

app.Run();
