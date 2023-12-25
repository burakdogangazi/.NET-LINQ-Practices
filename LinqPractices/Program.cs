using System;
using System.Linq;
using LinqPractices.DbOperations;

namespace LinqPractices
{
    class Program
    {
        static void Main(string[] args)
        {
            DataGenerator.Initialize();
            LinqDbContext _dbContext = new LinqDbContext();
            var students = _dbContext.Students.ToList();

            //Find()
            Console.WriteLine("***Find***");
            var student = _dbContext.Students.Where(student => student.StudentId == 1).FirstOrDefault();
            student = _dbContext.Students.Find(1);
            Console.WriteLine(student.Name);

            //FirstOrDefault()
            Console.WriteLine("***FirstOrDefault***");
            student = _dbContext.Students.Where(student => student.Name == "Burak").FirstOrDefault();
            Console.WriteLine(student.Name);

            student = _dbContext.Students.FirstOrDefault(x => x.Name == "Burak");
            //Default value is null actually, if you just use First it will throw exception.
            Console.WriteLine(student.Name);

            //SingleOrDefault()
            Console.WriteLine("***SingleOrDefault***");
            student = _dbContext.Students.SingleOrDefault(student => student.Name == "Burak");
            //it must be null or one data, cannot be multiple
            Console.WriteLine(student.Name);

            //ToList()
            Console.WriteLine("***ToList***");
            var studentList = _dbContext.Students.Where(student => student.ClassId == 2).ToList();
            Console.WriteLine(studentList.Count);

            //OrderBy()
            Console.WriteLine("***OrderBy***");
            studentList = _dbContext.Students.OrderBy(x => x.StudentId).ToList();
            foreach (var st in studentList)
            {
                Console.WriteLine(st.StudentId + " - " + st.Name + " " + student.Surname);
            }

            //OrderByDescending()
            Console.WriteLine("***OrderByDescending***");
            studentList = _dbContext.Students.OrderByDescending(x => x.StudentId).ToList();
            foreach (var st in studentList)
            {
                Console.WriteLine(st.StudentId + " - " + st.Name + " " + student.Surname);
            }

            //Anonymous Object Result
            Console.WriteLine("***AnonymousObjectResult***");
            var anonObj = _dbContext.Students.Where(x => x.ClassId == 2).Select(x => new
            {
                Id = x.StudentId,
                FullName = x.Name + x.Surname
            });

            foreach (var obj in anonObj)
            {
                Console.WriteLine(obj.Id + " - " + obj.FullName);
            }
        }
    }
}