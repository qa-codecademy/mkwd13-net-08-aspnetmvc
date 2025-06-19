# Views part 2 🍰

ASP.NET Core gives multiple systems for generating dynamic HTML code. There are Helpers for almost everything such as generic links to other routes, binding labels to our model, binding input fields to our model, creating forms with submitting functionality to the right address, etc. Main helper systems are:

- HTML Helpers
- Tag Helpers

## HTML Helpers in .NET 

HTML Helpers in ASP.NET MVC are methods that return a string. They are used to create HTML elements in views. They provide a way to generate HTML markup programmatically, which can help keep your views clean and maintainable.

## Tag Helpers in .NET

Tag Helpers in ASP.NET Core MVC are a new way to create dynamic HTML. They are similar to HTML Helpers, but they have a more HTML-like syntax, which can make your views more readable.

## Using Helpers 🔹

### Links

The link HTML helper is a helper that lets us create links to our routes in our MVC application by adding our action and even controller name as parameters. The razor engine will generate an HTML element that represents a link and that in the attributes has the right address to the action in question.

#### Razor View ( HTML Helper )

```csharp
@Html.ActionLink("Edit Student", "Edit", "Student", new { id = student.Id })
@Html.ActionLink("Course Details", "Details", "Course", new { id = student.ActiveCourse.Id })
```

#### Razor View ( Tag Helper )

```html
<a asp-controller="Student" asp-action="Edit" asp-route-id="@student.Id">Edit Student</a>
<a asp-controller="Course" asp-action="Details" asp-route-id="@student.ActiveCourse.Id">Course Details</a>
```

#### When rendered in HTML
```html
<a href="/Student/Edit/0">Edit Student</a>
<a href="/Course/Details/0">Course Details</a>
```

### Label

When adding a label for a property we use the Label HTML helper. This helper creates a label HTML tag with the content of the name of the property. Unlike Display HTML Helper this helper creates an HTML element. The default value will always be the name of the property, but this can be changed by adding an annotation to the properties in the class.

```csharp
@Html.LabelFor(x => x.FirstName)
<label asp-for="FirstName"></label>
```

### TextBox

The TextBox helper is the helper for creating and binding input fields with values. This helper is used when we want to create an input and the value that will be added in that input to be bound to some property of the model. This helper creates an input parameter with all the attributes automatically to bind the property that was added. This means that if that property has a value at the start of the page, that value will be written in the input field. If the input field is changed and the data is posted back to the back-end the value of that property will also be changed.

```csharp
@Html.TextBoxFor(x => x.FirstName)
<input asp-for="FirstName" />
```

### DropDownList

```csharp
@Html.DropDownListFor(x => x.ActiveCourseId, new SelectList(Model.Courses, "Id", "Name"))

<select asp-for="ActiveCourseId" asp-items="@(new SelectList(Model.Courses, "Id", "Name"))"></select>
```

### HiddenField

The hidden field helper is used a lot and its main objective is to send data that the user does not need to see on the screen. Since the back-end does not know from where the model came, we must send data to identify models that we send to views. The properties that we send for identifying the model later are stored in these hidden fields. Data like this is an Id of some object or some status that we need to keep and send back to the back-end application with the model. Hidden fields are an input that is not displayed.

```csharp
@Html.HiddenFor(x => x.Id)

<input type="hidden" asp-for="ActiveCourse.Id" />
```

### Display

For displaying things from the model we can also use Html Helpers. The display HTML helper lets us display a string in our views by requesting the name as a string ( loosely typed ) or requesting it by a lambda ( strongly typed )

```csharp
@Html.DisplayFor(x => x.FirstName)
```

<br>

# Model attributes 🔹

In the model, we can decorate the properties with attributes to get an extra layer of data for our properties. This means that we can add some extra significance to the properties and the razor engine will treat them differently or add some extra data when necessary. These attributes are added above the properties and can be used for validating, displaying different names, and pointing out how to be mapped in a database.

### Display attribute

