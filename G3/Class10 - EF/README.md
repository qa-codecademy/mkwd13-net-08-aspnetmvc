# Building Web Applications (Part 2) 🎂

## Interfaces 🔹

Interfaces are a key part of creating a good and scalable application. We use them to set some rule-set over our classes, but most importantly we use them as an abstraction for using service classes. Service classes unlike entity classes need only one instance and that instance is usually always the same. That is why we can make an abstraction and just wait for an instance to be built instead of creating it on our own. We can do this with the Dependency Injection technique.

## Dependency Injection

Dependency injection is a technique where we delegate our dependencies ( classes that we need, usually service classes ) to come from the outside instead of resolving them ( create instances ). This can be done through interfaces and containers. Containers are systems that create instances of classes for us. To do this we register the class that we want to be created with an interface. The next time we request an interface in a class constructor, the container detects this and creates an instance of that dependency for us. Think of it as requesting something that matches an interface and getting it from outside, without making any instances or writing code.

#### Service class

```csharp
// Class must inherit from an interface
public interface IUserService
{
  List<User> GetAllUsers();
  User GetUserById(int id);
}

public class UserService : IUserService
{
  public List<User> GetAllUsers()
  {
    return Db.Users;
  }
  
  public User GetUserById(int id)
  {
    return Db.Users.FirstOrDefault(x => x.Id == id);
  }
}
```

### With container

#### In Program.cs ( Configuring the container )

```csharp
// Here we register what class will be created when asked for an interface implementation
builder.Services.AddTransient<IOrderService, OrderService>();
```

#### In controller  ( Using the service )

```csharp
public class HomeController : Controllerf
{
  private IUserService _userService;
  public HomeController(IUserService userService)
  {
    _userService = userService;
  }

  public IActionResult Users()
  {
    List<User> users = _userService.GetAll();
    return View(users);
  }
}
```

### Without Container

#### In controller ( Using the service )

```csharp
public class HomeController : Controller
{
  private IUserService _userService;
  public HomeController()
  {
    _userService = new UserService();
  }

  public IActionResult Users()
  {
    List<User> users = _userService.GetAll();
    return View(users);
  }
}
```

## Extra Materials 📘

* [N-Tier architecture explanation](https://www.guru99.com/n-tier-architecture-system-concepts-tips.html)
* [Dependency Injection explained simple ( With drawing )](https://www.youtube.com/watch?v=IKD2-MAkXyQ)
* [Repository Design Pattern in C#](https://dotnettutorials.net/lesson/repository-design-pattern-csharp/)
