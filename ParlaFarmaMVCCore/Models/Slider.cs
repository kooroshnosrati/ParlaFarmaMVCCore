using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ParlaFarmaMVCCore.Models
{
    public partial class Slider
    {
        [Key]
        public int Id { get; set; }
        public int Lang { get; set; }
        public string Image { get; set; }
        public string Title1 { get; set; }
        public string Title2 { get; set; }
        public string Title3 { get; set; }
        public string ButtonText { get; set; }
        public string ButtonLink { get; set; }
    }
}
