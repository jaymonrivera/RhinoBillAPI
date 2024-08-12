# RhinoBill Simple University Application System

This project performs CRUD operations on the following entities
- Student
- Course
- Application

## Project Structure

- `RhinoBill.CRUD`: The main project containing the endpoints.
- `RhinoBill.Tests`: The test project containing unit tests for the CRUD operations and validations.

## Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/download) (Version 6.0 or later)
- [Visual Studio](https://visualstudio.microsoft.com/downloads/) or another IDE with .NET support
- [NUnit](https://nunit.org/),  [NUnit3TestAdapter](https://www.nuget.org/packages/NUnit3TestAdapter/), [Shouldly](https://github.com/shouldly/shouldly)  and  [Moq](https://www.nuget.org/packages/Moq/4.20.70/) for running tests
- [FluentValidation](https://fluentvalidation.net/) - Library for building strongly-typed validation rules
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/) - ORM for .NET

## Building the Project

To build the project, follow these steps:

1. **Clone the Repository**

   ```bash
   git clone https://github.com/jaymonrivera/RhinoBillAPI.git
   cd RhinoBillAPI
   
2. **Restore Dependencies**
   ```bash
   dotnet restore

3. **Build the Solution**
   ```bash
   dotnet build

## Running the Project
1. **Run the Application**

   Navigate to the API project directory and run.
   
   ```bash
   dotnet run --project RhinoBill.CRUD/RhinoBill.CRUD.csproj

2. **Access the API**

   Use the swagger
   ```
   https://localhost:7291/swagger/index.html
