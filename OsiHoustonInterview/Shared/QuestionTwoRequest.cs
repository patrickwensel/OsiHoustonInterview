using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsiHoustonInterview.Shared
{
    public class QuestionTwoRequest
    {
        [Required]
        [Display(Name = "String One")]
        public string StringOne { get; set; }

        [Required]
        [Display(Name = "String Two")]
        public string StringTwo { get; set; }
    }
}
