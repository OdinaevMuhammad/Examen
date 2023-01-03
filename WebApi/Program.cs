using System.Collections.Immutable;
using Infrastructure.Context;
using Infrastructure.Mapper;
using Infrastructure.Seeds;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(ServiceProfile));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<MovieService>();
builder.Services.AddDbContext<DataContext>(config=>config.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();
try
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<DataContext>();
        var actor = services.GetRequiredService<ModelBuilder>();
        var category = services.GetRequiredService<ModelBuilder>();
        var movie = services.GetRequiredService<ModelBuilder>();
        await context.Database.MigrateAsync();
        
        DefaultActorSeed.ActorSeed(actor);
        DefaultMovieSeed.MovieSeed(movie);
        DefaultCategorySeed.CategorySeed(category);
        
        
        app.Logger.LogInformation("Finished Seeding Default Data");
        app.Logger.LogInformation("Application Starting");
    }
}
catch (Exception ex)
{
    app.Logger.LogError($"An Error occurred while seeding the db:  {ex.Message}");
}


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
