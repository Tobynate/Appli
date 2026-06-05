using System.ComponentModel.DataAnnotations;

namespace Appli
{
    internal class JobApplicationTracker
    {
        private readonly List<JobApplication> _applications = [];

        internal IReadOnlyList<JobApplication> FetchApplications() => _applications;


        internal void AddApplication(JobApplication application)
        {
            application.Id = Guid.NewGuid();
            var context = new ValidationContext(application);
            Validator.ValidateObject(application, context, validateAllProperties: true);
            _applications.Add(application);
        }

        internal void RemoveApplication(Guid id)
        {
            _applications.RemoveAll(a => a.Id == id);
        }

        internal void EditStatus(Guid id, JobApplicationStatus status)
        {
            var app = _applications.FirstOrDefault(a => a.Id == id) ?? throw new InvalidOperationException("Application not found.");
            app.Status = status;

        }
    }
}
