using System;
using GradeBook.UserInterfaces;
using GradeBook.Enums;
using GradeBook.GradeBooks;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            //testRankedGradeBook();

            Console.WriteLine("#=======================#");
            Console.WriteLine("# Welcome to GradeBook! #");
            Console.WriteLine("#=======================#");
            Console.WriteLine();

            StartingUserInterface.CommandLoop();
            
            Console.WriteLine("Thank you for using GradeBook!");
            Console.WriteLine("Have a nice day!");
            Console.Read();
        }

        static void testRankedGradeBook()
        {
            BaseGradeBook gradebook = new RankedGradeBook("rankedTest", false);

            Student katie = new Student("Katie", StudentType.Standard, EnrollmentType.Campus);
            Student vincent = new Student("Vincent", StudentType.Standard, EnrollmentType.Campus);
            Student brian = new Student("Brian", StudentType.Standard, EnrollmentType.Campus);
            Student tommy = new Student("Tommy", StudentType.Standard, EnrollmentType.Campus);
            Student phillip = new Student("Phillip", StudentType.Standard, EnrollmentType.Campus);
            Student andrew = new Student("Andrew", StudentType.Standard, EnrollmentType.Campus);

            gradebook.AddStudent(katie);
            gradebook.AddStudent(vincent);
            gradebook.AddStudent(brian);
            gradebook.AddStudent(tommy);

            gradebook.AddGrade("Katie", 100.0);
            gradebook.AddGrade("Vincent", 90.0);
            gradebook.AddGrade("Brian", 80.0);
            gradebook.AddGrade("Tommy", 70.0);

            try
            {
                gradebook.GetLetterGrade(95.0);
                Console.WriteLine("Test 1 failed");
            }
            catch(InvalidOperationException e)
            {
                Console.WriteLine("Test 1 passed");
            }

            gradebook.AddStudent(phillip);
            gradebook.AddGrade("Phillip", 60.0);
            gradebook.AddStudent(andrew);
            gradebook.AddGrade("Andrew", 100.0);

            try
            {
                char grade = gradebook.GetLetterGrade(95.0);
                Console.WriteLine(grade);
                if(grade != 'C')
                    Console.WriteLine("Test 2 failed");
                else
                    Console.WriteLine("Test 2 passed");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Test 2 failed");
            }

        }
    }
}