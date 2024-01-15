using CustomerDemo.Application.Services;
using CustomerDemo.Core.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<ICustomerService, CustomerService>();


var allowSpecificOrigins = "AllowedOrigins";

var origins = builder.Configuration.GetValue<string>("AllowedOrigins:Allowed");

if (!string.IsNullOrEmpty(origins))
{
    builder.Services.AddCors(options =>
    {
        options.AddPolicy(name: allowSpecificOrigins,
            policy =>
            {
                policy.WithOrigins(origins.Split(',').ToArray())
                .AllowAnyMethod()
                .AllowAnyHeader();
            });
    });

}

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

app.UseCors(allowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
