using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsiHoustonInterview.Shared
{
    public class QuestionThreeRequest
    {
        [Required]
        [Display(Name = "Filter One")]
        public string FilterOne { get; set; }

        [Required]
        [Display(Name = "Filter Two")]
        public string FilterTwo { get; set; }

        [Required]
        [Display(Name = "Filter Three")]
        public string FilterThree { get; set; }
    }
}
