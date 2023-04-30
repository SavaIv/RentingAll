using System.ComponentModel.DataAnnotations;

namespace RentingAll.Areas.Cars.Models.Cars
{
    public class AllCarsQueryModel
    {
        public IEnumerable<string> Brands { get; set; }

        [Display(Name = "Search")]
        public IEnumerable<string> SearchTerm { get; set; }

        public CarSorting Sorting { get; set; }

        public IEnumerable<CarListingViewModel> Cars { get; set; }
    }
}
