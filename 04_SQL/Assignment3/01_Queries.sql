USE IMDB_Dummy;

/* 1. Get Age of Actors in Days */

SELECT 
	NAME,
	DATEDIFF(DAY, DateOfBirth, GETDATE()) as AgeInDays
FROM Foundation.Actors;


/* 2. Get Actors who worked with a given producer X
Example: 'Aditya Dhar'*/

SELECT DISTINCT 
	A.Id, A.Name AS ActorName
FROM Foundation.Producers P
INNER JOIN Foundation.Movies M
	ON P.Id = M.ProducerId
INNER JOIN Foundation.Actor_Movies AM
	ON M.Id = AM.MovieId
INNER JOIN Foundation.Actors A
	ON AM.ActorId = A.Id
WHERE P.Name = 'Aditya Dhar';


/*  3 Get the list of actors who have acted together in two or more movies.*/

SELECT A1.Name AS Actor1, A2.Name AS Actor2, COUNT(*) AS MoviesTogether
	FROM Foundation.Actor_Movies AM1
INNER JOIN Foundation.Actor_Movies AM2
	ON AM1.MovieId = AM2.MovieId
	AND AM1.ActorId < AM2.ActorId
INNER JOIN Foundation.Actors A1	
	ON AM1.ActorId = A1.Id
INNER JOIN Foundation.Actors A2 
	ON AM2.ActorId = A2.Id
GROUP BY A1.Id, A2.Id, A1.Name, A2.Name
	HAVING COUNT(*) >= 2;


/* 4. Get the youngest actor. */

SELECT Top 1 
	Name as ActorName, 
	DateOfBirth 
FROM Foundation.Actors A
ORDER BY DateOfBirth DESC;

/* 5. Get the actors who have never worked together */

SELECT A1.Name, A2.Name 
	FROM Foundation.Actors A1 
INNER JOIN Foundation.Actors A2
	ON A1.Id < A2.Id

EXCEPT

SELECT A1.Name , A2.Name 
	FROM Foundation.Actor_Movies AM1
INNER JOIN Foundation.Actor_Movies AM2
	ON AM1.MovieId = AM2.MovieId
INNER JOIN Foundation.Actors A1	
	ON AM1.ActorId = A1.Id
INNER JOIN Foundation.Actors A2 
	ON AM2.ActorId = A2.Id
	WHERE  AM1.ActorId < AM2.ActorId;

-- Using LEFT JOIN
SELECT 
	A1.Name as Actor1,
	A2.Name as Actor2
FROM Foundation.Actors A1
INNER JOIN Foundation.Actors A2
	ON A1.Id < A2.Id  -- GET ALL pairs
LEFT JOIN Foundation.Actor_Movies AM1
	ON A1.Id = AM1.ActorId  -- GET movies of A1 
LEFT JOIN Foundation.Actor_Movies AM2
	ON A2.Id = AM2.ActorId -- GET movies of A2
	AND AM1.MovieId = AM2.MovieId 
GROUP BY 
	A1.Id,
	A2.Id,
	A1.Name,
	A2.Name
HAVING COUNT(AM2.MovieId) = 0;


/* 6. Get the number of movies in each language.*/

SELECT 
	Language, 
	COUNT(*) AS MovieCount
FROM Foundation.Movies
GROUP BY Language;


/* 7. Get me the total profit of all the movies in each language separately. */

SELECT 
	Language, 
	SUM(Profit) AS TotalProfit
FROM Foundation.Movies
GROUP BY Language;


/* 8. Get the total profit of movies which have actor X in each language.*/

SELECT 
	M.Language, 
	SUM(M.Profit) AS TotalProfit
FROM Foundation.Movies M
INNER JOIN Foundation.Actor_Movies AM
	ON M.Id = AM.MovieId
INNER JOIN Foundation.Actors A
	ON AM.ActorId = A.Id
WHERE A.Name = 'Yami Gautam'
GROUP BY M.Language;



/* 9. Get the Total profit by year of release and language */

SELECT
	YearOfRelease,
	Language,
	SUM(Profit) AS TotalProfit
FROM Foundation.Movies
GROUP BY YearOfRelease, Language;


/* 10. Get number of movies in each language produced by each producer */

SELECT 
	P.Name as ProducerName,
	M.Language,
	COUNT(M.Id) as MovieCount
FROM Foundation.Movies M
INNER JOIN Foundation.Producers P
	ON M.ProducerId = P.Id
GROUP BY P.Id, P.Name, M.Language;