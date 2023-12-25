using System.Linq;
using LinqPractices.Entites;

namespace LinqPractices.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize()
        {
            using (var context = new LinqDbContext())
            {
                if (context.Students.Any())
                {
                    return;
                }

                context.Students.AddRange(
                    new Student()
                    {
                        Name = "Burak",
                        Surname = "Doğan",
                        ClassId = 1
                    },
                    new Student()
                    {
                        Name = "Metin",
                        Surname = "Doğan",
                        ClassId = 1
                    },
                    new Student()
                    {
                        Name = "Yeliz",
                        Surname = "Doğan",
                        ClassId = 3
                    },
                    new Student()
                    {
                        Name = "Aziz",
                        Surname = "Doğan",
                        ClassId = 4
                    }
                );
                context.SaveChanges();
            }
        }
    }
}