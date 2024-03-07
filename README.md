# Identity API

Identity API for review and practice of concepts.

## Controller-Service-Repository pattern .NET core

The Controller-Service-Repository pattern implemented in this repository is a bit different from the course we are reviewing, but I decided to implement it because it was a pattern widely used in my previous experiences as a developer, that is, the companies I worked for used this structure due to the benefits, which I will try to mention.

It is worth remembering that this pattern matches very well with DDD (Domain-Driven Design) which is a project architecture pattern focused on the business rules that an application may contain.

This pattern also goes very well with TDD (Test-Driven Design) as it reduces coupling between project layers, facilitating testing and reuse (DRY - Dont't Repeat Yourself).

(We may go deeper into DDD and TDD patterns in the future)

As the name suggests, the Controller-Service-Repository pattern divides the application into three layers, where each one has its own well-defined responsibility:

* Controller: is responsible for exposing the functionality so that it can be consumed by external entities (including, perhaps, a UI component).

* Service: is where all the business logic should go.

* Repository: is responsible for storing and retrieving some set of data.

## Using MySql database

After configuring the context and repository structure for data access, it is necessary to execute some commands to reflect the structure in the database installed on the machine.

Execute:

```dotnet ef migrations add <MigrationName>```

To create the migration for the database.

And:

```dotnet ef database update```

To apply migrations to the database.

Note: The commands presented correspond to the .NET CLI, that is, they can be applied via the terminal at the command prompt or in VS Code

## Entity Framework Core (EF Core)

EF (Entity Framework) Core is a lightweight, extensible, open source, cross-platform version of the popular Entity Framework data access technology.

EF Core can serve as an O/RM (object relational mapper), which:

Allows .NET developers to work with a database using .NET objects.
Eliminate the need for most of the data access code that normally needs to be written.
EF Core supports multiple database engines, see Database Providers for details.

For Learn how to use EF Core, see Microsoft Documentation

## Identity

By definition in the Microsoft documentation:

* It is an API that supports user interface (UI) login functionality.
* Manage users, passwords, profile data, roles, claims, tokens, email confirmation and more.

Being an API, its objective is to facilitate the use of user management in projects, providing several features that are common in the job market. 

Despite this, using Microsoft Identity is not mandatory and you can model your application to perform the same actions, and have greater control over the implementation of the project.