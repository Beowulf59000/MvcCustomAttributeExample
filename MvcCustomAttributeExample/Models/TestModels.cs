using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcCustomAttributeExample.Models
{
    public class TestModels
    {
        /// <summary>
        /// Type
        /// </summary>
        [Display(Name = "Type")]
        public string Type { get; set; }

        /// <summary>
        /// Contenu A
        /// </summary>
        [Display(Name = "Contenu A")]
        [StringLength(500, ErrorMessage = "50 caractères maximum.")]
        public string ContenuA { get; set; }

        /// <summary>
        /// Contenu B
        /// </summary>
        [Display(Name = "Contenu B")]
        [StringLength(500, ErrorMessage = "500 caractères maximum.")]
        public string ContenuB { get; set; }
    }
}
