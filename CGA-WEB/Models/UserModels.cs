using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CGA_WEB.Models
{
    public class UserModels
    {
        public string firstName { get; set; }

        [StringLength(255)]
        public string lastName { get; set; }

    }
}