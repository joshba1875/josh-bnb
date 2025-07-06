# josh-bnb
 An example of a hotel booking api

 - This is an example of a .net WebApi (PoC) where consumers of the api can search for a hotel, find availablity and manage their booking 
 - The app makes use of SOLID and Controller-Service-Repository/DAL design principals, separating concerns into api layers 
 - The app uses Entity Framework as the ORM to communicate with an in-memory database (please note, I have never used EF before, but I have helped to roll our own ORM in .Net and used Prisma for NodeJs)
 - A basic in-memory database is used due to time constraints, this is seeded with data upon running the app
 - Shutting down / restarting the app removes all data, ready for re-seeding
 - Alternatively, you can call the booking delete methods to remove a single booking or purge the only mutable dataset

# Get started

- Pull down repo locally
- run `dotnet run`
- Navigate to `http://localhost:5091/swagger` to begin testing
- Suggested runbook:
    - /api/Hotel/GetAll
    - /api/Hotel/GetByName("Does not Exist")
    - /api/Hotel/GetByName("blyThswoOd sPa")
    - /api/RoomBooking/GetAllRooms
    - /api/RoomBooking/GetAllBookings 
    - /api/RoomBooking/GetRoomAvailability (this resultset is filtered based on rooms available for given dates and capacity)
    - /api/RoomBooking/MakeBooking (pick a room not returned by the previous call to inspect error handling)
    - /api/RoomBooking/MakeBooking (with a valid roomid for your parameters)
    - /api/RoomBooking/MakeBooking (with same request details to inspect error handing)
    - /api/RoomBooking/MakeBooking (with a valid roomid for your parameters - use check Availability if unsure)
    - /api/RoomBooking/MakeBooking (with a valid roomid for your parameters - use check Availability if unsure)
    - /api/RoomBooking/GetAllBookings 
    - /api/RoomBooking/GetBooking (try with valid reference and invalid reference)
    - /api/RoomBooking/DeleteBooking (try with invalid reference and valid reference)
    - /api/RoomBooking/DeleteAllBookings
    - /api/RoomBooking/GetAllBookings 

# TODO

- Implement an API Gateway (authentication, reverse proxy, load balancing, connection pooling)
- Implement a real database
- Implement CRUD based access authorisation on incoming requests
- Further abstract interfaces to expose service CRUD based on collection mutability (e.g. IServiceMutable<T> and IServiceImmutable<T>)
- Implement DataAccessLayer to communicate with remote database
- Further normalise the entities (rooms have a type to avoid further repeating groups)
- Add unit tests to BLs and Services,incl. mocks for DBContext (suggest NUNIT /and Moq)
- Host on Azure
- Optimise data fetching via pagination and parameterisation
-Optimise api performance and concurrency using async and tasks
- further tweak EF implementation to better support optimisation for concurrent modification of dbcontext