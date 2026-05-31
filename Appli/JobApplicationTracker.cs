using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace Appli
{
    internal static class JobApplicationTracker
    {
        internal static List<JobApplication> Applications { get; set; }
        internal static JobApplication Application { get; set; }

        internal static void AddApplication(JobApplication application)
        {
            try
            {
                application.ValidateJobApplication();
                if (Applications == null)
                {
                    Applications = new List<JobApplication>();
                }
                Applications.Add(application);
            }
            catch (Exception ex)
            {
                ValidationHelper.ExceptionHandler(ex);
            }
        }
        internal static void RemoveApplication(JobApplication application)
        {
            try
            {
                application.ValidateJobApplication();
                Applications?.Remove(application);
            }
            catch (Exception ex)
            {
                ValidationHelper.ExceptionHandler(ex);
            }
        }


    }
}
