 Implement the two actions for getAll and getById for the Course Domain model

🔧 Requirements
1. To create an appropriate DTO model for each of the requirements

2. Create a service class: CourseService
    2.1 Add a method GetAllCourses() that:
        - Returns all courses from InMemoryDb
        - Maps each course to a Dto model (only the name)

    2.2 Add a method GetCourseById that:
        - Returns the full course object (id, name, nameOfClasses) based on the given ID but also of type DTO
        - Returns null if not found

3. Create a new controller: CourseController
  - Add two HTTP GET endpoints:
    3.1 First Action should return a list of all course names as JSON.
    3.2 Second Action should return the full course object as JSON.