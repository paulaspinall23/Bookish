using Bookish;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<BookishDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

// using Bookish;
// using Microsoft.EntityFrameworkCore;

// var dbContext = new BookishDbContext();
// //var books = dbContext.Books.ToList();
// var books = dbContext.Books
//     .Include(b => b.Author)
//     .ToList();
// foreach (var book in books)
// {
//     //Console.WriteLine(book.Title);
//     Console.WriteLine($"{book.Title}: By {book.Author.Name}");
// }
