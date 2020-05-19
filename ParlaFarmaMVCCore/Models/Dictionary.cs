using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ParlaFarmaMVCCore.Models
{
    public partial class Dictionary
    {
        [Key]
        public int Id { get; set; }
        public string EN { get; set; }
        public string AZ { get; set; }
        public string RU { get; set; }
    }
}
