# SmartPay

A simple payslip application that takes an employee's name, annual salary, super rate, and pay period, calculates the gross income, income tax, net income, and superannuation, and then displays it on the screen.

## Clone Repo

Open a CLI, navigate to an empty directory, and run: git clone https://github.com/StartestBright/SmartPay.git

## Prerequisite

### Frontend - smartpay.client

1. Download and install Node.js.
2. Navigate to the frontend project directory and open a CLI tool.
3. Install the dependent npm packages by typing: npm install

### Backend - SmartPay.Server

1. Install the .NET Core SDK - .NET 6.0.
2. Install the below NuGet packages if not installed (these should be automatically restored with the project but listed for completeness):

   **SmartPay.Server:**
   - AutoMapper by Jimmy Bogard v13.0.1
   - Microsoft.AspNetCore.SpaProxy v6.0.27
   - Microsoft.EntityFrameworkCore v6.0.27
   - Microsoft.EntityFrameworkCore.SqlServer v6.0.27
   - Swashbuckle.AspNetCore v6.5.0

   **SmartPay.Server.Tests:**
   - Moq by Daniel Cazzulino v4.20.70
   - xunit v2.4.2
   - xunit.runner.visualstudio v2.4.5
   - coverlet.collector v3.2.0

#### Assumptions:

1. The SmartPay application is not required to store the payslip and employee data in the database. However, for future development, the basic setup for a database via Entity Framework and other necessary models are included in the solution.
2. The tax rates and brackets provided are static and won't change frequently.
3. The frontend communicates with the backend via RESTful APIs.

##### Running the Application

1. In Visual Studio, right-click the SmartPay.Server project and set it as the Startup project.
2. Press F5, or click the Debug tab and start debugging.
3. Open another browser tab and enter https://localhost:7116. It will start the frontend via SPAProxy. 

- The backend will be running on `https://localhost:7116`.
- The frontend will be running on `https://localhost:5173`

Make sure those ports are not occupied before running the application. 

###### Testing the Application
1. Open your solution in Visual Studio.
2. In the Solution Explorer, find the testing project, 'SmartPay.Server.Tests'.
3. Right-click on the 'SmartPay.Server.Tests' project.
4. Click Run Tests.
