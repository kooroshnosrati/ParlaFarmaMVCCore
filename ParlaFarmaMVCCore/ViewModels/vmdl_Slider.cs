using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ParlaFarmaMVCCore.ViewModels
{
    public class vmdl_Slider
    {
        public int Id { get; set; }
        public int Lang { get; set; }
        [Display(Name = "Silder Image")] 
        public IFormFile Image { get; set; }
        public string ImageStr { get; set; }
        public string Title1 { get; set; }
        public string Title2 { get; set; }
        public string Title3 { get; set; }
        public string ButtonText { get; set; }
        public string ButtonLink { get; set; }
    }
}
