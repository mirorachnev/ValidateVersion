var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var devCorsPolicy = "devCorsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(devCorsPolicy, builder => {
        builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
    });
});

builder.Services.AddControllers();

var app = builder.Build();

app.UseCors(devCorsPolicy);

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
