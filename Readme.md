# About the project

This is a simple ASP.Net Core WebAPI Application with In Memory database.
Application manages database records of Companies and related Employees:
It lists all Companies, Company details and Employees and lets Add, Edit, Modify or Remove selected Company or Employee from the list.
Database records CRUD operations are implemented on the Backend side and are accessed through the REST requests.
On the Backend side Database object mapping is fulfilled by Entity Framework.
On the frontend side there is a vanila Javascript code which requests data from API and manages the received records.

## Build with

- ASP.NET 7.0
- Entity Framework Core 7.0

## REST API

The REST API to the app is described below.

### Get list of Companies

`GET api/company/`

### Get a specific Company

`GET api/company/{id}`

### Add a Company

`POST api/company/`
with body:
{"name":"...", "city":"...", "state":"...", "phone":"...", "address":"..."}

### Edit a specific Company

`PUT api/company/{id}`
with body:
{"name":"...", "city":"...", "state":"...", "phone":"...", "address":"..."}

### Remove a specific Company

`DELETE api/company/{id}`

### Get list of Employees by the specific Company

`GET api/employees/{companyId}`

### Get a specific Employee

`GET api/employees/{companyId}/{id}`

### Add an Employee

`POST api/employees`
with body:
{"firstName":"...", "lastName":"...", "title":"...", "birthDay":"...", "position":"...", "companyId":"..."}

### Edit a specific Employee

`PUT api/employees/{id}`
with body:
{"firstName":"...", "lastName":"...", "title":"...", "birthDay":"...", "position":"...", "companyId":"..."}

### Remove a specific Employee

`DELETE api/employees/{id}`

### Get list of Orders by the specific Company

`GET api/orders/{companyId}`

### Get list of Orders by the specific Company with Employees of that company

`GET api/orders/{companyId}/withemployees`

### Get a specific Order

`GET api/orders/{companyId}/{id}`