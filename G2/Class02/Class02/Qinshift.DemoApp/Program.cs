using Microsoft.AspNetCore.Mvc.Formatters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "course_by_id",
    pattern: "course/getCourseById/{id}",
    defaults: new { controller = "Course", action = "GetCourseById" }
    );

app.MapControllerRoute(
    name: "course_by_id_or_name",
    pattern: "course/getCourseByIdOrName/{id?}/{name?}",
     defaults: new { controller = "Course", action = "GetCourseByIdOrName" }
    );

app.Run();
