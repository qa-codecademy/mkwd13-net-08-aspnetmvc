# Homework: Edit Student Functionality 🏠

## 🎯 Objective

Complete the **Edit functionality** for the `StudentController` in our ASP.NET MVC project. You will allow users to modify existing student data via an Edit form.

## 📌 Instructions

- Use the provided **[Class Code](https://github.com/qa-codecademy/mkwd13-net-08-aspnetmvc/tree/main/G3/Class05%20-%20Views-pt2/Qinshift.Class05)** as a base. 
- Implement both the `GET` and `POST` versions of the `Edit` action inside `StudentController.cs`.
- Create a strongly typed **Edit.cshtml** Razor View using appropriate View Model.
- Populate the form fields with existing student data.
- When submitted, update the student inside `InMemoryDb.Students`.

## 🧩 Tips

- Use Tag Helpers to bind form fields to model properties.
- Redirect to the **Index** view after successful editing.
