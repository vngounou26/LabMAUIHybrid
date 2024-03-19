using ApiProject;
using ApiProject.Data;
using ApiProject.Repositories;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>();

// Add services to the container.

builder.Services.AddSingleton<IImageRepository, ImageRepository>();

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

app.MapGet("/images", async (IImageRepository repository) =>
{
	try
	{
        var images = await repository.GetImagesAsync();
        if (images is null)
            return Results.NotFound();
        return Results.Ok(images);
    }
	catch (Exception ex)
    {
        return Results.Problem($"Internal Server Error{ex.Message}");
    }
})
    .Produces<IEnumerable<MyImage>>()
    .WithDisplayName("GetAllImages");


app.MapGet("/images/{id}",async (IImageRepository repository, Guid id) =>
{
    try
    {
        var image = await repository.GetImageAsync(id);
        if (image is null)
            return Results.NotFound();
        return Results.Ok(image);
    }
    catch (Exception ex)
    {
        return Results.Problem($"Internal Server Error{ex.Message}");
    }
})
    .Produces<IEnumerable<MyImage>>()
    .WithDisplayName("GetImageById");

app.MapPost("/images", async (IImageRepository repository, [FromBody] MyImage image) =>
{
    try
    {
        if (image is null)
            return Results.BadRequest();

        await repository.AddImageAsync(image);
        return Results.Created($"/images/{image.Id}", image);
    }
    catch (Exception ex)
    {
        return Results.Problem($"Internal Server Error{ex.Message}");
    }   
})
    .WithDisplayName("AddImage");


app.Run();

