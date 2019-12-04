# Customer Portal API

This API was built for a coding challenge. Customer Portal API - Adding, Updating, Deleting and seraching customers.

## Getting Started

Run the app on visual studio or dotnet console.

Check out Swagger UI for all the api's involved
URL: http://localhost:5000/swagger

This APP uses In Memory Database.

### Assumptions


### Improvements


### Prerequisites

* .NET Core 2.2 to be installed
* Docker to be installed - windows

## Running the tests

I have created a few unit tests which are found in the folder CustomerControlTests. This could be run manually. Tests include the interface testing i.e. test the controllers. 

These tests will talk with the In memory database.


### Deisgn Architrecture

2 Tier Architecture - Business/API Layer, Data Access Layer

### Deisgn TEchnique

* Agile - split tasks into mini srints and then release them then and there
* TDD
* Continous Integration with the help of GitHub actions

## Built With

* .NET Core 2.2 WebAPI
* In Memory Entity Framework Store
* Dependency Injection
* XUnit
* Swagger/OpenAPI
