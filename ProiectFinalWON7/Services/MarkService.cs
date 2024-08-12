using ProiectFinalWON7.Data;
using ProiectFinalWON7.DTOs.Extensions;
using ProiectFinalWON7.DTOs;
using Microsoft.EntityFrameworkCore;
using ProiectFinalWON7.Exceptions;

namespace ProiectFinalWON7.Services
{
    public class MarkService
    {
        private readonly StudentRegistryDbContext ctx;
        public MarkService(StudentRegistryDbContext ctx)
        {
            this.ctx = ctx;
        }

        public MarkToGetDTO AddMark(MarkToCreateDTO markToCreate)
        {
            var mark = markToCreate.ToMark();
            ctx.Marks.Add(mark);
            ctx.SaveChanges();
            return mark.ToMarkToGetDTO();
        }

        public List<MarkToGetDTO> GetAllMarksByStudentId(int id)
        {
            var result= ctx.Marks.Where(m => m.StudentId == id).Select(m => m.ToMarkToGetDTO()).ToList();
            if(result.Count == 0)
            {
                throw new IdNotFoundException();
            }

            return result;
        }

        public List<MarkToGetDTO> GetAllMarksByStudentIdAndSubjectId(int studentId, int subjectID)
        {
            var result= ctx.Marks.Where(m => m.StudentId == studentId && m.SubjectId == subjectID).Select(m => m.ToMarkToGetDTO()).ToList();
            if (result.Count == 0)
            {
                throw new IdNotFoundException();
            }

            return result;
        }

        public List<SubjectAverageDTO> GetStudentSubjectAverages(int studentId)
        {
            var gradesPerSubject = ctx.Marks.Where(m => m.StudentId == studentId).GroupBy(m => m.SubjectId).ToList();
            if(gradesPerSubject.Count == 0)
            {
                throw new IdNotFoundException();
            }
            List<SubjectAverageDTO> result = new();
            foreach (var subjectGrades in gradesPerSubject)
            {
                result.Add(new SubjectAverageDTO { SubjectId = subjectGrades.Key, SubjectName = ctx.Subjects.FirstOrDefault(s => s.Id == subjectGrades.Key).Name, Value = subjectGrades.Average(m => m.Value) });
            }

            return result;
        }

        public List<GlobalAverageDTO> GetStudentsOrderedByAverageMark(bool sortDescending)
        {
            List<GlobalAverageDTO> result = new();
            foreach (var student in ctx.Students.Include(s=>s.Marks).ToList())
            {
                if (student.Marks.Count == 0)
                {
                    continue;
                }

                result.Add(new GlobalAverageDTO { StudentId = student.Id, LastName = student.LastName, FirstName = student.FirstName, Age = student.Age, MarkAverage = GetStudentSubjectAverages(student.Id).Average(a => a.Value) });
            }
            if (result.Count == 0)
            {
                throw new IdNotFoundException();
            }
            if (sortDescending)
            {
                return result.OrderByDescending(a => a.MarkAverage).ToList();
            }

            return result.OrderBy(a => a.MarkAverage).ToList();
        }
    }
}
