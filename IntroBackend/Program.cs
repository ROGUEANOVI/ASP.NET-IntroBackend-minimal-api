using IntroBackend;
using IntroBackend.Context;
using IntroBackend.Models;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStringIntroBackend"))
);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/breweries", () => new Repository().GetBreweries());

app.MapGet("/breweries/{id}", (int id) => {

    var brewery = new Repository().GetBreweryById(id);
    
    return brewery == null ? Results.NotFound($"No existe una cerveseria con el {id}") : Results.Ok(brewery);
});

app.MapGet("/beers", ( AppDbContext _dbContext) =>
{
    List<Beer> beers = null;

    beers = _dbContext.Beer.ToList();

    return beers;
});

app.MapPost("/beers", async (AppDbContext _dbContext, Beer beer) =>
{
    _dbContext.Add(beer);
    await _dbContext.SaveChangesAsync();

    return Results.Created($"beer/{beer.Id}", beer);
});

app.MapPut("/beers/{id}", async (AppDbContext _dbContext, Beer beer, int id) =>
{
    var beerExist = await _dbContext.Beer.FindAsync(id);

    if (beerExist == null)
    {
        return Results.NotFound($"No se ha encontrado una cerveza con el id {id}");
    }

    beerExist.Name = beer.Name;
    beerExist.BrandId = beer.BrandId;

    _dbContext.Update(beerExist);

    await _dbContext.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/beers/{id}", async (AppDbContext _dbContext, int id) =>
{
    var beerExist = await _dbContext.Beer.FindAsync(id);

    if (beerExist == null)
    {
        return Results.NotFound($"No se ha encontrado una cerveza con el id {id}");
    }

    _dbContext.Remove(beerExist);

    await _dbContext.SaveChangesAsync();

    return Results.NoContent();
});

app.Run();
