# Customer Portal API

This API was built for a coding challenge. Customer Portal API - Adding, Updating, Deleting and seraching customers.

## Getting Started

Run the app on visual studio or dotnet console.
Go to folder Customer/ 
and run 
```
dotnet run .
```
Check out Swagger UI for all the api's involved
URL: http://localhost:5000/swagger

This APP uses In Memory Database.

### Assumptions

* Simple App to showcase my tech skills and my adaptability to any skill.
* You can only add, update, delete and search for customers via the API.
* AsNoTracking used for concurrency problems with In memory Store dbContext.
* Basic validation when accessing data.
* HTTP return codes are returned along with actual data in JSON format.
* 2 Tier Architecture - Business/API Layer and Data Access Layer
* In Memory EF Store and swagger injected to the app via Dependency Injection principle.
* SOLID principles followed as much as possible.
* Sufficient Unit Tests

### Improvements

* UI could be created
* Use SQL or NoSQL for data storage.
* Authentication/Authorization for the APIs
* Can be hosted on AWS API Gateway or Azure API Management

### Prerequisites

* .NET Core 2.2 to be installed
* Docker to be installed - windows if you want the app to run in containers

### Container

* Build: Go to the Customer Folder and run ```docker build -t <username>/<repo_name> .```
* Run: ```docker run -d <username>/<repo_name>```

## Running the tests

I have created a few unit tests which are found in the folder CustomerControlTests. This could be run manually. Tests include the interface testing i.e. test the data layer. 

These tests will talk with the In memory store.

Go to Folder CustomerControlTests/ and run
```
dotnet test
```


### Deisgn Architrecture

2 Tier Architecture - Business/API Layer, Data Access Layer

### Deisgn TEchnique

* Agile - split tasks into mini sprints
* TDD
* Continous Integration with the help of GitHub actions.

## Built With

* .NET Core 2.2 WebAPI
* In Memory Entity Framework Store
* Dependency Injection
* XUnit
* Swagger/OpenAPI
