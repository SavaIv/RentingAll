using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static RentingAll.Areas.Cars.Data.CarsDataConstants;

namespace RentingAll.Areas.Cars.Data.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(CarBrandMaxLength)]
        public string Brand { get; set; }

        [Required]
        [MaxLength(CarModelMaxLength)]
        public string Model { get; set; }

        [Required]
        [MaxLength(CarDescriptionMaxlenght)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }
                     
        public int Year { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
