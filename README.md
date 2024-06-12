# RP

This is the backend API for the Race Portfolio project [WIP]

**This project is in the work in progress stage**

---

This project is designed to allow users, within the sim racing world,
to be able to set up and host sim races. Allowing anyone to race,
whether in a league or public.

The project uses docker to easily set up the database, seed the tables and run the project.
this would allow anyone to be able to spin up the project and have a working API with data.

**The .env file has been added for easy setup of the project,
but would not be included in the repository usually.**

This project uses:
- Net 8.0
- Entity Framework Core
- AutoMapper
- Minimal API
- OpenApi
  - not used currently but will be
- Docker
- Swagger UI

---

Completed Areas:
- Database connection and creation
  - Data seeding for the database
- User authentication
    - Cookie based 
- User registration
- User profile
-  Data models
  - Dto
    - Database entity
    - View models
    - Data mapping
      - Automated
      - Manual (where needed)
- Repository's
- Services
- Endpoints
  - All currently needed

Upcoming Features:
- Leagues
  - Tables
  - Standings
- Results
- Tracks
  - Need to be many to many with games
  - Track Layouts
- Automated testing
  - Highly likely to use Fluent Assertions

---

This project originally followed the MVC API pattern, using controllers to handle the requests. 
After careful consideration, it was decided that minimal API will be used.

The project currently follows a version of the repository pattern, using services to handle any complex logic.
This slightly differs from the standard repository pattern as the services are not used for most CRUD operations.

However, when investigating how some minimal API projects work, it seems that the repository pattern is not used,
which has created a debate in whether to just remove them for everything other than basic Queries.
This could mean that a simple generic repository could be used for the basic CRUD operations, taking in the type.