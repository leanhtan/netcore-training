# ASP.NET Core 2.0 Intensive training

## Course 1: Getting Started with ASP.NET Core 2.0

- Understand .NET Core
- .NET Standard
- .NET Core components
- Installation
- Working with .NET CLI
- Introduce ASP.NET Core
- Project structure
- Middleware

#### Homework

- Install latest vesion of Visual Studio 2017 (15.6.x) or Visual Studio Code
- Install .NET Core SDK 2.0
- Create an Empty ASP.NET Core Application
- Explore the project stucture, project file (.cspro)
- Write some middlewares: Run, Use, Map
- Create another project using MVC template with Athentication type Indiviual User Account, run the app
- Learn and use some CLI commands such as dotnet build, dotnet run,...
- Read the assignment

## Course 2: ASP.NET Core MVC

- Tag helpers
- View components
- Routing
- Model binding
- Areas
- Razor Pages

#### Homework

- Setup project structure for your Simple Blog Engine
- Create data model: Category, Post, etc,..
- Implement features: use both MVC and Razor Pages
- Create 1 or more TagHelper
- Create 1 or more ViewComponent
- Test precompilation feature

## Course 3: Authentication and Authorization on ASP.NET Core 2.0

- ASP.NET Identity
- Cookie authentication
- Token based authentication
- Role bases authorization
- Claim base authorization
- OpenIdDict
- Identity server 4

## Course 4: More on ASP.NET Core 2.0

- Logging
- Localization
- Caching
- Session
- Unit testing
- Javascript service
- Blazor

## Course 5: Configuration and deployment 

- Configuration on mulitple environments
- Data Protection
- Deploy on Windows
- Deploy on Linux
- Deploy with Docker

## Assignment

This program will have an assignment. “Building a simple Blog Engine using ASP.NET Core”. Please see the minimum requirement below:

For blog owner:

- Login/Logout
- Manage categories (Name, Description)
- Manage post (Slug, ShortDescription, Content, ThumbnailImage, CreatedDate, UpdatedDate)
- Manage comments (optional)

For internet users:

- Home page: lasted posts, categories menu
- View posts by category
- View post details
- Add comments (optional)

The project should apply as much techniques of ASP.NET MVC Core as possible. For example: TagHelpers, ViewComponents, Razor Pages and have Unit Test. The Unit Test don’t need to have a high coverage number but should demonstrate the ability to write unit test for common components: Controllers, ViewComponents, Services, …
Some people might prefer SPA. They can use any SPA frameworks but only for the back-office (blog owner). The front-office (internet users) must use Razor Views

The source code should be hosted in https://git.nashtechglobal.com the demo should be hosted in Azure WebApp (we will provide the accounts).

This assignment will be introduced to all attendees and start right after the first course, and end after the final course + 2 weeks.

### Soring portions

- 30% commit frequency. For example, the code should be checked-in at least one a week
- 45% runnable and meet all the requirement
- 25% the completeness: good layout, good code, rich features
