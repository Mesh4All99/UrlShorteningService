using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using ShorterUrls.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<RandomizedCharachters>();

builder.Services.AddDbContext<ApplicationDbContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("Default"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference("docs");
}

app.UseHttpsRedirection();

// url shortening endpoints
app.MapPost("shorturl", async (urlshortenRequest url,RandomizedCharachters helper,ApplicationDbContext context, HttpContext http) =>
{
    if(url.Alias != null)
    {
        if(!Uri.TryCreate(url.Url,UriKind.Absolute,out _))
        {
           return Results.BadRequest("الرابط المعطى غير صحيح"); 
        }
        if(await context.Urls.AnyAsync(x => x.Id == url.Alias))
        {
            return Results.BadRequest("هذا الاختصار مرتبط مسبقاً");
        }
        var validUrlObject = new Url
        {
        Id = url.Alias,
        LongUrl = url.Url,
        ShortUrl = $"{http.Request.Scheme}://{http.Request.Host}/{url.Alias}"  
        };
        await context.Urls.AddAsync(validUrlObject);

        await context.SaveChangesAsync();

        return Results.Ok(new UrlShortenResponse
        {
            ShortenUrl = validUrlObject.ShortUrl
        });
    }

    if(!Uri.TryCreate(url.Url,UriKind.Absolute,out _))
    {
        return Results.BadRequest("الرابط المعطى غير صحيح");
    }
        
    var randomId = await helper.GetRandomString(7);

    var newUrlObject = new Url
    {
      Id = randomId,
      LongUrl = url.Url,
      ShortUrl = $"{http.Request.Scheme}://{http.Request.Host}/{randomId}"
    };

    await context.Urls.AddAsync(newUrlObject);
    await context.SaveChangesAsync();
    return Results.Ok(new UrlShortenResponse
    {
        ShortenUrl = newUrlObject.ShortUrl
    });
});

app.MapGet("{alias}", async (string alias, ApplicationDbContext context, HttpContext http) =>
{
    var data = await context.Urls.FindAsync(alias);
    if (data == null)
    {
        return Results.NotFound("لم يتم إجاد المعرف الخاص بالرابط");
    }
    data.ClickCount++;
    await context.SaveChangesAsync();
    return Results.Redirect(data.LongUrl);
});
app.Run();