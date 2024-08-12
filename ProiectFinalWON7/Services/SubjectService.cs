using Microsoft.EntityFrameworkCore;
using ProiectFinalWON7.Data;
using ProiectFinalWON7.DTOs;
using ProiectFinalWON7.DTOs.Extensions;
using ProiectFinalWON7.Exceptions;
using ProiectFinalWON7.Models;

namespace ProiectFinalWON7.Services
{
    public class SubjectService
    {
        private readonly StudentRegistryDbContext ctx;
        public SubjectService(StudentRegistryDbContext ctx)
        {
            this.ctx = ctx;
        }

        public SubjectToGetDTO CreateSubject(SubjectToCreateDTO subjectToAdd)
        {
            var subject = subjectToAdd.ToSubject();
            ctx.Subjects.Add(subject);
            ctx.SaveChanges();
            return subject.ToSubjectToGetDTO();
        }

        public void DeleteSubject(int id)
        {
            var subject = ctx.Subjects.FirstOrDefault(s => s.Id == id);
            if (subject == null)
            {
                throw new IdNotFoundException();
            }
            ctx.Subjects.Remove(subject);
            ctx.SaveChanges();
        }

        public SubjectToGetDTO UpdateSubject(int id, SubjectToCreateDTO updatedSubject)
        {
            var subject = ctx.Subjects.FirstOrDefault(s => s.Id == id);
            if (subject == null)
            {
                throw new IdNotFoundException();
            }

            subject.Name = updatedSubject.Name;
            ctx.SaveChanges();
            return subject.ToSubjectToGetDTO();
        }
    }
}
