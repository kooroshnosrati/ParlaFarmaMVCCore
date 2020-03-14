using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParlaFarmaMVCCore.ViewModels
{
    public class vmdl_ApplicationForm
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string JobTitle { get; set; }
        public string AvailableStartDate { get; set; }
        public string EmploymentStatus { get; set; }
        public string ResumeURL { get; set; }
        [Display(Name = "Resume File")]
        public IFormFile ResumeFile { get; set; }

    }
}
