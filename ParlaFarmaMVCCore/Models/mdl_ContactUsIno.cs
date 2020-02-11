﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParlaFarmaMVCCore.Models
{
    public class mdl_ContactUsIno
    {
        [Key]
        [Required]
        public string FullName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string ContactEmail { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string MessageBody { get; set; }
    }
}
