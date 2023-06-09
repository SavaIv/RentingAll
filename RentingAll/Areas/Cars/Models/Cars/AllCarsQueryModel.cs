﻿using System.ComponentModel.DataAnnotations;

namespace RentingAll.Areas.Cars.Models.Cars
{
    public class AllCarsQueryModel
    {
        public const int CarsPerPage = 3;

        public int CurrentPage { get; set; } = 1;

        public int TotalCars { get; set; }

        public string Brand { get; set; }

        public IEnumerable<string> Brands { get; set; }

        [Display(Name = "Search by text")]
        public string SearchTerm { get; set; }

        public CarSorting Sorting { get; set; }

        public IEnumerable<CarListingViewModel> Cars { get; set; }
    }
}
