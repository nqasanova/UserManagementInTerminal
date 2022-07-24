using System;
using AuthenticationWithClie.ApplicationLogic.Validations;

namespace UserManagement.ApplicationLogic.Validation
{
    public class ReportValidation
    {
        public static bool IsReportValid(string firstName, int start, int end)
        {
            if (Validations.IsLengthBetween(firstName, start, end))
            {
                return true;
            }

            Console.WriteLine("Report's length should be more than 3 and less than 30!");
            return false;
        }

        public static string GetReport()
        {
            bool IsExceptionValid;
            string text = null;

            do
            {
                try
                {
                    Console.WriteLine("Please enter report : ");
                    text = Console.ReadLine();

                    if (text == "null")
                    {
                        throw new Exception();
                    }

                    IsExceptionValid = false;
                }

                catch (Exception)
                {
                    IsExceptionValid = true;
                    Console.WriteLine("There is an error");
                }
            }

            while (IsExceptionValid || !ReportValidation.IsReportValid(text, 3, 30));

            return text;
        }
    }
}