The display attribute changes the name of the property so that every time the name of the property is used, instead of the code name ( Ex. FirstName ) we get a different name ( Ex. First name of the user ). This helps us when putting labels for our properties. If we decorate our properties with a Display property the label will be displayed in the way we wanted, but the name of the property in the code will stay the same. Attributes related to the database are usually added in the domain models and the ones that affect how the properties are displayed are added in the view models

#### In model

```csharp
public class RegisterViewModel
{
  [Display(Name="First name of user")]
  public string FirstName { get; set; }
  [Display(Name="Last name of user")]
  public string LastName { get; set; }
}
```

#### In view

```csharp cshtml
    @Html.LabelFor(x => x.FirstName)
    @Html.TextBoxFor(x => x.FirstName)
    <br/>
    @Html.LabelFor(x => x.LastName)
    @Html.TextBoxFor(x => x.LastName)
```

#### When rendered in HTML

```html
<label for="FirstName">First name of user</label>
<input id="FirstName" name="FirstName" type="text" value="" />
<br />
<label for="LastName">Last name of user</label>
<input id="LastName" name="LastName" type="text" value="" />
```

<br>

# Forms 🔹

To send some data back to the back-end we need to add all our data into a form. All the TextBoxes that are bound to some properties need to be in a form so we can send them back. There is an HTML helper for a form that automatically knows which path to post to and detects the inputs that are bound with the model. When using this helper we just write TextBoxes in it that are bound to the model properties and a submit button or input. The rest is already set by the helper. The helper posts back to action in the current controller that has the same name as the action that is called the view and has the [HttpPost] attribute

### Razor View ( HTML Helper )

```csharp
@using(Html.BeginForm())
{
    @Html.LabelFor(x => x.FirstName)
    @Html.TextBoxFor(x => x.FirstName)
    @Html.LabelFor(x => x.LastName)
    @Html.TextBoxFor(x => x.LastName)
    @Html.LabelFor(x => x.DateOfBirth)
    @Html.TextBoxFor(x => x.DateOfBirth)
    @Html.DropDownListFor(x => x.ActiveCourseId, new SelectList(Model.Courses, "Id", "Name"))
    <button type="submit">Submit</button>
}
```

### Razor View ( Tag Helper )

```html
<form asp-controller="Student" asp-action="Create" method="post">
    <label asp-for="FirstName"></label>
    <input asp-for="FirstName" />
    <label asp-for="LastName"></label>
    <input asp-for="LastName" />
    <label asp-for="DateOfBirth"></label>
    <input asp-for="DateOfBirth" />
    <select asp-for="ActiveCourseId" asp-items="Model.Courses"></select>
    <button type="submit">Submit</button>
</form>
```

## Sending form data to controller 

### Domain Model

```csharp
public class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public int ActiveCourseId { get; set; }
    public Course ActiveCourse { get; set; }
}

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; }
}
```

### ViewModel

```csharp
public class StudentFormViewModel
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public int ActiveCourseId { get; set; }
    public List<SelectListItem> Courses { get; set; }
}
```

### Controller

```csharp
[HttpGet]
public IActionResult Create()
{
    var viewModel = new StudentFormViewModel
    {
        Courses = InMemoryDb.Courses.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList()
    };
    return View(viewModel);
}

[HttpPost]
public IActionResult Create(StudentFormViewModel model)
{
    var student = new Student
    {
        Id = InMemoryDb.GenerateStudentId(),
        FirstName = model.FirstName,
        LastName = model.LastName,
        DateOfBirth = model.DateOfBirth,
        ActiveCourseId = model.ActiveCourseId
    };

    InMemoryDb.Students.Add(student);
    return RedirectToAction("Index");
}
```

### View

```csharp
@model StudentFormViewModel

<h1>Create Student</h1>
<form asp-controller="Student" asp-action="Create" method="post">
    <label asp-for="FirstName"></label>
    <input asp-for="FirstName" />
    <label asp-for="LastName"></label>
    <input asp-for="LastName" />
    <label asp-for="DateOfBirth"></label>
    <input asp-for="DateOfBirth" />
    <label asp-for="ActiveCourseId"></label>
    <select asp-for="ActiveCourseId" asp-items="Model.Courses"></select>
    <button type="submit">Create</button>
</form>
```