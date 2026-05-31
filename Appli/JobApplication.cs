using System;
using System.Collections.Generic;
using System.Text;

namespace Appli
{
    internal enum JobApplicationStatus
    {
        Applied,
        Interviewing,
        Offered,
        Rejected
    }
    internal class JobApplication
    {
        public string Company { get; set; }
        public string Roles { get; set; }
        public string Link { get; set; }
        public JobApplicationStatus Status { get; set; }
    }
}
