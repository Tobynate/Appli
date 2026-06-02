using System.ComponentModel.DataAnnotations;

namespace Appli
{
    public enum JobApplicationStatus
    {
        Applied,
        Interviewing,
        Offered,
        Rejected
    }
    public class JobApplication
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Company name is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Company name cannot be longer than 100 characters or shorter than 3 characters")]
        public required string Company { get; set; }
        [Required(ErrorMessage = "Role is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Role name cannot be longer than 100 characters or shorter than 3 characters")]
        public required string Role { get; set; }
        [Required(ErrorMessage = "Link is required")]
        [Url(ErrorMessage = "Link must be a valid URL")]
        public string? Link { get; set; }
        [Required(ErrorMessage = "You need to set an application status")]
        public JobApplicationStatus Status { get; set; }
    }
}
