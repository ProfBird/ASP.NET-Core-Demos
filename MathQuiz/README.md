# MathQuiz
Demo ASP.NET web app for CS95N at LCC


## Directory

* MathQuiz: A very basic web app that uses minimal Razor Pages features. 
    * It does have a code-behind (.cshtmlcs) page.
    * Uses hidden form fields to store the numbers being added so they won't be lost when the submit button on the form is clicked to do an HTTP POST
* MathQuiz2: An improved version of this web app
    * Uses _Viewimports and _Layouts pages demonstrating how imports and common layout features can be shared by all pages
    * Uses the ASP.NET Session object to store the numbers used in the question so they are saved before doing an HTTP POST
* MathQuiz3: Refactored the code-behind and moved all the logic code for the math quiz to a separate class, MathQuiz
    * In OnGet, an instance of MathQuiz is instantiated using a constructor that generates random numbers. In the code-behind the numbers are stored in the Session object
    * In OnPost, an instance of MathQuiz is instantiated using a parameterized constructor that takes the numbers that were stored in the Session object as arguments.
* MathQuiz4: Uses Tag Helpers and model binding
    * The model properties are simplified because the properties in MathQuiz are now directly used as the code-behind model properties
    * In OnPost, the Answer fileld value is automatically transferred to MathQuiz.Answer
* MathQuiz.Tests: Unit tests for the MathQuiz class in MathQuiz4

----

Note: This app is just one app in the class demo repository.
To get the source code for this app you will need to
clone or download the whole repository.


I wrote this app for use with CS295N, Web Development 1:ASP.NET Android, a class I teach at Lane Community College.

My blog:
<https://birdsbits.wordpress.com>
