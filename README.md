# Context:
* Many of us are avid foosball players, but running around the office to check what is the status of the game is both tiring and wastes lots of our precious time. Therefore, we would appreciate a bit of help.

# Task:
* Implement a simple microservice for tracking status of foosball games.

# Our Foosball Rules:
* Each game consist from sets
* We play in BO3 system, meaning that first team that wins 2 sets, wins the game
* Each set consist from goals
* First team that shoots 10 goals wins a set
* Goals, sets and games can only be incremented (no "minus" goals, sets or games are allowed)

# Business Requirements:
* As an API user, I'd like to create and update status a foosball game, so progress can be tracked
* As an API user, I'd like to list all games sorted by start date descending, so I could check details of the one interesting for me
* As an API user, I'd like to see details of a particular game, so I could know if it was a one-sided match

# Technical Requirements:
* .NET Core
* C#
* RESTful API
* Some kind of SQL (Object-relational) or document DB
* xUnit or nUnit (optional - only if you plan to write unit tests)

# Additional Notes:
* Try to not spend more than 4 hours for thi task. If you don’t manage to implement everything, no worries - we’d be very pleasantly surprised if you did
* Use common sense if something wasn't specified
* Try to deliver a working solution
* Keep your code on GitHub

# Steps which are done
* Basic architecture creation
* Controller implementation
* Basic controller tests
* Database model creaton
* Fisrt two methods of with database communication are implementes
* Entity framework is added to the project
* Sturtups.cs is configured - services are connected

# Steps which should be done to finish everything
* Finish implementation of database connection part
* Add finial migration (solve problems with migration)
* Move connection string to configuration
* Add tests for database part
