using System;
using System.Collections.Generic;
using System.Text;

namespace Appli
{
    public static class ValidationHelper
    {
        internal static void ValidateJobApplication(this JobApplication jobApplication)
        {
            if (string.IsNullOrWhiteSpace(jobApplication.Company) || string.IsNullOrWhiteSpace(jobApplication.Roles) || string.IsNullOrWhiteSpace(jobApplication.Link))
            {
                throw new ArgumentException("Company, Roles, and Link cannot be null or empty.");
            }
            if (!Uri.IsWellFormedUriString(jobApplication.Link, UriKind.Absolute))
            {
                throw new ArgumentException("Link must be a valid URL.");
            }
            if (!Enum.IsDefined(typeof(JobApplicationStatus), jobApplication.Status))
            {
                throw new ArgumentException("Invalid JobApplicationStatus value.");
            }
        }

        public static void ExceptionHandler(Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
