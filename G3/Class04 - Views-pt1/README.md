## Views in ASP.NET

Views in ASP.NET are responsible for the application's data presentation and user interaction. They are HTML templates with embedded Razor markup. In ASP.NET Core MVC, views are `.cshtml` files that use the C# programming language in Razor markup. Usually, view files are grouped into folders named for each of the app's controllers.

## Types of Views in ASP.NET

There are three types of views in ASP.NET:

1. **Regular Views**: These are the standard views that display the application's user interface.
2. **Partial Views**: These reduce code duplication by managing reusable parts of views. For example, a partial view is useful for an author biography on a blog website that appears in several views.
3. **Layout Views**: These provide consistent webpage sections and reduce code repetition. Layouts often contain the header, navigation and menu elements, and the footer.

## Razor Engine

The Razor Engine is a key component of ASP.NET Core⁶. It provides a powerful and efficient way of generating HTML content dynamically⁶. The Razor Engine also offers a way to embed server-based code into web pages using an HTML-like template syntax⁶.

## Razor Syntax Examples

Razor syntax supports C# and uses the `@` symbol to transition from HTML to C#¹. Here are some examples:

- Single statement block:
    ```csharp
    @{
        var myMessage = "Hello World";
    }
    ```
- Inline expression or variable:
    ```csharp
    <p>The value of myMessage is: @myMessage </p>
    ```
- Multi-statement block:
    ```csharp
    @{
        var greeting = "Welcome to our site!";
        var weekDay = DateTime.Now.DayOfWeek;
        var greetingMessage = greeting + " Here in Huston it is: " + weekDay;
    }
    <p>The greeting is: @greetingMessage </p>
    ```
## If statement in a View

```csharp cshtml
@if (Model is Null)
{
    <p>No student was found with that id !!!</p>
}
```

## For loop in a View

```csharp cshtml
@model IEnumerable<Qinshift.Class04.Models.DtoModels.StudentDTO>
	<div>
		<span>This is partial view</span>
		<ul>
		@foreach(var item in Model)
		{
			<li>@item.FullName</li>
		}
		</ul>
	</div>
```
	
> Note that Razor generates an HTML view from the CSHTML file. C# does not render on the client machine itself

## ViewStart and ViewImports

ViewStart and ViewImports are views that affect all the views that we create in our ASP.NET application. They are not imported or used. If the framework finds them it uses them automatically. They are placed directly in the Views folder. Both of these views start with an **\_** before their names.

## ViewStart

When we want to use the same code in every view that we create we use the ViewStart view. In it, we can write some code and the razor engine will execute that code upon every loading of any view. Usually, in this view, we write code that is repeated on every view such as adding a layout.

```csharp cshtml
@{
    // setting the layout for all the views
    Layout = "~/Views/Shared/_Layout.cshtml";
}
```

## ViewImports

As by the name, ViewImports is a view where we store all our imports for every view that we create. This is a view where we usually write using statements that we need in all of our views. For instance, if we need a using statement for our models we create a using statement in the ViewImports to the folder Models so that we don't have to write the whole namespace when importing models in our views.

```csharp cshtml
@using Qinshift.Class04.Models
```

## Other shared Views

We can create our shared views if we need them. All views that can be used multiple times on different places and occasions are added in the Shared folder. These views can then be accessed whenever we need them. Usually, these views are connected to some general that all views have in common such as an Error or a Thank You page.

	
## Extra Materials 📘

For more detailed information, you can refer to the following resources:

- [Microsoft Learn - Views in ASP.NET Core MVC](^10^)
- [Microsoft Learn - Razor syntax reference for ASP.NET Core](^1^)
- TutorialsPoint Articles on Views
  - [Layout](https://www.tutorialspoint.com/asp.net_core/asp.net_core_razor_layout_views.htm)
  - [ViewStart](https://www.tutorialspoint.com/asp.net_core/asp.net_core_razor_view_start.htm)
  - [ViewImport](https://www.tutorialspoint.com/asp.net_core/asp.net_core_razor_view_import.htm)
- [Dot Net Tutorials - Razor View Engine and Razor Syntax in ASP.NET Core](^6^)
- [Microsoft on Partial Views](https://docs.microsoft.com/en-us/aspnet/core/mvc/views/partial?view=aspnetcore-2.1)
- [Quick Reference to Razor Syntax](https://haacked.com/archive/2011/01/06/razor-syntax-quick-reference.aspx/)
