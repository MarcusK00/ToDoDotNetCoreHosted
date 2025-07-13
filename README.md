# ToDo List Application

A ToDo list web app built with **Blazor WebAssembly** (frontend) and **ASP.NET Core Web API** (backend), persisting data to a SQL Server database.
<img width="1842" height="901" alt="HOME" src="https://github.com/user-attachments/assets/a9adcf88-d72f-43c6-b758-d85ca45aa717" />
<img width="1847" height="897" alt="EDIT" src="https://github.com/user-attachments/assets/151925b6-cd05-4e21-8bfa-3a1785aae8f9" />

---

## Table of Contents

1. [Features](#features)
2. [Tech Stack](#tech-stack)
3. [Prerequisites](#prerequisites)
4. [Installation](#installation)
5. [Database Setup](#database-setup)
6. [Running the Application](#running-the-application)
7. [NuGet Packages](#nuget-packages)

---

## Features

* Create, Read, Update, Delete (CRUD) ToDo items
* Modern, responsive UI with Blazor WASM
* RESTful API built on ASP.NET Core Web API
* SQL Server database persistence

---

## Tech Stack

* **Frontend:** Blazor WebAssembly (.NET 8+)
* **Backend:** ASP.NET Core Web API (.NET 8+)
* **Database:** SQL Server
* **ORM:** Entity Framework Core

---

## Prerequisites

* [.NET 7 SDK or later](https://dotnet.microsoft.com/download)
* [SQL Server 2017+](https://www.microsoft.com/sql-server)

---

## Installation

1. **Clone the repository**

   ```bash
   git clone https://github.com/MarcusK00/ToDoDotNetCoreHosted.git
   cd ToDoDotNetCoreHosted
   ```

2. **Configure connection string**

   In `Server/appsettings.json`, update the `ConnectionStrings:DefaultConnection` entry to point to your SQL Server instance. For example:

   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=ToDo;Trusted_Connection=True;MultipleActiveResultSets=true"
     }
   }
   ```

3. **Install dependencies**

   Restore NuGet packages for both projects:

   ```bash
   dotnet restore Server
   dotnet restore Client
   ```

---

## Database Setup

You can either use Entity Framework Core migrations or run the SQL script below to create the database and table manually.

### SQL Script

```sql
-- Create the ToDo database
CREATE DATABASE ToDo;
GO

USE ToDo;
GO

-- Create the ToDoItem table
CREATE TABLE ToDoItem (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(200) NOT NULL,
    IsCompleted BIT NOT NULL DEFAULT 0
);
GO
```

If you prefer migrations, run from the `Server` project folder:

```bash
cd Server
dotnet ef migrations add InitialCreate
dotnet ef database update
```

---

## Running the Application

### From CLI

1. **Start the API server**

   ```bash
   cd Server
   dotnet run
   ```


2. **Start the Blazor client**

   ```bash
   cd Client
   dotnet run
   ```

   Navigate to the port shown in the console.

### From Visual Studio

1. Open `ToDoDotNetCoreHosted.sln` in Visual Studio.
2. Set both **Server** and **Client** as startup projects.
3. Press **F5** to build and run both projects.

---

## NuGet Packages

### Server (ASP.NET Core Web API)

* `Microsoft.EntityFrameworkCore.SqlServer` – SQL Server provider
* `Microsoft.EntityFrameworkCore.Tools` – EF Core command-line tool

Install via CLI:

```bash
dotnet add Server/Server.csproj package Microsoft.EntityFrameworkCore.SqlServer
dotnet add Server/Server.csproj package Microsoft.EntityFrameworkCore.Tools
```

### Client (Blazor WebAssembly)

* `Microsoft.AspNetCore.Components.WebAssembly` – Blazor WASM runtime
* `Microsoft.AspNetCore.Components.WebAssembly.Http` – HTTP support

Install via CLI:

```bash
dotnet add Client/Client.csproj package Microsoft.AspNetCore.Components.WebAssembly
dotnet add Client/Client.csproj package Microsoft.AspNetCore.Components.WebAssembly.Http
```

---
