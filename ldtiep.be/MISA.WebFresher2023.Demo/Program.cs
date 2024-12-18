﻿using ldtiep.be.BL.Service;
using ldtiep.be.BL;
using ldtiep.be.DL;
using ldtiep.be.DL.Repository;
using ldtiep.be.Middleware;
using ldtiep.be.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using AutoMapper;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Lấy data từ file 
builder.ReadConfig();

// Tạo config instanced

AppConfig appConfig = builder.Configuration.GetConfig();

builder.Services.AddSingleton(appConfig);

// Add services to the container.

builder.Services.AddControllers();

// Định dạnh các thuộc tính trả về là kiểu Pascal
builder.Services.AddControllers().AddJsonOptions(option =>
{
    option.JsonSerializerOptions.PropertyNamingPolicy = null;

});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Thêm Cors cho font-end
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyVueApp",
                      policy =>
                      {
                          policy.WithOrigins("*")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                      });
});

//builder.Services.Configure<ApiBehaviorOptions>(options =>
//{
//    options.SuppressModelStateInvalidFilter = true;
//});

// Sử dụng automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IPictureRepository, PictureRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IColorRepository, ColorRepository>();
builder.Services.AddScoped<ISizeRepository, SizeRepository>();
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<IDistrictRepository, DistrictRepository>();
builder.Services.AddScoped<ICommuneRepository, CommuneRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IRuleRepository, RuleRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IPictureService, PictureService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IColorService, ColorService>();
builder.Services.AddScoped<ISizeService, SizeService>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<IDistrictService, DistrictService>();
builder.Services.AddScoped<ICommuneService, CommuneService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IRuleService, RuleService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<IUserService, UserService>();


builder.Services.AddScoped<IMSDatabase, MSDatabase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseCors("MyVueApp");

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints => endpoints.MapControllers());

app.MapControllers();

app.UseMiddleware<ExceptionMiddleware>();

app.Run();
