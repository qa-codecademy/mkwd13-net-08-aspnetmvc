using Microsoft.AspNetCore.Routing.Constraints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();


app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


// Conventional routing
app.MapControllerRoute("course_by_name_with_constraint",
				pattern: "course/{name}",
				defaults: new { controller = "Course", action = "GetCourseByName" },
				constraints: new { name = new MinLengthRouteConstraint(5) }); // Length constraint: min 5 characters);

app.MapControllerRoute("course_multiple_params",
				pattern: "course/{id}/{name}",
				defaults: new { controller = "Course", action = "GetCourseNameByIdOrName" });

app.Run();
