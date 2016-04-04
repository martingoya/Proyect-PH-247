using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OhlalaPH.Models
{
    public class ContactModels
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string Comment { get; set; }
    }
}