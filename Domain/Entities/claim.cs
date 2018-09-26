namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("claim")]
    public partial class claim
    {
        public int id { get; set; }
        [DataType(DataType.Date)]
        public DateTime? accidentDate { get; set; }
        [Required(ErrorMessage = "Date: You must enter a value")]
        public string localisation { get; set; }
        [Required(ErrorMessage = "localisation: You must enter a value")]
       
        public string namesAddressesPhonesWitnesses { get; set; }
        [Required(ErrorMessage = "Witnesses: You must enter a value")]

      //  [DataType(DataType.ImageUrl), Display(Name = "Image")]

        public string ImageUrl { get; set; }
        [Required]

        [StringLength(255, ErrorMessage = "Nooooooo", MinimumLength = 8)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "CIN")]
        public string cinInsured2 { get; set; }

        
        public string lang { get; set; }
        [Required(ErrorMessage = "Name: You must enter a value")]
        
        public string lat { get; set; }
       
        
        public string etat { get; set; }

        public int? contract_id { get; set; }
        [Required(ErrorMessage = "Name: You must enter a value")]
        public int injured { get; set; }
        [Required(ErrorMessage = "Name: You must enter a value")]
        
        public string otherObjectDamage { get; set; }
        [Required(ErrorMessage = "Name: You must enter a value")]
        public int vehiclesDamage { get; set; }
    }
}
