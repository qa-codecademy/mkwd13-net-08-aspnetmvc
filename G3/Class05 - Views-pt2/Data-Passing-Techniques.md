# Data passing techniques

## ViewData

`ViewData` is a dictionary object that is derived from `ViewDataDictionary` class. You can use it to pass data from controllers to views.

Here's an example of how to use `ViewData`:

```csharp
public ActionResult Index()
{
    ViewData["Message"] = "Hello, World!";
    return View();
}
```

In the view, you can access `ViewData` like this:

```csharp
<p>@ViewData["Message"]</p>
```

## ViewBag

`ViewBag` is a dynamic property that takes advantage of the new dynamic features in C# 4.0. It allows you to share values dynamically between the controller and the view.

Here's an example of how to use `ViewBag`:

```csharp
public ActionResult Index()
{
    ViewBag.Message = "Hello, World!";
    return View();
}
```

In the view, you can access `ViewBag` like this:

```csharp
<p>@ViewBag.Message</p>
```

## ViewModels

A `ViewModel` is a class that contains the properties you need in your view. It allows you to shape multiple entities into a single object, which can be useful for aggregation, computation, and more.

Here's an example of a `ViewModel`:

```csharp
public class HomeViewModel
{
    public string Message { get; set; }
}
```

You can use it in your controller like this:

```csharp
public ActionResult Index()
{
    var viewModel = new HomeViewModel
    {
        Message = "Hello, World!"
    };

    return View(viewModel);
}
```

And in your view, you can access the `ViewModel` like this:

```csharp
@model HomeViewModel

<p>@Model.Message</p>
```

## TempData

`TempData` is a dictionary object derived from `TempDataDictionary` class. It is used to store temporary data which can be used in the subsequent request. `TempData` can be useful for redirections, when you need to retain some data.

Here's an example of how to use `TempData`:

```csharp
public ActionResult FirstAction()
{
    TempData["Message"] = "Hello, World!";
    return RedirectToAction("SecondAction");
}

public ActionResult SecondAction()
{
    var message = TempData["Message"];
    return View();
}
```

In the view of `SecondAction`, you can access `TempData` like this:

```csharp
<p>@TempData["Message"]</p>
```

