# CS295-Demos
Demo ASP.NET apps for CS95N at LCC

Note: All these apps are in one repository, so you will
need to download or clone the whole repository even if you
only want code for one app.

## Directory

* __ASP.NET Razor Page apps__
  * WebPages3Tutorial - This is an updated (translated) version of an older tutorial for ASP.NET Web Pages 3, 
  [Introduction to ASP.NET Web Programming Using the Razor Syntax]
  (https://docs.microsoft.com/en-us/aspnet/web-pages/overview/getting-started/introducing-razor-syntax-c)
   
  * MathQuiz, 5 projects:
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

I wrote these apps for use with CS295N, Web Development 1:ASP.NET Android, a class I teach at Lane Community College.

My blog:
<https://birdsbits.wordpress.com>
