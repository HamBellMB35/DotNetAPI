var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS policy to have cross-origin reasource sharing
builder.Services.AddCors((options) => 
    {
        options.AddPolicy("DevCors", (corsBuilder) =>
            {
                // Angular, React, and ports for single page aplications
                corsBuilder.WithOrigins("http://localhost:4200","http://localhost:3000", "http://localhost:8000")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            });
         options.AddPolicy("ProdCors", (corsBuilder) =>
            {
                // Angular, React, and ports for single page aplications
                corsBuilder.WithOrigins("https://myProductionSite.com")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            });
        

    });

var app = builder.Build();

// Configure the HTTP request pipeline.
// If we are in development we want swaggerUI
if (app.Environment.IsDevelopment())
{
    app.UseCors("DevCors");
    app.UseSwagger();
    app.UseSwaggerUI();
}
// No SSL certificate on development so we set it up this way to avoid annoyances and warnings
// We dont want https redirection if we are in development
else
{
    app.UseCors("ProdCors");
    app.UseHttpsRedirection();

}

app.MapControllers();

// app.MapGet("/weatherforecast", () =>
// {   
// })
// .WithName("GetWeatherForecast")
// .WithOpenApi();

app.Run();
