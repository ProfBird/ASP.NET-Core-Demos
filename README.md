# CS295-Demos
Demo ASP.NET apps for CS95N at LCC

Note: All these apps are in one repository, so you will
need to download or clone the whole repository even if you
only want code for one app.

## Directory

__ASP.NET Razor Page apps__
* __WebPages3Tutorial__ - This is an updated (translated) version of an older tutorial for ASP.NET Web Pages 3, 
  [Introduction to ASP.NET Web Programming Using the Razor Syntax]
  (https://docs.microsoft.com/en-us/aspnet/web-pages/overview/getting-started/introducing-razor-syntax-c)
   
* __MathQuiz__, 5 projects:
  * MathQuiz: A very basic web app that uses minimal Razor Pages features.
     * It does have a code-behind (.cshtmlcs) page.
     * Uses hidden form fields to store the numbers being added so they won't be lost when the submit button on the form is clicked to do an HTTP POST.
  * MathQuiz2: An improved version of this web app
     * Uses _Viewimports and _Layouts pages demonstrating how imports and common layout features can be shared by all pages.
     * Uses the ASP.NET Session object to store the numbers used in the question so they are saved before doing an HTTP POST.
  * MathQuiz3: Refactored the code-behind and moved all the logic code for the math quiz to a separate class, MathQuiz.
     * In OnGet, an instance of MathQuiz is instantiated using a constructor that generates random numbers. In the code-behind the numbers are stored in the Session object.
     * In OnPost, an instance of MathQuiz is instantiated using a parameterized constructor that takes the numbers that were stored in the Session object as arguments.
  * MathQuiz4: Uses Tag Helpers and model binding
     * The model properties are simplified because the properties in MathQuiz are now directly used as the code-behind model properties.
     * In OnPost, the Answer fileld value is automatically transferred to MathQuiz.Answer
  * MathQuiz.Tests: Unit tests for the MathQuiz class in MathQuiz4.

* __Tic-Tac-Toe__: The classic game
  * Loads images when squares are clicked
  * Game state is saved in the Session object
  * HTML buttons have name and value attributes that determine arguments sent to the OnPost method
  * Has game-play logic in a separate class
  * Has unit tests

* __RomanNumerals__ - Demonstrates the use of async / await. Three Projects:
    * RomanConversion - library (dll) project containing the logic code to convert Roman numerals to Decimal digits and vice-versa
    * RomanConversion.Test - unit tests
    * RomanNumerals - Razor Pages app that uses the RomanConversion project.
     * Uses the asp-page-handler tag helper and named handlers

* __AsyncDemo__ - Demonstrates the use of async / await.
  Two Projects:
  * AsyncDemo.Console - main calls an async method with a time dely in it
  * AsyncDemo.Razor - has a link with an OnGetAsync handler that runs three async methods in parallel

* __LinqDemo__ - Demonstrates the use of Language Integrated Query.
  Two Projects:
  * LinqExercise.Dos
    Two exercises where a Linq query needs to be added to the code. Uses the same list of planets, but different queries from those in the demo.
  * LinqDemo.Dos
    Demonstrates the use of Linq through a series of quieries on a list of planets.

  __ASP.NET Web API app__

* __WebApiMovie__ - Demonstrates a Web API and Client.
  Two Projects:
  * AsyncDemo.Mac - Uses a SQLite database
  * AsyncDemo.Win - Uses SQL Express LocalDB
  * The wwwroot folder contains a web client for the web service.

  Both projects present a REST/JSON Web API for managing a database of movie data. These are the endpoints (HTTP Verb, URL)
  * GET, baseURL/api/movie - returns an array of movie objects
  * GET, baseURL/api/movie/id - returns a movie object with the give id (an integer)
  * POST, baseURL/api/movie - adds a movie to the database
  * PUT, baseURL/api/movie - updates a movie in the database
  * DELETE, baseURL/api/movie/id - removes a movie from the database

  The wwwroot folder contains a web client for the web service

----

I wrote these apps for use with CS295N, Web Development 1:ASP.NET, a class I teach at Lane Community College. Other course materials are here: <https://github.com/LCC-CIT/CS295N-CourseMaterials>

My blog:
<https://birdsbits.wordpress.com>
