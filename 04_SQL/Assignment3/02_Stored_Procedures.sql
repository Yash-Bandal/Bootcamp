use IMDB_Dummy;
Go

/*
(1) Write an SP to insert a movie:
	a. Take the movie details
	b. Take the Actor Details ( Actors IDs)
	c. Takes the producer Details (Producer IDs)
	d. Adds to the required tables.
*/

DROP PROCEDURE IF EXISTS Foundation.usp_InsertMovie;
GO

CREATE PROCEDURE Foundation.usp_InsertMovie
(
	@Name VARCHAR(150),
	@YearOfRelease INT,
	@Plot VARCHAR(300),
	@PosterImagePath VARCHAR(200),
	@ProducerId INT,
	@Language VARCHAR(50),
	@Profit INT,
	@ActorIds VARCHAR(50)
)
AS
BEGIN
	BEGIN TRY
	
		-- Set default values
		SET @Plot = ISNULL(@Plot, 'Not available');
		SET @PosterImagePath = ISNULL(@PosterImagePath, 'default.jpg');
		SET @Profit = ISNULL(@Profit, 0);

		-- Validations
		IF @Name IS NULL OR TRIM(@Name) = ''
			THROW 50001, 'Movie Name cannot be NULL or Empty', 1;

		IF @YearOfRelease IS NULL
			THROW 50002, 'Year of Release cannot be NULL', 1;

		IF @Language IS NULL OR TRIM(@Language) = ''
			THROW 50003, 'Language cannot be NULL or Empty', 1;

		IF @ProducerId IS NULL
			THROW 50004, 'Producer Id cannośt be NULL', 1;

		IF @ActorIds IS NULL OR TRIM(@ActorIds) = ''
            THROW 50005, 'Actor IDs cannot be NULL or empty.', 1;

		-- Transacition
		BEGIN TRANSACTION
		
		DECLARE @MovieId INT;

			-- Insert Movie
			INSERT INTO Foundation.Movies
			(
				Name,
				YearOfRelease,
				Plot,
				PosterImagePath,
				ProducerId,
				Language,
				Profit
			)
			VALUES
			(
				@Name,
				@YearOfRelease,
				@Plot,
				@PosterImagePath,
				@ProducerId,
				@Language,
				@Profit 
			);

			SET @MovieId = SCOPE_IDENTITY();

			-- Insert Actors
			INSERT INTO Foundation.Actor_Movies 
			(
				MovieId,
				ActorId
			)
			SELECT
				@MovieId,
				CAST(value as INT)
			FROM STRING_SPLIT(@ActorIds, ',');

		COMMIT TRANSACTION;

	END TRY
	
	BEGIN CATCH	
		ROLLBACK TRAN;
		THROW;
	END CATCH

END;
GO

EXEC Foundation.usp_InsertMovie
    @Name = 'Animal',
    @YearOfRelease = 2023,
    @Plot = 'Action Drama',
    @PosterImagePath = 'animal.jpg',
    @ProducerId = 3,
    @Language = 'Hindi',
    @Profit = NULL,
    @ActorIds = '7,8,9';
GO



/*
(2) Write an SP to Delete the Movie
	a. Takes the movie Id
*/

DROP PROCEDURE IF EXISTS Foundation.usp_DeleteMovie;
GO

CREATE PROCEDURE Foundation.usp_DeleteMovie
(
	@MovieId INT
)
AS
BEGIN
	BEGIN TRY
		-- Validation
		IF @MovieId IS NULL
			THROW 50001, 'MovieId cannot be NULL.', 1;

		-- Transaction
		BEGIN TRANSACTION

			DELETE FROM Foundation.Actor_Movies
			WHERE MovieId = @MovieId;

			DELETE FROM Foundation.Movies
			WHERE Id = @MovieId;

		COMMIT TRANSACTION
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN;
		THROW;
	END CATCH
END;

EXEC Foundation.usp_DeleteMovie
	@MovieId = 15;
GO

/*
(3) Write an SP to Delete a Producer
	a. Takes ProducerId
	b. Delete the movies directed by the producer as well
*/

DROP PROCEDURE IF EXISTS Foundation.usp_DeleteProducerMovie;
GO

CREATE PROCEDURE Foundation.usp_DeleteProducerMovie
(
	@ProducerId INT
)
AS
BEGIN
	
	BEGIN TRY
		-- Validation
		IF @ProducerId IS NULL
			THROW 50001, '@ProducerId cannot be NULL', 1;

		-- Transaction
		BEGIN TRANSACTION

			DELETE AM 
			FROM Foundation.Actor_Movies AM
			INNER JOIN Foundation.Movies M
				ON AM.MovieId = M.Id
			WHERE M.ProducerId = @ProducerId;

			DELETE FROM Foundation.Movies
			WHERE ProducerId = @ProducerId;

			DELETE FROM Foundation.Producers
			WHERE Id = @ProducerId;

		COMMIT TRANSACTION
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN;
		THROW;
	END CATCH

END;
GO

EXEC Foundation.usp_DeleteProducerMovie
	@ProducerId = 50
GO


/* (4) Write an SP to Delete a Actor
	a. Takes ActorId */

DROP PROCEDURE IF EXISTS Foundation.usp_DeleteActor;
GO

CREATE PROCEDURE Foundation.usp_DeleteActor
(
	@ActorId INT
)
AS 
BEGIN
	BEGIN TRY
		-- Validation
		IF @ActorId IS NULL
			THROW 50001, 'ActorId cannot be NULL', 1;
		
		-- Transaction
		BEGIN TRANSACTION

			DELETE FROM Foundation.Actor_Movies
			WHERE ActorId = @ActorId;

			DELETE FROM Foundation.Actors
			WHERE Id = @ActorId;

		COMMIT TRANSACTION
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN;
		THROW;
	END CATCH

END;
GO

EXEC Foundation.usp_DeleteActor
    @ActorId = 11;
GO