
"use strict";

// 
// 1. Movie creation form validation
// 

const movieForm = document.getElementById("movie-form");
const formSuccess = document.getElementById("form-success");

movieForm.addEventListener("submit", function (event) {
    // Prevent the browser from submitting or reloading the page.
    event.preventDefault();
    event.stopPropagation();

    // Bootstrap uses this class to display validation feedback.
    movieForm.classList.add("was-validated");

    // Stop if any required field is invalid.
    if (!movieForm.checkValidity()) {
        formSuccess.classList.add("d-none");
        return;
    }

    // This assignment requires no actual movie creation.
    formSuccess.textContent =
        "Form validation successful! No movie has been saved.";

    formSuccess.classList.remove("d-none");
});

// Clear validation styles and the success message after resetting.
movieForm.addEventListener("reset", function () {
    setTimeout(function () {
        movieForm.classList.remove("was-validated");
        formSuccess.classList.add("d-none");
    }, 0);
});


// 
// 2. Actor form validation
// 

const actorForm = document.getElementById("actor-form");

actorForm.addEventListener("submit", function (event) {
    event.preventDefault();
    event.stopPropagation();

    actorForm.classList.add("was-validated");

    if (!actorForm.checkValidity()) {
        return;
    }

    // Display-only behavior: nothing is saved.
    alert("Actor form validated. No actor has been saved.");

    $("#actorModal").modal("hide");
});


// 
// 3. Producer form validation
// 

const producerForm = document.getElementById("producer-form");

producerForm.addEventListener("submit", function (event) {
    event.preventDefault();
    event.stopPropagation();

    producerForm.classList.add("was-validated");

    if (!producerForm.checkValidity()) {
        return;
    }

    // Display-only behavior: nothing is saved.
    alert("Producer form validated. No producer has been saved.");

    $("#producerModal").modal("hide");
});


// 
// 4. Reset modal forms when they close
// 

$("#actorModal").on("hidden.bs.modal", function () {
    actorForm.reset();
    actorForm.classList.remove("was-validated");
});

$("#producerModal").on("hidden.bs.modal", function () {
    producerForm.reset();
    producerForm.classList.remove("was-validated");
});
