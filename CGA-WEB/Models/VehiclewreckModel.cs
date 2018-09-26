using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CGA_WEB.Models
{
    public class VehiclewreckModel
    {
        [Key]
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]

        public int vehicleId { get; set; }
    
        [Required(ErrorMessage = "Please Enter Vin Number")]
        [Display(Name = "Vehicle Identification number")]
        [StringLength(16)]
        public string numchassis { get; set; }




        [Display(Name = "Color")]
        [Required(ErrorMessage = "Color is required")]
        public string couleur { get; set; }



        [Display(Name = "Description")]
        [Required(ErrorMessage = "DEscription is required")]
        [StringLength(300)]
        public string description { get; set; }


        [Display(Name = "Model")]
        [Required(ErrorMessage = "Please enter Model !!!!")]
        public string modele { get; set; }



    }
}