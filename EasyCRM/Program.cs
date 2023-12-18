using EasyCRM;
using EasyCRM.DAL.Entity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//Declaring and Regestring the connection(DbContect connection)
var connectionstring = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(opt => opt.UseSqlServer(connectionstring), ServiceLifetime.Transient);


// Add services to the container.
builder.Services.AddControllersWithViews();
DependencyResolver.Resolve(builder);
    
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
//Auto Migration Method for Data Context 
using (var scope = app.Services.CreateScope())
{
    var dbCore = scope.ServiceProvider.GetRequiredService<DataContext>();
    dbCore.Database.Migrate();
}

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
