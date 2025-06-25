using Microsoft.AspNetCore.Mvc.RazorPages;
using Qinshift.ModelBindingAndValidations.Database;
using Qinshift.ModelBindingAndValidations.Models.Domain;
using Qinshift.ModelBindingAndValidations.Models.ViewModels;

namespace Qinshift.ModelBindingAndValidations.Helpers
{
    /// <summary>
    ///     This static class contains extension methods for mapping domain models to view models and vice versa
    /// </summary>
    public static class MapperExtensions
    {
        /// <summary>
        ///     Maps a Student domain model to a StudentViewModel.
        /// </summary>
        /// <param name="student">The Student domain object to map from.</param>
        /// <returns>A new instance of StudentViewModel.</returns>
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

        /// <summary>
        ///     Maps a CreateStudentViewModel to a new Student domain model.
        ///     Sets a new Id based on the current max Id in the in-memory database.
        /// </summary>
        /// <param name="model">The CreateStudentViewModel to map from.</param>
        /// <returns>A new instance of Student domain object.</returns>
        public static Student ToStudent(this CreateStudentViewModel model)
        {
            return new Student
            {
                Id = InMemoryDb.Students.Max(s => s.Id) + 1,
                DateOfBirth = model.DateOfBirth.HasValue ? model.DateOfBirth.Value : default,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber
            };
        }

        /// <summary>
        ///     Maps a Student domain model to a StudentDetailsViewModel.
        /// </summary>
        /// <param name="student">The Student domain object to map from.</param>
        /// <returns>A new instance of StudentDetailsViewModel.</returns>
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
