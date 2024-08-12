using ProiectFinalWON7.Models;

namespace ProiectFinalWON7.DTOs.Extensions
{
    public static class SubjectExtensions
    {
        public static SubjectToGetDTO ToSubjectToGetDTO(this Subject subject)
        {
            if (subject == null)
            {
                return null;
            }

            return new SubjectToGetDTO { Id = subject.Id, Name = subject.Name };
        }

        public static Subject ToSubject(this SubjectToCreateDTO subject)
        {
            if (subject == null)
            {
                return null;
            }

            return new Subject {Name = subject.Name};
        }
    }
}
