using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chef_Dishes.Models
{
    public class Chef
    {
        [Key]
        public int chefId{get;set;}

        [Required]
        [Display(Name="First Name")]
        public string f_name{get;set;}

        [Required]
        [Display(Name="Last Name")]
        public string l_name{get;set;}

        [Required(ErrorMessage="Date of Birth is required")]
        [DataType(DataType.Date)]
        [Display(Name="Date Of Birth")]
        public DateTime dob{get;set;}

        public DateTime created_at{get;set;}
        public DateTime updated_at{get;set;}

        public string full_name
        {
            get{return $"{f_name} {l_name}";}
        }

        public List<Dishes> dishes{get;set;}
    }

    public class Dishes
    {
        [Key]
        public int dishId{get;set;}

        [Required]
        [Display(Name="Chef")]
        public int chefId{get;set;}

        [Required]
        [Display(Name="Name")]
        public string name{get;set;}
        
        [Required]
        [Display(Name="Calories")]
        public int calories{get;set;}

        [Required]
        [Display(Name="Description")]
        public string description{get;set;}

        [Required]
        public int Tastiness{get;set;}

        public DateTime created_at{get;set;}
        public DateTime updated_at{get;set;}

        [NotMapped]
        public int [] Tastiness_Num {get; set;}


    }
}