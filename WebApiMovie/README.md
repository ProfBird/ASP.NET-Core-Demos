# WebApiMovie
Demo ASP.NET web app for CS95N at LCC

This project demonstrates a Web API and Client. There are three Projects:
  * AsyncDemo.Mac - Uses a SQLite database
  * AsyncDemo.Win - Uses SQL Express LocalDB
  * The wwwroot folder contains a web client for the web service.

  Both projects present a REST/JSON Web API for managing a database of movie data. These are the endpoints (HTTP Verb, URL)
  * GET, baseURL/api/movie - returns an array of movie objects
  * GET, baseURL/api/movie/id - returns a movie object with the give id (an integer)
  * POST, baseURL/api/movie - adds a movie to the database
  * PUT, baseURL/api/movie - updates a movie in the database
  * DELETE, baseURL/api/movie/id - removes a movie from the database

----

Note: This app is just one app in the class demo repository.
To get the source code for this app you will need to
clone or download the whole repository.


I wrote this app for use with CS295N, Web Development 1:ASP.NET Android, a class I teach at Lane Community College.

My blog:
<https://birdsbits.wordpress.com>
