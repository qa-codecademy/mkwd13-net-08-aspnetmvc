using Microsoft.AspNetCore.Routing.Constraints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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

//Conventional routing
app.MapControllerRoute("course_by_name_with_constraints",
    pattern: "course/{name}", //this way we specify the name of the controller ourselves (we are making up our own route that does not follow the default settings)
    defaults: new { controller = "Course", action = "GetCourseByName" },
    constraints: new {name = new MinLengthRouteConstraint(3)} //length contraint : min 5 chars for the value of name
    );

app.MapControllerRoute("course_multiple_params",
    pattern: "course/{id}/{name}",
    defaults: new { controller = "Course", action = "GetCourseByIdAndByName" }
    );

//app.MapControllerRoute("course_multiple_params",
//    pattern: "allCourses",
//    defaults: new { controller = "Course", action = "GetAllCourses" }
//    );

app.Run();
