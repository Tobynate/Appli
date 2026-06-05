using Appli;
using System.ComponentModel.DataAnnotations;

List<JobApplication> jobApplications = new List<JobApplication>();
JobApplicationTracker tracker = new();
string? response;


DisplayMenu();
while (response?.ToUpper() is not "C")
{
    switch (response?.ToUpper())
    {
        case "A":
            Console.WriteLine("Enter company name:");
            string? company = Console.ReadLine();
            Console.WriteLine("Enter role:");
            string? role = Console.ReadLine();
            Console.WriteLine("Enter link:");
            string? link = Console.ReadLine();
            Console.WriteLine("Enter status (Applied(A), Interviewing(I), Offered(O), Rejected(R)):");
            
            JobApplicationStatus status = ReadStatusChoice();
            JobApplication newApplication = new JobApplication
            {
                Company = company,
                Role = role,
                Link = link,
                Status = status
            };
            try
            {
                tracker.AddApplication(newApplication);
                Console.WriteLine("Job application added successfully.");
            }
            catch (ValidationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        
            break;

        case "E":
            Console.WriteLine("Enter the S/N of the application to edit:");
            string? editInput = Console.ReadLine();
            int validEditNumber;
            while (!int.TryParse(editInput, out validEditNumber) || validEditNumber < 1 || validEditNumber > jobApplications.Count)
            {
                Console.WriteLine("Enter the S/N of the application to be edited: ");
                editInput = Console.ReadLine();
            }
            JobApplication applicationToEdit = jobApplications[validEditNumber - 1];
            Console.WriteLine($"Current Status: {applicationToEdit.Status}. Enter new Status [Applied(A), Interviewing(I), Offered(O), Rejected(R)]:");
            JobApplicationStatus newStatus = ReadStatusChoice();
            try
            {
                tracker.EditStatus(applicationToEdit.Id, newStatus);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.WriteLine("Job application status updated successfully.");
            break;
        case "R":
            Console.WriteLine("Enter the S/N of the application to remove:");
            string? input = Console.ReadLine();
            int validNumber;
            while (!int.TryParse(input, out validNumber) || validNumber < 1 || validNumber > jobApplications.Count){
                Console.WriteLine("Enter the S/N of the application to be removed: ");
                input = Console.ReadLine();
            }
            tracker.RemoveApplication(jobApplications[validNumber - 1].Id);
            Console.WriteLine("Job application removed successfully.");
            break;
    }
    DisplayMenu();
}




void DisplayMenu()
{
    jobApplications = (tracker.FetchApplications()).ToList();
    // Table header
    Console.WriteLine("{0,-5} {1,-25} {2, -15} {3,-50} {4, -15}", "S/N", "Company", "Role", "Link", "Status");
    Console.WriteLine(new string('-', 120));

    // Table rows
    foreach (JobApplication application in jobApplications)
    {
        Console.WriteLine("{0,-5} {1,-25} {2, -15} {3,-30} {4, -15}", jobApplications.IndexOf(application) + 1, application.Company, application.Role, application.Link, application.Status);
    }
    Console.WriteLine();
    Console.WriteLine();

    Console.WriteLine("Please select action: Add(A), Remove(R), Edit Status(E), Close(C)");
    response = Console.ReadLine();
}

JobApplicationStatus ReadStatusChoice()
{
    string? newStatusInput = Console.ReadLine()?.ToUpper();
    while (newStatusInput is not ("A" or "I" or "O" or "R"))
    {
        Console.WriteLine("Invalid Status input. Please enter (Applied(A), Interviewing(I), Offered(O), Rejected(R)):");
        newStatusInput = Console.ReadLine()?.ToUpper();
    }

    return newStatusInput switch
    {
        "A" => JobApplicationStatus.Applied,
        "I" => JobApplicationStatus.Interviewing,
        "O" => JobApplicationStatus.Offered,
        "R" => JobApplicationStatus.Rejected,
         _ => throw new InvalidOperationException("Unreachable")

    };
}