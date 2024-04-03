using Microsoft.EntityFrameworkCore;
using StackOverflowTagApp.Core.Infrastructure.DI;
using StackOverflowTagApp.Core.SQL;
using System.Net;
using StackOverflowTagApp.Core.Application.DI;
using StackOverflowTagApp.Core.Infrastructure.ExceptionHandling;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Add connection to SQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("SQL"), sqlOptionsBuilder => 
{
    sqlOptionsBuilder.MigrationsAssembly("StackOverflowTagApp.Core.SQL");
    sqlOptionsBuilder.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds);
    sqlOptionsBuilder.UseQuerySplittingBehavior(QuerySplittingBehavior.SingleQuery);
}));

// HttpClient Registration

builder.Services.AddHttpClient("StackOverflowClient", c =>
{
    c.BaseAddress = new Uri("https://api.stackexchange.com/2.3/");
}).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
{
    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
});
builder.Services.AddStackOverflowServices();
builder.Services.AddCoreApplicationServices();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// GlobalExceptionHandler
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
}

// HTTP request pipeline configuration.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
