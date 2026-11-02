
"use strict";

// Static movie data
const movies = [
    {
        title: "WandaVision",
        year: 2021,
        genre: "Drama, Sci-Fi",
        director: "Matt Shakman",
        cast: "Elizabeth Olsen, Paul Bettany",
        description: "A mysterious life unfolds in a suburban town.",
        plot: "Wanda and Vision live an unusual suburban life where reality begins to change around them.",
        poster: "images/WandaViision.jpg"
    },
    {
        title: "Friends",
        year: 1994,
        genre: "Comedy",
        director: "David Crane",
        cast: "Jennifer Aniston, Courteney Cox",
        description: "Six friends navigate life and relationships in New York.",
        plot: "A group of friends share everyday adventures, relationships, and humorous situations.",
        poster: "images/Friends.webp"
    },
    {
        title: "The Hitman's Wife's Bodyguard",
        year: 2021,
        genre: "Action, Comedy",
        director: "Patrick Hughes",
        cast: "Ryan Reynolds, Samuel L. Jackson",
        description: "An action-packed mission filled with chaos and comedy.",
        plot: "A bodyguard becomes involved in another dangerous mission with an unpredictable hitman.",
        poster: "images/TheHitmansWifesBodyguard.jpg"
    },
    {
        title: "Raya and the Last Dragon",
        year: 2021,
        genre: "Animation, Adventure",
        director: "Don Hall",
        cast: "Kelly Marie Tran, Awkwafina",
        description: "A warrior searches for the last dragon to save her world.",
        plot: "Raya travels across Kumandra to find the last dragon and restore unity to her divided land.",
        poster: "images/Raya.jpg"
    },
    {
        title: "Sound of Metal",
        year: 2019,
        genre: "Drama, Music",
        director: "Darius Marder",
        cast: "Riz Ahmed, Olivia Cooke",
        description: "A musician faces a life-changing loss of hearing.",
        plot: "A heavy-metal drummer struggles to adjust when his hearing begins to deteriorate.",
        poster: "images/SoundOfMetal.jpg"
    },
    {
        title: "Nobody",
        year: 2021,
        genre: "Action, Thriller",
        director: "Ilya Naishuller",
        cast: "Bob Odenkirk, Connie Nielsen",
        description: "An ordinary man reveals an extraordinary past.",
        plot: "After a home invasion, an underestimated family man is pulled back into a violent world.",
        poster: "images/Nobody.jpg"
    },
    {
        title: "Inception",
        year: 2010,
        genre: "Sci-Fi, Thriller",
        director: "Christopher Nolan",
        cast: "Leonardo DiCaprio, Joseph Gordon-Levitt",
        description: "A skilled thief enters dreams to steal secrets.",
        plot: "A specialist in dream infiltration is offered a chance to erase his past through one final job.",
        poster: "images/Inception.jpg"
    },
    {
        title: "Interstellar",
        year: 2014,
        genre: "Sci-Fi, Adventure",
        director: "Christopher Nolan",
        cast: "Matthew McConaughey, Anne Hathaway",
        description: "Explorers search for humanity's next home.",
        plot: "A team travels beyond Earth in search of a habitable world as humanity faces a global crisis.",
        poster: "images/Interstellar.jpg"
    },
    {
        title: "The Dark Knight",
        year: 2008,
        genre: "Action, Crime",
        director: "Christopher Nolan",
        cast: "Christian Bale, Heath Ledger",
        description: "Gotham faces a dangerous new criminal.",
        plot: "Batman confronts a chaotic criminal who pushes Gotham and its heroes to their limits.",
        poster: "images/TheDarkKnight.jpg"
    },
    {
        title: "Coco",
        year: 2017,
        genre: "Animation, Family",
        director: "Lee Unkrich",
        cast: "Anthony Gonzalez, Gael García Bernal",
        description: "A young musician discovers his family's hidden history.",
        plot: "Miguel enters the Land of the Dead and uncovers secrets about his family and music.",
        poster: "images/Coco.jpg"
    },
    {
        title: "The Martian",
        year: 2015,
        genre: "Sci-Fi, Adventure",
        director: "Ridley Scott",
        cast: "Matt Damon, Jessica Chastain",
        description: "An astronaut fights to survive alone on Mars.",
        plot: "An astronaut stranded on Mars uses science and ingenuity to survive until rescue can arrive.",
        poster: "images/TheMartian.jpg"
    },
    {
        title: "Knives Out",
        year: 2019,
        genre: "Mystery, Comedy",
        director: "Rian Johnson",
        cast: "Daniel Craig, Ana de Armas",
        description: "A detective investigates a suspicious family gathering.",
        plot: "A detective examines the death of a wealthy novelist and uncovers a web of family secrets.",
        poster: "images/KnivesOut.jpg"
    }
];

// Find the HTML element where the cards will be displayed.
const movieList = document.getElementById("movie-list");

// Create and display all movie cards.
function renderMovies() {
    movieList.innerHTML = "";

    movies.forEach(function (movie, index) {
        const column = document.createElement("div");
        column.className = "col-12 col-md-3 mb-4";

        const card = document.createElement("div");
        card.className = "card movie-card h-100";

        const poster = document.createElement("img");
        poster.src = movie.poster;
        poster.alt = movie.title + " poster";
        poster.className = "card-img-top movie-poster";

        const body = document.createElement("div");
        body.className = "card-body d-flex flex-column";

        const title = document.createElement("h5");
        title.className = "card-title font-weight-bold";
        title.textContent = movie.title;

        const description = document.createElement("p");
        description.className = "card-text movie-description";
        description.textContent = movie.description;

        const actions = document.createElement("div");
        actions.className = "movie-actions mt-auto";

        const exploreButton = document.createElement("button");
        exploreButton.type = "button";
        exploreButton.className = "btn btn-link btn-sm p-0";
        exploreButton.textContent = "Explore →";
        exploreButton.addEventListener("click", function () {
            exploreMovie(index);
        });

        const editDelete = document.createElement("div");

        const editButton = document.createElement("button");
        editButton.type = "button";
        editButton.className = "btn btn-outline-primary btn-sm mr-1";
        editButton.textContent = "Edit";
        editButton.addEventListener("click", function () {
            alert("Edit functionality is not required.");
        });

        const deleteButton = document.createElement("button");
        deleteButton.type = "button";
        deleteButton.className = "btn btn-outline-danger btn-sm";
        deleteButton.textContent = "Delete";
        deleteButton.addEventListener("click", function () {
            alert("Delete functionality is not required.");
        });

        editDelete.append(editButton, deleteButton);
        actions.append(exploreButton, editDelete);
        body.append(title, description, actions);
        card.append(poster, body);
        column.appendChild(card);
        movieList.appendChild(column);
    });
}

// Display details for the selected movie.
function exploreMovie(index) {
    const movie = movies[index];

    document.getElementById("modal-title").textContent = movie.title;
    document.getElementById("modal-year").textContent = movie.year;
    document.getElementById("modal-director").textContent = movie.director;
    document.getElementById("modal-genre").textContent = movie.genre;
    document.getElementById("modal-cast").textContent = movie.cast;
    document.getElementById("modal-plot").textContent = movie.plot;

    const modalPoster = document.getElementById("modal-poster");
    modalPoster.src = movie.poster;
    modalPoster.alt = movie.title + " poster";

    $("#movieModal").modal("show");
}

// Render the page when the script loads.
renderMovies();
