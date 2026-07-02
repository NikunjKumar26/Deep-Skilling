Objective: 
To understand Object Relational Mapping (ORM) and how Entity Framework Core 8.0 maps C# classes to SQL Server database tables.

Theory:
Object Relational Mapping (ORM) is a technique that maps C# classes (objects) to database tables. It allows developers to perform database operations using C# code instead of writing SQL queries manually.

Benefits:
Increases productivity
Reduces SQL coding
Easier maintenance
Improves code readability

Entity Framework Core (EF Core):
-->Entity Framework Core (EF Core) is a lightweight, open-source, cross-platform Object Relational Mapper (ORM).
-->It supports Windows, Linux, and macOS.
-->It provides better performance.

Entity Framework (EF6)
Entity Framework 6 (EF6) is a mature Object Relational Mapper (ORM) for the .NET Framework.
It mainly supports Windows operating systems.
It is comparatively heavier than EF Core.



LAB 5:
Objective:
Retrieve product details from the database using EF Core query methods.

Methods Used:
ToListAsync() – Retrieves all records from the Products table.
FindAsync() – Retrieves a product using its primary key (Id).
FirstOrDefaultAsync() – Returns the first product that matches a given condition or null if no record is found.


