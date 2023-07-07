# NLayerMovieApp

<p>NLayerMovieApp is a project based on the n-tier architecture and utilizes object-oriented programming principles. It is a simple application developed for managing movie information.</p>


## About the Project
NLayerMovieApp is a movie management application built using a layered architecture. The project consists of three main layers: database operations, business logic, and user interface. By minimizing dependencies between these layers, a more flexible and maintainable codebase is created.


## Installation
1. Clone this project to your local machine:  `git clone https://github.com/Yesarib/NLayerMovieApp.git`
2. Navigate to the root directory of the cloned project:  `cd NLayerMovieApp`
3. Install the required dependencies to run the project:  `dotnet restore`
4. Create the database and add sample data by running the following command:   `dotnet ef database update`
5. Start the application:   `dotnet run`

## Technologies
The NLayerMovieApp project utilizes the following technologies:
- Asp.Net Core 6.0
- Entity Framework Core
- SQL Server

## Layers

NLayerMovieApp consists of the following layers:

- NLayerMovieApp.Core: This is the layer where business logic base definitions take place. Models, services, DTO's and repository interfaces are located in this layer.
- NLayerMovieApp.Repository: This is the layer responsible for database operations. It uses Entity Framework Core to handle database connectivity and perform CRUD operations.
- NLayerMovieApp.API: This is the web API layer with a user interface. It handles user requests, calls relevant business logic operations, and returns results.
- **NLayerMovieApp.Services**: This layer is dedicated to the service layer of the application. It contains the implementation of various services that encapsulate the business logic of the system. The service layer abstracts the complex operations and business rules, providing a simplified interface for the presentation layer to interact with. It enables separation of concerns and promotes code reusability.
