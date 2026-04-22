using SravaniWebAPI;
using SravaniWebAPI.DBContext;
using SravaniWebAPI.Repository;
using SravaniWebAPI.Services;
using FluentValidation.AspNetCore;
using FluentValidation;
using SravaniWebAPI.Validations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IMongoDBContext, MongoDBContext>();
builder.Services.AddScoped<IMongoOrderServicecs, MongoOrderService>();
builder.Services.AddScoped<IMongoOrderRepository, MongoOrderRepository>();
builder.Services.AddControllers();

// Add services to the FluentValidation 
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CreateOrderRequestValidator>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.Run();
