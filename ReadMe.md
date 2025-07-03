# josh-bnb
 An example of a hotel booking api

 - This is an example of a .net WebApi (PoC) where consumers of the api can search for a hotel, find availablity and manage their booking 
 - The app makes use of SOLID design principals and separates concerns into api layers 
 - The app uses Entity Framework as the ORM to communicate with a Postgres Database

# Get started

- Pull down repo locally
- run `dotnet run --launch-profile https`
- Navigate to `http://localhost:7226/swagger/` to begin testing

# TODO

- Implement an API Gateway (security, load balanacing)