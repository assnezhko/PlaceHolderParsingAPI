using System;
using System.Collections.Generic;
using System.Text;

namespace PlaceHolderParsingAPI.Domain.Models
{
    /// <summary>
    /// модель геолокации
    /// </summary>
    public class GeoModel
    {
        /// <summary>
        /// широта
        /// </summary>
        public double Lat { get; set; }

        /// <summary>
        /// долгота
        /// </summary>
        public double Lng { get; set; }
    }
}
