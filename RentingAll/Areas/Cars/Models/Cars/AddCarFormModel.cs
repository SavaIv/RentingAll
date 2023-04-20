using System.ComponentModel.DataAnnotations;

namespace RentingAll.Areas.Cars.Models.Cars
{
    public class AddCarFormModel
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public string Description { get; set; }

        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; }

        public int Year { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<CarCategoryViewModel> Categories { get; set; }
    }
}
