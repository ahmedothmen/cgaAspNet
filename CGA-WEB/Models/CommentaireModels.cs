using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CGA_WEB.Models
{
    public class CommentaireModels
    {
        public int id { get; set; }

        [StringLength(255)]
        [Required(ErrorMessage = "The text is required.")]
        public string text { get; set; }
        public int policy_id { get; set; }

        public int like { get; set; }
        public int nbr { get; set; }
        public int user_id { get; set; }
        public string date { get; set; }
        public virtual policy policy { get; set; }
        public IEnumerable<user> users{ get; set; }
        public IEnumerable<commentaire> commentaires { get; set; }
    }
}