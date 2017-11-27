const MOVIE_URL = "http://localhost:5000/api/movie";
// const MOVIE_URL = "http://webapimovie.azurewebsites.net/api/movie";

function getMovies() {
    var ajax = new XMLHttpRequest();
    ajax.onload = parseMovies;
    ajax.onerror = errorHandler;
    ajax.open("GET", MOVIE_URL, true);
    ajax.send();

  var form = document.getElementsByTagName('form')[0];
  /*
  button.addEventListener("click", function(event){
  event.preventDefault();
  });
  button.addEventListener("click", sendMovie);
  */
          form.onsubmit = function (e) {
  // stop the regular form submission
  e.preventDefault();
  sendMovie();
  }
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

        var form = document.getElementsByTagName('form')[0];
        //form.send.disabled = true;

    /*

    // collect the form data while iterating over the inputs
    var data = {};
    for (var i = 0; i < form.length; ++i) {
        var input = form[i];
        if (input.name) {
            data[input.name] = input.value;
        }
    }
    */
    // Fake data for testing
    var data = {
        "title": "Lord of the Rings: The Fellowship of the Ring",
        "releaseDate": "12/19/2001",
        "genre": "Fantasy",
        "price": 9.99,
        "rating": "PG-13"
    };
    // create an HTTP request
    var ajax = new XMLHttpRequest();
    // Parameters: request type, URL, async (if false, send does not return until a response is recieved)
    ajax.open("POST", MOVIE_URL, true);
    ajax.setRequestHeader("Content-Type", "application/json");
    ajax.onerror = errorHandler;
    ajax.onload = showResponse;

    ajax.onreadystatechange = function() {
        // readyState of 4 means 'done', status of 200 means "success"
        /* if (ajax.readyState === 4 && ajax.status === 200) {
             alert("success");
         }
         */
        // For testing
        alert("readyState: " + ajax.readyState + " status: " + ajaz.status);
    };

    // serialize the data to a string so it can be sent
    var dataString = JSON.stringify(data);
    ajax.send(dataString);
}

function showResponse() {
    alert(this.responseText);
}