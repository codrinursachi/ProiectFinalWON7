using ProiectFinalWON7.Data;
using ProiectFinalWON7.Models;

namespace ProiectFinalWON7.Services
{
    public class SeedService
    {
        private readonly StudentRegistryDbContext ctx;
        public SeedService(StudentRegistryDbContext ctx)
        {
            this.ctx = ctx;
        }

        public void Seed()
        {
            ctx.Students.Add(new Student
            {
                LastName = "dent1",
                FirstName = "Stu",
                Age = 21,
                Address = new Address
                {
                    City = "City1",
                    Street = "Street1",
                    Number = 1

                }
            });
            ctx.Students.Add(new Student
            {
                LastName = "dent2",
                FirstName = "Stu",

                Age = 22,
                Address = new Address
                {
                    City = "City2",
                    Street = "Street2",
                    Number = 2

                }
            });
            ctx.Students.Add(new Student
            {
                LastName = "dent3",
                FirstName = "Stu",

                Age = 23,
                Address = new Address
                {
                    City = "City3",
                    Street = "Street3",
                    Number = 3

                }
            });

            ctx.SaveChanges();
        }
    }
}
