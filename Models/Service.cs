using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WhereToWatch.Models
{
    public class Service
    {
        public int ServiceId {get; set;} // Primary Key
        [Required]
        public string Name {get; set;}
        [Display(Name = "Web Address")]
        [Required]
        public string WebAddress {get; set;}
        public List<ShowService> ShowService {get; set;} //Navigation Property
    }

    public class ShowService
    {
        public int ServiceId {get; set;} //Composite Primary Key, Foreign Key 1
        public int ShowId {get; set;} //Composite Primary Key, Foreign Key 2
        public Service Service {get; set;} //Navigation Property. 
        public Show Show {get; set;} //Navigation Property.
    }
}
