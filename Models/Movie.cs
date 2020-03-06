using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required"), StringLength(60, MinimumLength = 3) ]
        public string Title { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true), Display(Name = "Release Date"), DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$"),Required(ErrorMessage = "Genre is required"), StringLength(30)]
        public string Genre { get; set; }
        [Range(1, 100), DataType(DataType.Currency), Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
         [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$"), Required(ErrorMessage = "Rating is required"), StringLength(5)]
        public string Rating { get; set; }
    }
}