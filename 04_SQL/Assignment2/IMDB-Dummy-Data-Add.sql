
/*Insert Data*/
INSERT INTO Foundation.Producers
(Name, Sex, DateOfBirth, Biography)
VALUES
('Aditya Dhar', 'Male','1983-03-12', 'Indian Movie Producer'),
('Christopher Nolan','Male','1970-07-30','Hollywood Director');

INSERT INTO Foundation.Actors
(Name, Sex, DateOfBirth, Biography)
VALUES
('Vicky Kaushal', 'Male', '1988-05-16', 'Indian Actor'),
('Yami Gautam', 'Female', '1988-11-28', 'Indian Actress'),
('Paresh Rawal', 'Male', '1955-05-30', 'Indian Actor'),
('Christian Bale', 'Male', '1974-01-30', 'British Actor'),
('Cillian Murphy', 'Male', '1976-05-25', 'Irish Actor'),
('Tom Hardy', 'Male', '1977-09-15', 'English Actor');

INSERT INTO Foundation.Movies
(Name, YearOfRelease, Plot, PosterImagePath, ProducerId)
VALUES
('URI: The Surgical Strike', 2019, 'Patriotic Movie', 'url_1', 1),
('Article 370', 2024, 'Political drama', 'url_2', 1),
('Dhoom Dhaam', 2025, 'Adventure Movie', 'url_3', 1),
('Border 2', 2026, 'Indian War Movie.', 'url_4', 1),
('The Dark Knight', 2008, 'Batman Series', 'url_5', 2),
('Oppenheimer', 2023, 'Atomic Bomb Invention', 'url_6', 2);

INSERT INTO Foundation.Actor_Movies
(MovieId, ActorId)
VALUES
(1,1),
(1,2),
(1,3),

(2,2),
(2,3),

(3,2),

(4,1),

(5,4),
(5,6),

(6,5);
