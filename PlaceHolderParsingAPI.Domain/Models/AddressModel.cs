using System;
using System.Collections.Generic;
using System.Text;

namespace PlaceHolderParsingAPI.Domain.Models
{
    /// <summary>
    /// модель адреса
    /// </summary>
    public class AddressModel
    {
        public string Street { get; set; }

        public string Suite { get; set; }

        public string City { get; set; }

        public string Zipcode { get; set; }

        public GeoModel Geo { get; set; }
    }
}
