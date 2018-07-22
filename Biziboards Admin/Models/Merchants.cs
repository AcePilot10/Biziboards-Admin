using System;
using System.Collections.Generic;

namespace Biziboards_Admin.Models
{
    public partial class Merchants
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Information { get; set; }
        public string PhoneNumber { get; set; }
        public string Location { get; set; }
        public string LogoUrl { get; set; }
        public bool IsPaying { get; set; }
        public string OffersList { get; set; }
    }
}
