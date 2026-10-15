USE IMDB_Dummy;
GO

/*
Question: 
1. Users most frequently search for movies by name using the following query:

	SELECT * 
	FROM Foundation.Movies 
	WHERE name = 'Bugonia';

Which type of index would be most efficient for this query?

Answer:
A NONCLUSTERED Index is more efficient for this query

Reason:
- The Movie table already has a Primary Key (Id) , and we cannot have another clustered index,
- Also we dont want to change the physical order just because users search by name
- Clustered index is efficient in terms of searching in Range (Between), and Non clustered in terms of equality (Filtering - with WHERE and all)

Write the SQL statement to create that index.
*/

CREATE NONCLUSTERED INDEX IX_Movie_Name
ON Foundation.Movies(Name);

/* ---------------------------------------------------------------------------------- */

/*
2. When a PRIMARY KEY constraint is created on a table, 
is a clustered index automatically created? 

Answer:
Yes, in SQL Server when a PRIMARY KEY is created, 
a CLUSTERED Index is automatically created by default
only when NO Clustered index already exist on the Table

Example:

CREATE TABLE DemoTable
(
    Id INT PRIMARY KEY,
    Name VARCHAR(50)
);

Here SQL Server by default creates a clustered index on Id.

How ever, if CLUSTERED Index already exist, 
a unique NONCLUSTERED index for Primary Key is created
*/

/* ---------------------------------------------------------------------------------- */

/*
3. 
A non-clustered index exists on the DOB column in the Actors table. 
Consider the following query:

SELECT ID 
FROM Actors 
WHERE DATEDIFF(day, DOB, GETDATE()) > 30; 

Will this query use the index on DOB?
If not, explore why and rewrite the query so that the index can be used efficiently.
*/

-- Existing query 
SELECT ID 
FROM Actors 
WHERE DATEDIFF(day, DOB, GETDATE()) > 30; 

/*
Problem:
The DATEDIFF is applied on the DOB Column,

For every row, Our SQL server has to do :
Take DOB -> Calculate DATEDIFF -> Check if > 30
(Extra compute)

This reduces usage of Index efficiently 
*/

/*
Solution:

DATEDIFF(DAY, DOB, GETDATE()) > 30

=

GETDATE() - DOB > 30

Let

T = GETDATE()
D = DOB

T - D > 30
multiplying - on both sides

-T + D < -30
     D < -30 + T
	 D < T - 30

	↓

DOB < GETDATE() - 30 Days
DOB < DATEADD(DAY, -30, GETDATE())
*/

/* Better Query (Index Friendly): */
SELECT ID
FROM Actors
WHERE DOB < DATEADD(DAY, -30, GETDATE());

/* ---------------------------------------------------------------------------------- */

/*
You need to retrieve all movies produced by ‘Aditya Chopra’
by joining the Movies and Producers tables
on Movies.ProducerId = Producers.Id.
Which columns should be indexed to optimize the join performance? 
Create the required index(es) and explore why they improve query efficiency.
*/

-- Solution: 
-- Existing Query
SELECT M.Name
FROM Foundation.Movies M
JOIN Foundation.Producers P
	ON M.ProducerId = P.ProducerId
WHERE P.Name = 'Aditya Chopra';

/*
Indexes Required
1. Index on Producer.Name (For filtering Producer)
2. Index of Movie.ProducerId (For Joining Tables)
*/

-- Index for searching Producer by Name
CREATE NONCLUSTERED INDEX IDX_Foundation_Producers_ProducersName
ON Foundation.Producers (Name);

-- Index for Joining Producer and Movies
CREATE NONCLUSTERED INDEX IDX_Foundation_Movies_ProducerId
ON Foundation.Movies (ProducerId);

/* ---------------------------------------------------------------------------------- */