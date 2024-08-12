using ProiectFinalWON7.Models;

namespace ProiectFinalWON7.DTOs.Extensions
{
    public static class MarkExtensions
    {
        public static MarkToGetDTO ToMarkToGetDTO(this Mark mark)
        {
            if (mark == null)
            {
                return null;
            }

            return new MarkToGetDTO { Id = mark.Id, Value = mark.Value, TimeOfGrading = mark.TimeOfGrading, StudentId = mark.StudentId, SubjectId = mark.SubjectId };
        }

        public static Mark ToMark(this MarkToCreateDTO mark)
        {
            if (mark == null)
            {
                return null;
            }

            return new Mark { Value = mark.Value, StudentId = mark.StudentId, SubjectId=mark.SubjectId };
        }
    }
}
