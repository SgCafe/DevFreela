using DevFreela.API.ExceptionHandler;
using DevFreela.Application;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddDbContext<DevFreelaDbContext>(o =>
//     o.UseInMemoryDatabase("DevFreelaDb"));

var connectionString = builder.Configuration.GetConnectionString("DevFreelaCs");
builder.Services.AddDbContext<DevFreelaDbContext>(o => o.UseSqlServer(connectionString));

builder.Services.AddApplication();

builder.Services.AddExceptionHandler<ApiExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.InjectStylesheet("/swagger-ui/SwaggerDark.css");
    });
}

app.UseStaticFiles();

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();