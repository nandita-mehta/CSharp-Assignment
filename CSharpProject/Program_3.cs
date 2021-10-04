using System;

namespace CSharpProject
{
    class Program_3
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter Birth Date (YYYY/MM/DD): ");
            string Birthdate = Console.ReadLine();
            DateTime dob = Convert.ToDateTime(Birthdate);
            DateTime Now = DateTime.Now;
            int Years = new DateTime(DateTime.Now.Subtract(dob).Ticks).Year - 1;
            DateTime PastYearDate = dob.AddYears(Years);
            int Months = 0;
            for (int i = 1; i <= 12; i++)
            {
                if (PastYearDate.AddMonths(i) == Now)
                {
                    Months = i;
                    break;
                }
                else if (PastYearDate.AddMonths(i) >= Now)
                {
                    Months = i - 1;
                    break;
                }
            }
            int Days = Now.Subtract(PastYearDate.AddMonths(Months)).Days;
            Console.WriteLine(Years+" years "+Months+" months "+Days+" days");
        }
    }
}
