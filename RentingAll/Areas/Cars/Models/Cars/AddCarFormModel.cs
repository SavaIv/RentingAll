using System.ComponentModel.DataAnnotations;

namespace RentingAll.Areas.Cars.Models.Cars
{
    public class AddCarFormModel
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int Year { get; set; }

        public int CategoryId { get; set; }
    }
}
