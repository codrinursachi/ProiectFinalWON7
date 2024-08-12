using Microsoft.EntityFrameworkCore;
using ProiectFinalWON7.Data;
using ProiectFinalWON7.DTOs;
using ProiectFinalWON7.DTOs.Extensions;
using ProiectFinalWON7.Exceptions;
using ProiectFinalWON7.Models;

namespace ProiectFinalWON7.Services
{
    public class StudentService
    {
        private readonly StudentRegistryDbContext ctx;
        public StudentService(StudentRegistryDbContext ctx)
        {
            this.ctx = ctx;
        }

        public List<StudentToGetDTO> GetAllStudents()
        {
            var results = ctx.Students.Select(s => s.ToStudentToGetDTO()).ToList();
            if (results.Count == 0)
            {
                throw new IdNotFoundException();
            }
            return results;
        }

        public StudentToGetDTO GetStudentById(int id)
        {
            var result= ctx.Students.FirstOrDefault(s => s.Id == id).ToStudentToGetDTO();
            if(result== null)
            {
                throw new IdNotFoundException();
            }

            return result;
        }

        public StudentToGetDTO CreateStudent(StudentToCreateDTO studentToCreateDTO)
        {
            var newStudent = studentToCreateDTO.ToStudent();
            ctx.Students.Add(newStudent);
            ctx.SaveChanges();
            return newStudent.ToStudentToGetDTO();
        }

        public StudentToGetDTO UpdateStudent(int id, StudentToCreateDTO updatedStudent)
        {
            var student = ctx.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                throw new IdNotFoundException();
            }
            student.LastName = updatedStudent.LastName;
            student.FirstName = updatedStudent.FirstName;
            student.Age = updatedStudent.Age;
            ctx.SaveChanges();
            return student.ToStudentToGetDTO();
        }

        public AddressToGetDTO GetAddressByStudentId(int id)
        {
            if(ctx.Students.FirstOrDefault(s=>s.Id == id) == null)
            {
                throw new IdNotFoundException();
            }

            var result = ctx.Addresses.FirstOrDefault(a => a.StudentId == id).ToAdressToGetDTO();
            if(result== null)
            {
                throw new AddressNotFoundException();
            }

            return result;
        }

        public AddressToGetDTO UpdateAddressByStudentId(int id, AddressToCreateDTO updatedAddress)
        {
            if (ctx.Students.FirstOrDefault(s => s.Id == id) == null)
            {
                throw new IdNotFoundException();
            }

            var address = ctx.Addresses.FirstOrDefault(a => a.StudentId == id);
            if (address == null)
            {
                address = new Address();
                ctx.Addresses.Add(address);
            }
            address.City = updatedAddress.City;
            address.Street = updatedAddress.Street;
            address.Number = updatedAddress.Number;
            address.StudentId = id;
            ctx.SaveChanges();
            return address.ToAdressToGetDTO();
        }

        public void DeleteStudent(int id, bool deleteAddress)
        {
            var student = ctx.Students.Include(s => s.Address).Include(s => s.Marks).FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                throw new IdNotFoundException();
            }
            ctx.Students.Remove(student);
            if (!deleteAddress)
            {
                ctx.Addresses.FirstOrDefault(a => a.StudentId == id).StudentId = null;
            }
            ctx.SaveChanges();
        }
    }
}
