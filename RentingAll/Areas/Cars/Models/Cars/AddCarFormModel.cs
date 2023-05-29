using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using static RentingAll.Areas.Cars.Data.CarsDataConstants.Car;

namespace RentingAll.Areas.Cars.Models.Cars
{
    public class AddCarFormModel
    {
        [Required]        
        [StringLength(CarBrandMaxLength,MinimumLength = CarBrandMinLength)]
        public string Brand { get; set; }

        [Required]        
        [StringLength(CarModelMaxLength, MinimumLength = CarModelMinLength)]
        public string Model { get; set; }

        [Required]
        [StringLength(CarDescriptionMaxlenght, MinimumLength = CarDescriptionMinlenght)]
        public string Description { get; set; }

        [Required]
        [Url]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; }

        [Range(CarYearMinValue, CarYearMaxValue)] 
        public int Year { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [BindNever]
        public IEnumerable<CarCategoryViewModel> ? Categories { get; set; }
    }
}
