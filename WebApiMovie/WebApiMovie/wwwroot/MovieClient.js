// const MOVIE_URL = "http://localhost:5000/api/movie";
const MOVIE_URL = "http://webapimovie.azurewebsites.net/api/movie";

/********************* Get all movies from the database *************/

function getAllMovies(onloadHandler) {
    var xhr = new XMLHttpRequest();
    xhr.onload = onloadHandler;
    xhr.onerror = errorHandler;
    xhr.open("GET", MOVIE_URL, true);
    xhr.send();
}

// Loop through the movies and put them in the table
function fillTable() {
    var movies = JSON.parse(this.responseText);
    for (var i in movies) {
        addRow(movies[i]);
    }
}

// Put info for one movie in a table row
function addRow(movie) {
    var tbody = document.getElementsByTagName('tbody')[0];
    var fields = ["title", "releaseDate", "genre", "price", "rating"];
    var tr = document.createElement('tr');
    // Add a cell with the value from each field
    for (var i in fields) {
        var td = document.createElement('td');
        var field = fields[i];
        if (field == "releaseDate") {
            td.innerHTML = movie[field].substr(0, 10);
        } else {
            td.innerHTML = movie[field];
        }
        tr.appendChild(td);
    }
    tbody.appendChild(tr);
}

function errorHandler(e) {
    window.alert("Movie API request failed.");
}

/***************** Add a movie to the database *********************/

// Generate a movie object from the HTML form data
function getFormData() {
    // collect the form data by iterating over the input elements
    var data = {};
    var form = document.getElementById('movieForm');
    for (var i = 0; i < form.length; ++i) {
        var input = form[i];
        if (input.name) {
            data[input.name] = input.value;
        }
    }
    return data;
}

// Send a new movie object to the database
function addMovie() {
    var data = getFormData();

    /* // Fake data for testing
    var data = {
        "title": "Lord of the Rings: The Fellowship of the Ring",
        "releaseDate": "12/19/2001",
        "genre": "Fantasy",
        "price": 9.99,
        "rating": "PG-13"
    };  */

    // create an HTTP POST request
    var xhr = new XMLHttpRequest();
    // Parameters: request type, URL, async (if false, send does not return until a response is recieved)
    xhr.open("POST", MOVIE_URL, true);
    xhr.setRequestHeader("Content-Type", "application/json");
    xhr.onerror = errorHandler;
    xhr.onreadystatechange = function() {
        // if readyState is "done" and status is "success"
        if (xhr.readyState == 4 && xhr.status == 200) {
            // window.location.reload(); // referesh the page
            addRow(data);
        }
    };
    // serialize the data to a string so it can be sent
    var dataString = JSON.stringify(data);
    xhr.send(dataString);
}

/************ Update a movie already in the database *************/

// Fill the select (drop down list) with movie titles
// Called when page loads
function fillSelect() {
    var movies = JSON.parse(this.responseText);
    var sel = document.getElementsByTagName('select')[0];
    for (var i in movies) {
        var opt = document.createElement("option");
        opt.setAttribute("value", movies[i].id);
        opt.innerHTML = movies[i].title;
        sel.appendChild(opt);
    }
}

// get one move by it's ID
// onloadHandler will be fillForm()
// Called when a movie is selected from the select list
function getMovieById(event) {
    var xhr = new XMLHttpRequest();
    xhr.onload = fillForm;
    xhr.onerror = errorHandler;
    xhr.open("GET", MOVIE_URL + "/" + event.target.value, true);
    xhr.send();
}

// puts data from existing movie into the form 
// called back by getMovieById
function fillForm() {
    var movie = JSON.parse(this.responseText);
    var inputs = document.getElementsByTagName("input");
    inputs[0].value = movie.id;
    inputs[1].value = movie.title;
    inputs[2].value = movie.releaseDate.substr(0, 10); // just the date, not the time
    inputs[3].value = movie.genre;
    inputs[4].value = movie.price;
    inputs[5].value = movie.rating;
}

// Send new data for an existing movie to the database
function updateMovie() {
    var data = getFormData();

    // create an HTTP PUT request
    var xhr = new XMLHttpRequest();
    xhr.open("PUT", MOVIE_URL + "/" + data.id, true);
    xhr.setRequestHeader("Content-Type", "application/json");
    xhr.onerror = errorHandler;

    // serialize the data to a string so it can be sent
    var dataString = JSON.stringify(data);
    xhr.send(dataString);
}
/******************** Delete a movie ***************/