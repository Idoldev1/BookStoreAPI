using BookStoreAPI.DAL;
using BookStoreAPI.Repository;
using BookStoreAPI.Sevices;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration().
    MinimumLevel.Information()
    .WriteTo.File("Log/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IBookstoreRepository, BookstoreRepository>();
builder.Services.AddTransient<BookServices>();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BookStoreDbContext>(options => 

    options.UseSqlite(builder.Configuration.GetConnectionString("DbConnection"))
);



var app = builder.Build();

//var logger = app.Services.GetRequiredService<ILogger>();
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

app.Run();
