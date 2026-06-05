# Appli — Job Application Tracker (CLI)

A simple command-line tool to track job applications. I built this as
the first version of a tracker I'll actually use while applying for
remote roles. The next iteration will be a full-stack web app, but I
wanted a working version in my hands first — and to relearn .NET
fundamentals in the process.

![Screenshot of Appli running in the terminal](docs/screenshot.png)

## Features

- Add a job application (company, role, link, status)
- List all applications in a clean table view
- Edit the status of an application (Applied → Interviewing → Offered → Rejected)
- Remove an application
- Input validation using `DataAnnotations` (required fields, URL format, length limits)

## Tech

- C# / .NET 10
- Console application, no external dependencies
- Data is held in memory and lost when the program closes — persistence
  is intentionally left for the next version (Web API + database)

## Running it

```bash
git clone https://github.com/Tobynate/Appli.git
cd Appli
dotnet run --project Appli
```

You'll need the .NET SDK installed (10 or compatible).

## How it's structured

- `JobApplication` — the model. Properties carry `DataAnnotations` for
  validation (`[Required]`, `[Url]`, `[StringLength]`).
- `JobApplicationTracker` — owns the in-memory list and exposes
  `Add` / `Remove` / `EditStatus` / `Fetch`. All mutations go through
  the tracker; the list is private and exposed as `IReadOnlyList`.
- `Program.cs` — the menu loop. Reads user input, calls the tracker,
  catches validation failures, refreshes the display.
- `ValidationHelper` — small helper for surfacing validation errors.

Each piece has one job: the model carries data and validation rules,
the tracker owns mutation, the menu owns user interaction.

## What I learned building it

- Why interfaces and instance classes matter — even before tests or
  DI enter the picture, they keep mutation centralized and the code
  swappable.
- How `DataAnnotations` actually work — the attributes are metadata,
  and something (`Validator.ValidateObject` here, the framework later)
  has to run them.
- Error handling: catch the specific exception type, let the layer
  that can do something useful handle it, don't swallow failures.
- Reference vs value semantics in C# and why mutating a list entry
  through a local variable just works.

## Roadmap

- **v2 — Web API**: same domain, now as an ASP.NET Core Web API with
  a real database (EF Core + SQLite). Adds persistence and prepares
  for a frontend.
- **v3 — Full-stack**: React frontend on top of the API. Auth,
  filtering, basic dashboard.

## License

MIT.
