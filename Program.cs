var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
// If we are in development we want swaggerUI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// No SSL certificate on development so we set it up this way to avoid annoyances and warnings
// We dont want https redirection if we are in development
else
{
    app.UseHttpsRedirection();

}

app.MapControllers();


// app.MapGet("/weatherforecast", () =>
// {
   
// })

// .WithName("GetWeatherForecast")
// .WithOpenApi();

app.Run();
