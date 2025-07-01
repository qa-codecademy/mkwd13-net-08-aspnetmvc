using ModelBinidingsAndDataAnnotations.Database;
using ModelBinidingsAndDataAnnotations.Models.Domain;
using ModelBinidingsAndDataAnnotations.Models.ViewModels;

namespace ModelBinidingsAndDataAnnotations.Helpers
{
    public static class Mapper
    {
        public static StudentViewModel MapToStudentViewModel(this Student student)
        {
            return new StudentViewModel
            {
                Id = student.Id,
                Email = student.Email,
                FullName = student.GetFullName(),
                Age = DateTime.Now.Year - student.DateOfBirth.Year
            };
        }

        public static StudentDetailsViewModel MapToStudentDetailsVM(this Student student)
        {
            return new StudentDetailsViewModel
            {
                Id = student.Id,
                Email = student.Email,
                FullName = student.GetFullName(),
                Age = DateTime.Now.Year - student.DateOfBirth.Year,
                Phone = student.PhoneNumber
            };
        }

        public static Student ToStudent(this CreateStudentViewModel createStudentViewModel)
        {
            return new Student
            {
                Id = StaticDb.Students.LastOrDefault().Id + 1,
                Email = createStudentViewModel.Email,
                DateOfBirth = createStudentViewModel.DateOfBirth,
                FirstName = createStudentViewModel.FirstName,
                LastName = createStudentViewModel.LastName,
                PhoneNumber = createStudentViewModel.PhoneNumber
            };
        }
    }
}
