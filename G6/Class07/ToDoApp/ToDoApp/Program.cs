using Microsoft.AspNetCore.DataProtection.Repositories;
using ToDoApp.DataAccess.Implementation;
using ToDoApp.DataAccess.Interfaces;
using ToDoApp.Domain;
using ToDoApp.Services.Implementation;
using ToDoApp.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Here we register dependencies using Dependency Injection
#region Register Repositories
//scoped lifetime: a new instance is creted once per cliend requests (if in a HTTP request there are multiple requests for this, one instance will be created and used)
//builder.Services.AddScoped<IRepository<ToDo>, ToDoRepository>();
//singleton: a single instance is created the first time it is requested and that instance is used and shared among the app
//builder.Services.AddSingleton<IRepository<ToDo>, ToDoRepository>();

//this tells the app that anywhere where an instance of IRepository<toDo> is requested, the implem that should be called is ToDoRepository.
//if we want to change the impl, we only need to specify the new impl here 
//Transient lifetime: a new instance is created every time it is requested
builder.Services.AddTransient<IRepository<ToDo>, ToDoRepository>();

builder.Services.AddTransient<IRepository<Category>, CategoryRepository>();
builder.Services.AddTransient<IRepository<Status>, StatusRepository>();
#endregion

#region Register services
builder.Services.AddTransient<IToDoService, ToDoService>();
builder.Services.AddTransient<IFilterService, FilterService>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
