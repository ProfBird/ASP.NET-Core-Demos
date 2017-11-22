﻿using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiMovie.Win.Models
{
    public class Movie
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [Required]
        [StringLength(30)]
        public string Genre { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [StringLength(5)]
        [Required]
        public string Rating { get; set; }
    }
}

/* The DataType data annotation affects the way the data is displayed
on a web page. In this case it causes just the date part of the value
stored in DateTime to be displayed
https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.datatypeattribute?view=netcore-2.0
*/
