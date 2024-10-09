# Asset Management System

## Overview

This project is an Asset Management System developed in C#. It helps manage assets and employees by providing functionalities such as adding, viewing, updating, and deleting asset and employee records. The project follows a clean architecture with separate layers for business logic, services, UI, and database connections.

## Folder Structure

AssetManagement/ ├── AssetManagement.Business/ │ ├── EmployeeRepository.cs │ ├── IEmployeeRepository.cs │ └── AssetRepository.cs ├── AssetManagement.Services/ │ ├── EmployeeService.cs │ └── AssetService.cs ├── AssetManagement.UI/ │ ├── EmployeeMenu.cs │ ├── AssetManagementApp.cs │ └── MainMenu.cs ├── AssetManagement.Util/ │ └── DBConnection.cs ├── Database/ │ └── CreateSchema.sql ├── appsettings.json ├── AssetManagement.sln └── README.md

### Project Layers

1. **Business Layer (`AssetManagement.Business/`)**: Contains repositories that interact with the data layer for employees and assets.
2. **Services Layer (`AssetManagement.Services/`)**: Houses business logic and provides services to the UI layer.

3. **UI Layer (`AssetManagement.UI/`)**: Contains the main application menu and other user interfaces for interacting with the system.

4. **Utilities (`AssetManagement.Util/`)**: Manages reusable utility functions such as database connection handling.

5. **Database (`Database/`)**: Contains SQL scripts for creating the necessary database schema.

## Setup Instructions

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (Running in Docker if applicable)
- [VS Code](https://code.visualstudio.com/) (with the C# extension)

### Getting Started

1. **Clone the Repository:**
   git clone https://github.com/your-username/AssetManagement.git
   Database Setup:

Run the SQL script Database/CreateSchema.sql to set up the database.
Configure Database Connection:

2. **Update the connection string in appsettings.json.**
   Build the Solution: Navigate to the root of the project and run the following:

dotnet build

3. **Run the Application: After building, run the app using:**

dotnet run --project AssetManagement.UI/AssetManagementApp.csproj 4. **Features**
Employee management (add, update, delete, view)
Asset management (add, update, delete, view)
