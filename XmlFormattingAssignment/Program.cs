using XmlFormattingAssignment.Model;
using XmlFormattingAssignment;

class Program
{
    static void Main(string[] args)
    {
        Course course = new Course
        {
            Title = "Asp.net",
            Fees = 30000,
            Teacher = new Instructor
            {
                Name = "Jalaluddin",
                Email = "jalal@example.com",
                PresentAddress = new Address
                {
                    Street = "123 Main St",
                    City = "Dhaka",
                    Country = "Bangladesh"
                },
                
                PhoneNumbers = new List<Phone>
                {
                    new Phone { Number = "123456789", Extension = "001", CountryCode = "+880" },
                    new Phone { Number = "01912531068", Extension = "001", CountryCode = "+880" }
                }
            },
            Topics = new List<Topic>
            {
                new Topic
                {
                    Title = "Introduction",
                    Description = "Overview of ASP.NET",
                    Sessions = new List<Session>
                    {
                        new Session { DurationInHour = 2, LearningObjective = "Understand Basics" }
                    }
                },
                new Topic
                {
                    Title = "Introduction OOP",
                    Description = "Overview of OOP",
                    Sessions = new List<Session>
                    {
                        new Session { DurationInHour = 2, LearningObjective = "Understand Basics" }
                    }
                }
            },
            Tests = new List<AdmissionTest>
            {
                new AdmissionTest
                {
                    StartDateTime = DateTime.Now,
                    EndDateTime = DateTime.Now.AddHours(2),
                    TestFees = 500
                },
                new AdmissionTest
                {
                    StartDateTime = DateTime.Now.AddDays(2),
                    EndDateTime = DateTime.Now.AddDays(2).AddHours(2),
                    TestFees = 100
                }
            }
        };

        string xml = XmlFormatter.Convert(course);
        Console.WriteLine(xml);
    }
}