using Microsoft.EntityFrameworkCore;
using Psd_day10.Models;

namespace Psd_day10.Data
{
    public class PsdDbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PsdSchoolContext(serviceProvider.GetRequiredService<DbContextOptions<PsdSchoolContext>>()))
            {
                context.Database.EnsureCreated();
                if (context.Majors.Any())
                {
                    return;
                }
                var majors = new PsdMajor[]
                {
                    new PsdMajor { MajorName = "IT" },
                    new PsdMajor { MajorName = "Economics" },
                    new PsdMajor { MajorName = "Mathematics" }
                };
                foreach (var major in majors)
                {
                    context.Majors.Add(major);
                }
                context.SaveChanges();

                var learners = new PsdLearner[]
                {
                    new PsdLearner { FirstMidName = "Carson", LastName = "Alexander", EnrollmentDate = DateTime.Parse("2005-09-01"), MajorID = 1 },
                    new PsdLearner { FirstMidName = "Meredith", LastName = "Alonso", EnrollmentDate = DateTime.Parse("2002-09-01"), MajorID = 2 }
                };
                foreach (var l in learners)
                {
                    context.Learners.Add(l);
                }
                context.SaveChanges();

                var courses = new PsdCourse[]
                {
                    new PsdCourse { CourseID = 1050, Title = "Chemistry", Credits = 3 },
                    new PsdCourse { CourseID = 4022, Title = "Microeconomics", Credits = 3 },
                    new PsdCourse { CourseID = 4041, Title = "Macroeconomics", Credits = 3 }
                };
                foreach (var c in courses)
                {
                    context.Courses.Add(c);
                }
                context.SaveChanges();

                var enrollments = new PsdEnrollment[]
                {
                    new PsdEnrollment { LearnerID = 1, CourseID = 1050, Grade = 5.5f },
                    new PsdEnrollment { LearnerID = 1, CourseID = 4022, Grade = 7.5f },
                    new PsdEnrollment { LearnerID = 2, CourseID = 1050, Grade = 3.5f },
                    new PsdEnrollment { LearnerID = 2, CourseID = 4041, Grade = 7f }
                };
                foreach (var e in enrollments)
                {
                    context.Enrollments.Add(e);
                }
                context.SaveChanges();
            }
        }
    }
}
