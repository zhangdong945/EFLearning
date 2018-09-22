using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using log4net;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace EFLearning
{
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));
        private static readonly ILog logHardware = LogManager.GetLogger("hardware");

        static void Main(string[] args)
        {
            //test 123
            log.Info("Application Start...");
            logHardware.Debug("XX hardware message received...");
            Console.WriteLine("Waiting...");
            Console.ReadKey();
#if false
            using (var db = new BloggingContext())
            {
                // Create and save a new Blog
                Console.Write("Enter a name for a new Blog: ");
                var name = Console.ReadLine();

                var blog = new Blog { Name = name };
                db.Blogs.Add(blog);
                db.SaveChanges();

                // Display all Blogs from the database
                var query = from b in db.Blogs
                            orderby b.Name
                            select b;

                Console.WriteLine("All blogs in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }

            using (var db1 = new RegisteringContext())
            {
                // Create and save a new Blog
                Console.Write("Enter a name for a new Student: ");
                var name = Console.ReadLine();

                var blog = new Student { Name = name };
                db1.Students.Add(blog);
                db1.SaveChanges();

                // Display all Blogs from the database
                var query = from b in db1.Students
                            orderby b.Name
                            select b;

                Console.WriteLine("All Students in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
#endif
        }
    }

    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }

        public virtual List<Course> Courses { get; set; }
    }

    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }

        public virtual List<Student> Students { get; set;  }
    }

    public class RegisteringContext : DbContext
    {
        public DbSet<Student> Students { get; set;  }
        public DbSet<Course> Courses { get; set;  }
    }
}
