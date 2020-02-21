using System;
using System.Collections.Generic;

namespace ParlaFarmaMVCCore.Models
{
    public partial class TblSliders
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Title1 { get; set; }
        public string Title2 { get; set; }
        public string Title3 { get; set; }
        public string ButtonText { get; set; }
        public string ButtonLink { get; set; }
    }
}
