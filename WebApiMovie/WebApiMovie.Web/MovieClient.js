// const MOVIE_URL = "http://localhost:5000/api/movie";
const MOVIE_URL = "http://webapimovie.azurewebsites.net/api/movie";

function init() {
    // set up the event handler for posting movie data
    var form = document.getElementById("postForm");
    form.onsubmit = function(e) {
        // prevent the form from sending an HTTP request when it is submitted
        e.preventDefault();
        sendMovie();
    };
    // Fill the table on the page with movie data when the page opens
    getMovies();
}

function getMovies() {
    var ajax = new XMLHttpRequest();
    ajax.onload = parseMovies;
    ajax.onerror = errorHandler;
    ajax.open("GET", MOVIE_URL, true);
    ajax.send();
}

function parseMovies() {
    var movies = JSON.parse(this.responseText);
    var tbody = document.getElementsByTagName('tbody')[0];
    var fields = ["title", "releaseDate", "genre", "price", "rating"];
    for (var i in movies) {
        var tr = document.createElement('tr');
        for (var j in fields) {
            var td = document.createElement('td');
            var movie = movies[i];
            td.innerHTML = movie[fields[j]];
            tr.appendChild(td);
        }
        tbody.appendChild(tr);
    }
}

function errorHandler(e) {
    window.alert("Movie API request failed.");
}

/********* Send form data as JSON in an HTTP POST ************/

function sendMovie() {

    var form = document.getElementById('postForm');

    // collect the form data while iterating over the inputs
    var data = {};
    for (var i = 0; i < form.length; ++i) {
        var input = form[i];
        if (input.name) {
            data[input.name] = input.value;
        }
    }
    /* // Fake data for testing
    var data = {
        "title": "Lord of the Rings: The Fellowship of the Ring",
        "releaseDate": "12/19/2001",
        "genre": "Fantasy",
        "price": 9.99,
        "rating": "PG-13"
    };  */

    // create an HTTP request
    var ajax = new XMLHttpRequest();
    // Parameters: request type, URL, async (if false, send does not return until a response is recieved)
    ajax.open("POST", MOVIE_URL, true);
    ajax.setRequestHeader("Content-Type", "application/json");
    ajax.onerror = errorHandler;

    // serialize the data to a string so it can be sent
    var dataString = JSON.stringify(data);
    ajax.send(dataString);
}