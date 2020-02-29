using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ParlaFarmaMVCCore.ViewModels
{
    public class vmdl_Slider
    {
        public int Lang { get; set; }
        [Required(ErrorMessage = "Please choose image")]
        [Display(Name = "Silder Image")] 
        public IFormFile Image { get; set; }
        public string Title1 { get; set; }
        public string Title2 { get; set; }
        public string Title3 { get; set; }
        public string ButtonText { get; set; }
        public string ButtonLink { get; set; }
    }
}
