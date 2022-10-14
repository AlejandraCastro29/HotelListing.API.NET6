﻿using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelListing.API.Models.Hotel
{
    public abstract class BaseHotelDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        public double? Rating { get; set; }

        [Required]
        public int CountryId { get; set; }
    }
}
