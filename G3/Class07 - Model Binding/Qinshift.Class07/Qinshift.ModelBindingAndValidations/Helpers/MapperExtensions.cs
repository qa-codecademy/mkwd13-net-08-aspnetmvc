using Microsoft.AspNetCore.Mvc.RazorPages;
using Qinshift.ModelBindingAndValidations.Database;
using Qinshift.ModelBindingAndValidations.Models.Domain;
using Qinshift.ModelBindingAndValidations.Models.ViewModels;

namespace Qinshift.ModelBindingAndValidations.Helpers
{
    public static class MapperExtensions
    {
        public static StudentViewModel MapToStudentViewModel(this Student student)
        {
            return new StudentViewModel
            {
                Id = student.Id,
                FullName = student.GetFullName(),
                Age = DateTime.Now.Year - student.DateOfBirth.Year,
                Email = student.Email
            };
        }

        public static Student ToStudent(this CreateStudentViewModel model)
        {
            return new Student
            {
                Id = InMemoryDb.Students.Max(s => s.Id) + 1,
                DateOfBirth = model.DateOfBirth,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber
            };
        }

        public static StudentDetailsViewModel ToStudentDetailsVM(this Student student)
        {
            return new StudentDetailsViewModel
            {
                Age = DateTime.Now.Year - student.DateOfBirth.Year,
                Email = student.Email,
                FirstName = student.FirstName,
                LastName = student.LastName,
                PhoneNumber = student.PhoneNumber
            };
        }
    }
}
