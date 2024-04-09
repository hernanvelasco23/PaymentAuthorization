using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PaymentAuthorization.Data;
using PaymentAuthorization.Data.Repoditories;
using PaymentAuthorization.Data.Repositories;
using PaymentAuthorization.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Agregar el servicio PaymentProcessorService al contenedor de servicios
builder.Services.AddScoped<PaymentProcessorService>();
builder.Services.AddScoped<IPaymentRequestRepository, PaymentRequestRepository>();
builder.Services.AddScoped<IApprovedAuthorizationRepository, ApprovedAuthorizationRepository>();

builder.Services.AddDbContext<PaymentAuthorizationDbContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("PaymentAuthorizationConnection")), ServiceLifetime.Scoped);


builder.Services.AddScoped<HttpContextAccessor>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
