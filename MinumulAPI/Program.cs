using Microsoft.EntityFrameworkCore;
using MinumulAPI;

var builder = WebApplication.CreateBuilder(args);
//Here added db context configuration
builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseInMemoryDatabase("TestDb");
});
var app = builder.Build();
//app.MapGet("/", () =>
//{
//    return "Hello world!";
//});

//Retrive data from data base
app.MapGet("/api/post", (ApplicationDbContext db) =>
{
    var posts = db.posts.ToList();
    return Results.Ok(posts);
});


//Save data in database
app.MapPost("/api/post", (Post objpost ,ApplicationDbContext db) =>
{
   db.posts.Add(objpost);
    bool isSaved = db.SaveChanges() > 0;
    if (isSaved)
    {
        return Results.Ok("Data saved successfull!");
    }
    return Results.BadRequest("Data not saved successfull!");
});
app.MapPut("/api/post", () =>
{
    return Results.Ok("Put method is called here");
});
app.MapDelete("/api/post", () =>
{
    return Results.Ok("Delete method is called here");
});


app.Run();