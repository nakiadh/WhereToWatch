using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WhereToWatch.Models
{
    public class Show
    {
        public int ShowId {get; set;} //Primary Key
        [Required]
        public string Title {get; set;}
        [Display(Name = "Release Date")]
        [Required]
        public DateTime ReleaseDate {get; set;}
        [Required]
        public string Type {get; set;}
        [Required]
        public string Genre {get; set;}
        [Required]
        public string Rating {get; set;}
        public List<ShowService> ShowService {get; set;} //Navigation Property
    }
}
