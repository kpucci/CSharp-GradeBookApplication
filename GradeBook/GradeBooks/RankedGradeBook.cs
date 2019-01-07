using GradeBook.Enums;
using System;
using System.Collections.Generic;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {

        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
            Students.Sort();
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5) throw new InvalidOperationException();

            int cutoffNum = Students.Count / 5;

            int count = 0;

            foreach(Student s in Students)
            {
                if (s.AverageGrade == averageGrade)
                    break;
                else if (s.AverageGrade > averageGrade)
                    count++;
            }

            int gradeNum = count / cutoffNum;
            switch (gradeNum)
            {
                case 0:
                    return 'A';
                case 1:
                    return 'B';
                case 2:
                    return 'C';
                case 3:
                    return 'D';                 
            }

            return 'F';
        }
    }
}
