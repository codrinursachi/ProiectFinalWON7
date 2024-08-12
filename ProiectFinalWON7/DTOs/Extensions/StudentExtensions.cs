using ProiectFinalWON7.Models;

namespace ProiectFinalWON7.DTOs.Extensions
{
    public static class StudentExtensions
    {
        public static StudentToGetDTO ToStudentToGetDTO(this Student student)
        {
            if (student == null)
            {
                return null;
            }

            return new StudentToGetDTO { Id=student.Id, LastName=student.LastName, FirstName=student.FirstName, Age=student.Age };
        }

        public static Student ToStudent(this StudentToCreateDTO student)
        {
            if (student == null)
            {
                return null;
            }

            return new Student { LastName=student.LastName, FirstName=student.FirstName, Age=student.Age };
        }
    }
}
