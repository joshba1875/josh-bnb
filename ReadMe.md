# josh-bnb
 An example of a hotel booking api

 - This is an example of a .net WebApi (PoC) where consumers of the api can search for a hotel, find availablity and manage their booking 
 - The app makes use of SOLID design principals and separates concerns into api layers 
 - The app uses Entity Framework as the ORM to communicate with a Postgres Database
 - A basic in-memory database is used due to time constraints, this is seeded with data upon running the app
 - Shutting down the app removes all data, ready for re-seeding

# Get started

- Pull down repo locally
- run `dotnet run`
- Navigate to `http://localhost:7226/swagger/` to begin testing
- 

# TODO

- Implement an API Gateway (authentication, reverse proxy, load balanacing, connection pooling)
- Implement a real database
- Further normalise the entities (rooms have a type to avoid further repeating groups)
- Add unit tests (suggest NUNIT)
- Host on Azure