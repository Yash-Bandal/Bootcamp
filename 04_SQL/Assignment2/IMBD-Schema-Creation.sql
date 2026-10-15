
/* Create IMDB Database */
CREATE DATABASE IMDB;
GO

USE IMDB;
GO

CREATE SCHEMA Foundation;
GO


/*Create tables*/
DROP TABLE IF EXISTS Foundation.Actors;

CREATE TABLE Foundation.Actors
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Sex VARCHAR(10),
    DateOfBirth DATETIME,
    Biography VARCHAR(1000),
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME
)


DROP TABLE IF EXISTS Foundation.Producers;

CREATE TABLE Foundation.Producers
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Sex VARCHAR(10),
    DateOfBirth DATETIME,
    Biography VARCHAR(1000),
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME
)

DROP TABLE IF EXISTS Foundation.Movies;

CREATE TABLE Foundation.Movies
(
    Id INT IDENTITY(1,1),
    Name VARCHAR(150) NOT NULL,
    YearOfRelease INT,
    Plot VARCHAR(500),
    PosterImagePath VARCHAR(300),
    ProducerId INT,
    CreatedAt DATETIME
        CONSTRAINT DF_Foundation_Movies_CreatedAt
        DEFAULT GETDATE(),

    UpdatedAt DATETIME,

    CONSTRAINT PK_Foundation_Movies
        PRIMARY KEY(Id),

    CONSTRAINT FK_Foundation_Movies_Producers
        FOREIGN KEY(ProducerId)
        REFERENCES Foundation.Producers(Id),
)


DROP TABLE IF EXISTS Foundation.Actor_Movies;

CREATE TABLE Foundation.Actor_Movies
(
    Id INT IDENTITY(1,1),
    MovieId INT NOT NULL,
    ActorId INT NOT NULL
)


/*Add Primary Keys seperately*/

ALTER TABLE Foundation.Actor_Movies
ADD CONSTRAINT PK_Foundation_ActorsMovies_Movies
PRIMARY KEY (Id);


/*Add Foreign keys*/

ALTER TABLE Foundation.Actor_Movies
ADD CONSTRAINT FK_Foundation_ActorMovies_Actors
FOREIGN KEY (ActorId)
REFERENCES Foundation.Actors(Id);

ALTER TABLE Foundation.Actor_Movies
ADD CONSTRAINT FK_Foundation_ActorsMovies_Movies
FOREIGN KEY (MovieId)
REFERENCES Foundation.Movies(Id);


/*Add created at and updated at*/
ALTER TABLE Foundation.Actor_Movies
    ADD CreatedAt DATETIME,
        UpdatedAt DATETIME;

ALTER TABLE Foundation.Actor_Movies
    ADD CONSTRAINT DF_Foundation_ActorMovies_CreatedAt
    DEFAULT GETDATE() FOR CreatedAt;

/* Add Language and Profit column */
ALTER TABLE Foundation.Movies
    ADD Language VARCHAR(50),
        Profit INT;
Go

/* Create and use trigger*/
CREATE TRIGGER TR_Foundation_Movies_UpdateUpdatedAt
ON Foundation.Movies
AFTER UPDATE
AS
    BEGIN
        UPDATE M
            SET UpdatedAt = GETDATE()
            FROM Foundation.Movies M
            INNER JOIN inserted I
                ON M.Id = I.Id;
    END;


UPDATE Foundation.Movies
SET Profit = 150
WHERE Id = 1;

/* Show Tables */

SELECT * FROM Foundation.Actors;
SELECT * FROM Foundation.Movies; 
SELECT * FROM Foundation.Producers;
SELECT * FROM Foundation.Actor_Movies;


