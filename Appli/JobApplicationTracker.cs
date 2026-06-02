using System.ComponentModel.DataAnnotations;

namespace Appli
{
    internal class JobApplicationTracker
    {
        private readonly List<JobApplication> _applications = [];

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
    }
}
